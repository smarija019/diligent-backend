using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace diligent_backend.Models.Entities
{
    public class Lawyer
    {
        public int Id { get; set; }

        public string user_id { get; set; }
        public int lawsuit_id { get; set; }
    }
}
