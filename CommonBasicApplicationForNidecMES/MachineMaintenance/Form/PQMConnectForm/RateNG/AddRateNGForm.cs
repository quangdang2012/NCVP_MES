using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.PQMConnectCbm.RateNGCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance
{
    public partial class AddRateNGForm : FormCommonNCVP
    {
        public AddRateNGForm(string status)
        {
            InitializeComponent();
            UpdateText_lbl.Text = status;
        }
        public RateNGVo vo = null;
        public int RatelId = 0;
        public string RateCode = "";
        public string RateModel = "";
        public string RateLine = "";
        public string RateRatio = "";

        public int IntSuccess = -1;
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            if (checkdate())
            {
                RateNGVo outvo = new RateNGVo();
                RateNGVo invo = new RateNGVo
                {
                    RatelId = this.RatelId,
                    RateModel = model_cmb.Text,
                    RateLine = line_cmb.Text,
                    RateCode = RateCode_txt.Text,
                    RateRatio = Ratio_txt.Text
                };
                try
                {
                    if (invo.RatelId > 0)
                    {
                        outvo = (RateNGVo)DefaultCbmInvoker.Invoke(new UpdateRateNGCbm(), invo);
                    }
                    else
                    {
                        outvo = (RateNGVo)DefaultCbmInvoker.Invoke(new InsertRateNGCbm(), invo);
                    }
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }
                if (outvo.AffectedCount > 0)
                {
                    if (UpdateText_lbl.Text == "Add")
                    {
                        messageData = new MessageData("mmci00001", Properties.Resources.mmci00001);
                        popUpMessage.Information(messageData, "Notice");
                        ResetControlValues.ResetControlValue(this);
                    }
                    else
                    {
                        messageData = new MessageData("mmci00002", Properties.Resources.mmci00002);
                        popUpMessage.Information(messageData, "Notice");
                        Close();
                    }
                }
            }
        }
        private bool checkdate()
        {

            if (RateCode_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, RankCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                RateCode_txt.Focus();
                return false;
            }
            if (Ratio_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, RankName_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                Ratio_txt.Focus();
                return false;
            }
            RateCode_txt.Text = RateCode_txt.Text.Trim();
            Ratio_txt.Text = Ratio_txt.Text.Trim();
            RateNGVo outVo = new RateNGVo(), inVo = new RateNGVo { RateCode = RateCode_txt.Text, RateModel = model_cmb.Text, RateLine = line_cmb.Text };
            try
            {
                outVo = (RateNGVo)DefaultCbmInvoker.Invoke(new CheckRateNGCbm(), inVo);
                if (outVo.AffectedCount > 0 && RatelId == 0)
                {
                    messageData = new MessageData("mmcc00006", Properties.Resources.mmcc00006, RankCode_lbl.Text);
                    popUpMessage.Warning(messageData, Text);
                    RateCode_txt.Focus();
                    return false;
                }
            }
            catch (Com.Nidec.Mes.Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return false;
            }
            return true;

        }
        private void AddRankForm_Load(object sender, EventArgs e)
        {
            Ratio_txt.Select();
            if (RatelId > 0)
            {
                RateCode_txt.Text = RateCode;
                Ratio_txt.Text = RateRatio;
                model_cmb.Text = RateModel;
                line_cmb.Text = RateLine;
            }
            else
            {
                CallModel();
            }
        }
        public void CallModel()
        {
            ValueObjectList<RateNGVo> modelVo = (ValueObjectList<RateNGVo>)DefaultCbmInvoker.Invoke(new GetModelRateNGCbm(), new RateNGVo() { });
            model_cmb.DisplayMember = "RateModel";
            model_cmb.DataSource = modelVo.GetList();
            model_cmb.Text = "";
        }
        public void CallLine()
        {
            ValueObjectList<RateNGVo> LineVo = (ValueObjectList<RateNGVo>)DefaultCbmInvoker.Invoke(new GetLineRateNGCbm(), new RateNGVo() { RateModel = model_cmb.Text });

            line_cmb.DisplayMember = "RateLine";
            line_cmb.DataSource = LineVo.GetList();
            line_cmb.Text = "";
        }
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void model_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            CallLine();
        }
    }
}
