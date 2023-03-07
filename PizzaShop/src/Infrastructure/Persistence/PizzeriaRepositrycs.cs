using Application.Persistence;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class PizzeriaRepositrycs : IPizzeriaRepository
    {
        private readonly IDapperRepository _dapper;

        private string _procedure = "Pizzeria_CRUD";

        public PizzeriaRepositrycs(IDapperRepository dapper)
        {
            this._dapper = dapper;
        }
        public async Task Delete(int Id)
        {
            var entity = new BaseEntity();
            entity.Flag = "DELETE";
            await _dapper.ExecuteQueryAsync<Pizzeria>(_procedure, entity);
        }
        public async Task<List<Pizzeria>> GetAll()
        {
            var entity = new BaseEntity();
            entity.Flag = "GET";
            var data = await _dapper.ExecuteQueryAsync<Pizzeria>(_procedure, entity);
            return data;
        }
        public async Task<Pizzeria> GetById(int Id)
        {
            var entity = new BaseEntity();
            entity.Flag = "GETBYID";
            var data = await _dapper.ExecuteQueryAsync<Pizzeria>(_procedure, entity);
            return data.FirstOrDefault();
        }
        public async Task<Pizzeria> Insert(Pizzeria Pizzeria)
        {
            Pizzeria.Flag = string.IsNullOrEmpty(Pizzeria.Flag) ? "INSERT" : Pizzeria.Flag;
            var response = await _dapper.ExecuteQueryAsync<Pizzeria>(_procedure, Pizzeria);
            return response.FirstOrDefault();
        }

        public async Task<Pizzeria> Update(Pizzeria Pizzeria)
        {
            Pizzeria.Flag = "UPDATE";
            var response = await _dapper.ExecuteQueryAsync<Pizzeria>(_procedure, Pizzeria);
            return response.FirstOrDefault();
        }
    }
}
