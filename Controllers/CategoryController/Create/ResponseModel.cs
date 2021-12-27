using System;
using Cheapy_API.Models;

namespace Cheapy_API.Controllers.CategoryController.Create
{
    public class ResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ResponseModel(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
        }
    }
}