﻿using System.Data.Entity;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Context;
using DAL.Entities;

namespace BLL.Repositories
{
    public class TemplateService : AbstractService<RecurringFlightsTemplate, RecurringFlightsTemplateModel>
    {
        public TemplateService(BaseContext db, IUnitOfWork uow) : base(db, db.RecurringFlightsTemplates, uow)
        {
            var toDalConfig = new MapperConfiguration(cfg =>
                cfg.CreateMap<RecurringFlightsTemplateModel, RecurringFlightsTemplate>());
            // .ForMember("FirstAirport", opt =>
            //     opt.MapFrom(s => new AirportModel()))
            // .ForMember("SecondAirport", opt =>
            //     opt.MapFrom(s => new AirportModel())));
            this.toDal = new Mapper(toDalConfig);
            var toModelConfig = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RecurringFlightsTemplate, RecurringFlightsTemplateModel>();
                    cfg.CreateMap<Airplane, AirplaneModel>();
                    cfg.CreateMap<Airport, AirportModel>();
                }
            );
            this.toModel = new Mapper(toModelConfig);
        }
    }
}