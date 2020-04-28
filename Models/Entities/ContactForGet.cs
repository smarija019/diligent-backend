using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace diligent_backend.Models.Entities
{
    public class ContactForGet
    {
        public int Id { get; set; }

        public string name { get; set; }
        public string tel1 { get; set; }
        public string tel2 { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public int flag { get; set; }
        public string profession { get; set; }
        public string company { get; set; }
    }
}
