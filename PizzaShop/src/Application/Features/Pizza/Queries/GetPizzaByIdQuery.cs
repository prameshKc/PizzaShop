using Application.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Pizza.Queries
{
    public class GetPizzaByIdQuery : IRequest<PizzaDto>
    {
        public int Id { get; set; }
    }

    public class GetPizzaByIdHander : IRequestHandler<GetPizzaByIdQuery, PizzaDto>
    {
        private readonly IPizzaRepository _repo;
        private readonly IMapper _mapper;

        public GetPizzaByIdHander(IPizzaRepository pizzaRepository, IMapper mapper)
        {
            this._repo = pizzaRepository;
            this._mapper = mapper;
        }

        public async Task<PizzaDto> Handle(GetPizzaByIdQuery request, CancellationToken cancellationToken)
        {
            var pizzas = await _repo.GetById(request.Id);
            return _mapper.Map<PizzaDto>(pizzas);
        }
    }
}
