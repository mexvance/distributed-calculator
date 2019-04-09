using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorker.Models
{
    public class ErrorCheck
    {
        public Guid JobId { get; set; }
        public string ErrorMessage { get; set; }
    }
}
