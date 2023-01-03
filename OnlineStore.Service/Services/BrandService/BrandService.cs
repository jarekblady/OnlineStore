using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnlineStore.Repository.Repositories.BrandRepository;
using OnlineStore.Service.DTOs;

namespace OnlineStore.Service.Services.BrandService
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public BrandService(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<List<BrandDto>> GetAllBrands()
        {
            return _mapper.Map<List<BrandDto>>(await _brandRepository.GetAllBrands());
        }
    }
}
