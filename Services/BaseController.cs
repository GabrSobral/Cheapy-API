using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Cheapy_API.Services
{
    public class BaseController : ControllerBase
    {
        protected Guid GetUserEmail()
        {
            return Guid.Parse(User.Claims.First(i => i.Type == "Email").Value);
        }
    }
}