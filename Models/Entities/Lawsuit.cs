using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace diligent_backend.Models.Entities
{
    public class Lawsuit
    {
        public int Id { get; set; }

        public DateTime date { get; set; }
        public int location { get; set; }
        public int judge { get; set; }
        public string inst_type { get; set; }
        public string procedure_id { get; set; }
        public int courtroom { get; set; }
        public int plaintiff { get; set; }
        public int defendant { get; set; }
        public string note{ get; set; }

        public int procedure_type { get; set; }
    }
}
