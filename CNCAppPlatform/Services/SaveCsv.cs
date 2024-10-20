using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Xml.Linq;

namespace CNCAppPlatform
{
    internal class SaveCsv
    {
        private static string debug_path = Path.Combine(Application.StartupPath, "Configurations/");         // Debug 資料夾路徑

        /// <summary>
        /// 當前資料總列數
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="in_degug"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 將 datagridview 資料寫進 CSV
        /// </summary>
        /// <param name="dataGridView1"></param>
        /// <param name="filePath"></param>
        /// <param name="in_degug"></param>
        public static void SaveDataGridViewToCSV(DataGridView dataGridView1, string filePath, bool in_degug = true, bool message = true)
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
                if(message) MessageBox.Show("資料已成功保存為 CSV！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存時發生錯誤：" + ex.Message);
            }
        }

        /// <summary>
        /// 將 CSV 檔案讀取為 datagridview
        /// </summary>
        /// <param name="dataGridView1"></param>
        /// <param name="filePath"></param>
        /// <param name="in_degug"></param>
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

        /// <summary>
        /// 將 CSV 檔案讀取為字串列表
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="in_degug"></param>
        /// <returns></returns>
        public static List<string[]> LoadCSVToString(string filePath, bool in_degug = true)
        {
            // 若 in_debug == true，filePath 改為基於 Debug 路徑的相對路徑
            if (in_degug) filePath = Path.Combine(debug_path, filePath);

            List<string[]> csv_array = new List<string[]>();

            try
            {
                // 使用 StreamReader 讀取 CSV 檔案
                using (StreamReader reader = new StreamReader(filePath))
                {

                    // 讀取第一行，這通常是標題行
                    string headerLine = reader.ReadLine();

                    // 讀取接下來的每一行作為數據
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        csv_array.Add(line.Split(',')); // 用逗號分割
                    }
                }

                return csv_array;
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取檔案時發生錯誤：" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 篩選後另存
        /// </summary>
        /// <param name="filePath">原始 CSV 檔案</param>
        /// <param name="columnName">欲篩選的欄位名稱</param>
        /// <param name="filterValue">欲篩選的條件值</param>
        public static void FilterCsv(string filePath, string columnName, string filterValue, bool in_degug = true, bool is_xml = false)
        {
            // 若 in_debug == true，filePath 改為基於 Debug 路徑的相對路徑
            if (in_degug) filePath = Path.Combine(debug_path, filePath);

            //string outputFilePath = "output.csv"; // 篩選後的 CSV 檔案

            List<string[]> csvData = new List<string[]>();

            try
            {
                // 讀取 CSV 檔案
                using (var reader = new StreamReader(filePath))
                {
                    string[] headers = reader.ReadLine().Split(','); // 讀取標題行
                    csvData.Add(headers);

                    int filterColumnIndex = Array.IndexOf(headers, columnName);
                    if (filterColumnIndex == -1)
                    {
                        Console.WriteLine($"找不到欄位: {columnName}");
                        return;
                    }

                    while (!reader.EndOfStream)
                    {
                        var row = reader.ReadLine().Split(',');
                        if (row[filterColumnIndex] == filterValue)
                        {
                            csvData.Add(row);
                        }
                    }
                }

                // 打開文件選擇器
                string outputFilePath = GetSaveFilePath(is_xml);
                if (string.IsNullOrEmpty(outputFilePath))
                {
                    Console.WriteLine("未選擇儲存路徑");
                    return;
                }

                if (is_xml)
                {
                    var headers = csvData[0]; // 第一行是標題行
                    var rows = csvData.Skip(1); // 跳過標題行

                    XElement xml = new XElement("Rows",
                        rows.Select(row =>
                            new XElement("Row",
                                headers.Select((header, index) =>
                                    new XElement(header, row[index])
                                )
                            )
                        )
                    );

                    xml.Save(outputFilePath);
                }
                else
                {
                    // 將篩選後的資料寫回新的 CSV 檔案
                    using (var writer = new StreamWriter(outputFilePath))
                    {
                        foreach (var row in csvData)
                        {
                            writer.WriteLine(string.Join(",", row));
                        }
                    }
                }

                MessageBox.Show("篩選並儲存成功！");
            }
            catch (Exception ex) 
            {
                MessageBox.Show("讀取檔案時發生錯誤：" + ex.Message);
            }
        }

        static string GetSaveFilePath(bool is_xml = false)
        {

            if (is_xml)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "XML files (*.xml)|*.xml";
                    sfd.Title = "另存 XML 檔案";
                    sfd.DefaultExt = "xml";
                    sfd.AddExtension = true;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        return sfd.FileName;
                    }
                }
                return null;
            }
            else
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV files (*.csv)|*.csv";
                    sfd.Title = "另存 CSV 檔案";
                    sfd.DefaultExt = "csv";
                    sfd.AddExtension = true;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        return sfd.FileName;
                    }
                }
                return null;
            }            
        }
    }
}
