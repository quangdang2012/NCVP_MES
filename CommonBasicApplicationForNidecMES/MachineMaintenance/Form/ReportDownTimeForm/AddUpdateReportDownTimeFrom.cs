using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.ReportDownTimeCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class AddUpdateReportDownTimeFrom : FormCommonNCVP
    {
        public AddUpdateReportDownTimeFrom()
        {
            InitializeComponent();
        }

        public ReportDownTimeVo reportDownTimeVo = new ReportDownTimeVo();

        private void model_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModelVo mvo = (ModelVo)model_cmb.SelectedItem;
            ValueObjectList<LineVo> linevo = (ValueObjectList<LineVo>)DefaultCbmInvoker.Invoke(new GetLineMoCbm(), new LineVo { LineId = mvo.ModelId });
            line_cmb.DisplayMember = "LineCode";
            line_cmb.DataSource = linevo.GetList();
            line_cmb.ResetText();

            ValueObjectList<ProcessWorkVo> ProcessWorkvolist = (ValueObjectList<ProcessWorkVo>)DefaultCbmInvoker.Invoke(new GetProcessWorkCbm(), new ProcessWorkVo { ProcessWorkId = mvo.ModelId });
            process_cmb.DisplayMember = "ProcessWorkName";
            process_cmb.DataSource = ProcessWorkvolist.GetList();
        }
        private void process_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProcessWorkVo pvo = (ProcessWorkVo)process_cmb.SelectedItem;
            ReportDownTimeVo inVo = new ReportDownTimeVo
            {
                ProcessWorkId = pvo.ProcessWorkId
            };
            //ReportDownTimeVo outVo = new ReportDownTimeVo();

            //outVo = (ReportDownTimeVo)DefaultCbmInvoker.Invoke(new GetProcessMoCbm(), inVo);
            ValueObjectList<ReportDownTimeVo> outVo = (ValueObjectList<ReportDownTimeVo>)DefaultCbmInvoker.Invoke(new GetProcessMoCbm(), inVo);
            assy_txt.Text = outVo.GetList()[0].ProcessName;
            machine_txt.Text = outVo.GetList()[0].MachineName;
            //ValueObjectList<ProcessWorkVo> prwvo = (ValueObjectList<ProcessWorkVo>)DefaultCbmInvoker.Invoke(new GetCauseAndDefectiveCbm(), new ProcessWorkVo { ProcessWorkId = pvo.ProcessId });
            //assy_txt.Text = prwvo.ToString();
            //assy_txt.DataSource = prwvo.GetList();
        }
        private void machine_txt_TextChanged(object sender, EventArgs e)
        {
            //if (machine_txt.SelectedItem != null)
            //{
            ReportDownTimeVo inVo = new ReportDownTimeVo
            {
                MachineName = machine_txt.Text
            };

            ValueObjectList<DefectiveReasonVo> defectivereasonvo = (ValueObjectList<DefectiveReasonVo>)DefaultCbmInvoker.Invoke(new GetCauseAndDefectiveCbm(), new DefectiveReasonVo { DefectiveReasonCode = inVo.MachineName });
            cause_cmb.DisplayMember = "DefectiveReasonName";
            cause_cmb.DataSource = defectivereasonvo.GetList();

            ValueObjectList<ProdutionWorkContentVo> respmachinevolist = (ValueObjectList<ProdutionWorkContentVo>)DefaultCbmInvoker.Invoke(new GetActicAndContentCbm(), new ProdutionWorkContentVo { ProdutionWorkContentCode = inVo.MachineName });
            action_cmb.DisplayMember = "ProdutionWorkContentName";
            action_cmb.DataSource = respmachinevolist.GetList();

            cause_cmb.ResetText();
            action_cmb.ResetText();
            //process_cmb.ResetText();
            //}
        }

        private void AddUpdateReportDownTimeFrom_Load(object sender, EventArgs e)
        {
            ValueObjectList<ModelVo> modelvolist = (ValueObjectList<ModelVo>)DefaultCbmInvoker.Invoke(new GetModelCbm(), new ModelVo());
            model_cmb.DisplayMember = "ModelCode";
            BindingSource b1 = new BindingSource(modelvolist.GetList(), null);
            model_cmb.DataSource = b1;
            model_cmb.Text = "";

            //ProcessVo processvo = (ProcessVo)DefaultCbmInvoker.Invoke(new GetProcessMasterMntCbm(), new ProcessVo());
            //process_cmb.DisplayMember = "ProcessName";
            //BindingSource b2 = new BindingSource(processvo.ProcessListVo, null);
            //process_cmb.DataSource = b2;
            //process_cmb.Text = "";

            //MachineVo machinevo = (MachineVo)DefaultCbmInvoker.Invoke(new GetMachineMasterMntCbm(), new MachineVo());
            //machine_cmb.DisplayMember = "MachineName";
            //BindingSource b4 = new BindingSource(machinevo.MachineListVo, null);
            //machine_cmb.DataSource = b4;
            //machine_cmb.Text = "";

            line_cmb.Text = "";
            cause_cmb.Text = "";
            action_cmb.Text = "";
            process_cmb.ResetText();
            assy_txt.ResetText();
            machine_txt.ResetText();

            if (reportDownTimeVo.DowntimeReportId > 0)
            {
                //model_cmb.Enabled = false;
                //line_cmb.Enabled = false;
                //timefrom_dtp.Enabled = false;
                timefrom_dtp.Value = reportDownTimeVo.TimeFrom;
                timeto_dtp.Value = reportDownTimeVo.TimeTo;
                model_cmb.Text = reportDownTimeVo.ModelCode;
                line_cmb.Text = reportDownTimeVo.LineCode;
                assy_txt.Text = reportDownTimeVo.ProcessName;
                machine_txt.Text = reportDownTimeVo.MachineName;
                cause_cmb.Text = reportDownTimeVo.DefectiveReasonName;
                action_cmb.Text = reportDownTimeVo.ProductionWorkContentName;
                process_cmb.Text = reportDownTimeVo.ProcessWorkName;
                remake_txt.Text = reportDownTimeVo.Remakes;
                User_txt.Text = reportDownTimeVo.RegistrationUserCode;
            }
        }
        bool checkdata()
        {
            if (model_cmb.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, model_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                model_cmb.Focus();
                return false;
            }
            //if (assy_txt.Text == null)
            //{
            //    messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, assy_lbl.Text);
            //    popUpMessage.Warning(messageData, Text);
            //    assy_txt.Focus();
            //    return false;
            //}
            if (line_cmb.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, line_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                line_cmb.Focus();
                return false;
            }
            if (String.IsNullOrEmpty(User_txt.Text))
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, User_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                User_txt.Focus();
                return false;
            }
            if (action_cmb.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, action_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                action_cmb.Focus();
                return false;
            }
            if (cause_cmb.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, cause_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                cause_cmb.Focus();
                return false; 
            }
            if (timefrom_dtp.Value > timeto_dtp.Value)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, "Time Error");
                popUpMessage.Warning(messageData, Text);
                timefrom_dtp.Focus();
                return false;
            }
            return true;
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            if (checkdata())
            {
                ReportDownTimeVo outVo = new ReportDownTimeVo();
                ReportDownTimeVo inVo = new ReportDownTimeVo
                {
                    DowntimeReportId = this.reportDownTimeVo.DowntimeReportId,
                    TimeFrom = this.timefrom_dtp.Value,
                    TimeTo = this.timeto_dtp.Value,
                    Remakes = this.remake_txt.Text,
                    LineId = ((LineVo)this.line_cmb.SelectedItem).LineId,
                    MachineCode = this.machine_txt.Text,
                    ModelId = ((ModelVo)this.model_cmb.SelectedItem).ModelId,
                    ProcessCode = this.assy_txt.Text,
                    ProcessWorkId = ((ProcessWorkVo)this.process_cmb.SelectedItem).ProcessWorkId,
                    ProductionWorkContentId = ((ProdutionWorkContentVo)this.action_cmb.SelectedItem).ProdutionWorkContentId,
                    DefectiveReasonId = ((DefectiveReasonVo)this.cause_cmb.SelectedItem).DefectiveReasonId,
                    RegistrationUserCode = User_txt.Text, //UserData.GetUserData().UserName,
                    FactoryCode = UserData.GetUserData().FactoryCode
                };
                try
                {
                    if (inVo.DowntimeReportId > 0)
                    {
                        outVo = (ReportDownTimeVo)DefaultCbmInvoker.Invoke(new UpdateReportDownTimeCbm(), inVo);
                    }
                    else
                    {
                        outVo = (ReportDownTimeVo)DefaultCbmInvoker.Invoke(new AddReportDownTimeCbm(), inVo);
                    }

                    ResetControlValues.ResetControlValue(tableLayoutPanel1);
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void User_txt_Click(object sender, EventArgs e)
        {
            User_txt.Text = UserData.GetUserData().UserName;
        }
    }
}