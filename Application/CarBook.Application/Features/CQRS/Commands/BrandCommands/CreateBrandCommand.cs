﻿using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.Brands
{
    public class CreateBrandCommand
    {
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
    }
}
