using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence
{
    public interface IPizzeriaRepository
    {
        Task<List<Pizzeria>> GetAll();
        Task<Pizzeria> Insert(Pizzeria pizza);
        Task<Pizzeria> Update(Pizzeria pizza);
        Task Delete(int Id);
        Task<Pizzeria> GetById(int Id);
    }
}
