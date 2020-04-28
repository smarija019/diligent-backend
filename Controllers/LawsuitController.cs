using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using diligent_backend.Models;
using diligent_backend.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace diligent_backend.Controllers
{
   
    [ApiController]
    public class LawsuitController : ControllerBase
    {
        readonly LawsuitModel context;
        public LawsuitController(LawsuitModel context)
        {
            this.context = context;
        }

        [Authorize(Roles = "admin,customer")]
        [HttpGet("api/lawsuit")]
        public IEnumerable<LawsuitForGet> Get()
        {
            return this.context.GetLawsuits();
        }

        [Authorize(Roles = "admin,customer")]
        [HttpPost("api/lawsuit")]
        public void Post([FromBody]Lawsuit lawsuit)
        {
            this.context.AddLawsuit(lawsuit);
        }

        [Authorize(Roles = "admin,customer")]
        [HttpPut("api/lawsuit/{id}")]
        public void Put(int id, [FromBody] Lawsuit lawsuit)
        {
            this.context.UpdateLawsuit(id, lawsuit);
        }

        [Authorize(Roles = "admin,customer")]
        [HttpDelete("api/lawsuit/{id}")]
        public void Delete(int id)
        {
            this.context.RemoveLawsuit(id);
        }
    }
}
