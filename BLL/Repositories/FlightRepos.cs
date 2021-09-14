using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;

namespace BLL.Repositories
{
    // public class FlightRepos : AbstractRepository<Flight>, IFlightRepository
    // {
    //     private readonly IUnitOfWork UOW;
    //
    //     public FlightRepos(BaseContext context, IUnitOfWork uow) : base(context, context.Flights)
    //     {
    //         UOW = uow;
    //     }
    //
    //     public override List<Flight> GetList()
    //     {
    //         var ListNewFlights = base.GetList();
    //         /*
    //         foreach (var item in ListNewFlights)
    //         {
    //             item.StartAirport = item.IsDeparture ? UOW.Airports.MainAirport : item.Airport;
    //             item.EndAirport = !item.IsDeparture ? UOW.Airports.MainAirport : item.Airport;
    //         }
    //         */
    //         return ListNewFlights;
    //     }
    //
    //     public void CreateFlightsByTemplate(RecurringFlightsTemplate model)
    //     {
    //         DateTime date = model.StartDateOfCreatingFlights;
    //         while (model.DayOfWeek != (int)date.DayOfWeek)
    //         {
    //             date = date.AddDays(1);
    //         }
    //
    //         for (; date < model.EndDateOfCreatingFlights; date = date.AddDays(7))
    //         {
    //             var newflight = new Flight()
    //             {
    //                 Airplane = model.Airplane,
    //                 Airport = model.Airport,
    //                 DepartureDate = date + model.DepartureDate,
    //                 ArrivalDate = model.DepartureDate > model.ArrivalDate ? date.AddDays(1) + model.ArrivalDate : date + model.ArrivalDate,
    //                 Edited = false,
    //                 IsDeparture = model.IsDeparture,
    //                 RecurringFlightsTemplate = model,
    //             };
    //             Create(newflight);
    //         }
    //
    //         UOW.Save();
    //     }
    //
    //     public (bool isCreate, string message) CheckAndUpdate(Flight model)
    //     {
    //         var checker = Check(model);
    //         if (checker.isCreate)
    //         {
    //             if (model.Id > 0) //это значит, что модель существует, и надо обновить
    //             {
    //                 var editedFlight = DB.Flights.Find(model.Id);
    //                 DB.Entry(editedFlight).CurrentValues.SetValues(model);
    //                 UOW.Save();
    //                 return (true, "Успешно обновлено");
    //             }
    //             else
    //             {
    //                 DB.Flights.Add(model);
    //                 UOW.Save();
    //                 return (true, "Успешно создано");
    //             }
    //         }
    //         return (false, checker.message);
    //     }
    //
    //     public (bool isCreate, string message) Check(Flight model)
    //     {
    //         var startTimeDeparture = model.ArrivalDate.AddMinutes(-10);
    //         var endTimeDeparture = model.ArrivalDate.AddMinutes(10);
    //         var conflictsFlights = DB.Flights.Where(f => f.Id != model.Id &&
    //                                                      f.ArrivalDate >= startTimeDeparture &&
    //                                                      f.ArrivalDate <= endTimeDeparture).FirstOrDefault();
    //         if (conflictsFlights != null) return (false, $"В выбранное время есть конфликтующий рейс №{conflictsFlights.Id} в {conflictsFlights.ArrivalDate.ToString()}");
    //         return (true, "");
    //     }
    // }
}