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


        public void CreateFlightsByModel(RecurringFlightsTemplateModel model)
        {
            throw new System.NotImplementedException();
        }

        public (bool isCreate, string message) CheckAndUpdate(FlightModel flight)
        {
            throw new System.NotImplementedException();
        }
    }
}