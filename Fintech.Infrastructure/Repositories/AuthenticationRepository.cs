using Fintech.Application.Repositories;
using Fintech.Domain.Dtos;
using Fintech.Domain.Models;
using Fintech.Domain.Responses;
using Fintech.Infrastructure.Data;
using Fintech.Infrastructure.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Infrastructure.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IOptions<JwtSection> options;
        public AuthenticationRepository(ApplicationDbContext context, IOptions<JwtSection> config)
        {
            _context = context;
            options = config;
        }
        public async Task<Response> Register(Register user)
        {
            if(user == null)
            {
                return new Response
                {
                    Status = false,
                    Message= "Model is null"
                };
            }
            var checkedUser = await FindByEmail(user.EmailAddress!);

            if(checkedUser != null )
            {
                return new Response
                {
                    Status = false,
                    Message = "User Already exist"
                };
            }
            // save user 
            var applicationUser = new User
            {
                Name = user.Name,
                Email = user.EmailAddress,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
            };
            _context.Add(applicationUser);
            await _context.SaveChangesAsync();

            var checkedRole = await _context.Roles.FirstOrDefaultAsync(x => x.RoleName == "Admin");
            if(checkedRole is null)
            {
                var createAdminRole = new Roles
                {
                    RoleName = "Admin",
                };
                _context.Roles.Add(createAdminRole);
                await _context.SaveChangesAsync();

                await AddToDatabase(new UserRole() { RoleId = createAdminRole.RoleId , UserId = applicationUser.UserId});
                return new Response
                {
                    Status = true,
                    Message = "Account Successfully Created",
                };
            }
            var checkedUserRole = await _context.Roles.FirstOrDefaultAsync(x => x.RoleName == "User");
            if(checkedUserRole is null)
            {
                var createUserRole = new Roles()
                {
                    RoleName = "User",
                };
                _context.Roles.Add(createUserRole);
                await _context.SaveChangesAsync();

               await AddToDatabase(new UserRole() { RoleId = createUserRole.RoleId, UserId = applicationUser.UserId});
            }
            await AddToDatabase(new UserRole() { RoleId = checkedUserRole.RoleId, UserId = applicationUser.UserId });
            return new Response
            {
                Status = true,
                Message = "Account Successfully Created"
            };
            
        }
       
        public async Task<LoginResponse> SignInAsync(Login loginModel)
        {
            if(loginModel == null)
            {
                return new LoginResponse
                {
                    Status = false,
                    Message = "Model is empty"
                };
            }
            var user = await FindByEmail(loginModel.Email);

            if(user is null)
            {
                return new LoginResponse
                {
                    Status= false,
                    Message = "User Not Found",
                };
            }
            if (!BCrypt.Net.BCrypt.Verify(loginModel.Password, user.Password))
            {
                return new LoginResponse
                {
                    Status = false,
                    Message = "Incorrect Email or Password"
                };
            }
            var getUserRole = await GetUserRole(user.UserId);
            if(getUserRole == null)
            {
                return new LoginResponse
                {
                    Status = false,
                    Message = "User Role not found"
                };
            }
            var getRoleName = await GetUserRoleName(getUserRole.RoleId);
            if(getRoleName == null)
            {
                return new LoginResponse
                {
                    Status = false,
                    Message = "Role Not Found"
                };
            }
            string jwtToken = GenerateToken(user, getRoleName.RoleName!);
            string refereshToken = GenerateRefereshToken();
            return new LoginResponse { Status = true, Message = "Login Successfully", Token = jwtToken, RefereshToken = refereshToken };
        }
        public string GenerateToken(User user, string role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.Key!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Name, user.Name!),
                new Claim(ClaimTypes.Role, role)
            };

            var token = new JwtSecurityToken
            (
                claims: userClaims,
            notBefore: null,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials,
                audience: options.Value.Audience
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
        private async Task<UserRole> GetUserRole(int Id) => await _context.UserRoles.FirstOrDefaultAsync(x => x.UserId == Id);
        private async Task<Roles> GetUserRoleName(int RoleId) => await _context.Roles.FirstOrDefaultAsync(x => x.RoleId == RoleId);
        private async Task<User> FindByEmail(string email) => await _context.ApplicationUser.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
        private static string GenerateRefereshToken() => Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

        private async Task<T> AddToDatabase<T>(T model)
        {
            var result = _context.Add(model!);
            await _context.SaveChangesAsync();
            return (T)result.Entity;
        }
    }
}
