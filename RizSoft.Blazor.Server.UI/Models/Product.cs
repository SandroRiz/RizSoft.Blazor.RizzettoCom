﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace RizSoft.Blazor.Models
{
    public partial class Product
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public long CategoryId { get; set; }
        public decimal Price { get; set; }

        public virtual Category Category { get; set; }
    }
}