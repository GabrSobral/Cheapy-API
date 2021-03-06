using System;
using System.Collections.Generic;
using Cheapy_API.Models;

namespace Cheapy_API.Controllers.FeedbackController.ListFromProduct
{
    public class ResponseModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public int Stars { get; set; }
        public Boolean Recomendation { get; set; }
        public DateTime CreatedAt { get; set; }
        public Object User { get; set; }
    }

    public class Result 
    {
        public List<ResponseModel> Feedbacks { get; set; }
        public ResponseModel MyFeedback { get; set; }
    }
}