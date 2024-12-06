﻿using CarBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class Feature:EntityBase
    {
        public string Name { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
    }
}
