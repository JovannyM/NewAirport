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
                                                           f.ArrivalDate <= endTimeChek)));
            if (conflictsFlights.Count() == 0) return (true, "МОжно создавать пупу");
            return (false, "Пупа не пупа");
        }
    }
}