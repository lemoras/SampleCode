using Member.Api.Filter;
using Microsoft.AspNetCore.Mvc;

namespace Member.Api.Controllers.Base
{
    [ServiceFilter(typeof(AuthorizationAttribute))]
    public class BaseController : Controller
    {

    }
}
