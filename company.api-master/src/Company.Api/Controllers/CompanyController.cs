using System.Threading.Tasks;
using Company.Api.Controllers.Base;
using Company.Domain.Request;
using Company.Domain.Service.Define;
using Microsoft.AspNetCore.Mvc;

namespace Company.Api.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : BaseController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost("createCompany")]
        public async Task<IActionResult> CreateCompanyAsync([FromBody]CreateCompanyRequest request)
        {
            return Ok(await _companyService.CreateCompanyAsync(request));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody]CreateCompanyRegisterRequest request)
        {
            return Ok(await _companyService.CreateAsync(request));
        }
    }
}