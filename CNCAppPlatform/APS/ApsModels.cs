using RosSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace CNCAppPlatform.APS
{
    public interface IDispatcher
    {
        void Dispatching(DateTime begin_time);
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

        public Job(int reserved ,string orderNo, string dueDate, string priority, List<Process> processes, string material, string quantity)
        {
            order_no = orderNo;
            due_date = DateTime.Parse(dueDate);
            this.priority = Int32.Parse(priority);
            this.processes = processes;
            required_material = material;
            required_quantity = Int32.Parse(quantity);
        }

        public static Process FindProcess((Job job, int processIndex) sche_bundle)
        {
            return sche_bundle.job.processes[sche_bundle.processIndex];
        }

        public static List<Job> ImportCSV(string csv_path) 
        {
            List<Job> job_list = new List<Job>();
            

            List<string[]> csv_array = SaveCsv.LoadCSVToString(csv_path);
            
            for (int i = 0; i < csv_array.Count-1; i++) 
            {
                List<Process> processes = new List<Process> { new Process(csv_array[i][6], csv_array[i][7]) };

                for (int j = i; j < csv_array.Count-1; j++)
                {
                    string[] current_order = csv_array[j];
                    string[] next_order = csv_array[j + 1];
                    if (current_order[1] == next_order[1])
                    {
                        // 相同製程
                        processes.Add(new Process(next_order[6], next_order[7]));
                        i++;
                    }
                    else
                    {
                        break;
                    }
                }

                Job _job = new Job(1, csv_array[i][1], csv_array[i][5], csv_array[i][2], processes, csv_array[i][3], csv_array[i][4]);

                job_list.Add(_job);
            }

            return job_list;
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

        public Process(string processId, string time)
        {
            process_id = Int32.Parse(processId);
            process_time = double.Parse(time);
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

            schedule = schedule.OrderBy(sche => sche.job.processes[sche.processIndex].end_time.Value).ToList();
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
