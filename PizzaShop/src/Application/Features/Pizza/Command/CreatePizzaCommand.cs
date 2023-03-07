using Application.Features.Pizzeria.Queries;
using Application.Persistence;
using AutoMapper;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Pizza.Command
{
    public class CreatePizzaCommand:IRequest<PizzaDto>
    {
        public PizzaDto Pizza { get; set; }
    }

    public class CreatePizzaCommandHandler : IRequestHandler<CreatePizzaCommand, PizzaDto>
    {
        private readonly IPizzaRepository _repo;
        private readonly IMapper _map;

        public CreatePizzaCommandHandler(IPizzaRepository repo, IMapper map)
        {
            this._repo = repo;
            _map = map;
        }
        public async Task<PizzaDto> Handle(CreatePizzaCommand request, CancellationToken cancellationToken)
        {
            var response = new Domain.Entity.Pizza();
            if (string.IsNullOrEmpty(request.Pizza.PizzaID.ToString()) || request.Pizza.PizzaID==0)
            {
                response= await _repo.Insert(_map.Map<Domain.Entity.Pizza>(request.Pizza));
            } else
            {
                response = await _repo.Update(_map.Map<Domain.Entity.Pizza>(request.Pizza));

            }
            return  _map.Map<PizzaDto>(response);
        }
    }
}
