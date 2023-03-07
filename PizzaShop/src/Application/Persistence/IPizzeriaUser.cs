using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence
{
    public interface IPizzeriaUser
    {
        Task<PizzeriaUserLogin> GetByIdAsync(int id);
        Task<List<PizzeriaUserLogin>> GetAll();
        Task<PizzeriaUserLogin> GetByCredentialsAsync(string username, string password);
        Task AddAsync(PizzeriaUserLogin login);
        Task UpdateAsync(PizzeriaUserLogin login);
        Task DeleteAsync(int id);

    }
}
