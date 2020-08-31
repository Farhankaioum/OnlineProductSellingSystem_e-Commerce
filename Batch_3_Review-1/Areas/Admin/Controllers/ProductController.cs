using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Batch_3_Review_1.Areas.Admin.Models;
using Batch_3_Review_1.Models;
using Etsy.T_Shirt_Store.Framework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Batch_3_Review_1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IConfiguration _configuration;

        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var model = new ProductIndexModel(_configuration);
            return View(model);
        }

        public IActionResult GetProducts()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = new ProductIndexModel(_configuration);
            var data = model.GetProducts(tableModel);
            return Json(data);
        }
    }
}
