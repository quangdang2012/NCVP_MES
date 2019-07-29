using Com.Nidec.Mes.Framework;
using System;
using System.Drawing;
using System.Windows.Forms;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class ProductionControllerNCVCForm : FormCommonNCVP
    {
        public ProductionControllerNCVCForm()
        {
            InitializeComponent();
            production_controller_dgv.AutoGenerateColumns = false;
        }
        public int confirm_status = 0;
        private void ProductionControllerForm_Load(object sender, EventArgs e)
        {
            ValueObjectList<ProductionControllerNCVCVo> model = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new GetModelProNCVCCbm(), new ProductionControllerNCVCVo());
            model_cmb.DisplayMember = "ProModel";
            model_cmb.DataSource = model.GetList();

            ValueObjectList<ProductionControllerNCVCVo> line = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new GetLineProNCVCCbm(), new ProductionControllerNCVCVo());
            line_cmb.DisplayMember = "ProLine";
            line_cmb.DataSource = line.GetList();
            timefrom_dtp.Value = timefrom_dtp.Value.Date.AddDays(-7);
        }
        private void RateNG()
        {
            if (production_controller_dgv.RowCount > 0)
            {
                for (int i = 0; i < production_controller_dgv.RowCount; i++)
                {

                    double totalNG_rate = int.Parse(production_controller_dgv.Rows[i].Cells["colTotalNG"].Value.ToString());
                    double Output_rate = int.Parse(production_controller_dgv.Rows[i].Cells["colOutput"].Value.ToString());

                    if (production_controller_dgv.Rows[i].Cells["colInputCase"].Value.ToString().Length > 0 && production_controller_dgv.Rows[i].Cells["colOutput"].Value.ToString().Length > 0)
                    {
                        int Input = int.Parse(production_controller_dgv.Rows[i].Cells["colInputCase"].Value.ToString());
                        int Output = int.Parse(production_controller_dgv.Rows[i].Cells["colOutput"].Value.ToString());
                    }
                    if (Output_rate > 200)
                    {
                        double a = ((totalNG_rate / Output_rate) * 100);
                        if (a.ToString().Length > 4)
                        {
                            production_controller_dgv.Rows[i].Cells["colRateNG"].Value = a.ToString().Substring(0, 5);
                        }
                        else
                        {
                            production_controller_dgv.Rows[i].Cells["colRateNG"].Value = a.ToString();
                        }
                    }
                    else
                    {
                        production_controller_dgv.Rows[i].Cells["colRateNG"].Value = 0;
                        production_controller_dgv.Rows[i].Cells["colRateNG"].Style.BackColor = Color.Red;

                    }
                }
            }
        }
        private void search_btn_Click(object sender, EventArgs e)
        {
            if (date_rab.Checked)
            {
                confirm_status = 0;
                production_controller_dgv.Columns["colEndday"].DataPropertyName = "EndDay";
                production_controller_dgv.Columns["colStarday"].DataPropertyName = "StartDay";

                production_controller_dgv.Columns["colStarday"].HeaderText = "Star Day";
                production_controller_dgv.Columns["colStarday"].Visible = true;
                production_controller_dgv.Columns["colEndday"].HeaderText = "End Day";
                if (line_cmb.Text != "All Line")
                {
                    production_controller_dgv.Columns["colEndday"].Visible = true;

                    GridBindDate();

                }
                else if (line_cmb.Text == "All Line")
                {
                    production_controller_dgv.Columns["colEndday"].Visible = false;
                    GridBindAllLineByDate();
                }
                RateNG();
                Total_By_Date();
            }
            else if (time_rab.Checked)
            {
              
                production_controller_dgv.Columns["colEndday"].DataPropertyName = "TimeHour";

                production_controller_dgv.Columns["colEndday"].HeaderText = "Times";

                production_controller_dgv.Columns["colStarday"].Visible = false;
                production_controller_dgv.Columns["colEndday"].Visible = true;
                if (line_cmb.Text != "All Line")
                {
                    confirm_status = 1;
                    GridBindHour();
                    RateNG();
                }
                else if (line_cmb.Text == "All Line")
                {
                    //production_controller_dgv.DataSource = null;
                    //MessageBox.Show("Pls, Select one Line to go on.!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //code load all line ve 7 chart.
                    confirm_status = 2;
                    GridBindChartAllLine();
                    RateNG();
                }
                Total_By_Hour();
            }
            else MessageBox.Show("You must choose search by Date or Time", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void GridBindChartAllLine()
        {
            production_controller_dgv.DataSource = null;
            try
            {
                ProductionControllerNCVCVo vo = new ProductionControllerNCVCVo
                {
                    //ProLine = line_cmb.Text,
                    StartDay = DateTime.Parse(timefrom_dtp.Value.ToShortDateString()),
                    //EndDay = timeto_dtp.Value
                };

                ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchMainProChartAllLineNCVCCbm(), vo);
                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    production_controller_dgv.AutoGenerateColumns = false;
                    BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                    production_controller_dgv.DataSource = bindingsource;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                production_controller_dgv.ClearSelection();
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        private void GridBindAllLineByDate()
        {
            production_controller_dgv.DataSource = null;
            try
            {
                ProductionControllerNCVCVo vo = new ProductionControllerNCVCVo
                {
                    ProLine = line_cmb.Text,
                    StartDay = timefrom_dtp.Value,
                    EndDay = timeto_dtp.Value,
                    ProModel = model_cmb.Text
                };

                ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchMainProByDateAllLineNCVCCbm(), vo);
                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    production_controller_dgv.AutoGenerateColumns = false;
                    BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                    production_controller_dgv.DataSource = bindingsource;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                production_controller_dgv.ClearSelection();
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        private void GridBindDate()
        {
            production_controller_dgv.DataSource = null;
            try
            {
                ProductionControllerNCVCVo vo = new ProductionControllerNCVCVo
                {
                    ProLine = line_cmb.Text,
                    StartDay = DateTime.Parse(timefrom_dtp.Value.ToShortDateString()),
                    EndDay = DateTime.Parse(timeto_dtp.Value.ToShortDateString()),
                };

                ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchMainProByDateNCVCCbm(), vo);
                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    production_controller_dgv.AutoGenerateColumns = false;
                    BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                    production_controller_dgv.DataSource = bindingsource;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                production_controller_dgv.ClearSelection();
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        private void GridBindHour()
        {
            production_controller_dgv.DataSource = null;
            try
            {
                ProductionControllerNCVCVo vo = new ProductionControllerNCVCVo
                {
                    ProLine = line_cmb.Text,
                    Date = timefrom_dtp.Text,
                    ProModel = model_cmb.Text,
                };

                ValueObjectList<ProductionControllerNCVCVo> volist = (ValueObjectList<ProductionControllerNCVCVo>)DefaultCbmInvoker.Invoke(new SearchMainProByHourNCVCCbm(), vo);
                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    production_controller_dgv.AutoGenerateColumns = false;
                    BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                    production_controller_dgv.DataSource = bindingsource;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                production_controller_dgv.ClearSelection();
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        public float input;
        public float output;
        public float ng;
        public float extant;
        private void Total_By_Date()
        {
            input = 0;
            output = 0;
            ng = 0;
            extant = 0;
            int rowCount = production_controller_dgv.RowCount;
            for (int i = 0; i < rowCount; i++)
            {
                input += float.Parse(production_controller_dgv.Rows[i].Cells["colInputCase"].Value.ToString());
                ng += float.Parse(production_controller_dgv.Rows[i].Cells["colTotalNG"].Value.ToString());
                output += float.Parse(production_controller_dgv.Rows[i].Cells["colOutput"].Value.ToString());
                extant = input - output - ng;
            }
            input_txt.Text = input.ToString();
            output_txt.Text = output.ToString();
            ng_txt.Text = ng.ToString();
            extant_txt.Text = extant.ToString();
        }
        private void Total_By_Hour()
        {
            input = 0;
            output = 0;
            ng = 0;
            extant = 0;
            int rowCount = production_controller_dgv.RowCount;
            if (rowCount == 0)
            {
                ng = 0;
                input = 0;
                output = 0;
            }
            else
            {
                ng = float.Parse(production_controller_dgv.Rows[rowCount - 1].Cells["colTotalNG"].Value.ToString());
                input = float.Parse(production_controller_dgv.Rows[rowCount - 1].Cells["colInputCase"].Value.ToString());
                output = float.Parse(production_controller_dgv.Rows[rowCount - 1].Cells["colOutput"].Value.ToString());
                extant = input - output - ng;
            }
            input_txt.Text = input.ToString();
            output_txt.Text = output.ToString();
            ng_txt.Text = ng.ToString();
            extant_txt.Text = extant.ToString();
        }
        private void production_controller_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int i = e.RowIndex;
            int j = e.ColumnIndex;
            string date = String.Format("{0:yyyy/MM/dd}", DateTime.Parse(production_controller_dgv.Rows[i].Cells["colStarday"].Value.ToString()));
            string process = "";
            //colTotalNG
            if (production_controller_dgv.Rows[i].Cells["colTotalNG"].Selected)//totalNG
            {
                process = "All";
            }
            else if (production_controller_dgv.Rows[i].Cells["colFinal_App"].Selected)//holder
            {
                process = "Final_App";
            }
            else if (production_controller_dgv.Rows[i].Cells["colEn2"].Selected)//En2
            {
                process = "En2";
            }
            else if (production_controller_dgv.Rows[i].Cells["colEn1"].Selected)//en1
            {
                process = "En1";
            }
            else if (production_controller_dgv.Rows[i].Cells["colTrustGap"].Selected)//insertcase
            {
                process = "TrustGap";
            }
            else if (production_controller_dgv.Rows[i].Cells["colRotor"].Selected)//RA
            {
                process = "Rotor";
            }
            else if (production_controller_dgv.Rows[i].Cells["colBracket"].Selected)//SolderRing
            {
                process = "Bracket";
            }
            else if (production_controller_dgv.Rows[i].Cells["colBracketMetal"].Selected)//SolderWire
            {
                process = "BracketMetal";
            }
            else if (production_controller_dgv.Rows[i].Cells["colCaseAssy"].Selected)//Wingding
            {
                process = "CaseAssy";
            }
            else if (production_controller_dgv.Rows[i].Cells["colCaseMG"].Selected)//Welding
            {
                process = "CaseMG";
            }
            else if (production_controller_dgv.Rows[i].Cells["colMGBonding"].Selected)//Core
            {
                process = "MGBonding";
            }
            //action
            if (( j >= 6) && (date_rab.Checked == true))
            {
                ProductionControllerDetailNCVCForm pro = new ProductionControllerDetailNCVCForm(process, model_cmb.Text, line_cmb.Text, date);
                pro.ShowDialog(this);
            }
            else if (time_rab.Checked == true)
            {
                MessageBox.Show("Not Action", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (j == 2 && (date_rab.Checked == true)) //ColStartDay
            {

                int confirm_status_C = 3;//vao bieu do tron main             
                ProductionControllerChart_CNCVCForm form = new ProductionControllerChart_CNCVCForm(model_cmb.Text, line_cmb.Text, process, ref production_controller_dgv, i, confirm_status_C);
                form.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("Process is available!", "Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private string directorySave = "";
        private void browser_btn_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fl = new FolderBrowserDialog();
            fl.SelectedPath = "d:\\";
            fl.ShowNewFolderButton = true;
            if (fl.ShowDialog() == DialogResult.OK)
            {
                linksave_txt.Text = fl.SelectedPath;
                directorySave = linksave_txt.Text;
            }
        }

        private void exportexcel_btn_Click(object sender, EventArgs e)
        {
            string name;
            DateTime dat = DateTime.Now;

            Common.ExcelClass_ProductionControl ex = new Common.ExcelClass_ProductionControl();
            name = model_cmb.Text + "_" + line_cmb.Text + "_" + dat.ToString("yyyy.MM.dd");
            ex.exportexcel(ref production_controller_dgv, directorySave, name, model_cmb.Text, line_cmb.Text);
        }

        private void production_controller_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ProductionControllerForm_Resize(object sender, EventArgs e)
        {
            production_controller_dgv.Columns["colEndday"].Frozen = true;
            production_controller_dgv.Anchor = AnchorStyles.Top;
            production_controller_dgv.Anchor = AnchorStyles.Bottom;
            production_controller_dgv.Anchor = AnchorStyles.Left;
            production_controller_dgv.Anchor = AnchorStyles.Right;
            production_controller_dgv.Dock = DockStyle.Bottom;

        }

        private void chart_btn_Click(object sender, EventArgs e)
        {
            ProductionControllerChartNCVCForm form = new ProductionControllerChartNCVCForm(ref production_controller_dgv, model_cmb.Text, line_cmb.Text, timefrom_dtp.Value, timeto_dtp.Value, confirm_status);
            form.ShowDialog(this);
        }

        private void date_rab_CheckedChanged(object sender, EventArgs e)
        {
            if (date_rab.Checked == true)
            {

                timeto_lbl.Visible = true;
                timeto_dtp.Visible = true;
                timefrom_lbl.Text = "Time From";

            }
            else
            {
                timeto_lbl.Visible = false;
                timeto_dtp.Visible = false;
                timefrom_lbl.Text = "Select Date";
            }
        }

        private void time_rab_CheckedChanged(object sender, EventArgs e)
        {
            if (date_rab.Checked == true)
            {

                timeto_lbl.Visible = true;
                timeto_dtp.Visible = true;
                timefrom_lbl.Text = "Time From";

            }
            else
            {
                timeto_lbl.Visible = false;
                timeto_dtp.Visible = false;
                timefrom_lbl.Text = "Select Date";
            }
        }

        private void person_btn_Click(object sender, EventArgs e)
        {
            MachineMaintenance.Form.PersonNCVCForm newform = new PersonNCVCForm();
            newform.ShowDialog();
        }

        private void buttonCommon2_Click(object sender, EventArgs e)
        {
            string now = DateTime.Now.ToShortDateString();
            ProductionControllerDetailNCVCForm pro = new ProductionControllerDetailNCVCForm("All", model_cmb.Text, "All Line", now);
            pro.ShowDialog(this);
        }

        private void production_controller_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 selectedCellCount = production_controller_dgv.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                double sum = 0;
                for (int i = 0; i < selectedCellCount; i++)
                {
                    int rowIndex = production_controller_dgv.SelectedCells[i].RowIndex;
                    int colIndex = production_controller_dgv.SelectedCells[i].ColumnIndex;

                    if (!String.IsNullOrEmpty(production_controller_dgv.Rows[rowIndex].Cells[colIndex].Value.ToString()))
                    {
                        string sum_value = production_controller_dgv.Rows[rowIndex].Cells[colIndex].Value.ToString();
                        if (isNumber(sum_value))
                        {
                            sum += double.Parse(production_controller_dgv.Rows[rowIndex].Cells[colIndex].Value.ToString());
                        }
                    }
                    sum_txt.Text = sum.ToString();
                }
            }
        }
        public bool isNumber(string number)
        {
            double num;
            return double.TryParse(number, out num);
        }
    }
}
