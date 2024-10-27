using HZH_Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCAppPlatform.APS
{
    internal class EnergyOptimization : IDispatcher
    {
        private List<Machine> Machines;
        private List<Job> Jobs;

        public EnergyOptimization(List<Job> jobList, List<Machine> machineList)
        {
            Machines = machineList;
            Jobs = jobList;
        }

        public void Dispatching(DateTime begin_time)
        {
            // 清空機台的排程
            foreach (var machine in Machines)
            {
                machine.schedule.Clear();
            }

            // 依據交期和優先度進行排序
            var sortedJobs = Jobs.OrderBy(j => j.due_date)
                                 .ThenByDescending(j => j.priority)
                                 .ToList();
            // 開始排程
            foreach (var job in sortedJobs)
            {
                foreach (var process in job.processes)
                {
                    
                    // 選擇最後完工機台
                    //Machine latestMachine = Machines.OrderByDescending(m => m.schedule.Last().job.processes[m.schedule.Last().processIndex].end_time).FirstOrDefault();

                    Machine bestMachine = null;
                    DateTime bestStartTime = DateTime.MaxValue;

                    bool over_date = true;

                    foreach (var machine in Machines)
                    {
                        // 檢查機台是否能處理該製程
                        if (machine.CanProcess(process.process_id))
                        {
                            // 確保前一製程已完成後，才能開始下一製程
                            var previousProcess = job.processes.IndexOf(process) > 0
                                ? job.processes[job.processes.IndexOf(process) - 1]
                                : null;
                            DateTime prevProcessEndTime = previousProcess?.end_time ?? begin_time;

                            // 計算該機台的下一可用時間
                            DateTime machineNextAvailable = machine.GetNextAvailableTime(prevProcessEndTime, process.process_time);

                            // 找出最早能開始該製程的機台
                            //if (machineNextAvailable < bestStartTime)
                            //{
                            //    bestMachine = machine;
                            //    bestStartTime = machineNextAvailable;
                            //}

                            if (over_date)
                            {
                                bestMachine = machine;
                                bestStartTime = machineNextAvailable;
                            }

                            // 若未逾期，只記錄目前
                            if (machineNextAvailable.AddHours(process.process_time) < job.due_date) 
                            {
                                over_date = false;
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
                    }
                }

            }
        }




    }
}
