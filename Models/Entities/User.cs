using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace diligent_backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public int role { get; set; }
        public string username { get; set; }
        public string password { get; set; }


    }
}
