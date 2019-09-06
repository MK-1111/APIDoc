using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace APIDoc.Models
{
    [JsonObject]
    public class VMJson
    {
        public Server server = new Server();
    }

    [JsonObject("server")]
    public class Server
    {
        [JsonProperty("imageRef")]
        public string ImageRef { get; set; }
        [JsonProperty("flavorRef")]
        public string FlavorRef { get; set; }
        [JsonProperty("adminPass")]
        public string AdminPass { get; set; }

        public Metadata metadata = new Metadata();
        
    }

    [JsonObject("metadata")]
    public class Metadata
    {
        [JsonProperty("instance_name_tag")]
        public string Name_tag;
    }
}