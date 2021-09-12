using System.Data.Entity;
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
            this.toDal = new Mapper(toDalConfig);
            var toModelConfig = new MapperConfiguration(cfg =>
                cfg.CreateMap<RecurringFlightsTemplate, RecurringFlightsTemplateModel>());
            this.toModel = new Mapper(toModelConfig);
        }
    }
}