﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private StoreDbContext context;

        public IQueryable<Product> Products => context.Products;

        public EFStoreRepository(StoreDbContext context)
        {
            this.context = context;
        }
    }
}
