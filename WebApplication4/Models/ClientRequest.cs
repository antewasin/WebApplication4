using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class ClientRequest
    {
        public Guid Id { get; set; }
        public string Request { get; set; }

        public ClientRequest() { }
    }
}