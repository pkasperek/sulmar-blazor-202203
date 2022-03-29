﻿using Shopper.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopper.Domain.Services;

public interface IProductService
{
    Task<IEnumerable<Product>?> GetAsync(CancellationToken token = default);
    Task<Product?> GetByIdAsync(int id);
}