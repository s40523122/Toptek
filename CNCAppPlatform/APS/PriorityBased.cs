using Messages.sensor_msgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCAppPlatform.APS
{
    public class PriorityBased
    {
        private List<Machine> machines;
        private List<Job> jobs;

        public PriorityBased(List<Machine> machineList, List<Job> jobList)
        {
            machines = machineList;
            jobs = jobList;
        }

       
    }

}
