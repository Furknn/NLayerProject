﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NLayerProject.Core.Models;

namespace NLayerProject.Core.Repositories
{
    interface IProductRepository:IRepository<Product>
    {
        Task<Product> GettWithCategoryByIdAsync(int productId);
    }
}
