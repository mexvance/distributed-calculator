using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWorker.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorker.Controllers
{
    public class ErrorCheckController : Controller
    {
        private ILogger<ErrorCheckController> _context;

        public ErrorCheckController(ILogger<ErrorCheckController> context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Index([FromBody] ErrorCheck errorCheck)
        {
            Console.WriteLine("Error Check Here " + errorCheck.ErrorMessage);
            _context.LogDebug($"Couldn't solve this problem: {JsonConvert.SerializeObject(errorCheck)}");
            return Ok();
        }
    }
}
