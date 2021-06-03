using System.Runtime.Remoting.Messaging;
using Ninject;
using Ninject.Parameters;

namespace NewAirport.Utilites
{
    public static class IoC
    {
        private static IKernel Kernel = new StandardKernel(new NinjectRegistration());

        public static T Get<T>(params IParameter[] parametres) => Kernel.Get<T>(parametres);
    }
}