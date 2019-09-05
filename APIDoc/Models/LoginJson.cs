using Newtonsoft.Json
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIDoc.Models
{
    [JsonObject]
    public class LoginJson
    {
        public Auth AuthP { get; set; }

        [JsonProperty("tenantId")]
        public string TenantId { get; set; }
    }

    [JsonObject("auth")]
    public class Auth
    {
        public PasswordCre PassC { get; set; }
    }

    [JsonObject("passwordCredentials")]
    public class PasswordCre
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }
    }

}