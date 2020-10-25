using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Response
    {
        public int Code { get; set; }
        public Coordinates Position { get; set; }
        public string Message { get; set; }
        public Response(int code, Coordinates position, string message)
        {
            Code = code;
            Position = position;
            Message = message;
        }
    }
}