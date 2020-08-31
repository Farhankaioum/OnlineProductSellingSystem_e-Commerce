using Etsy.T_Shirt_Store.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Etsy.T_Shirt_Store.Framework
{
    public class ProductServiceAdoDotNet : IProductService
    {
        private readonly string _connectionString;

        public ProductServiceAdoDotNet()
        {

        }

        public ProductServiceAdoDotNet(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Dispose()
        {
            
        }

        public (IList<Product> records, int total, int totalDisplay) GetProducts(int pageIndex, int pageSize, string searchText, string sortText)
        {
            using var dbProvider = new SqlServerDataProvider<Product>(_connectionString);

            var products = dbProvider.GetData("SpGetAllProducts", new List<(string, object, bool)>() {
                ("PageIndex", pageIndex, false),
                ("PageSize", pageSize, false),
                ("SearchText", searchText, false),
                ("OrderBy", sortText, false),
                ("Total", 0, true),
                ("TotalDisplay", 0, true)
            });

            return (products.result, products.total, products.totalDisplay);
        }
    }
}
