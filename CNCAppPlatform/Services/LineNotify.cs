using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace JinToolkit.Services
{
    class LineNotify
    {
        /// <summary>
        /// Line Notify 連線 Token
        /// </summary>
        public static string connectToken = "";

        private static async Task LineNotifyFn(Dictionary<string, string> formData)
        {
            string url = "https://notify-api.line.me/api/notify";

            using (var client = new HttpClient())
            {
                // 設定 Authorization Bearer token
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", connectToken);

                var content = new FormUrlEncodedContent(formData);

                try
                {
                    // 發送 POST 請求
                    HttpResponseMessage response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // 成功響應
                        string responseBody = await response.Content.ReadAsStringAsync();
                        //MessageBox.Show($"Response: {responseBody}");                   
                    }
                    else
                    {
                        // 處理錯誤響應
                        Console.WriteLine($"【LineNotify】Error: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    // 處理請求異常
                    Console.WriteLine($"【LineNotify】Error: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// 傳送訊息至 Line Notify
        /// </summary>
        /// <param name="msg"></param>
        public static async void send2LineNotify(string msg)
        {
            var formData = new Dictionary<string, string>
                {
                    { "message", msg }
                };

            await LineNotifyFn(formData);
        }
    }

    
}
