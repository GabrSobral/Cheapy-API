using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cheapy_API.Services
{
    public class BaseController : ControllerBase
    {
        protected Guid GetUserId()
        {
            try
            {
                Guid UserId;
                Guid.TryParse(User.Claims
                    .FirstOrDefault(i => i.Type == "Id").Value, out UserId);
                return UserId; 
            }
            catch
            {
                return Guid.Empty;
            }
        }
    }
}