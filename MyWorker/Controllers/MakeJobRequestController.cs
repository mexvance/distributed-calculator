using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWorker.Models;
using Newtonsoft.Json;

namespace MyWorker.Controllers
{
    public class MakeJobRequestController : Controller
    {
        private readonly ILogger<MakeJobRequestController> _context;

        public MakeJobRequestController(ILogger<MakeJobRequestController> context)
        {
            _context = context;
        }

        [HttpPost]
        public WorkerResult Index([FromBody] MakeJobRequest makeJobRequest)
        {
            Console.WriteLine(makeJobRequest.Calculation);
            _context.LogDebug($"PROBLEM:  {JsonConvert.SerializeObject(makeJobRequest)}");
            decimal result = 0;
            var parts = makeJobRequest.Calculation.Split(' ');
            var mathString = makeJobRequest.Calculation.Replace("CALCULATE: ", "");
            decimal.TryParse(parts[1], out result);
            decimal value;
            /*if (mathString.Contains("ln"))
            {
                var mathStringArray = mathString.Split(' ');
            }*/
            if (mathString.Contains('^'))
            {
                var mathStringArray = mathString.Split('^');
                var value1 = Convert.ToDecimal(new DataTable().Compute(mathStringArray[0], null).ToString());
                var value2 = Convert.ToDecimal(new DataTable().Compute(mathStringArray[1], null).ToString());
                value = (decimal)Math.Pow((double)value1, (double)value2);

            }
            else
            {
                value = Convert.ToDecimal(new DataTable().Compute(mathString, null).ToString());
            }
            /*switch (parts[2])
            {
                case "+":
                    result = decimal.Parse(parts[1]) + decimal.Parse(parts[3]);
                    break;
                case "-":
                    result = decimal.Parse(parts[1]) - decimal.Parse(parts[3]);
                    break;
                case "/":
                    result = decimal.Parse(parts[1]) / decimal.Parse(parts[3]);
                    break;
                case "*":
                    result = decimal.Parse(parts[1]) * decimal.Parse(parts[3]);
                    break;
            }*/
            Console.WriteLine("Answer I got: " + $"{value:0.###}");

            var workerResult = new WorkerResult
            {
                Id = makeJobRequest.JobId,
                Result = $"{value:0.###}"
            };
            //_context.LogDebug($"SOLUTION: {JsonConvert.SerializeObject(workerResult)}");
            return workerResult;
        }
    }
}