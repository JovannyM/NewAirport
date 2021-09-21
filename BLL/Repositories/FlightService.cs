using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Context;
using DAL.Entities;

namespace BLL.Repositories
{
    public partial class FlightService : AbstractService<Flight, FlightModel>, IFlightRepository
    {
        public FlightService(BaseContext db, IUnitOfWork uow) : base(db, db.Flights, uow)
        {
            var toDalConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FlightModel, Flight>()
                    .ForMember("RecurringFlightsTemplate",
                        opt => { opt.Ignore(); }
                    )
                    .ForMember("PairFlight", opt => opt.Ignore())
                    .ForMember("Airplane", opt => opt.Ignore())
                    .ForMember("Airport", opt => opt.Ignore())
                    .ForMember("RecurringFlightsTemplate", opt => opt.Ignore());
                cfg.CreateMap<AirplaneModel, Airplane>();
                cfg.CreateMap<AirportModel, Airport>();
            });
            this.toDal = new Mapper(toDalConfig);
            var toModelConfig = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Flight, FlightModel>()
                        .ForMember("RecurringFlightsTemplate",
                            opt => { opt.Ignore(); })
                        .ForMember("DepartureAirport",
                            opt =>
                            {
                                opt.MapFrom((d, m) => { return d.IsDeparture ? UOW.Airports.MainAirport : m.Airport; });
                            })
                        .ForMember("ArrivalAirport",
                            opt =>
                            {
                                opt.MapFrom((d, m) => { return d.IsDeparture ? m.Airport : UOW.Airports.MainAirport; });
                            });
                    cfg.CreateMap<Airplane, AirplaneModel>();
                    cfg.CreateMap<Airport, AirportModel>();
                }
            );
            this.toModel = new Mapper(toModelConfig);
        }


        public string CreateFlightsByTemplate(int templateId)
        {
            
            //TODO Сделать проверку на веденные данные (если ли они вообще?, хъотели в конктрутор создавать каждый раз новый current template)
            string message = "";
            var template = DB.RecurringFlightsTemplates.Find(templateId);

            DateTime PossibleFirstFlightArrivalDate = template.StartDateOfCreatingFlights;
            DateTime firstFlightArrivalDate;
            DateTime secondFlightDepartureDate;

            var lastFlightByCurrentTemplate = DB.Flights.Where(f => f.RecurringFlightsTemplate.Id == template.Id)
                .OrderByDescending(f => f.DepartureDate).FirstOrDefault();

            if (lastFlightByCurrentTemplate != null)
            {
                var lastFlightDateByCurrentTemplate =
                    lastFlightByCurrentTemplate.DepartureDate.AddMinutes(UOW.Airports.TimeBetweenFlights);
                if (lastFlightDateByCurrentTemplate > PossibleFirstFlightArrivalDate)
                {
                    PossibleFirstFlightArrivalDate = lastFlightDateByCurrentTemplate;
                }
            }

            firstFlightArrivalDate = PossibleFirstFlightArrivalDate.Date + template.ArrivalTimeFromFirstCity;

            while ((int)firstFlightArrivalDate.DayOfWeek != template.ArrivalFromFirstCityDayOfWeek ||
                   firstFlightArrivalDate < PossibleFirstFlightArrivalDate)
            {
                firstFlightArrivalDate = firstFlightArrivalDate.AddDays(1);
            }

            secondFlightDepartureDate = firstFlightArrivalDate.Date + template.DepartureTimeToSecondCity;

            while ((int)secondFlightDepartureDate.DayOfWeek != template.DepartureToSecondCityDayOfWeek)
            {
                secondFlightDepartureDate = secondFlightDepartureDate.AddDays(1);
            }

            var firstFlightDepartureDate = template.DepartureTimeFromFirstCity < template.ArrivalTimeFromFirstCity
                ? firstFlightArrivalDate.Date + template.DepartureTimeFromFirstCity
                : firstFlightArrivalDate.Date.AddDays(-1) + template.DepartureTimeFromFirstCity;

            var secondFlightArrivalDate = template.DepartureTimeToSecondCity < template.ArrivalTimeToSecondCity
                ? secondFlightDepartureDate.Date + template.ArrivalTimeToSecondCity
                : secondFlightDepartureDate.AddDays(1) + template.ArrivalTimeToSecondCity;


            while (firstFlightArrivalDate <= template.EndDateOfCreatingFlights)
            {
                var arrivalFlightFromFirstCity = new Flight()
                {
                    Airplane = template.Airplane,
                    Airport = template.FirstAirport,
                    DepartureDate = firstFlightDepartureDate,
                    ArrivalDate = firstFlightArrivalDate,
                    IsDeparture = false,
                    Edited = false,
                    RecurringFlightsTemplate = template,
                };
                var departureFlightToSecondCity = new Flight()
                {
                    Airplane = template.Airplane,
                    Airport = template.SecondAirport,
                    DepartureDate = secondFlightDepartureDate,
                    ArrivalDate = secondFlightArrivalDate,
                    IsDeparture = true,
                    Edited = false,
                    RecurringFlightsTemplate = template,
                };
                var CheckFirst = CheckFlights(toModel.Map<FlightModel>(arrivalFlightFromFirstCity));
                var CheckSecond = CheckFlights(toModel.Map<FlightModel>(departureFlightToSecondCity));
                if (CheckFirst.isCreate && CheckSecond.isCreate)
                {
                    DbSet.AddRange(new[] { arrivalFlightFromFirstCity, departureFlightToSecondCity });
                    UOW.Save();
                    arrivalFlightFromFirstCity.PairFlight_Id = departureFlightToSecondCity.Id;
                    departureFlightToSecondCity.PairFlight_Id = arrivalFlightFromFirstCity.Id;
                    UOW.Save();
                    message += $"Прибытие успешно добавлено {arrivalFlightFromFirstCity.ArrivalDate}\n";
                    message += $"Отправление успешно добавлено {departureFlightToSecondCity.DepartureDate}\n";
                }
                else
                {
                    message += $"Невозможно создать прибытие, потому что {arrivalFlightFromFirstCity.ArrivalDate} запланирован рейс\n";
                    message += $"Невозможно создать отправление, потому что {departureFlightToSecondCity.ArrivalDate} запланирован рейс\n";
                }

                firstFlightDepartureDate = firstFlightDepartureDate.AddDays(7);
                firstFlightArrivalDate = firstFlightArrivalDate.AddDays(7);
                secondFlightDepartureDate = secondFlightDepartureDate.AddDays(7);
                secondFlightArrivalDate = secondFlightArrivalDate.AddDays(7);
            }

            return message.Length>0? message:"Рейсы не были добавлены, так как в этот промежуток времени все рейсы этого шаблона уже есть";
        }

        public (bool isCreate, string message) CheckAndUpdate(FlightModel flight)
        {
            var checker = CheckFlights(flight);
            if (checker.isCreate)
            {
                this.Update(flight);
                return (true, "Успешно обновлено");
            }
            return (checker);
        }

        public List<FlightModel> GetList(bool sortByDate)
        {
            if (!sortByDate) return base.GetList();
            var listD = DB.Flights.Where(f=>f.IsDeleted==false).OrderBy(f => f.DepartureDate).ToList();
            var listModels = toModel.Map<List<Flight>,List<FlightModel>>(listD);
            return listModels;
        }
    }
}