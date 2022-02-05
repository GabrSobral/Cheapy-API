using System;

namespace Cheapy_API.Controllers.FavoriteController.MyFavorites
{
    public class ResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public float Discount { get; set; }
        public string Thumb { get; set; }
        public double AverageRating { get; set; }
    }
}