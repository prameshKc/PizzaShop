using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Persistence
{
    public interface IPizzaRepository
    {
        Task<List<Pizza>> GetAll();
        Task<Pizza> Insert(Pizza pizza);
        Task<Pizza> Update(Pizza pizza);
        Task Delete(int Id);
        Task<Pizza> GetById(int Id);


    }
}
