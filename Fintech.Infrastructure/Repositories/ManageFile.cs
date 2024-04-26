using Fintech.Application.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Infrastructure.Repositories
{
    public class ManageFile : IManageFile
    {
        public Task<string> UploadFile(IFormFile formFile)
        {
            throw new NotImplementedException();
        }
    }
}
