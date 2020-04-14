using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using diligent_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace diligent_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        // GET: api/Registration
        [HttpGet]
        public IEnumerable<User> Get()
        {
            RegistrationModel context = HttpContext.RequestServices.GetService(typeof(RegistrationModel)) as RegistrationModel;

            List<User> list = new List<User>();

            for (int i = 0; i < 2; i++)
            {
                list.Add(context.GetTest()[i]);
            }
            return list.ToArray();
        }

        //// GET: api/Registration/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Registration
        [HttpPost]
        public void Post([FromBody] User user)
        {
            RegistrationModel context = HttpContext.RequestServices.GetService(typeof(RegistrationModel)) as RegistrationModel;

            context.AddUser(user);

        }

        //// PUT: api/Registration/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
