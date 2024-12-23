﻿using CarBook.Domain.Common;

namespace CarBook.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }
        public List<Blog> Blog { get; set; }
    }
}
