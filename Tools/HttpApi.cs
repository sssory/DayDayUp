using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Common
{
    public static class HttpApi
    {

        public static string logFolder = "ApiLog";
        /// <summary>
        /// 序列号 utf-8 json格式请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="body">序列化body对象</param>
        /// <returns></returns>
        public static StringContent DefaultContent<T>(T body)
        {
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            return stringContent;
        }

        /// <summary>
        /// 返回泛型结果的GET
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="islog"></param>
        /// <returns></returns>
        public static async Task<T> SendGetAsync<T>(string url, Dictionary<string, string> headers = null, bool islog = false)
        {

            string str = await SendGetAsync(url, headers, islog);

            try
            {
                return JsonConvert.DeserializeObject<T>(str);
            }
            catch (Exception)
            {
                return default;
            }
        }

        /// <summary>
        /// 返回泛型结果的POST
        /// </summary>
        /// <returns></returns>
        public static async Task<T> SendPostAsync<T>(string url, HttpContent content, Dictionary<string, string> headers = null, bool islog = false)
        {
            string str = await SendPostAsync(url, content, headers, islog);

            try
            {
                return JsonConvert.DeserializeObject<T>(str);
            }
            catch (Exception)
            {
                return default;
            }
        }

        /// <summary>
        /// GET
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="headers">head</param>
        /// <param name="islog">是否记录日志</param>
        /// <returns>json</returns>
        public static async Task<string> SendGetAsync(string url, Dictionary<string, string> headers = null, bool islog = false)
        {
            if (islog)
            {
                LogError.Write("请求：" + url, logFolder);
            }

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
            };

            // Add headers to the request
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    httpRequestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(2);
                HttpResponseMessage response = await client.SendAsync(httpRequestMessage);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                if (islog)
                {
                    if (responseBody == null) responseBody = string.Empty;
                    LogError.Write("回复：" + responseBody.Replace("\r", "").Replace("\n", ""), logFolder);
                }
                return responseBody;

            }
        }

        /// <summary>
        /// POST
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="content">body</param>
        /// <param name="headers">head</param>
        /// <param name="islog">是否记录日志</param>
        /// <returns>json</returns>
        public static async Task<string> SendPostAsync(string url, HttpContent content, Dictionary<string, string> headers = null, bool islog = false)
        {

            if (islog)
            {
                string requestJOSN = await content.ReadAsStringAsync();
                LogError.Write("请求：" + url + "\r\n" + requestJOSN, logFolder);
            }

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url),
                Content = content,
            };

            // Add headers to the request
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    httpRequestMessage.Headers.TryAddWithoutValidation(header.Key, header.Value);
                }
            }
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(2);
                HttpResponseMessage response = await client.SendAsync(httpRequestMessage);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                if (islog)
                {
                    if (responseBody == null) responseBody = string.Empty;
                    LogError.Write("回复：" + responseBody.Replace("\r", "").Replace("\n", ""), logFolder);
                }
                return responseBody;
            }
        }


        /// <summary>
        /// ping MES网段
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static bool Ping(string address)
        {
            Match matchIP = Regex.Match(address, @"\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}");

            try
            {
                if (matchIP.Success)
                {
                    var isSuccess = new Ping().Send(matchIP.Value, 200);
                    return (isSuccess.Status == IPStatus.Success);
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
