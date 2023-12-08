﻿using Aplication.Dtos;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Commands.Products
{
    public class UpdateProduct : IMessage
    {
        public ProductDto Product { get; set; }
    }
}
