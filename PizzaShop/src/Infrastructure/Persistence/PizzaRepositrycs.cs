using Application.Persistence;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class PizzaRepositrycs : IPizzaRepository
    {
        private readonly IDapperRepository _dapper;

        private string _procedure = "Pizza_CRUD";

        public PizzaRepositrycs(IDapperRepository dapper)
        {
            this._dapper = dapper;
        }
        public async Task Delete(int Id)
        {
            var entity = new BaseEntity();
            entity.Flag = "DELETE";
            entity.Id = Id.ToString();
            await _dapper.ExecuteQueryAsync<Pizza>(_procedure, entity);
        }

        public async Task<List<Pizza>> GetAll()
        {
            var entity = new BaseEntity();
            entity.Flag = "GET";
            var data = await _dapper.ExecuteQueryAsync<Pizza>(_procedure, entity);
            return data;
        }

        public async Task<Pizza> GetById(int Id)
        {
            var entity = new BaseEntity();
            entity.Flag = "GETBYID";
            entity.Id = Id.ToString();
           var data= await _dapper.ExecuteQueryAsync<Pizza>(_procedure, entity);
            return data.FirstOrDefault();
        }

        public async Task<Pizza> Insert(Pizza pizza)
        {

            pizza.Flag = "INSERT";
            var response = await _dapper.ExecuteQueryAsync<Pizza>(_procedure, pizza);
            return response.FirstOrDefault();

        }

        public async Task<Pizza> Update(Pizza pizza)
        {
            pizza.Flag = "UPDATE";
            pizza.Photo= string.IsNullOrEmpty(pizza.Photo) ? null: pizza.Photo;
            var response = await _dapper.ExecuteQueryAsync<Pizza>(_procedure, pizza);
            return response.FirstOrDefault();
        }
    }
}
