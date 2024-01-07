using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thesis_3
{
    public partial class TableValue : Form
    {
        private Device device = null;
        private int rowCount = 1;
        public TableValue(Device _device)
        {
            device = _device;
            InitializeComponent();
            InitializeDataGridView();

        }
        private void InitializeDataGridView()
        {
            dataGridView1.ColumnCount = 8;

            // Set column headers (adjust as needed)
            dataGridView1.Columns[0].HeaderText = "No.";
            dataGridView1.Columns[1].HeaderText = "Date&Time";
            dataGridView1.Columns[2].HeaderText = "Storage";
            dataGridView1.Columns[3].HeaderText = "Chemical";
            dataGridView1.Columns[4].HeaderText = "Freshwater1";
            dataGridView1.Columns[5].HeaderText = "Freshwater2";
            dataGridView1.Columns[6].HeaderText = "Normal Water";
        }

        private void TableValue_Load(object sender, EventArgs e)
        {
            UpdateValue.Enabled = true;
        }

        private void UpdateValue_Tick(object sender, EventArgs e)
        {
            ushort storage_lv = device.Storage_water;
            ushort Che_lv = device.Chemical_water;
            ushort fw1 = device.Fresh_water_1;
            ushort fw2 = device.Fresh_water_2;
            ushort nw_lv = device.Normal_water;
            dataGridView1.Rows.Add(rowCount++, DateTime.Now, storage_lv, Che_lv, fw1, fw2, nw_lv);
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
        }

        private void PrintValue_btn_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        private void ExportToExcel()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Thesis_3_TableValue";
                saveFileDialog.FileName = "DataExport" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo newFile = new FileInfo(saveFileDialog.FileName);
                    
                    using (ExcelPackage excelPackage = new ExcelPackage(newFile))
                    {
                        // Create a new worksheet
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("DataSheet");

                        // add logo truong
                        var picture = worksheet.Drawings.AddPicture("Logo", new FileInfo(@"Image\HCMUT_official_logo.png"));
                        picture.SetPosition(0,0,0,0);
                        picture.SetSize(100, 100);
                        // Add main header

                        worksheet.Cells["D3:K3"].Merge = true;
                        worksheet.Cells["D3:K3"].Value = "Thesis Report Water Treatment System";
                        worksheet.Cells["D3:K3"].Style.Font.Size = 20;
                        worksheet.Cells["D3:K3"].Style.Font.Bold = true;
                        worksheet.Cells["D3:K3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells["A7:C7"].Merge = true;
                        worksheet.Cells["A7:C7"].Value = "Student: Tran Le Trung" + "-" + "1851118";
                        worksheet.Cells["A8:C8"].Merge = true;
                        worksheet.Cells["A8:C8"].Value = "Student: Ngo Thanh Duan" + "-" + "1951031";
                        worksheet.Cells["A9:C9"].Merge = true;
                        worksheet.Cells["A9:C9"].Value = "Instructor: Truong Dinh Chau";

                        // Add column headers
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            worksheet.Cells[10, i + 1].Value = dataGridView1.Columns[i].HeaderText;
                        }

                        // Add data to the worksheet
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridView1.Columns.Count; j++)
                            {
                                // Check if the current column is the one containing TimeSpan data
                                if (dataGridView1.Columns[j].HeaderText == "Date&Time")
                                {
                                    // Check if the cell value is not null
                                    if (dataGridView1.Rows[i].Cells[j].Value != null &&
                                        DateTime.TryParse(dataGridView1.Rows[i].Cells[j].Value.ToString(), out DateTime dateTimeValue))
                                    {
                                        // Use DateTime.TryParse to handle cases where the value is not a valid DateTime
                                        worksheet.Cells[i + 11, j + 1].Value = dateTimeValue;

                                        // Set the number format for the "Date&Time" column to show date and time
                                        worksheet.Cells[i + 11, j + 1].Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss";
                                    }
                                    else
                                    {
                                        // Handle the case where the cell value is null or not a valid DateTime
                                        worksheet.Cells[i + 11, j + 1].Value = "";
                                    }
                                }
                                else
                                {
                                    // For other columns, simply copy the cell value
                                    worksheet.Cells[i + 11, j + 1].Value = dataGridView1.Rows[i].Cells[j].Value;
                                }
                            }
                        }

                        // Save the Excel file
                        worksheet.Column(2).AutoFit();
                        excelPackage.Save();
                        MessageBox.Show("Exported to Excel successfully!", "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
