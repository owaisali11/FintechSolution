using Fintech.Application.Repositories;
using Fintech.Application.Services.Interface;
using Fintech.Domain.Models;
using Fintech.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Application.Services.Implementation
{   
    public class FaqServices : IFaqService
    {
        private readonly IFaqRepository _faqRepository;
        public FaqServices(IFaqRepository faqRepository)
        {
            _faqRepository = faqRepository;
        }
        public Task<GeneralResponse<Faq>> GetAllFaq()
        {
            return _faqRepository.GetAllFaq();
        }
    }
}
