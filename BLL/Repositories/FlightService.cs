using System;
using System.Data.Entity;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Context;
using DAL.Entities;

namespace BLL.Repositories
{
    public class FlightService : AbstractService<Flight, FlightModel>, IFlightRepository
    {
        public FlightService(BaseContext db,IUnitOfWork uow) : base(db, db.Flights, uow)
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
            DateTime date = template.StartDateOfCreatingFlights;
            
            
           
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
                DbSet.AddRange(new []{arrivalFlight,departureFlight});
            }
            
        }

        public (bool isCreate, string message) CheckAndUpdate(FlightModel flight)
        {
            throw new System.NotImplementedException();
        }

        
    }
}