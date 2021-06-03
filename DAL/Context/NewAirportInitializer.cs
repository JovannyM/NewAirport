using System;
using System.Collections.Generic;
using DAL.Entities;

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
                    IsMain = true,
                    CountOfRunways = 4,
                    SizeOfParking = 24
                },
                new Airport()
                {
                    Name = "Внуково[Москва]",
                    IsMain = false,
                    CountOfRunways = 3,
                    SizeOfParking = 15
                },
                new Airport()
                {
                    Name = "Шереметьево[Москва]",
                    IsMain = false,
                    CountOfRunways = 4,
                    SizeOfParking = 20
                },
                new Airport()
                {
                    Name = "Пулково[Санкт-Петербург]",
                    IsMain = false,
                    CountOfRunways = 2,
                    SizeOfParking = 30
                },
                new Airport()
                {
                    Name = "Пулково-2[Санкт-Петербург]",
                    IsMain = false,
                    CountOfRunways = 2,
                    SizeOfParking = 20
                },
                new Airport()
                {
                    Name = "Пашковский[Краснодар]",
                    IsMain = false,
                    CountOfRunways = 2,
                    SizeOfParking = 15
                },
                new Airport()
                {
                    Name = "Адлер[Сочи]",
                    IsMain = false,
                    CountOfRunways = 2,
                    SizeOfParking = 10
                },
                new Airport()
                {
                    Name = "Витязево[Анапа]",
                    IsMain = false,
                    CountOfRunways = 1,
                    SizeOfParking = 5
                },
                new Airport()
                {
                    Name = "Бельбек[Симферополь]",
                    IsMain = false,
                    CountOfRunways = 2,
                    SizeOfParking = 12
                },
                new Airport()
                {
                    Name = "Кольцово[Екатеринбург]",
                    IsMain = false,
                    CountOfRunways = 2,
                    SizeOfParking = 15
                },
                new Airport()
                {
                    Name = "Толмачево[Новосибирск]",
                    IsMain = false,
                    CountOfRunways = 2,
                    SizeOfParking = 10
                },
                new Airport()
                {
                    Name = "Новый[Хабаровск]",
                    IsMain = false,
                    CountOfRunways = 2,
                    SizeOfParking = 15
                },
                new Airport()
                {
                    Name = "Уфа[Уфа]",
                    IsMain = false,
                    CountOfRunways = 1,
                    SizeOfParking = 10
                },
                new Airport()
                {
                    Name = "Оренбург[Оренбург]",
                    IsMain = false,
                    CountOfRunways = 2,
                    SizeOfParking = 20
                },
                new Airport()
                {
                    Name = "Уйташ[Махачкала]",
                    IsMain = false,
                    CountOfRunways = 1,
                    SizeOfParking = 4
                },
                new Airport()
                {
                    Name = "Charles de Gaulle[Paris]",
                    IsMain = false,
                    CountOfRunways = 3,
                    SizeOfParking = 36
                },
                new Airport()
                {
                    Name = "Orly[Paris]",
                    IsMain = false,
                    CountOfRunways = 4,
                    SizeOfParking = 40
                },
                new Airport()
                {
                    Name = "Côte d'Azur[Nice]",
                    IsMain = false,
                    CountOfRunways = 2,
                    SizeOfParking = 22
                },
                new Airport()
                {
                    Name = "Brandenburg[Berlin]",
                    IsMain = false,
                    CountOfRunways = 3,
                    SizeOfParking = 30
                },
                new Airport()
                {
                    Name = "Bremen[Bremen]",
                    IsMain = false,
                    CountOfRunways = 3,
                    SizeOfParking = 25
                },
                new Airport()
                {
                    Name = "ANC[Anchorage]",
                    IsMain = false,
                    CountOfRunways = 2,
                    SizeOfParking = 20
                },
                new Airport()
                {
                    Name = "Bellingham[Washington]",
                    IsMain = false,
                    CountOfRunways = 4,
                    SizeOfParking = 35
                },
                new Airport()
                {
                    Name = "LYH[Virginia]",
                    IsMain = false,
                    CountOfRunways = 3,
                    SizeOfParking = 28
                },
                new Airport()
                {
                    Name = "GRB[Wisconsin]",
                    IsMain = false,
                    CountOfRunways = 3,
                    SizeOfParking = 30
                },
                new Airport()
                {
                    Name = "Galeen[Rio de Janeiro]",
                    IsMain = false,
                    CountOfRunways = 1,
                    SizeOfParking = 4
                },
                new Airport()
                {
                    Name = "Dumont[Santos]",
                    IsMain = false,
                    CountOfRunways = 1,
                    SizeOfParking = 4
                },
                new Airport()
                {
                    Name = "Cheklapkok[Hong Kong]",
                    IsMain = false,
                    CountOfRunways = 1,
                    SizeOfParking = 4
                },
                new Airport()
                {
                    Name = "Belage[Spain]",
                    IsMain = false,
                    CountOfRunways = 3,
                    SizeOfParking = 30
                }
            };

            var airplaneList = new List<Airplane>()
            {
                new Airplane()
                {
                    Name = "A320 1215",
                    Capacity = 150
                },
                new Airplane()
                {
                    Name = "A320 1102",
                    Capacity = 150
                },
                new Airplane()
                {
                    Name = "Boenig 747 0003",
                    Capacity = 600
                },
                new Airplane()
                {
                    Name = "Boeing 775 5035",
                    Capacity = 450
                }
            };

            var modelList = new List<Model>()
            {
                new Model()
                {
                    IsDeparture = false,
                    Airplane = airplaneList[0],
                    Airport = airportList[2],
                    Time = new TimeSpan(12, 0, 0),
                    DayOfWeek = 1,
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddDays(14)
                },
                new Model()
                {
                    IsDeparture = true,
                    Airplane = airplaneList[0],
                    Airport = airportList[2],
                    Time = new TimeSpan(12, 0, 0),
                    DayOfWeek = 2,
                    Cost = 5500,
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddDays(14)
                }
            };

            airportList.ForEach(e => context.Airports.Add(e));
            airplaneList.ForEach(e => context.Airplanes.Add(e));
            modelList.ForEach(e => context.Models.Add(e));

            context.SaveChanges();
        }
    }
}