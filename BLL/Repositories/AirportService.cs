using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Context;
using DAL.Entities;

namespace BLL.Repositories
{
    public class AirportService : AbstractService<Airport, AirportModel>, IAirportRepository
    {
        private int mainAirportId = 0;

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
            get
            {
                var ret = this.GetItem(Int32.Parse(ConfigurationManager.AppSettings["Airport"]));
                if (ret == null) ret = this.GetItem(mainAirportId);
                return ret;
            }
        }

        public void SetMainAirportId(int id)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Airport"].Value = id.ToString();
            config.Save();
            mainAirportId = id;
            OnSelectedAirport?.Invoke(this, new EventArgs());
        }

        public event EventHandler OnSelectedAirport;
        public List<AirportModel> GetList(bool withoutMain)
        {
            if (!withoutMain) return base.GetList();
            var listD = DbSet.Where(a => a.Id != MainAirport.Id && a.IsDeleted==false).ToList();
            var listModels = toModel.Map<List<Airport>, List<AirportModel>>(listD);
            return listModels;
        }

        public int TimeBetweenFlights
        {
            get
            {
                var ret = Int32.Parse(ConfigurationManager.AppSettings["DefaultTimeBetweenFlights"]) /
                          MainAirport.CountOfRunways;
                return ret;
            }
        }
    }
}