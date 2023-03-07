using Application.Persistence;
using AutoMapper;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Login.Command
{
    public class CreateLoginUserCommand : IRequest<LoginUserDto>
    {
        public LoginUserDto loginUser { get; set; }
    }
    public class CreateLoginUserCommandHandler : IRequestHandler<CreateLoginUserCommand, LoginUserDto>
    {
        private readonly IPizzeriaUser _repo;
        private readonly IMapper _map;

        public CreateLoginUserCommandHandler(IPizzeriaUser repo, IMapper map)
        {
            _repo = repo;
            _map = map;
        }

        public async Task<LoginUserDto> Handle(CreateLoginUserCommand request, CancellationToken cancellationToken)
        {
            await _repo.AddAsync(_map.Map<PizzeriaUserLogin>(request.loginUser));

            return request.loginUser;
        }
    }
}
