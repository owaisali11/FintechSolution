using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Application.Repositories
{
    public interface IManageFile
    {
        Task<String> UploadFile(IFormFile formFile);
    }
}
