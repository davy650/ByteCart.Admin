using System;
using System.Collections.Generic;

namespace ByteCart.Admin.Domain.Entities.Products
{
    internal class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        // cater for nested categories
        public Guid? ParentCategoryId { get; set; }
        public Category? ParentCategory { get; set; }
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();
        
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
    }
}