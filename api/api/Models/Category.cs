﻿using api.Models;

namespace api.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
        public int CategoryTypeId { get; set; }

    }
}