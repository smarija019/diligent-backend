using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace diligent_backend.Models.Entities
{
    public class Company
    {
        public int Id { get; set; }

        public string name { get; set; }
        public string address { get; set; }
    }
}
