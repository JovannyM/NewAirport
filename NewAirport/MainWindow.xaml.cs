using Ninject;
using System;
using System.Configuration;
using BLL.Interfaces;
using NewAirport.Utilites;

namespace NewAirport
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            string connect = ConfigurationManager.ConnectionStrings["NewAirport"].ConnectionString;
            var KERNEL = new StandardKernel(new NinjectRegistration());

            IUnitOfWork DB = KERNEL.Get<IUnitOfWork>();

            var pupa = DB.Airplanes.GetList();
        }
    }
}