using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnlineStore.Repository.Repositories.CategoryRepository;
using OnlineStore.Service.DTOs;

namespace OnlineStore.Service.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetAllCategories()
        {
            return _mapper.Map<List<CategoryDto>>(await _categoryRepository.GetAllCategories());
        }
    }
}