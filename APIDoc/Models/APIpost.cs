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
        public async Task<bool> VMAdd(string token)
        {
            HttpClient client = new HttpClient();

            //リクエスト先のURL
            string url = "https://compute.tyo1.conoha.io/v2/3084bba7e8c2401883ec92ad536b203a/servers";

            var json = "{\"server\":{ \"imageRef\" : \"5a026e16-1444-47e4-a3d1-300424c701a7\", \"flavorRef\" : \"d92b02ce-9a4f-4544-8d7f-ae8380bc08e7\" }}";

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            content.Headers.ContentType= new MediaTypeHeaderValue("application/json");
            content.Headers.Add("X-Auth-Token", "dda1af67d3824ceb9e70b133023bdf15");

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

            //

            //レスポンスを整形

            //文字列から必要な部分だけ抜き取る
        }
    }
}