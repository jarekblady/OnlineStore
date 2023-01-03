using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Repository.Entities;

namespace OnlineStore.Repository
{
    public static class PagingSortingFiltering
    {
        public static IQueryable<Product> Sort(this IQueryable<Product> query, string orderBy)
        {
            if (string.IsNullOrEmpty(orderBy)) return query.OrderBy(p => p.Name);

            query = orderBy switch
            {
                "cost" => query.OrderBy(p => p.Cost),
                "costDesc" => query.OrderByDescending(p => p.Cost),
                _ => query.OrderBy(p => p.Name)
            };

            return query;
        }

        public static IQueryable<Product> Search(this IQueryable<Product> query, string searchPhrase)
        {
            if (string.IsNullOrEmpty(searchPhrase)) return query;

            var lowerCaseSearchTerm = searchPhrase.Trim().ToLower();

            return query.Where(p => p.Name.ToLower().Contains(lowerCaseSearchTerm));
        }

        public static IQueryable<Product> Filter(this IQueryable<Product> query, int brandId, int categoryId)
        {

            query = query.Where(p => brandId == 0 || p.BrandId == brandId);
            query = query.Where(p => categoryId == 0 || p.CategoryId == categoryId);

            return query;
        }
    }
}
