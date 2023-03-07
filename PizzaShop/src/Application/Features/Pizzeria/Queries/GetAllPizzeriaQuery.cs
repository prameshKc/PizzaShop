using Application.Features.Pizzeria.Queries;
using Application.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Pizzeria.Queries
{
    public class GetAllPizzeriaQuery: IRequest<List<PizzeriaDto>>
    {
    }

    public class GetAllPizzeriaQueryHandler : IRequestHandler<GetAllPizzeriaQuery, List<PizzeriaDto>>
    {
        private readonly IPizzeriaRepository _repo;
        private readonly IMapper _mapper;

        public GetAllPizzeriaQueryHandler(IPizzeriaRepository pizzaRepository,IMapper mapper)
        {
            this._repo = pizzaRepository;
            this._mapper = mapper;
        }
        public async Task<List<PizzeriaDto>> Handle(GetAllPizzeriaQuery request, CancellationToken cancellationToken)
        {
            var pizzas = await _repo.GetAll();
            return _mapper.Map<List<PizzeriaDto>>(pizzas);
        }

       
    }
}
