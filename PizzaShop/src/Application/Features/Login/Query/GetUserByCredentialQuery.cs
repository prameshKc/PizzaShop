using Application.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Login.Query
{
    public class GetUserByCredentialQuery : IRequest<LoginUserDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class GetUserByCredentialQueryHandler : IRequestHandler<GetUserByCredentialQuery, LoginUserDto>
    {
        private readonly IPizzeriaUser _repo;
        private readonly IMapper _map;

        public GetUserByCredentialQueryHandler(IPizzeriaUser repo, IMapper map)
        {
            this._repo = repo;
            this._map = map;
        }
        public async Task<LoginUserDto> Handle(GetUserByCredentialQuery request, CancellationToken cancellationToken)
        {

            var isValidUser = await _repo.GetByCredentialsAsync(request.UserName, request.Password);
            return _map.Map<LoginUserDto>(isValidUser);
        }
    }

}
