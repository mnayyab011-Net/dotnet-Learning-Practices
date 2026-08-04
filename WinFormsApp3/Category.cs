using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp3
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = String.Empty;
        public virtual ObservableCollectionListSource<Product> Products { get; } = new();
    }
}
