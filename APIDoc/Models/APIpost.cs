using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace APIDoc.Models
{
    public class APIpost
    {
        public async Task<bool> VMAdd(string token,string urls,string name,string pass)
        {
            HttpClient client = new HttpClient();

            //リクエスト先のURL
            string url = urls+ "/servers";

            VMJson data = new VMJson();
            data.server.ImageRef="5a026e16-1444-47e4-a3d1-300424c701a7";
            data.server.FlavorRef = "d92b02ce-9a4f-4544-8d7f-ae8380bc08e7";
            data.server.metadata.Name_tag = name;
            data.server.AdminPass = pass;
            string json = JsonConvert.SerializeObject(data);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            content.Headers.ContentType= new MediaTypeHeaderValue("application/json");
            content.Headers.Add("X-Auth-Token", token);
            Debug.WriteLine(url);
            Debug.WriteLine(token);

            //APIリクエスト
            var response=await client.PostAsync(url,content);
            Debug.WriteLine(response);

            if (response.StatusCode == HttpStatusCode.Accepted)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}