using Application.Persistence;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class PizzeriaUserRepository : IPizzeriaUser
    {
        private readonly IDapperRepository _dapper;

        private string _procedure = "PizzeriaUserLoginCRUD";

        public PizzeriaUserRepository(IDapperRepository dapper)
        {
            this._dapper = dapper;
        }
        public async Task AddAsync(PizzeriaUserLogin login)
        {
            login.Flag = string.IsNullOrEmpty(login.Flag) ? "INSERT" : login.Flag;
            await _dapper.ExecuteQueryAsync<int>(_procedure, login);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = new BaseEntity();
            entity.Flag = "DELETE";
            await _dapper.ExecuteQueryAsync<int>(_procedure, entity);
        }

        public async Task<List<PizzeriaUserLogin>> GetAll()
        {
            var entity = new BaseEntity();
            entity.Flag = "GET";
           return  await _dapper.ExecuteQueryAsync<PizzeriaUserLogin>(_procedure, entity);
        }

        public async Task<PizzeriaUserLogin> GetByCredentialsAsync(string username, string password)
        {
            var entity = new PizzeriaUserLogin();
            entity.Flag = "LOGIN";
            entity.UserName = username;
            entity.Password = password;
            var response= await _dapper.ExecuteQueryAsync<PizzeriaUserLogin>(_procedure, entity);
            return response.FirstOrDefault();
        }

        public Task<PizzeriaUserLogin> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PizzeriaUserLogin login)
        {
            throw new NotImplementedException();
        }
    }
}
