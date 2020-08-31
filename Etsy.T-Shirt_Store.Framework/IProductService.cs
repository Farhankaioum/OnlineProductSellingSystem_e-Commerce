using System;
using System.Collections.Generic;
using System.Text;

namespace Etsy.T_Shirt_Store.Framework
{
    public interface IProductService : IDisposable
    {
        (IList<Product> records, int total, int totalDisplay) GetProducts
            (int pageIndex, int pageSize,
            string searchText, string sortText);
    }
}
