using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Repository.Context;
using OnlineStore.Repository.Entities;

namespace OnlineStore.Repository.Repositories.BrandRepository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly StoreDbContext _context;

        public BrandRepository(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<List<Brand>> GetAllBrands()
        {
            return await _context.Brands.ToListAsync();
        }
    }
}