﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Repository.Context;
using OnlineStore.Repository.Entities;

namespace OnlineStore.Repository.Repositories.CartProductRepository
{
    public class CartProductRepository: ICartProductRepository
    {
        private readonly StoreDbContext _context;

        public CartProductRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<CartProduct>> GetAllCartProducts()
        {

            return await _context.CartProducts.Include(p => p.Product).ToListAsync();
        }


        public async Task<CartProduct> GetByIdCartProduct(int id)
        {
            return await _context.CartProducts.Include(p => p.Product).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateCartProduct(CartProduct cartProduct)
        {

            await _context.CartProducts.AddAsync(cartProduct);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateCartProduct(CartProduct cartProduct)
        {
            _context.CartProducts.Update(cartProduct);
            await _context.SaveChangesAsync();

        }
        public void DeleteCartProduct(CartProduct cartProduct)
        {
            _context.CartProducts.Remove(cartProduct);

            _context.SaveChanges();

        }
    }
}
