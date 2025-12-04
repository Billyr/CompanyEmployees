using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System.Reflection.Metadata.Ecma335;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController(IServiceManager service) : ControllerBase
    {
        private readonly IServiceManager _service = service;


        [HttpGet]
        public IActionResult GetCompanies()
        {
            //throw new Exception("Exception");

            var companies = _service.CompanyService.GetAllCompanies(false);

            return Ok(companies);
        }

        [HttpGet("{id:guid}", Name = "CompanyById")]
        public IActionResult GetCompany(Guid id)
        {
            var company = _service.CompanyService.GetCompany(id, trackChanges: false);
            return Ok(company);
        }


        [HttpPost]
        public IActionResult CreateCompany([FromBody] CompanyForCreationDto company)
        {
            if (company == null)
                return BadRequest("Company object is null");

            var createdCompany = _service.CompanyService.CreateCompany(company);

            return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);

        }


    }
}
