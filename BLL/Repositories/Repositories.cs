﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;

namespace BLL.Repositories
{
    public class AirplaneRepos : AbstractRepository<Airplane>
    {
        public AirplaneRepos(BaseContext context) : base(context, context.Airplanes)
        {
        }
    }

    public class AirportRepos : AbstractRepository<Airport>, IAirportRepository
    {
        private Airport _mainAirport;
        public Airport MainAirport => _mainAirport ??= GetMainAirport();
        public AirportRepos(BaseContext context) : base(context, context.Airports)
        {
        }
        private Airport GetMainAirport() => DB.Airports.Where(a => a.IsMain).FirstOrDefault();
    }

    public class ModelRepos : AbstractRepository<Model>
    {
        private IUnitOfWork UOW;
        public ModelRepos(BaseContext context, IUnitOfWork uow) : base(context, context.Models)
        {
            UOW = uow;
        }

        public override Model GetItem(int id)
        {
            var item = base.GetItem(id);
            item.StartAirport = item.IsDeparture ? UOW.Airports.MainAirport : item.Airport;
            item.EndAirport = !item.IsDeparture ? UOW.Airports.MainAirport : item.Airport;
            return item;
        }

        public override List<Model> GetList()
        {
            var ListNewModels = base.GetList();
            foreach (var item in ListNewModels)
            {
                item.StartAirport = item.IsDeparture ? UOW.Airports.MainAirport : item.Airport;
                item.EndAirport = !item.IsDeparture ? UOW.Airports.MainAirport : item.Airport;
            }
            return ListNewModels;
        }
    }

    public class FlightRepos : AbstractRepository<Flight>, IFlightRepository
    {
        private IUnitOfWork UOW;
        public FlightRepos(BaseContext context, IUnitOfWork uow) : base(context, context.Flights)
        {
            UOW = uow;
        }

        public override List<Flight> GetList()
        {
            var ListNewFlights = base.GetList();
            foreach (var item in ListNewFlights)
            {
                item.StartAirport = item.IsDeparture ? UOW.Airports.MainAirport : item.Airport;
                item.EndAirport = !item.IsDeparture ? UOW.Airports.MainAirport : item.Airport;
            }
            return ListNewFlights;
        }

        public void CreateFlightsByModel(Model model)
        {
            DateTime date = model.StartDate;
            while (model.DayOfWeek != (int)date.DayOfWeek)
            {
                date = date.AddDays(1);
            }

            for (;date < model.EndDate; date = date.AddDays(7))
            {
                var newflight = new Flight()
                {
                    Model = model,
                    Airplane = model.Airplane,
                    Airport = model.Airport,
                    DateTime = date,
                    IsDeparture = model.IsDeparture,
                    Cost = model.Cost,
                    Edited = false
                };
                Create(newflight);
            }

            DB.SaveChanges();
        }
    }

    public class TicketRepos : AbstractRepository<Ticket>
    {
        public TicketRepos(BaseContext context) : base(context, context.Tickets)
        {
        }
    }
}