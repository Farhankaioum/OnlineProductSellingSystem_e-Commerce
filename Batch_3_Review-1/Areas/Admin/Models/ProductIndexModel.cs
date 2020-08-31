using Batch_3_Review_1.Models;
using Etsy.T_Shirt_Store.Data;
using Etsy.T_Shirt_Store.Framework;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Batch_3_Review_1.Areas.Admin.Models
{
    public class ProductIndexModel : ProductBaseModel
    {
        private readonly IProductService _productService;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public bool Available { get; set; }

        public ProductIndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public ProductIndexModel(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _productService = new ProductServiceAdoDotNet(connectionString);
        }

        internal object GetProducts(DataTablesAjaxRequestModel tableModel)
        {
            var data = _productService.GetProducts(
                 tableModel.PageIndex,
                 tableModel.PageSize,
                 tableModel.SearchText,
                 tableModel.GetSortText(new string[] {"Name", "Category", "Price", "Color", "Available", "Id" })
                );

            return new {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name,
                            record.Category,
                            record.Price.ToString(),
                            record.Color,
                            record.Available.ToString(),
                            record.Id.ToString()
                        }).ToArray()
            };
        }
    }
}
