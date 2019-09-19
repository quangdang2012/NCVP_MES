using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
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

        public void exportcsv(ref DataTable dt, string filepath)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                int rowcount = dt.Rows.Count;
                int columncount = dt.Columns.Count;
                List<string> cols = new List<string>();
                for (int i = 0; i < columncount; i++)
                {

                    cols.Add(dt.Columns[i].ColumnName + @"|");
                }
                builder.AppendLine(string.Join("\t", cols.ToArray()));
                for (int i = 0; i < rowcount; i++)
                {
                    cols = new List<string>();
                    for (int j = 0; j < columncount; j++)
                    {
                        cols.Add(dt.Rows[i][j].ToString() + @"|");
                    }
                    builder.AppendLine(string.Join("\t", cols.ToArray()));
                }

                System.IO.File.WriteAllText(filepath, builder.ToString());
                MessageBox.Show("Save ok. Filename: " + filepath);
            }
            catch
            {
                MessageBox.Show("ERROR. Please create folder " + filepath + " to save as...");
                return;

            }
        }

        public void ReadLineCSVtoList(string path, ref List<string> itemlist)
        {
            var lines = System.IO.File.ReadAllText(path).Split('\n').ToList();
            itemlist = lines;
        }

        public void ReadCSVtoTable(string path, ref DataTable dt, bool ColumnName)
        {
            List<string> lines = (System.IO.File.ReadAllText(path).Split('\n')).ToList();
            if(ColumnName)
            {
                List<string> colnames = (from col in lines[0].Split(',') select col).ToList();
                foreach (string name in colnames)
                    dt.Columns.Add(name);
                lines.RemoveAt(0);
            }
            else
            {
                List<string> colnames = (from col in lines[0].Split(',') select col).ToList();
                int i = 0;
                foreach (string name in colnames)
                {
                    i++;
                    dt.Columns.Add("Column " + i);
                }
            }
            foreach(string line in lines)
            {
                dt.Rows.Add(line);
            }
        }
    }
}