using Microsoft.AspNetCore.Mvc;
using MyWorker.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorker.Controllers
{
    public class RegController : Controller
    {
        public IActionResult Index(RegRequest regRequest)
        {
            Console.WriteLine("RegisterRequest," + regRequest.WorkerId);
            var client = new RestClient("http://localhost");
            var request = new RestRequest("register", Method.POST);

            request.AddJsonBody(regRequest);

            try
            {
                var response = client.Execute(request);

                return View(new RegisterResult { Message = response.Content });
            } catch (Exception e)
            {
                return View(new RegisterResult
                {
                    Message = $"Registration failed, the exeption that was thrown was: {e.Message}"
                });
            }
        }
    }
}
