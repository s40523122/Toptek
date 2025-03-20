using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace CNCAppPlatform
{
    public class INiReader
    {
        // 寫入 INI 檔案的方法
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

        /// <summary>
        /// 將資料寫入 INI 檔案
        /// </summary>
        /// <param name="path">INI 檔案地址</param>
        /// <param name="section">資料所在之節</param>
        /// <param name="key">資料參數名稱</param>
        /// <param name="value">資料參數之值</param>
        /// <returns>(bool) 是否寫入</returns>
        /// <remarks>
        /// 若欲使用工作位置資料夾路徑，可使用下列程式碼
        /// <code>
        /// string DataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config/temp.ini");
        /// </code>
        /// </remarks>
        public static bool WriteINIFile(string path, string section, string key, string value)
        {
            try
            {
                // 寫入INI檔案
                WritePrivateProfileString(section, key, value, path);
                return true;
            }
            catch
            {
                return false;
            }

        }

        // 讀取 INI 檔案的方法
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder returnBuffer, int size, string filePath);

        /// <summary>
        /// 讀取 INI 檔案內資料之值
        /// </summary>
        /// <param name="path">INI 檔案地址</param>
        /// <param name="section">資料所在之節</param>
        /// <param name="key">資料參數名稱</param>
        /// <returns>(string) 讀取之資料內容</returns>
        /// <remarks>
        /// 若欲使用工作位置資料夾路徑，可使用下列程式碼
        /// <code>
        /// string DataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config/temp.ini");
        /// </code>
        /// </remarks>
        public static string ReadINIFile(string path, string section, string key)
        {
            const int bufferSize = 255; // 緩衝區大小
            StringBuilder buffer = new StringBuilder(bufferSize);

            GetPrivateProfileString(section, key, "", buffer, bufferSize, path);

            return buffer.ToString();
        }

        
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileSection(string lpAppName, byte[] lpszReturnBuffer, int nSize, string lpFileName);

        /// <summary>
        /// 讀取節點資料並轉換為字典
        /// </summary>
        /// <param name="path">INI 檔案地址</param>
        /// <param name="section">資料所在之節</param>
        public static Dictionary<string, string> ReadSection(string path, string section)
        {

            byte[] buffer = new byte[2048];

            GetPrivateProfileSection(section, buffer, 2048, path);
            String[] tmp = Encoding.Default.GetString(buffer).Trim('\0').Split('\0');

            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            foreach (String entry in tmp)
            {
                if (entry.Contains('='))
                {
                    string[] keyValue = entry.Split(new char[] { '=' }, 2);
                    if (keyValue.Length == 2)
                    {
                        keyValuePairs[keyValue[0]] = keyValue[1];
                    }
                }
            }

            return keyValuePairs;
        }

        [DllImport("kernel32")]
        static extern uint GetPrivateProfileSectionNames(IntPtr pszReturnBuffer, uint nSize, string lpFileName);

        /// <summary>
        /// 取得所有節點名稱
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] GetAllSectionNames(string path)
        {
            path = Path.GetFullPath(path);
            uint MAX_BUFFER = 32767;
            IntPtr pReturnedString = Marshal.AllocCoTaskMem((int)MAX_BUFFER);
            uint bytesReturned = GetPrivateProfileSectionNames(pReturnedString, MAX_BUFFER, path);
            if (bytesReturned == 0)
                return null;
            string local = Marshal.PtrToStringAnsi(pReturnedString, (int)bytesReturned).ToString();
            Marshal.FreeCoTaskMem(pReturnedString);
            //use of Substring below removes terminating null for split
            return local.Substring(0, local.Length - 1).Split('\0');
        }

    }
}
