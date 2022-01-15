using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Cheapy_API.Services
{
    public class BaseController : ControllerBase
    {
        protected string GetUserEmail()
        {
            return User.Claims.First(i => i.Type == "Email").Value;
        }
    }
}