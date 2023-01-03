using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Service.DTOs;

namespace OnlineStore.Service.Services.BrandService
{
    public interface IBrandService
    {
        Task<List<BrandDto>> GetAllBrands();
    }
}

