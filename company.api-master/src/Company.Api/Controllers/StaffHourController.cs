using System.Threading.Tasks;
using Company.Api.Controllers.Base;
using Company.Domain.Request;
using Company.Domain.Service.Define;
using Microsoft.AspNetCore.Mvc;

namespace Company.Api.Controllers
{
    [Route("api/v1/[controller]")]
    public class StaffHourController : BaseController
    {
        private readonly IStaffHourService _staffHourService;

        public StaffHourController(IStaffHourService staffHourService)
        {
            _staffHourService = staffHourService;
        }

        [HttpPost("createStaffHour")]
        public async Task<IActionResult> CreateStaffHourAsync([FromBody]CreateStaffHourRequest request)
        {
            return Ok(await _staffHourService.CreateStaffHourAsync(request));
        }

        [HttpPut("updateStaffHour")]
        public async Task<IActionResult> UpdateStaffHourAsync([FromBody]UpdateStaffHourRequest request)
        {
            return Ok(await _staffHourService.UpdateStaffHourAsync(request));
        }
    }
}