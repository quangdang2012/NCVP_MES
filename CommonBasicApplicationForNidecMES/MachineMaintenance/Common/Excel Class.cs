using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common
{
    public class Excel_Class
    {
        private void defineDt(ref DataTable dt)
        {
            dt.Columns.Add("scdl_day", Type.GetType("System.String"));
            dt.Columns.Add("m", Type.GetType("System.Double"));
        }

        public void exportexcel(ref DataGridViewCommon dgv, string link, string filename)
        {
            try
            {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Workbooks.Add();
                Excel.Worksheet ws = excelApp.ActiveSheet;
                // column headings
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    ws.Cells[1, (i + 1)] = dgv.Columns[i].HeaderText;
                }
                // rows
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv[j, i].Value != null)

                            ws.Cells[(i + 2), (j + 1)] = dgv[j, i].Value.ToString();
                    }
                }
                excelApp.Visible = true;

                ws.SaveAs(link + @"\" + filename + ".xlsx");
            }
            catch
            {
                MessageBox.Show("ERROR. Please create folder " + link + " to save as...");
                return;
            }
        }
        public void exportexcelGA1(ref DataGridViewCommon dgv, string link, string filename, string model, string line, string dateFrom, string dateTo)
        {
            try
            {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Workbooks.Add();
                Excel.Worksheet ws = excelApp.ActiveSheet;

                ws.Cells[1, 1] = "Model:"; ws.Cells[1, 2] = model;
                ws.Cells[1, 3] = "Line:"; ws.Cells[1, 4] = line;
                ws.Cells[2, 1] = "From;"; ws.Cells[2, 2] = dateFrom;
                ws.Cells[2, 3] = "To:"; ws.Cells[2, 4] = dateTo;
                // column headings
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    ws.Cells[4, (i + 1)] = dgv.Columns[i].HeaderText;
                }
                // rows

                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        ws.Cells[(i + 5), (j + 1)] = dgv[j, i].Value.ToString();
                        if (i < dgv.RowCount - 1)
                        {
                            if (dgv.Rows[i].Cells["process"].Value.ToString() == dgv.Rows[i + 1].Cells["process"].Value.ToString())
                            {
                                ws.Range[ws.Cells[i + 5, 1], ws.Cells[i + 6, 1]].Merge();
                            }
                        }
                    }
                }
                excelApp.Visible = true;
                if (link.Length == 3)
                {
                    ws.SaveAs(link + filename + ".xlsx");
                }
                else ws.SaveAs(link + @"\" + filename + ".xlsx");
            }
            catch
            {
                MessageBox.Show("ERROR. Please create folder " + link + " to save as...");
                return;
            }
        }
        public void Export(ref DataGridViewCommon dgv, string filename)
        {
            try
            {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Workbooks.Add();
                Excel.Worksheet ws = excelApp.ActiveSheet;
                // column headings
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    ws.Cells[1, (i + 1)] = dgv.Columns[i].HeaderText;
                }
                // rows
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv[j, i].Value != null)

                            ws.Cells[(i + 2), (j + 1)] = dgv[j, i].Value.ToString();
                    }
                }
                excelApp.Visible = true;

                //ws.SaveAs(link + @"\" + filename + ".xlsx");
            }
            catch
            {
                MessageBox.Show("ERROR. Can not export this data...");
                return;
            }
        }
        public void ExportToExcel(DataTable dt)
        {
            try
            {
                if (dt == null || dt.Columns.Count == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                Excel.Application excelApp = new Excel.Application();
                excelApp.Workbooks.Add();
                Excel.Worksheet ws = excelApp.ActiveSheet;

                // column headings
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ws.Cells[1, (i + 1)] = dt.Columns[i].ColumnName;
                }

                // rows
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ws.Cells[(i + 2), (j + 1)] = dt.Rows[i][j];
                    }
                }
                excelApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void exportExcelIPQC(string model, string line, string user, string usl, string lsl, string process, string inspect, string sample, string descrip, DataGridView dgv, string dtpFrom, string dtpTo)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(@"D:\Database IPQC\Template.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                #region Sheet 1
                //Add data in Sheet 1
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1); //add data sheet1

                xlWorkSheet.Cells[7, 18] = line; //Line
                xlWorkSheet.Cells[4, 3] = model; //Model
                xlWorkSheet.Cells[7, 21] = user; //User
                xlWorkSheet.Cells[7, 3] = process; //Process
                xlWorkSheet.Cells[9, 3] = descrip; //Description
                xlWorkSheet.Cells[7, 12] = lsl; //LSL, USL
                xlWorkSheet.Cells[7, 13] = usl;
                xlWorkSheet.Cells[7, 26] = sample; //Sample

                //datagridw
                for (int i = 0; i <= dgv.Rows.Count - 1; i++) //dong
                {
                    for (int j = 0; j < 5; j++) //cot
                    {
                        DataGridViewCell cell = dgv[j + 6, i]; //cot , dong
                        xlWorkSheet.Cells[j + 17, i + 3] = cell.Value; // dong , cot
                    }
                }

                //ngay, gio, status
                for (int i = 0; i <= dgv.Rows.Count - 1; i++)
                {
                    //ngay là 14:3
                    DataGridViewCell cell = dgv[1, i]; //cot , dong
                    xlWorkSheet.Cells[15, i + 3] = cell.Value; // dong , cot 

                    //giờ là 15:3
                    xlWorkSheet.Cells[16, i + 3] = cell.Value; // dong , cot 

                    //status
                    DataGridViewCell cell1 = dgv[5, i];
                    xlWorkSheet.Cells[14, i + 3] = cell1.Value;

                    //repair
                    DataGridViewCell cell2 = dgv[4, i];
                    xlWorkSheet.Cells[62, i + 3] = cell2.Value;
                }

                #endregion

                xlWorkBook.SaveAs("D:\\Database IPQC\\#" + line + "#" + descrip + ".xlsx", Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                        misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                MessageBox.Show("Excel file created, you can find in the folder D:\\Database IPQC", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Workbooks.Open("D:\\Database IPQC\\#" + line + "#" + descrip + ".xlsx");
                xlApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error happened in the process.");
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }
    }
}
