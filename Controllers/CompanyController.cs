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
    public class CompanyController : ControllerBase
    {
        readonly CompanyModel context;

        public CompanyController(CompanyModel context)
        {
            this.context = context;
        }

        [Authorize(Roles = "admin, customer")]
        [Route("api/company")]
        [HttpGet]
        public IEnumerable<Company> GetCompanies()
        {
            return this.context.GetCompanies().ToArray();
        }

        [Authorize(Roles = "admin")]
        [Route("api/company")]
        [HttpPost]
        public void PostCompany([FromBody]Company company)
        {
            this.context.AddCompany(company);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("api/company/{id}")]
        public void DeleteCompany(int id)
        {
            this.context.RemoveCompany(id);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("api/company/{id}")]
        public void PutLocation(int id, Company company)
        {
            this.context.UpdateCompany(id, company);
        }
    }
}