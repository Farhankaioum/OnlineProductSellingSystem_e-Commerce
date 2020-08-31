using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Batch_3_Review_1.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Batch_3_Review_1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var model = new DashboardModel();
            return View(model);
        }
    }
}
