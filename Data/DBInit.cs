using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SytnerTest.Models;


namespace SytnerTest.Data
{
    public class DBInit
    {
        public static void Init(DBContext context)
        {
            context.Database.EnsureCreated();

            //Checks if database already has content
            if (context.cars.Any())
            {
                return;
            }

            //Else Populates it
            var cars = new car[]
            {
                new car { Make = "Alfa Romeo", Model="Gulia Veloce", Year=2017 },
                new car { Make = "Audi",Model="S5 Sportback",Year=2017 },
                new car { Make = "BMW", Model="M3 E30", Year=1994 },
                new car { Make = "BMW", Model="M4 F83", Year=2016 },
                new car { Make = "Jaguar", Model="F-Type SVR", Year=2017 },
                new car { Make = "Lamborghini", Model="Hurican L-63 Avio", Year=2017 },
                new car { Make = "Nissan", Model="GTR Black", Year=2012 },
                new car { Make = "Porsche", Model="Panamera Turbo", Year=2017 },
                new car { Make = "Seat", Model="Leon FR 184", Year=2014 }
            };
            foreach(car c in cars)
            {
                context.cars.Add(c);
            }
            context.SaveChanges();

        }

    }
}
