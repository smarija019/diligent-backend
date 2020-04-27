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
    public class LocationController : ControllerBase
    {

        readonly LocationModel context;

        public LocationController(LocationModel context)
        {
            this.context = context;
        }

        [Authorize(Roles = "admin")]
        [Route("api/location")]
        [HttpGet]
        public IEnumerable<Location> GetLocations()
        {
            return this.context.GetLocations().ToArray();
        }

        [Authorize(Roles = "admin")]
        [Route("api/location")]
        [HttpPost]
        public void PostLocation([FromBody] Location location)
        {
            this.context.AddLocation(location);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("api/location/{id}")]
        public void DeleteLocation(int id)
        {
            this.context.RemoveLocation(id);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("api/location/{id}")]
        public void PutLocation(int id, Location location)
        {
            this.context.UpdateLocation(id, location);
        }

    }
}
