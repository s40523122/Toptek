using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNCAppPlatform
{
    internal class SaveCsv
    {
        private static string debug_path = Path.Combine(Application.StartupPath, "Configurations/");         // Debug 資料夾路徑

        public static int DataRowCount(string filePath, bool in_degug = true)
        {
            // 若 in_debug == true，filePath 改為基於 Debug 路徑的相對路徑
            if (in_degug) filePath = Path.Combine(debug_path, filePath);

            int rowCount = 0;

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // 讀取第一行（標題行），不計算進 rowCount
                    reader.ReadLine();

                    // 讀取每一行資料，並計數
                    while (reader.ReadLine() != null)
                    {
                        rowCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取檔案時發生錯誤：" + ex.Message);
            }

            return rowCount;
        }

        public static void SaveDataGridViewToCSV(DataGridView dataGridView1, string filePath, bool in_degug = true)
        {
            // 若 in_debug == true，filePath 改為基於 Debug 路徑的相對路徑
            if (in_degug) filePath = Path.Combine(debug_path, filePath);
            
            try
            {
                // 使用 append 模式打開檔案，不會覆蓋原來的資料
                using (StreamWriter writer = new StreamWriter(filePath, true)) // true 表示追加模式
                {
                    // 如果文件是空的，則寫入標題列（只在新文件時寫入）
                    if (new FileInfo(filePath).Length == 0)
                    {
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            writer.Write(dataGridView1.Columns[i].HeaderText);
                            if (i < dataGridView1.Columns.Count - 1)
                            {
                                writer.Write(","); // 欄位之間用逗號分隔
                            }
                        }
                        writer.WriteLine();
                    }

                    // 寫入每一行的資料
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow) // 跳過新增行
                        {
                            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                            {
                                writer.Write(row.Cells[i].Value?.ToString());
                                if (i < dataGridView1.Columns.Count - 1)
                                {
                                    writer.Write(","); // 欄位之間用逗號分隔
                                }
                            }
                            writer.WriteLine();
                        }
                    }
                }
                MessageBox.Show("資料已成功保存為 CSV！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存時發生錯誤：" + ex.Message);
            }
        }

        public static void LoadCSVToDataGridView(DataGridView dataGridView1, string filePath, bool in_degug = true)
        {
            // 若 in_debug == true，filePath 改為基於 Debug 路徑的相對路徑
            if (in_degug) filePath = Path.Combine(debug_path, filePath); 
            
            try
            {
                // 使用 StreamReader 讀取 CSV 檔案
                using (StreamReader reader = new StreamReader(filePath))
                {
                    // 清除原本的資料
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();

                    // 讀取第一行，這通常是標題行
                    string headerLine = reader.ReadLine();
                    if (headerLine != null)
                    {
                        // 將標題行分割並設為 DataGridView 的欄位
                        string[] headers = headerLine.Split(',');
                        foreach (string header in headers)
                        {
                            dataGridView1.Columns.Add(header, header); // 加入欄位
                        }
                    }

                    // 讀取接下來的每一行作為數據
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(','); // 用逗號分割
                        dataGridView1.Rows.Add(data); // 將資料加入 DataGridView
                    }
                }

                MessageBox.Show("CSV 檔案已成功載入！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取檔案時發生錯誤：" + ex.Message);
            }
        }
    }
}
