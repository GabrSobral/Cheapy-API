using System;
using System.ComponentModel.DataAnnotations;

namespace Cheapy_API.Controllers.RefreshTokenController.UpdateToken
{
    public class RequestModel
    {
        [Required] public Guid UserId { get; set; }
    }
}