using System;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Context;
using DAL.Entities;

namespace BLL.Repositories
{
    public class FlightService : AbstractService<Flight, FlightModel>, IFlightRepository
    {
        public FlightService(BaseContext db, IUnitOfWork uow) : base(db, db.Flights, uow)
        {
            var toDalConfig = new MapperConfiguration(cfg =>
                cfg.CreateMap<FlightModel, Flight>());
            this.toDal = new Mapper(toDalConfig);
            var toModelConfig = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Flight, FlightModel>().ForMember("RecurringFlightsTemplate", opt =>
                    {
                        opt.Ignore();
                    });
                    cfg.CreateMap<Airplane, AirplaneModel>();
                    cfg.CreateMap<Airport, AirportModel>();
                }
            );
            this.toModel = new Mapper(toModelConfig);
        }


        public void CreateFlightsByTemplate(int templateId)
        {
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

            while ((int)firstFlightArrivalDate.DayOfWeek != template.ArrivalFromFirstCityDayOfWeek &&
                   firstFlightArrivalDate > PossibleFirstFlightArrivalDate)
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
                    //PairFlight = arrivalFlightFromFirstCity,
                };
                //arrivalFlightFromFirstCity.PairFlight = departureFlightToSecondCity;
                DbSet.AddRange(new[] { arrivalFlightFromFirstCity, departureFlightToSecondCity });

                firstFlightDepartureDate = firstFlightDepartureDate.AddDays(7);
                firstFlightArrivalDate = firstFlightArrivalDate.AddDays(7);
                secondFlightDepartureDate = firstFlightArrivalDate.AddDays(7);
                secondFlightArrivalDate = secondFlightArrivalDate.AddDays(7);
            }

            UOW.Save();
        }

        public (bool isCreate, string message) CheckAndUpdate(FlightModel flight)
        {
            throw new System.NotImplementedException();
        }
    }
}