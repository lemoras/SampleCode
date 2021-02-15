using System.Threading.Tasks;
using Company.Api.Controllers.Base;
using Company.Domain.Request;
using Company.Domain.Service.Define;
using Microsoft.AspNetCore.Mvc;

namespace Company.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class BranchController : BaseController
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpPost("createBranch")]
        public async Task<IActionResult> CreateBranchAsync([FromBody]CreateBranchRequest request)
        {
            return Ok(await _branchService.CreateBranchAsync(request));
        }

        [HttpGet("getAllBranch")]
        public async Task<IActionResult> GetAllBranchAsync([FromQuery]int companyId)
        {
            return Ok(await _branchService.GetAllBranchAysnc(companyId));
        }

        [HttpGet("getBranchById")]
        public async Task<IActionResult> GetBranchByIdAysnc([FromQuery]int branchId)
        {
            return Ok(await _branchService.GetBranchByIdAysnc(branchId));
        }

        [HttpGet("getBranchByIdWithWorkHours")]
        public async Task<IActionResult> GetBranchByIdWithWorkHoursAysnc([FromQuery]int branchId)
        {
            return Ok(await _branchService.GetBranchByIdWithHoursAysnc(branchId));
        }
    }
}