using Fintech.Domain.Models;
using Fintech.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Application.Repositories
{
    public interface IFaqRepository
    {
        Task<GeneralResponse<Faq>> GetAllFaq();
    }
}
