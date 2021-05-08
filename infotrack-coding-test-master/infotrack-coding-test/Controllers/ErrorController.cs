using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using infotrack_coding_test.Models;
using infotrack_coding_test.services.interfaces;

namespace infotrack_coding_test.Controllers
{
    public class ErrorController : Controller
    {

        [HttpGet]
        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}