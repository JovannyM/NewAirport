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
    public class AirplaneService : AbstractService<Airplane, AirplaneModel>, IAirplaneService
    {
        public AirplaneService(BaseContext db, IUnitOfWork uow) : base(db, db.Airplanes, uow)
        {
            var toDalConfig = new MapperConfiguration(cfg =>
                cfg.CreateMap<AirplaneModel, Airplane>());
            this.toDal = new Mapper(toDalConfig);
            var toModelConfig = new MapperConfiguration(cfg =>
                cfg.CreateMap<Airplane, AirplaneModel>());
            this.toModel = new Mapper(toModelConfig);
        }

        public List<AirplaneModel> GetList(bool withoutUsingAirplane)
        {
            if (!withoutUsingAirplane) return base.GetList();
            var allAirplanes = base.GetList();
            List<AirplaneModel> returnedList = new List<AirplaneModel>();
            foreach (var airplane in allAirplanes)
            {
                var count = DB.RecurringFlightsTemplates.Where(t => t.Airplane_Id == airplane.Id).Count();
                if (count == 0)
                {
                    returnedList.Add(airplane);
                }
            }
            return returnedList;
        }
    }
}