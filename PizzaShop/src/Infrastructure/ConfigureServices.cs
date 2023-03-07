using Application.Persistence;
using Domain.Entity;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PizzaShop.Application.Common.Interfaces;
using PizzaShop.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IDapperRepository, DapperRepository>();
            services.AddTransient<IPizzaRepository, PizzaRepositrycs>();
            services.AddTransient<IPizzeriaRepository, PizzeriaRepositrycs>();
            services.AddTransient<IPizzeriaUser, PizzeriaUserRepository>();
            services.AddTransient<IDateTime, DateTimeService>();
           
            return services;

        }

    }
}
