using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common
{
    public class ExcelClass_ProductionControl
    {
        public void exportexcel(ref DataGridViewCommon dgv, string link, string filename,string model,string line)
        {
            try
            {
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook wb = excelApp.Workbooks.Add();
                Excel.Worksheet ws = wb.ActiveSheet;
                // column headings
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    ws.Cells[3, (i + 1)] = dgv.Columns[i].HeaderText; 
                }
                //
                ws.Cells[2, 2] = "Model:" + model;
                ws.Cells[2, 4] = "Line:" + line;
                // rows
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {

                        ws.Cells[(i + 4), (j + 1)] = dgv[j, i].Value.ToString();

                    }
                }
                
                ws.SaveAs(link + @"\" + filename + ".xlsx");
                excelApp.Visible = true;
            }
            catch
            {
                MessageBox.Show("ERROR. Please create folder " + link + " to save as...");
                return;

            }
        }
    }
}
