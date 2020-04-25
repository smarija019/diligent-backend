using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using diligent_backend.Models;
using diligent_backend.Models.Entities;
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

        [Route("api/location")]
        [HttpGet]
        public IEnumerable<Location> GetLocations()
        {
            return this.context.GetLocations().ToArray();
        }
        [Route("api/location")]
        [HttpPost]
        public void PostLocation([FromBody] Location location)
        {
            this.context.AddLocation(location);
        }

        [HttpDelete("api/location/{id}")]
        public void DeleteLocation(int id)
        {
            this.context.RemoveLocation(id);

        }

    }
}
