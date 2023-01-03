using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Repository.Entities;

namespace OnlineStore.Repository.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
    }
}
