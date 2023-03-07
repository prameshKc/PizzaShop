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
    public class GetPizzeriaByIdQuery : IRequest<PizzeriaDto>
    {
        public int Id { get; set; }
    }

    public class GetPizzaByIdHander : IRequestHandler<GetPizzeriaByIdQuery, PizzeriaDto>
    {
        private readonly IPizzeriaRepository _repo;
        private readonly IMapper _mapper;

        public GetPizzaByIdHander(IPizzeriaRepository pizzaRepository, IMapper mapper)
        {
            this._repo = pizzaRepository;
            this._mapper = mapper;
        }

        public async Task<PizzeriaDto> Handle(GetPizzeriaByIdQuery request, CancellationToken cancellationToken)
        {
            var pizzas = await _repo.GetById(request.Id);
            return _mapper.Map<PizzeriaDto>(pizzas);
        }
    }
}
