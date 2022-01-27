using System;
using System.ComponentModel.DataAnnotations;

namespace Cheapy_API.Controllers.FavoriteController.Mark
{
    public class RequestModel
    {
        [Required] public Boolean IsFavorited { get; set; }
    }
}