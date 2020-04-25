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
    public class CompanyController : ControllerBase
    {
        readonly CompanyModel context;

        public CompanyController(CompanyModel context)
        {
            this.context = context;
        }
        [Route("api/company")]
        [HttpGet]
        public IEnumerable<Company> GetCompanies()
        {
            return this.context.GetCompanies().ToArray();
        }

        [Route("api/company")]
        [HttpPost]
        public void PostCompany([FromBody]Company company)
        {
            this.context.AddCompany(company);
        }

        [HttpDelete("api/company/{id}")]
        public void DeleteCompany(int id)
        {
            this.context.RemoveCompany(id);
        }
    }
}