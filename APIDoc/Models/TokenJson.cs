using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace APIDoc.Models
{
    [JsonObject]
    public class TokenJson
    {
        public access Access { get; set; } = new access();
    }


    [JsonObject("access")]
    public class access
    {
        public token Token { get; set; } = new token();
        [JsonProperty("serviceCatalog")]
        public List<Point> Catarog { get; set; }
    }

    [JsonObject("token")]
    public class token
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Point
    {
        [JsonProperty("endpoints")]
        public List<URL> Endpoints { get; set; }
    }

    [JsonObject]
    public class URL
    {
        [JsonProperty("publicURL")]
        public string PublicURL { get; set; }
    }
}