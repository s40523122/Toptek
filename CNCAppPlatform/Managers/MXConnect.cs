using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ActUtlTypeLib;

namespace CNCAppPlatform.Managers
{
    internal class MXConnect
    {
        public static ActUtlType axActUtlType = new ActUtlType();       // PLC

        static MXConnect()
        {

        }

        public static bool Connect(int logical_station_number)
        {
            int returncode;
            try
            {
                axActUtlType.ActLogicalStationNumber = logical_station_number;
                returncode = axActUtlType.Open();
                if (returncode != 0)
                {
                    return true;

                }
                else
                {
                    MessageBox.Show("unconnect");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("unconnect");
                return false;
            }
        }

        public static void Disconnect()
        {
            axActUtlType.Close();
        }

        public static short[] Plc_Read(string start_reg, int reg_count)
        {
            short[] arraydata = new short[reg_count];

            axActUtlType.ReadDeviceBlock2(start_reg, reg_count, out arraydata[0]);
            return arraydata;
        }

        public void PlcWrite(string d, string value)
        {
            int no = 1;
            short[] arraydata;

            arraydata = new short[1] { (short)Convert.ToInt32(value) };
            axActUtlType.WriteDeviceBlock2(d, no, ref arraydata[0]);
        }
    }
}
