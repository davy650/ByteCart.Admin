using System;
using System.Collections.Generic;
using ByteCart.Admin.Domain.Common;

namespace ByteCart.Admin.Domain.Entities.Products
{
    public class Category : Auditable
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