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
    public class AdminController : ControllerBase
    {

        #region GET, POST, DELETE requests for Location entity

        [Route("api/admin/getlocations")]
        [HttpGet]
        public IEnumerable<Location> GetLocations()
        {
            AdminModel context = HttpContext.RequestServices.GetService(typeof(AdminModel)) as AdminModel;

            return context.GetLocations().ToArray();
        }

        [Route("api/admin/postlocations")]
        [HttpPost]
        public void PostLocation([FromBody] Location location)
        {
            AdminModel context = HttpContext.RequestServices.GetService(typeof(AdminModel)) as AdminModel;

            context.AddLocation(location);
        }

        [HttpDelete("api/admin/deletelocation/{id}")]
        public void DeleteLocation(int id)
        {
            AdminModel context = HttpContext.RequestServices.GetService(typeof(AdminModel)) as AdminModel;

            context.RemoveLocation(id);

        }

        #endregion
        //// PUT: api/Admin/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        #region GET, POST, DELETE requests for CustomType entity

        [Route("api/admin/gettypes")]
        [HttpGet]
        public IEnumerable<CustomType> GetTypes()
        {
            AdminModel context = HttpContext.RequestServices.GetService(typeof(AdminModel)) as AdminModel;

            return context.GetTypes().ToArray();
        }

        [Route("api/admin/posttype")]
        [HttpPost]
        public void PostType([FromBody]CustomType type)
        {
            AdminModel context = HttpContext.RequestServices.GetService(typeof(AdminModel)) as AdminModel;

            context.AddType(type);
        }

        [HttpDelete("api/admin/deletetype/{id}")]
        public void DeleteType(int id)
        {
            AdminModel context = HttpContext.RequestServices.GetService(typeof(AdminModel)) as AdminModel;

            context.RemoveType(id);

        }

        #endregion

        #region GET, POST, DELETE requests for Contact entity

        [Route("api/admin/getcontacts")]
        [HttpGet]
        public IEnumerable<Contact> GetContacts()
        {
            AdminModel context = HttpContext.RequestServices.GetService(typeof(AdminModel)) as AdminModel;

            return context.GetContacts().ToArray();
        }

        [Route("api/admin/postcontact")]
        [HttpPost]
        public void PostContact([FromBody]Contact contact)
        {
            AdminModel context = HttpContext.RequestServices.GetService(typeof(AdminModel)) as AdminModel;

            context.AddContact(contact);
        }

        [HttpDelete("api/admin/deletecontact/{id}")]
        public void DeleteContact(int id)
        {
            AdminModel context = HttpContext.RequestServices.GetService(typeof(AdminModel)) as AdminModel;

            context.RemoveContact(id);

        }

        #endregion


        #region GET, POST, DELETE requests for Company entity

        [Route("api/admin/getcompanies")]
        [HttpGet]
        public IEnumerable<Company> GetCompanies()
        {
            AdminModel context = HttpContext.RequestServices.GetService(typeof(AdminModel)) as AdminModel;

            return context.GetCompanies().ToArray();
        }

        [Route("api/admin/postcompany")]
        [HttpPost]
        public void PostCompany([FromBody]Company company)
        {
            AdminModel context = HttpContext.RequestServices.GetService(typeof(AdminModel)) as AdminModel;

            context.AddCompany(company);
        }

        [HttpDelete("api/admin/deletecompany/{id}")]
        public void DeleteCompany(int id)
        {
            AdminModel context = HttpContext.RequestServices.GetService(typeof(AdminModel)) as AdminModel;

            context.RemoveCompany(id);
        }

        #endregion


    }
}
