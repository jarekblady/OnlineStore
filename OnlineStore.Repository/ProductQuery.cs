﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Repository
{
    public class ProductQuery
    {
        public string SearchPhrase { get; set; }
        public string OrderBy { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 2;
    }
}
