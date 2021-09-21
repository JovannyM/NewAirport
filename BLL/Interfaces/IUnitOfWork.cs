using System;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAirplaneService Airplanes { get; }
        IAirportRepository Airports { get; }
        IService<RecurringFlightsTemplateModel> Templates { get; }
        IFlightRepository Flights { get; }
        event EventHandler OnUpdateDbEvent;
        void Save();
    }
}