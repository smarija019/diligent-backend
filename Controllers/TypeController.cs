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
    public class TypeController : ControllerBase
    {
        readonly TypeModel context;

        public TypeController(TypeModel context)
        {
            this.context = context;
        }

        [Authorize(Roles = "admin")]
        [Route("api/type")]
        [HttpGet]
        public IEnumerable<CustomType> GetTypes()
        {

            return this.context.GetTypes().ToArray();
        }

        [Authorize(Roles = "admin")]
        [Route("api/type")]
        [HttpPost]
        public void PostType([FromBody]CustomType type)
        {
            this.context.AddType(type);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("api/type/{id}")]
        public void DeleteType(int id)
        {
            this.context.RemoveType(id);

        }

        [Authorize(Roles = "admin")]
        [HttpPut("api/type/{id}")]
        public void PutType(int id, CustomType type)
        {
            this.context.UpdateType(id, type);

        }
    }
}