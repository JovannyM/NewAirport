using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using DAL.Entities;

// ReSharper disable StringLiteralTypo

namespace DAL.Context
{
    public class NewAirportInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BaseContext>
    {
        protected override void Seed(BaseContext context)
        {
            var airportList = new List<Airport>()
            {
                new Airport()
                {
                    Name = "Домодедово[Москва]",
                    CountOfRunways = 4,
                    SizeOfParking = 24
                },
                new Airport()
                {
                    Name = "Внуково[Москва]",
                    CountOfRunways = 3,
                    SizeOfParking = 15
                },
                new Airport()
                {
                    Name = "Шереметьево[Москва]",
                    CountOfRunways = 4,
                    SizeOfParking = 20
                },
                new Airport()
                {
                    Name = "Пулково[Санкт-Петербург]",
                    CountOfRunways = 2,
                    SizeOfParking = 30
                },
                new Airport()
                {
                    Name = "Пулково-2[Санкт-Петербург]",
                    CountOfRunways = 2,
                    SizeOfParking = 20
                },
                new Airport()
                {
                    Name = "Пашковский[Краснодар]",
                    CountOfRunways = 2,
                    SizeOfParking = 15
                },
                new Airport()
                {
                    Name = "Адлер[Сочи]",
                    CountOfRunways = 2,
                    SizeOfParking = 10
                },
                new Airport()
                {
                    Name = "Витязево[Анапа]",
                    CountOfRunways = 1,
                    SizeOfParking = 5
                },
                new Airport()
                {
                    Name = "Бельбек[Симферополь]",
                    CountOfRunways = 2,
                    SizeOfParking = 12
                },
                new Airport()
                {
                    Name = "Кольцово[Екатеринбург]",
                    CountOfRunways = 2,
                    SizeOfParking = 15
                },
                new Airport()
                {
                    Name = "Толмачево[Новосибирск]",
                    CountOfRunways = 2,
                    SizeOfParking = 10
                },
                new Airport()
                {
                    Name = "Новый[Хабаровск]",
                    CountOfRunways = 2,
                    SizeOfParking = 15
                },
                new Airport()
                {
                    Name = "Уфа[Уфа]",
                    CountOfRunways = 1,
                    SizeOfParking = 10
                },
                new Airport()
                {
                    Name = "Оренбург[Оренбург]",
                    CountOfRunways = 2,
                    SizeOfParking = 20
                },
                new Airport()
                {
                    Name = "Уйташ[Махачкала]",
                    CountOfRunways = 1,
                    SizeOfParking = 4
                },
                new Airport()
                {
                    Name = "Charles de Gaulle[Paris]",
                    CountOfRunways = 3,
                    SizeOfParking = 36
                },
                new Airport()
                {
                    Name = "Orly[Paris]",
                    CountOfRunways = 4,
                    SizeOfParking = 40
                },
                new Airport()
                {
                    Name = "Côte d'Azur[Nice]",
                    CountOfRunways = 2,
                    SizeOfParking = 22
                },
                new Airport()
                {
                    Name = "Brandenburg[Berlin]",
                    CountOfRunways = 3,
                    SizeOfParking = 30
                },
                new Airport()
                {
                    Name = "Bremen[Bremen]",
                    CountOfRunways = 3,
                    SizeOfParking = 25
                },
                new Airport()
                {
                    Name = "ANC[Anchorage]",
                    CountOfRunways = 2,
                    SizeOfParking = 20
                },
                new Airport()
                {
                    Name = "Bellingham[Washington]",
                    CountOfRunways = 4,
                    SizeOfParking = 35
                },
                new Airport()
                {
                    Name = "LYH[Virginia]",
                    CountOfRunways = 3,
                    SizeOfParking = 28
                },
                new Airport()
                {
                    Name = "GRB[Wisconsin]",
                    CountOfRunways = 3,
                    SizeOfParking = 30
                },
                new Airport()
                {
                    Name = "Galeen[Rio de Janeiro]",
                    CountOfRunways = 1,
                    SizeOfParking = 4
                },
                new Airport()
                {
                    Name = "Dumont[Santos]",
                    CountOfRunways = 1,
                    SizeOfParking = 4
                },
                new Airport()
                {
                    Name = "Cheklapkok[Hong Kong]",
                    CountOfRunways = 1,
                    SizeOfParking = 4
                },
                new Airport()
                {
                    Name = "Belage[Spain]",
                    CountOfRunways = 3,
                    SizeOfParking = 30
                }
            };

            var airplaneList = new List<Airplane>()
            {
                new Airplane()
                {
                    Name = "A320 1215",
                },
                new Airplane()
                {
                    Name = "A320 1102",
                },
                new Airplane()
                {
                    Name = "Boeing 747 0003",
                },
                new Airplane()
                {
                    Name = "Boeing 775 5035",
                }
            };

            var modelList = new List<RecurringFlightsTemplate>()
            {
                new RecurringFlightsTemplate()
                {
                    IsDeparture = false,
                    Airport = airportList[9],
                    Airplane = airplaneList[0],
                    DayOfWeek = 1,
                    DepartureTime = new TimeSpan(8, 0, 0),
                    ArrivalTime = new TimeSpan(10, 15, 0),
                    StartDateOfCreatingFlights = DateTime.Today,
                    EndDateOfCreatingFlights = DateTime.Today.AddDays(14)
                },
                new RecurringFlightsTemplate()
                {
                    IsDeparture = true,
                    Airport = airportList[5],
                    Airplane = airplaneList[0],
                    DayOfWeek = 4,
                    DepartureTime = new TimeSpan(20, 0, 0),
                    ArrivalTime = new TimeSpan(1, 30, 0),
                    StartDateOfCreatingFlights = DateTime.Today,
                    EndDateOfCreatingFlights = DateTime.Today.AddDays(14)
                }
            };


            airportList.ForEach(e => context.Airports.Add(e));
            airplaneList.ForEach(e => context.Airplanes.Add(e));
            modelList.ForEach(e => context.RecurringFlightsTemplates.Add(e));

            context.SaveChanges();

            var currentAirport = Queryable.FirstOrDefault(context.Airplanes).Id;
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Airport"].Value = currentAirport.ToString();
            config.Save();
        }
    }
}