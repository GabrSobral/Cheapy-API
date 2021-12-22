using Microsoft.AspNetCore.Mvc;
using System;

namespace Cheapy_API.Services
{
    public class ErrorCatcher : ControllerBase
    {
        private string _message { get; set; }
        private int    _status  { get; set; }

        public ErrorCatcher(Exception error) 
        {
            var errorMessage = error.Message.Split(" status:");
            _message = errorMessage[0];
            _status = errorMessage.Length == 2 ? int.Parse(errorMessage[1]) : 500;
        }

        public ObjectResult Return()
        {
            return StatusCode(_status, new { message = _message });
        }
    }
}