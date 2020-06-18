using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KiaserMid
{
    public static class ClientHelper
    {
        /// <summary>
        /// 异步-Get
        /// </summary>
        /// <param name="url"></param>
        public static async void GetAsync(string url)
        {
            HttpClient httpClient = new HttpClient();

            //频繁请求可能会阻塞
            //var response = httpClient.GetAsync(url).Result;
            //string strData = response.Content.ReadAsStringAsync().Result.ToString();

            // 创建一个异步GET请求，当请求返回时继续处理（Continue-With模式）
            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string resultStr = await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 异步-Post 
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="userId"></param>
        public static string PostAsync(string host, string url, string devId,string currDate,string leaveDate,string phone,string code)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                // 设置请求头信息
                httpClient.DefaultRequestHeaders.Add("Host", host);
                //httpClient.DefaultRequestHeaders.Add("Method", "Post");
                //httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");   // HTTP KeepAlive设为false，防止HTTP连接保持
                //httpClient.DefaultRequestHeaders.Add("UserAgent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.95 Safari/537.11");

                // 构造POST参数
                HttpContent postContent = new FormUrlEncodedContent(new Dictionary<string, string>()
                {
                    { "c",devId},
                    { "d",currDate},
                    { "d1",leaveDate},
                    { "sj",phone},
                    { "code",code}
                 });

               return httpClient.PostAsync(url, postContent).Result.ToString();

                #region 异步处理--注释

                //await httpClient.PostAsync(url, postContent).ContinueWith(t =>
                // {
                //    HttpResponseMessage res = t.Result;
                //    // 确认响应成功，否则抛出异常
                //    res.EnsureSuccessStatusCode();
                //    //频繁请求可能会阻塞
                //    //res.Content.ReadAsStringAsync().Result.ToString();
                //    // 异步读取响应为字符串
                //    res.Content.ReadAsStringAsync().ContinueWith(ta =>
                //    {
                //        //Console.WriteLine("响应网页内容：" + ta.Result);
                //        //Console.WriteLine("响应后数据");
                //    });
                //}

	             #endregion

            }
            catch (Exception ex)
            {
                LogHelper.WriteError(ex.Message + "--" + ex.StackTrace);
                return null;
            }
        }
    }
}
