using Ninject;
using System;
using System.Configuration;
using BLL.Interfaces;
using NewAirport.Utilites;

namespace NewAirport.VVM
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            IUnitOfWork DB = IoC.Get<IUnitOfWork>();
        }
    }
}