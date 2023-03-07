using Application.Features.Login;
using Application.Persistence;
using Domain.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SeedData
{
    public static class SeedExtension
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            var _pizza = app.ApplicationServices.GetService<IPizzaRepository>();
            var _pizzeria = app.ApplicationServices.GetService<IPizzeriaRepository>();
            var _pizzeriaUser = app.ApplicationServices.GetService<IPizzeriaUser>();

            var isPizzaeriaExist = _pizzeria.GetAll()
                                            .GetAwaiter()
                                            .GetResult()
                                            .FirstOrDefault();

            var isPizaExist = _pizza.GetAll()
                                    .GetAwaiter()
                                    .GetResult()
                                    .FirstOrDefault();

            if (isPizzaeriaExist is null)
            {

                List<Pizzeria> pizzerias = JsonConvert
                                        .DeserializeObject<List<Pizzeria>>(File.ReadAllText("../Infrastructure/SeedData/Pizzeria.json"));

                foreach (var item in pizzerias)
                {
                    item.Flag = "SEED_DATA";
                    _pizzeria.Insert(item);
                }


                if (isPizaExist is null)
                {
                    List<Pizza> pizzas = JsonConvert
                                       .DeserializeObject<List<Pizza>>(File.ReadAllText("../Infrastructure/SeedData/Pizzas.json"));

                    foreach (var item in pizzas)
                    {
                        _pizza.Insert(item);
                    }
                }


            }
            SeedUser(_pizzeriaUser);

        }

        public static void SeedUser(IPizzeriaUser pizzeriaUser)
        {
            var isUserExist = pizzeriaUser.GetAll()
                                          .GetAwaiter()
                                          .GetResult();
            if (isUserExist.Count == 0)
            {
                var users= JsonConvert.DeserializeObject<List<PizzeriaUserLogin>>(File.ReadAllText("../Infrastructure/SeedData/users.json"));
                foreach (var item in users)
                {
                    item.Flag = "SEED_DATA";
                    pizzeriaUser.AddAsync(item);
                }
            }
        }

    }
}
