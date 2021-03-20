using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json.Serialization;

namespace aspdotnetCORETest.DataContracts
{
    public class Error
    {
        [JsonProperty("status")]
        public HttpStatusCode Status { get; set; } 

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
