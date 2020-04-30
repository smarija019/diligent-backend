using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using diligent_backend.Helpers;
using diligent_backend.Models;
using diligent_backend.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace diligent_backend.Controllers
{
 
    [ApiController]
    public class LawyerController : ControllerBase
    {
        readonly LawyerModel context;
        public LawyerController(LawyerModel context)
        {
            this.context = context;
        }

        [Authorize(Roles = "admin,customer")]
        [HttpGet("api/lawyer")]
        public IEnumerable<LawyerForGet> Get()
        {
            return this.context.GetLawyers();
        }

        [Authorize(Roles = "admin,customer")]
        [HttpGet("api/lawyer/{id}")]
        public IEnumerable<LawyerForGet> Get(string id)
        {
            return this.context.GetMyLawyers(id);
        }

        [Authorize(Roles = "admin,customer")]
        [HttpPost("api/lawyer")]
        public void Post([FromBody]Lawyer lawyer)
        {
            this.context.AddLawyer(lawyer);
        }

        [Authorize(Roles = "admin,customer")]
        [HttpPut("api/lawyer/{id}")]
        public void Put(int id, [FromBody] Lawyer lawyer)
        {
            this.context.UpdateLawyer(id, lawyer);
        }

        [Authorize(Roles = "admin,customer")]
        [HttpDelete("api/lawyer/{id}")]
        public void Delete(int id)
        {
            this.context.RemoveLawyer(id);
        }
    }
}
