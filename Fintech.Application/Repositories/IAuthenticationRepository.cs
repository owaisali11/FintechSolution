using Fintech.Domain.Dtos;
using Fintech.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Application.Repositories
{
    public interface IAuthenticationRepository
    {
        Task<Response> Register(Register registerModel); 
        Task <LoginResponse> SignInAsync(Login loginModel);
    }
}
