using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Diagnostics;

namespace APIDoc.Models
{
    public class Loginpost
    {
        public async Task<string> GetToken(string Username,string Password,string Tenant_id,string endpoint,int s)
        {
            HttpClient client = new HttpClient();

            //リクエスト先のURL
            string url = endpoint+"/tokens";

            LoginJson data = new LoginJson();
            data.auth.passwordCredentials.username = Username;
            data.auth.passwordCredentials.password = Password;
            data.auth.tenantId = Tenant_id;


            string json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //APIリクエスト
            try
            {
                var response = await client.PostAsync(url, content);


                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return "none";
                }

                string responseForJson = ConvertResponse(response);
                TokenJson tokenIn = JsonConvert.DeserializeObject<TokenJson>(responseForJson);
                string token = tokenIn.Access.Token.Id;
                string VMurl = tokenIn.Access.Catarog[1].Endpoints[0].PublicURL;
                string Mailurl = tokenIn.Access.Catarog[6].Endpoints[0].PublicURL;
                string DNSurl = tokenIn.Access.Catarog[7].Endpoints[0].PublicURL;
                if (s == 1)
                {
                    return token;
                }
                else if (s == 2)
                {
                    return VMurl;
                }
                else if (s == 3)
                {
                    return Mailurl;
                }
                else if (s == 4)
                {
                    return DNSurl;
                }
                else
                {
                    return "none";
                }
            }
            catch (InvalidOperationException)
            {
                return "none";
            }

        }

        public void PostSample()
        {
            //URI


            //HttpClientをインスタンス化


            //リクエストメソッド、URIを指定


            //ヘッダーにトークン情報を追加


            //ボディに代入するリクエストをJson形式で宣言&代入


            //StringContentを使いエンコード形式の指定,Content-Typeの指定


            //リクエスト

        }

        /// <summary>
        /// 指定した文字と文字の間を切り取るメソッド
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="orgStr"></param>
        /// <returns></returns>
        private string GetBetweenStrings(string str1, string str2, string orgStr)
        {
            int orgLen = orgStr.Length; //原文の文字列の長さ
            int str1Len = str1.Length; //str1の長さ

            int str1Num = orgStr.IndexOf(str1); //str1が原文のどの位置にあるか

            string s = ""; //返す文字列

            //例外処理
            try
            {
                s = orgStr.Remove(0, str1Num + str1Len); //原文の初めからstr1のある位置まで削除
                int str2Num = s.IndexOf(str2); //str2がsのどの位置にあるか
                s = s.Remove(str2Num); //sのstr2のある位置から最後まで削除
            }
            catch (Exception)
            {
                return orgStr; //原文を返す
            }

            return s; //戻り値
        }

        /// <summary>
        /// APIのレスポンスを整形してくれるメソッド
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private string ConvertResponse(HttpResponseMessage response)
        {
            var responseContents = response.Content.ReadAsStringAsync().Result;
            string responseForJson = JsonConvert.DeserializeObject(responseContents).ToString();
            return responseForJson;
        }
    }
}