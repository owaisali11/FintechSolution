using Fintech.Application.Repositories;
using Fintech.Application.Services.Interface;
using Fintech.Domain.Dtos;
using Fintech.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Application.Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        public AuthenticationService(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }
        public Task<Response> Register(Register registerModel)
        {
            return _authenticationRepository.Register(registerModel);
        }
    }
}
