using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;


namespace CoreBB.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();
            ViewBag.StatusCode = HttpContext.Response.StatusCode;
            ViewBag.Message = exception.Error.Message;
            ViewBag.StackTrace = exception.Error.StackTrace;

            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}