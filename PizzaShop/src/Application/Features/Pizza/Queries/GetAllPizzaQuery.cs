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
    public class GetAllPizzaQuery: IRequest<List<PizzaDto>>
    {
    }

    public class GetAllPizzaHandler : IRequestHandler<GetAllPizzaQuery, List<PizzaDto>>
    {
        private readonly IPizzaRepository _repo;
        private readonly IMapper _mapper;

        public GetAllPizzaHandler(IPizzaRepository pizzaRepository,IMapper mapper)
        {
            this._repo = pizzaRepository;
            this._mapper = mapper;
        }
        public async Task<List<PizzaDto>> Handle(GetAllPizzaQuery request, CancellationToken cancellationToken)
        {
            var pizzas = await _repo.GetAll();
            return _mapper.Map<List<PizzaDto>>(pizzas);
        }

       
    }
}
