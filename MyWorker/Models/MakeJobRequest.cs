using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorker.Models
{
    public class MakeJobRequest
    {
        public Guid JobId { get; set; }
        public string Calculation { get; set; }
    }
}
