using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Service.DTOs;

namespace OnlineStore.Service.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategories();
    }
}
