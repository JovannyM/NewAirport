using BLL.Interfaces;
using BLL.UnitOfWork;
using Ninject.Modules;

namespace NewAirport.Utilites
{
    public class NinjectRegistration : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
        }
    }
}