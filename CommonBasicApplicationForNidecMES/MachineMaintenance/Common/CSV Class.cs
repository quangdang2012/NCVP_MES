using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common
{
    public class CSV_Class
    {
        public void exportcsv(ref DataGridViewCommon dgv, string link, string filename)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                int rowcount = dgv.Rows.Count;
                int columncount = dgv.Columns.Count;
                List<string> cols = new List<string>();
                for (int i = 0; i < dgv.ColumnCount; i++)
                {

                    cols.Add(dgv.Columns[i].HeaderText + @"|");
                }
                builder.AppendLine(string.Join("\t", cols.ToArray()));
                for (int i = 0; i < rowcount; i++)
                {
                    cols = new List<string>();
                    for (int j = 0; j < columncount; j++)
                    {
                        cols.Add(dgv.Rows[i].Cells[j].Value.ToString() + @"|");
                    }
                    builder.AppendLine(string.Join("\t", cols.ToArray()));
                }

                System.IO.File.WriteAllText(link + @"\" + filename + ".csv", builder.ToString());
                MessageBox.Show("Save ok. Filename: " + link + @"\" + filename + ".csv");
            }
            catch
            {
                MessageBox.Show("ERROR. Please create folder " + link + " to save as...");
                return;

            }
        }
    }
}