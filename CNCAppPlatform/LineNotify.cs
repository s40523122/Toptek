using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace CNCAppPlatform.Stone
{
    class LineNotify
    {
        public string strToken { get; set; }

        public LineNotify(string token)
        {
            strToken = token;
        }

        public int pushNotify(string msg, string imgUrl)
        {
            try
            {
                #region push Line Notify
                string Url = "https://notify-api.line.me/api/notify";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "POST";
                request.KeepAlive = true;
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Set("Authorization", "Bearer " + strToken);
                string content = "";
                content += "message=\r\n" + msg;

                if (imgUrl.Length > 1)
                {
                    #region send Pic
                    content += "&imageThumbnail=" + imgUrl;
                    content += "&imageFullsize=" + imgUrl;
                    #endregion
                }

                byte[] bytes = Encoding.UTF8.GetBytes(content);
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();
                #endregion

                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
