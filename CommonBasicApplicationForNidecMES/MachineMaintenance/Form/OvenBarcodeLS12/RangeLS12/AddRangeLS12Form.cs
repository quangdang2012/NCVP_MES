using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.OvenBarcodeLS12Cbm.RangeLS12Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.OvenBarcodeLS12Cbm.OvenLS12Cbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance
{
    public partial class AddRangeLS12Form : FormCommonNCVP
    {
        public AddRangeLS12Form()
        {
            InitializeComponent();
        }
        public RangeVo vo = null;
        public int IntSuccess = -1;
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            if (checkdate())
            {
                int fail = 0;
                int a = vo.RangeId;
                RangeVo outvo = new RangeVo();
                try
                {
                    if (vo.RangeId > 0)
                    {
                        outvo = (RangeVo)DefaultCbmInvoker.Invoke(new UpdateRangeLS12Cbm(), new RangeVo
                        {
                            RangeId = vo.RangeId,
                            Model = model_cbm.Text,
                            Line = process_cbm.Text,
                            Lower = lower_txt.Text,
                            Upper = upper_txt.Text,
                            RegistrationUser = UserData.GetUserData().UserCode
                        });
                        IntSuccess = outvo.AffectedCount;
                    }
                    else
                    {
                        int countDem = 0;
                        
                        RangeVo checkBarcode = (RangeVo)DefaultCbmInvoker.Invoke(new CheckBarcodeRangeLS12Cbm(), new RangeVo()
                        {
                            Model = model_cbm.Text,
                            Process = process_cbm.Text,
                        });

                        countDem = countDem + 1;
                        if (checkBarcode.Count == 0)//kiểm tra barcode có trùng trong database
                        {
                            outvo = (RangeVo)DefaultCbmInvoker.Invoke(new AddRangeLS12Cbm(), new RangeVo
                            {
                                RangeId = vo.RangeId,
                                Model = model_cbm.Text,
                                Process = process_cbm.Text,
                                Lower = lower_txt.Text,
                                Upper = upper_txt.Text,
                                RegistrationUser = UserData.GetUserData().UserCode
                            });
                            IntSuccess = outvo.AffectedCount;
                        }
                        else
                        {
                            messageData = new MessageData("mmcc00005", "Process have set temperature", "Warning");
                            popUpMessage.ApplicationError(messageData, Text);
                        }
                    }

                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }
                if ((IntSuccess > 0) || (IntSuccess == 0))
                {
                    if(fail > 0)
                    {

                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        private bool checkdate()
        {
            if (model_cbm.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, model_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                lower_txt.Focus();
                return false;
            }
            if (process_cbm.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, process_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                upper_txt.Focus();
                return false;
            }
                   
            if (lower_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, lower_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                lower_txt.Focus();
                return false;
            }
            if (upper_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, upper_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                upper_txt.Focus();
                return false;
            }
            //model_cbm.Text = model_cbm.Text.Trim();
            //line_cbm.Text = line_cbm.Text.Trim();
            lower_txt.Text = lower_txt.Text.Trim();
            upper_txt.Text = upper_txt.Text.Trim();
            //RangeVo outVo = new RangeVo(),
            //    inVo = new RangeVo { RangeId = vo.RangeId,  };
            //try
            //{
            //    outVo = (RangeVo)DefaultCbmInvoker.Invoke(new CheckRankCbm(), inVo);
            //    if (outVo.AffectedCount > 0)
            //    {
            //        messageData = new MessageData("mmcc00006", Properties.Resources.mmcc00006, lower_lbl.Text);
            //        popUpMessage.Warning(messageData, Text);
            //        lower_txt.Focus();
            //        return false;
            //    }
            //}
            //catch (Com.Nidec.Mes.Framework.ApplicationException exception)
            //{
            //    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
            //    logger.Error(exception.GetMessageData());
            //    return false;
            //}
            return true;

        }
        private void AddRankForm_Load(object sender, EventArgs e)
        {
            //lower_txt.Select();
            ValueObjectList<OvenBarcodeVo> modelVo = (ValueObjectList<OvenBarcodeVo>)DefaultCbmInvoker.Invoke(new GetModelOvenLS12Cbm(), new OvenBarcodeVo());
            model_cbm.DisplayMember = "Model";
            model_cbm.DataSource = modelVo.GetList();
            model_cbm.Text = "";

            if (vo.RangeId > 0)
            {
                model_cbm.Text = vo.Model;
                model_cbm.Enabled = false;
                process_cbm.Text = vo.Process;
                process_cbm.Enabled = false;
                upper_txt.Text = vo.Upper;
                lower_txt.Text = vo.Lower;
            }
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void model_cbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValueObjectList<OvenBarcodeVo> linelVo = (ValueObjectList<OvenBarcodeVo>)DefaultCbmInvoker.Invoke(new GetpProcessOvenLS12Cbm(), new OvenBarcodeVo() { Model = model_cbm.Text, });
            process_cbm.DisplayMember = "Process";
            process_cbm.DataSource = linelVo.GetList();
            process_cbm.Text = "";
        }
        
        
        private void line_cbm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
