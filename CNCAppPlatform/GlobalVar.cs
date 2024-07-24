using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCAppPlatform
{
    class DevState
    {
        public static int RBA00001 = 0;
        public static int VMC00001 = 0;
        public static int AGV00001 = 0;
    }

    class sqlLink
    {
        public static string server = "";
        public static string db = "";
        public static string user = "";
        public static string pw = "";
        public static bool state = false;
    }

    class GlobalVar
    {
        public static bool loadData = false;
    }

    class globalVar
    {
        public static bool bStreamStart = false;
        public static string activeLocation = "";
        public static string activeEquipment = "";
        public static int opMode = 0;
        public static string[] stockinInfo = new string[12];
        public static string today = "";

        public static string startDate = "";
        public static string endDate = "";
        public static string endDateReal = "";
    }

}
