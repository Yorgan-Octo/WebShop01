﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_V3.Entity
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
