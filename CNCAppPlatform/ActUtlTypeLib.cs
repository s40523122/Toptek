﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActUtlTypeLib
{
    public partial class ActUtlType
    {
        public int ActLogicalStationNumber { get; set; }

        public ActUtlType()
        {

        }
        public int ReadDeviceBlock2(string _, int __, out short aa)
        {
            aa = 1;
            return 1;
        }

        public int WriteDeviceBlock2(string _, int __, ref short aa)
        {
            return 1;
        }

        public int ReadDeviceBlock(string _, int __, out int aa)
        {
            aa = 0;
            return 1;
        }

        public int WriteDeviceBlock(string _, int __, ref int aa)
        {
            return 1;
        }

        public void Close()
        {
        }

        public int Open()
        {
            return 1;
        }

        public void SetDevice(string _, byte aa)
        {

        }

        public void SetDevice(string _, int aa)
        {

        }
    }
}
