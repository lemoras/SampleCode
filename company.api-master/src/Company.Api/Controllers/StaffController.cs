using System.Threading.Tasks;
using Company.Api.Controllers.Base;
using Company.Domain.Request;
using Company.Domain.Service.Define;
using Microsoft.AspNetCore.Mvc;

namespace Company.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class StaffController : BaseController
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpPost("createStaff")]
        public async Task<IActionResult> CreateStaffAsync([FromBody]CreateStaffRequest request)
        {
            return Ok(await _staffService.CreateStaffAsync(request));
        }

        [HttpPut("updateStaff")]
        public async Task<IActionResult> UpdateStaffAsync([FromBody]UpdateStaffRequest request)
        {
            return Ok(await _staffService.UpdateStaffAsync(request));
        }

        [HttpGet("getStaffsByBranchId")]
        public async Task<IActionResult> GetStaffsByBranchIdAsync([FromQuery] int branchId)
        {
            return Ok(await _staffService.GetStaffByBranchIdAsync(branchId));
        }


    }
}