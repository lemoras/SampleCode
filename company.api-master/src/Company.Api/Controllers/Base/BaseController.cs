using Company.Api.Filter;
using Microsoft.AspNetCore.Mvc;

namespace Company.Api.Controllers.Base
{
    [ServiceFilter(typeof(AuthorizationAttribute))]
    public class BaseController:Controller
    {

    }
}
