using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.JigRepairInformationCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.DrawCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.ReportDownTimeCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class AddJigRepairInformationForm : FormCommonNCVP
    {
        public AddJigRepairInformationForm()
        {
            InitializeComponent();
        }

        public JigRepairInformationVo jvo = new JigRepairInformationVo();

        private void AddJigRepairInformationForm_Load(object sender, EventArgs e)
        {
            resuft_cmb.Items.Add("OK");
            resuft_cmb.Items.Add("NG");

            ValueObjectList<ModelVo> modelvolist = (ValueObjectList<ModelVo>)DefaultCbmInvoker.Invoke(new GetModelCbm(), new ModelVo());
            model_cmb.DisplayMember = "ModelCode";
            BindingSource b1 = new BindingSource(modelvolist.GetList(), null);
            model_cmb.DataSource = b1;
            model_cmb.Text = "";

            ValueObjectList<JigResponseVo> respmachinevolist = (ValueObjectList<JigResponseVo>)DefaultCbmInvoker.Invoke(new GetJigResponseCbm(),
                new JigResponseVo());
            jigresponse_cmb.DisplayMember = "JigResponseName";
            jigresponse_cmb.DataSource = respmachinevolist.GetList();
            jigresponse_cmb.Text = "";

            ValueObjectList<JigCauseVo> respmachinevolist12 = (ValueObjectList<JigCauseVo>)DefaultCbmInvoker.Invoke(new GetJigCauseCbm(),
                new JigCauseVo());
            jigause_cmb.DisplayMember = "JigCauseName";
            jigause_cmb.DataSource = respmachinevolist12.GetList();
            jigause_cmb.Text = "";

            line_cmb.Text = "";
            process_cmb.Text = "";

            if (jvo.JigRepairId > 0)
            {
                model_cmb.Enabled = false;
                model_cmb.Text = jvo.ModelCode;
                process_cmb.Text = jvo.ProcessName;
                line_cmb.Text = jvo.LineCode;
                jig_code_txt.Text = jvo.JigRepairCode;
                jigresponse_cmb.Text = jvo.JigResponseName;
                jigause_cmb.Text = jvo.JigCauseName;
                resuft_cmb.Text = jvo.JigRepairResult;
                place_txt.Text = jvo.JigPlace;
                jigause_cmb.Text = jvo.JigCauseName;
                afterstatus_txt.Text = jvo.JigAfterRepairStatus;
                beforestatus_txt.Text = jvo.JigCurrentStatus;
                timeto_dtp.Value = jvo.TimeTo;
                timefrom_dtp.Value = jvo.TimeFrom;
            }
        }

        private void model_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (model_cmb.SelectedItem != null)
            {
                ModelVo mvo = (ModelVo)model_cmb.SelectedItem;
                ValueObjectList<LineVo> linevo = (ValueObjectList<LineVo>)DefaultCbmInvoker.Invoke(new GetLineMoCbm(), new LineVo { LineId = mvo.ModelId });
                line_cmb.DisplayMember = "LineCode";
                line_cmb.DataSource = linevo.GetList();
            }

            if (model_cmb.SelectedItem != null)
            {
                ModelVo mvo = (ModelVo)model_cmb.SelectedItem;
                ValueObjectList<ProcessVo> linevo = (ValueObjectList<ProcessVo>)DefaultCbmInvoker.Invoke(new GetProcessModelCbm(), new ProcessVo { ProcessId = mvo.ModelId });
                process_cmb.DisplayMember = "ProcessName";
                process_cmb.DataSource = linevo.GetList();
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
            if (process_cmb.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, process_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                process_cmb.Focus();
                return false;
            }
            if (line_cmb.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, line_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                line_cmb.Focus();
                return false;
            }

            if (jigresponse_cmb.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, jigresponse_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                jigresponse_cmb.Focus();
                return false;
            }

            if (jigause_cmb.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, jigause_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                jigause_cmb.Focus();
                return false;
            }

            if (jig_code_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, jig_code_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                jig_code_txt.Focus();
                return false;
            }
            if (afterstatus_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, afterstatus_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                afterstatus_txt.Focus();
                return false;
            }
            if (beforestatus_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, beforestatus_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                beforestatus_txt.Focus();
                return false;
            }
            if (place_txt.Text.Trim().Length == 0)
            { 
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, place_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                place_txt.Focus();
                return false;
            }
            if (resuft_cmb.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, resuft_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                resuft_cmb.Focus();
                return false;
            }

            return true;
        }

        private void buttonCommon1_Click(object sender, EventArgs e) // ok button
        {
            if(checkdata())
            {
                JigRepairInformationVo outVo = new JigRepairInformationVo();
                JigRepairInformationVo inVo = new JigRepairInformationVo
                {
                    JigRepairId = this.jvo.JigRepairId,
                    TimeFrom = this.timefrom_dtp.Value,
                    TimeTo = this.timeto_dtp.Value,
                    LineId = ((LineVo)this.line_cmb.SelectedItem).LineId,
                    JigCauseId = ((JigCauseVo)this.jigause_cmb.SelectedItem).JigCauseId,
                    ModelId = ((ModelVo)this.model_cmb.SelectedItem).ModelId,
                    ProcessId = ((ProcessVo)this.process_cmb.SelectedItem).ProcessId,
                    JigResponseId = ((JigResponseVo)this.jigresponse_cmb.SelectedItem).JigResponseId,
                    JigRepairCode = jig_code_txt.Text,
                    RegistrationUserCode = UserData.GetUserData().UserCode,
                    FactoryCode = UserData.GetUserData().FactoryCode,

                    //---------------
                    JigRepairResult = resuft_cmb.Text,
                    JigPlace = place_txt.Text,
                    JigCauseCode = jig_code_txt.Text,
                    JigAfterRepairStatus=  afterstatus_txt.Text,
                    JigCurrentStatus = beforestatus_txt.Text

                };
                try
                {

                    if (inVo.JigRepairId > 0)
                    {
                        outVo = (JigRepairInformationVo)DefaultCbmInvoker.Invoke(new UpdateJigRepairInformationCbm(), inVo);
                    }
                    else
                    {
                        outVo = (JigRepairInformationVo)DefaultCbmInvoker.Invoke(new AddJigRepairInformationCbm(), inVo);
                    }
                }
                catch (Com.Nidec.Mes.Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }
                if (outVo.AffectedCount > 0)
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void buttonCommon2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
