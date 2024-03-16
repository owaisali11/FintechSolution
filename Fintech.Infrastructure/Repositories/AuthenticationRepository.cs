using Fintech.Application.Repositories;
using Fintech.Domain.Dtos;
using Fintech.Domain.Models;
using Fintech.Domain.Responses;
using Fintech.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Infrastructure.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthenticationRepository(ApplicationDbContext context)
        {
            _context = context;
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
            var checkedUser = FindByEmail(user.EmailAddress!);

            if(checkedUser != null)
            {
                return new Response
                {
                    Status = false,
                    Message = "User Already exist"
                };
            }
            // save user 
            var applicationUser = new ApplicationUser
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
            var checkedUserRole = _context.Roles.FirstOrDefaultAsync(x => x.RoleName == "User");
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
            await AddToDatabase(new UserRole() { RoleId = checkedUserRole.Id, UserId = applicationUser.UserId });
            return new Response
            {
                Status = true,
                Message = "Account Successfully Created"
            };
           

            
        }
        private async Task<ApplicationUser> FindByEmail(string email)
        {
            var user = await _context.ApplicationUser.FirstOrDefaultAsync(x=>x.Email.ToLower() == email.ToLower());
            return user;
        }
        private async Task<T> AddToDatabase<T>(T model)
        {
            var result = _context.Add(model!);
            await _context.SaveChangesAsync();
            return (T)result.Entity;
        }
    }
}
