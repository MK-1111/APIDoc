using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIDoc.Models
{
    [JsonObject]
    public class LoginJson
    {
        public Auth auth { get; set; } = new Auth();
    }

    [JsonObject("auth")]
    public class Auth
    {
        public PasswordCre passwordCredentials { get; set; } = new PasswordCre();

        [JsonProperty("tenantId")]
        public string tenantId { get; set; }
    }

    [JsonObject("passwordCredentials")]
    public class PasswordCre
    {
        [JsonProperty("username")]
        public string username { get; set; }
        [JsonProperty("password")]
        public string password { get; set; }
    }

}