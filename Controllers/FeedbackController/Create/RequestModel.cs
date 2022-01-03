using System;

namespace Cheapy_API.Controllers.FeedbackController.Create
{
    public class RequestModel
    {
        public string Message { get; set; }
        public string Title { get; set; }
        public Boolean Recomendation { get; set; }
        public int Stars { get; set; }
    }
}