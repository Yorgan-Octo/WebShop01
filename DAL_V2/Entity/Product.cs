﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_V2.Entity
{
    public class Product
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double ActionPrice { get; set; }
        public string Description { get; set; }
        public string DescriptionField1 { get; set; }
        public string DescriptionField2 { get; set; }
        public string ImageUrl { get; set; }
        public Category Category { get; set; }
        public List<Cart> Cart { get; set; }

        [NotMapped]
        public List<KeyParams> KeyWords { get; set; }
    }
}
