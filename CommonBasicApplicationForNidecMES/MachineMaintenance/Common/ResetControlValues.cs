using System;
using System.Windows.Forms;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common
{
    class ResetControlValues
    {
        //new class
        public static void ResetControlValue(Control Parent)
        {
            foreach (Control mycontrols in Parent.Controls)
            {
                if (mycontrols is TextBox)
                {
                    (mycontrols as TextBox).ResetText(); //Text = string.Empty;
                }
                else if (mycontrols is DateTimePicker)
                {
                    (mycontrols as DateTimePicker).Value = DateTime.Now;
                }
                else if (mycontrols is ComboBox)
                {
                    (mycontrols as ComboBox).ResetText(); //SelectedIndex = 0;
                }
                //else if (mycontrols is DataGridView)
                //{
                //    (mycontrols as DataGridView).Rows.Clear();
                //}
            }
        }
    }
}
