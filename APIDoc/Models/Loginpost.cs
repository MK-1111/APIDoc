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
        public async Task<string> GetToken(string Username,string Password,string Tenant_id)
        {
            HttpClient client = new HttpClient();

            //リクエスト先のURL
            string url = "https://identity.tyo1.conoha.io/v2.0/tokens";

            var data = new LoginJson();
            data.AuthP.PassC.Username = Username;
            data.AuthP.PassC.Password = Password;
            data.TenantId = Tenant_id;


            string json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //APIリクエスト
            var response = await client.PostAsync(url, content);
            Debug.WriteLine(response);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return "true";
            }

            string responseForJson = ConvertResponse(response);
            string news = GetBetweenStrings("\"id\": \"", "\"", responseForJson);
            return news;

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
}