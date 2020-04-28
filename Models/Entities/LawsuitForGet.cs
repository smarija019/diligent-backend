using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace diligent_backend.Models.Entities
{
    public class LawsuitForGet
    {
        public int Id { get; set; }

        public string date { get; set; }
        public string time { get; set; }
        public string location { get; set; }
        public string judge { get; set; }
        public string inst_type { get; set; }
        public string procedure_id { get; set; }
        public int courtroom { get; set; }
        public string plaintiff { get; set; }
        public string defendant { get; set; }
        public string note { get; set; }

        public string procedure_type { get; set; }
    }
}
