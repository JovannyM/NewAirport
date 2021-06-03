using System.Data.Entity;
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

    public class AirportRepos : AbstractRepository<Airport>
    {
        public AirportRepos(BaseContext context) : base(context, context.Airports)
        {
        }
    }

    public class ModelRepos : AbstractRepository<Model>
    {
        public ModelRepos(BaseContext context) : base(context, context.Models)
        {
        }
    }

    public class FlightRepos : AbstractRepository<Flight>
    {
        public FlightRepos(BaseContext context) : base(context, context.Flights)
        {
        }
    }

    public class TicketRepos : AbstractRepository<Ticket>
    {
        public TicketRepos(BaseContext context) : base(context, context.Tickets)
        {
        }
    }
}