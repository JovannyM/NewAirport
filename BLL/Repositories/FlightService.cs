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
                cfg.CreateMap<Flight, FlightModel>());
            this.toModel = new Mapper(toModelConfig);
        }


        public void CreateFlightsByTemplate(int templateId)
        {
            var template = DB.RecurringFlightsTemplates.Find(templateId);
            
            DateTime PossibleFirstFlightArrivalDate = template.StartDateOfCreatingFlights;
            DateTime firstFlightArrivalDate = template.StartDateOfCreatingFlights;
            DateTime secondFlightDepartureDate;

            var lastFlightByCurrentTemplate = DB.Flights.Where(f => f.RecurringFlightsTemplate.Id == template.Id)
                .OrderByDescending(f => f.DepartureTime).FirstOrDefault();

            if (lastFlightByCurrentTemplate != null)
            {
                var lastFlightDateByCurrentTemplate =
                    lastFlightByCurrentTemplate.DepartureTime.AddMinutes(UOW.Airports.TimeBetweenFlights);
                if (lastFlightDateByCurrentTemplate > PossibleFirstFlightArrivalDate)
                {
                    PossibleFirstFlightArrivalDate = lastFlightDateByCurrentTemplate;
                }
            }

            while ((int)firstFlightArrivalDate.DayOfWeek != template.ArrivalDayOfWeek)
            {
                firstFlightArrivalDate = firstFlightArrivalDate.AddDays(1);
            }
            
            for (;;)
            {
                var arrivalFlight = new Flight()
                {
                    RecurringFlightsTemplate = template,
                };
                var departureFlight = new Flight()
                {
                    RecurringFlightsTemplate = template,
                    PairFlight = arrivalFlight,
                };
                arrivalFlight.PairFlight = departureFlight;
                DbSet.AddRange(new[] { arrivalFlight, departureFlight });
            }
        }

        public (bool isCreate, string message) CheckAndUpdate(FlightModel flight)
        {
            throw new System.NotImplementedException();
        }
    }
}