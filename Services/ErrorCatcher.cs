using Microsoft.AspNetCore.Mvc;
using System;

namespace Cheapy_API.Services
{
    public class ErrorCatcher
    {
        private string _message { get; set; }
        private int _status { get; set; }

        public ErrorCatcher(Exception error) 
        {
            _message = error.Message.Split("status:")[0];
            _status = int.Parse(error.Message.Split("status:")[1]);

            Console.WriteLine(_status);

            if(_status == 0)
                _status = 500;
        }

        public StatusCodeResult Return()
        {
            return new StatusCodeResult((_status));
        }
    }
}