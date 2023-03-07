using Application.Features.Pizza.Queries;
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

namespace Application.Features.Pizzeria.Command
{
    public class CreatePizzeriaCommand:IRequest<PizzeriaDto>
    {
        public PizzeriaDto PizzeriaDto { get; set; }
    }

    public class CreatePizzeriaCommandHandler : IRequestHandler<CreatePizzeriaCommand, PizzeriaDto>
    {
        private readonly IPizzeriaRepository _repo;
        private readonly IMapper _map;

        public CreatePizzeriaCommandHandler(IPizzeriaRepository repo, IMapper map)
        {
            this._repo = repo;
            _map = map;
        }
        public async Task<PizzeriaDto> Handle(CreatePizzeriaCommand request, CancellationToken cancellationToken)
        {

            var response = new Domain.Entity.Pizzeria();
            if (string.IsNullOrEmpty(request.PizzeriaDto.PizzeriaID.ToString()))
            {
                response = await _repo.Insert(_map.Map<Domain.Entity.Pizzeria>(request.PizzeriaDto));

            }
            else
            {
                response= await _repo.Update(_map.Map<Domain.Entity.Pizzeria>(request.PizzeriaDto));

            }

            return  _map.Map<PizzeriaDto>(response);
        }
    }
}
