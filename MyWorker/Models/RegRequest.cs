using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorker.Models
{
    public class RegRequest
    {
        public const string YourLocalIP = "144.17.24.145";
        public Guid WorkerId { get; set; } = Guid.NewGuid();
        public string TeamName { get; set; } = "{your name here}";
        public string CreateJobEndpoint { get; set; } = $"http://localhost:5000/reg";
        public string ErrorCheckEndpoint { get; set; } = $"http://localhost:5000/ErrorCheck";
    }
}
