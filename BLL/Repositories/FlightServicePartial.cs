using System;
using System.Linq;
using BLL.Models;

namespace BLL.Repositories
{
    public partial class FlightService
    {
        public (bool isCreate, string message) CreateFlight(FlightModel flight)
        {
            var checker = CheckFlights(flight);
            if (checker.isCreate)
            {
                this.Create(flight);
            }

            return checker;
        }
        
        public (bool isCreate, string message) CheckFlights(FlightModel flight)
        {
            DateTime startTimeCheck;
            DateTime endTimeChek;
            if (flight.IsDeparture)
            {
                startTimeCheck = flight.DepartureDate.AddMinutes(-1 * UOW.Airports.TimeBetweenFlights);
                endTimeChek = flight.DepartureDate.AddMinutes(UOW.Airports.TimeBetweenFlights);
            }
            else
            {
                startTimeCheck = flight.ArrivalDate.AddMinutes(-1 * UOW.Airports.TimeBetweenFlights);
                endTimeChek = flight.ArrivalDate.AddMinutes(UOW.Airports.TimeBetweenFlights);
            }

            var conflictsFlights = DB.Flights.Where(f => f.Id != flight.Id &&
                                                         ((f.IsDeparture && f.DepartureDate >= startTimeCheck &&
                                                           f.DepartureDate <= endTimeChek) ||
                                                          (!f.IsDeparture && f.ArrivalDate >= startTimeCheck &&
                                                           f.ArrivalDate <= endTimeChek))).ToList();
            
            if (conflictsFlights.Count() == 0) return (true, "Рейс успешно добавлен");
            var firstConflictFlight = conflictsFlights.FirstOrDefault();
            var concflictTime = firstConflictFlight.IsDeparture
                ? firstConflictFlight.DepartureDate
                : firstConflictFlight.ArrivalDate;
            return (false, $"Создание/обновление невозможно так как запланирован конфликтный рейст в {concflictTime}");
        }

        public override (bool isDeleted, string messages) Delete(int id)
        {
            var flight = GetItem(id);
            if (flight.PairFlight_Id != null)
            {
                base.Delete((int)flight.PairFlight_Id);
                base.Delete(id);
                return (true,
                    $"Рейс с номером {id} и парный ему рейс с номером {flight.PairFlight_Id} успешно удалены");
                
            }
            base.Delete(id);
            return (true, $"Рейс с номером {id} успешно удален");
        }
    }
}