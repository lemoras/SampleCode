using System.Threading.Tasks;
using Member.Api.Controllers.Base;
using Member.Domain.Services;
using Member.Domain.Request;
using Microsoft.AspNetCore.Mvc;

namespace Member.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserRoleController : BaseController
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpPost("createUserRole")]
        public async Task<IActionResult> CreateBranchAsync([FromBody]CreateUserRoleRequest request)
        {
            return Ok(await _userRoleService.CreateUserRolehAsync(request));
        }

        [HttpGet("getUserRoleByUserId")]
        public async Task<IActionResult> GetBranchByIdAysnc([FromQuery]int userId)
        {
            return Ok(await _userRoleService.GetUserRoleByUserIdAysnc(userId));
        }

        [HttpGet("getUserRole")]
        public async Task<IActionResult> GetUserRoleAysnc()
        {
            return Ok(await _userRoleService.GetUserRoleAysnc());
        }
    }
}