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
            {
                cfg.CreateMap<RecurringFlightsTemplateModel, RecurringFlightsTemplate>()
                    .ForMember("Airplane", opt => opt.Ignore())
                    .ForMember("FirstAirport", opt => opt.Ignore())
                    .ForMember("SecondAirport", opt => opt.Ignore());
            });

            this.toDal = new Mapper(toDalConfig);
            var toModelConfig = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RecurringFlightsTemplate, RecurringFlightsTemplateModel>()
                        .ForMember("DepartureFromFirstCityDayOfWeekString",
                            opt => opt.MapFrom((d, m) =>
                            {
                                if (d.DepartureTimeFromFirstCity < d.ArrivalTimeFromFirstCity)
                                    return DayOfWeekModel.DaysOfWeek[d.ArrivalFromFirstCityDayOfWeek].Name;
                                if (d.ArrivalFromFirstCityDayOfWeek > 0)
                                    return DayOfWeekModel.DaysOfWeek[d.ArrivalFromFirstCityDayOfWeek - 1].Name;
                                return DayOfWeekModel.DaysOfWeek[6].Name;
                            }))
                        .ForMember("ArrivalFromFirstCityDayOfWeekString",
                            opt => opt.MapFrom((d, m) =>
                            {
                                return DayOfWeekModel.DaysOfWeek[d.ArrivalFromFirstCityDayOfWeek].Name;
                            }))
                        .ForMember("DepartureToSecondCityDayOfWeekString",
                            opt => opt.MapFrom((d, m) =>
                            {
                                return DayOfWeekModel.DaysOfWeek[d.DepartureToSecondCityDayOfWeek].Name;
                            }))
                        .ForMember("ArrivalToSecondCityDayOfWeekString",
                            opt => opt.MapFrom((d, m) =>
                            {
                                if (d.DepartureTimeToSecondCity < d.ArrivalTimeToSecondCity)
                                    return DayOfWeekModel.DaysOfWeek[d.DepartureToSecondCityDayOfWeek].Name;
                                if (d.DepartureToSecondCityDayOfWeek < 6)
                                    return DayOfWeekModel.DaysOfWeek[d.DepartureToSecondCityDayOfWeek + 1].Name;
                                return DayOfWeekModel.DaysOfWeek[0].Name;
                            }));
                    cfg.CreateMap<Airplane, AirplaneModel>();
                    cfg.CreateMap<Airport, AirportModel>();
                }
            );
            this.toModel = new Mapper(toModelConfig);
        }
    }
}