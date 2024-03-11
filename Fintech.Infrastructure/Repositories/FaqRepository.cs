using Fintech.Application.Repositories;
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
    public class FaqRepository : IFaqRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FaqRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<GeneralResponse<Faq>> GetAllFaq()
        {
            var faq = await _dbContext.Faqs.ToListAsync();

            if(faq == null)
            {
                return new GeneralResponse<Faq>
                {
                    status = false,
                    Data = null,
                };
            }
            var res = new GeneralResponse<Faq>
            {
                status = true,
                Data = faq
            };
            return res;
        }
    }
}
