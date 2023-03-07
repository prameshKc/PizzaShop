using Application.Features.Login;
using Application.Features.Pizza;
using Application.Features.Pizzeria.Queries;
using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class MapperProfile:Profile
    {

        public MapperProfile()
        {
            CreateMap<Pizza, PizzaDto>().ReverseMap();
            CreateMap<Pizzeria, PizzeriaDto>().ReverseMap();
            CreateMap<PizzeriaUserLogin, LoginUserDto>().ReverseMap();
        }
    }
}
