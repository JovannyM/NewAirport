using System.Data.Entity;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Context;
using DAL.Entities;

namespace BLL.Repositories
{
    public class AirplaneService : AbstractService<Airplane, AirplaneModel>
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
    }
}