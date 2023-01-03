using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Repository
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalPages { get; set; }
        public int ItemsFrom { get; set; }
        public int ItemsTo { get; set; }
        public int TotalItemsCount { get; set; }

        public PagedResult(List<T> items, int totalCount, int pageSize, int pageNumber)
        {
            Items = items;
            TotalItemsCount = totalCount;
            ItemsFrom = pageSize * (pageNumber - 1) + 1;
            ItemsTo = ItemsFrom + pageSize - 1;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }

        public PagedResult(List<T> items, int totalItemsCount, int itemsFrom, int itemsTo, int totalPages)
        {
            Items = items;
            TotalItemsCount = totalItemsCount;
            ItemsFrom = itemsFrom;
            ItemsTo = itemsTo;
            TotalPages = totalPages;

        }
    }
}
