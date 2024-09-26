using Messages.sensor_msgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCAppPlatform.APS
{
    public class PriorityBased : IDispatcher
    {
        private List<Machine> Machines;
        private List<Job> Jobs;

        public PriorityBased(List<Job> jobList, List<Machine> machineList)
        {
            Machines = machineList;
            Jobs = jobList;
        }

        // 根據最小化工單延遲邏輯進行工單分配
        public void Dispatching()
        {
            // 清空機台時程表
            foreach (var machine in Machines)
            {
                machine.schedule.Clear();
            }

            // 將工單依據交期、優先級進行排序
            var sortedJobs = Jobs.OrderByDescending(j => j.priority)
                                 .ThenBy(j => j.due_date)
                                 .ToList();

            // 開始排程
            foreach (var job in sortedJobs)
            {
                foreach (var process in job.processes)
                {
                    // 選擇一個最早能夠開始該製程的機台
                    Machine bestMachine = null;
                    DateTime bestStartTime = DateTime.MaxValue;

                    foreach (var machine in Machines)
                    {
                        // 檢查機台是否能處理該製程
                        if (machine.CanProcess(process.process_id))
                        {
                            // 確保前一製程已完成後，才能開始下一製程
                            var previousProcess = job.processes.IndexOf(process) > 0
                                ? job.processes[job.processes.IndexOf(process) - 1]
                                : null;
                            DateTime prevProcessEndTime = previousProcess?.end_time ?? DateTime.Now;

                            // 計算目前製程可開始時間
                            DateTime machineNextAvailable = machine.GetNextAvailableTime(prevProcessEndTime, process.process_time);

                            // 找出最早能開始該製程的機台
                            if (machineNextAvailable < bestStartTime)
                            {
                                bestMachine = machine;
                                bestStartTime = machineNextAvailable;
                            }
                        }
                    }

                    if (bestMachine != null)
                    {
                        // 分配製程到最佳機台
                        bestMachine.AddSchedule(job, job.processes.IndexOf(process), bestStartTime);
                    }
                    else
                    {
                        Console.WriteLine($"工單 {job.order_no} 的製程 {process.process_id} 暫時無法分配。");
                        continue;
                    }
                }
            }
        }
    }
}
