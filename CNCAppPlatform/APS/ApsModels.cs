using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNCAppPlatform.APS
{
    internal class ApsModels
    {
    }
    public class Job
    {
        public string order_no { get; set; }
        public DateTime due_date { get; set; }
        public int priority { get; set; }
        public List<Process> processes { get; set; }
        public string required_material { get; set; }
        public int required_quantity { get; set; }

        public Job(string orderNo, DateTime dueDate, int priority, List<Process> processes, string material, int quantity)
        {
            order_no = orderNo;
            due_date = dueDate;
            this.priority = priority;
            this.processes = processes;
            required_material = material;
            required_quantity = quantity;
        }
    }

    public class Process
    {
        public int process_id { get; set; }
        public double process_time { get; set; }
        public DateTime? start_time { get; set; }
        public DateTime? end_time { get; set; }

        public Process(int processId, double time)
        {
            process_id = processId;
            process_time = time;
            start_time = null;
            end_time = null;
        }
    }

    public class Machine
    {
        public int machine_id { get; set; }
        public List<int> capable_processes { get; set; }
        public List<(Job job, int processIndex)> schedule { get; set; }

        public Machine(int id, List<int> capableProcesses)
        {
            machine_id = id;
            capable_processes = capableProcesses;
            schedule = new List<(Job job, int processIndex)>();
        }

        public bool CanProcess(int processId)
        {
            return capable_processes.Contains(processId);
        }

        /// <summary>
        /// 計算目前製程可開始時間
        /// </summary>
        /// <param name="earlierProcessTime">能開始的最早時間，通常是指上一製程結束時間</param>
        /// <param name="process_time">製程所需小時數</param>
        /// <returns></returns>
        public DateTime GetNextAvailableTime(DateTime earlierProcessTime, double process_time)
        {
            if (schedule.Count == 0)
                return earlierProcessTime;  // 如果機台沒有被分配工單，則立即可用

            // 計算時程表中的空檔是否能插入製程
            for (int i = 1; i < schedule.Count; i++)
            {
                // 取得空檔的開始、結束時間
                DateTime? start_idle = schedule[i - 1].job.processes[schedule[i - 1].processIndex].end_time;
                DateTime? end_idle = schedule[i].job.processes[schedule[i].processIndex].start_time;

                // 開始或結束時間有空值，表示無空檔，跳出迴圈
                if (!end_idle.HasValue || !start_idle.HasValue) break;

                // 若空檔在能開始的最早時間前結束，跳過
                if (earlierProcessTime > end_idle.Value) continue;

                // 若能開始的最早時間在空檔間，以製程結束時間做為空檔開始時間
                if (earlierProcessTime > start_idle.Value) start_idle = earlierProcessTime;

                // 若空檔時間大於於程所需時間，插入該製程
                double idle_hours = (end_idle.Value - start_idle.Value).TotalHours;     // 計算空檔存在小時數
                if (idle_hours > process_time)
                {
                    return start_idle.Value;
                }
            }

            // 空檔皆無法插入製程時，返回機台最後一個製程的結束時間
            DateTime prev_schedule_end_time = schedule.Last().job.processes[schedule.Last().processIndex].end_time.Value;
            return earlierProcessTime > prev_schedule_end_time ? earlierProcessTime : prev_schedule_end_time;
        }

        public void AddSchedule(Job job, int processIndex, DateTime startTime)
        {
            var process = job.processes[processIndex];
            process.start_time = startTime;
            process.end_time = startTime.AddHours(process.process_time);

            schedule.Add((job, processIndex));
            Console.WriteLine($"機台 {machine_id} 被分配工單 {job.order_no} 的製程 {process.process_id}");
        }

        public void DisplaySchedule()
        {
            Console.WriteLine($"\n機台 {machine_id} 的時程表:");
            foreach (var entry in schedule)
            {
                var job = entry.job;
                var process = job.processes[entry.processIndex];
                Console.WriteLine($"工單 {job.order_no} 製程 {process.process_id}: 開始時間 {process.start_time}, 完工時間 {process.end_time}, 交期 {job.due_date}");
            }
        }
    }
}
