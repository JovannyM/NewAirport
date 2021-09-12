using System;
using System.Configuration;
using System.Data.Entity;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Context;
using DAL.Entities;

namespace BLL.Repositories
{
    public class AirportService : AbstractService<Airport, AirportModel>, IAirportRepository
    {
        public AirportService(BaseContext db, IUnitOfWork uow) : base(db, db.Airports, uow)
        {
            var toDalConfig = new MapperConfiguration(cfg =>
                cfg.CreateMap<AirportModel, Airport>());
            this.toDal = new Mapper(toDalConfig);
            var toModelConfig = new MapperConfiguration(cfg =>
                cfg.CreateMap<Airport, AirportModel>());
            this.toModel = new Mapper(toModelConfig);
        }


        public AirportModel MainAirport
        {
            get => this.GetItem(Int32.Parse(ConfigurationManager.AppSettings["Airport"]));
        }
    }
}