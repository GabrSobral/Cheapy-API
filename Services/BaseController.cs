using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Cheapy_API.Services
{
    public class BaseController : ControllerBase
    {
        protected Guid GetUserId()
        {
            return Guid.Parse(User.Claims.First(i => i.Type == "Id").Value);
        }
    }
}