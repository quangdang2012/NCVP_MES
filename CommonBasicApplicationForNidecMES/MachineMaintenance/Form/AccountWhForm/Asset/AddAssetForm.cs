using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.AssetMasterCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.Asset
{
    public partial class AddAssetForm : FormCommonNCVP
    {
        public AddAssetForm()
        {
            InitializeComponent();
        }
        public AssetVo vo = null;
        public int IntSuccess = -1;

        private void AddAssetForm_Load(object sender, EventArgs e)
        {
            AssetCode_txt.Select();
            if (vo.AssetId > 0)
            {
                AssetCode_txt.Text = vo.AssetCode;
                (AssetNo_txt.Text) = vo.AssetNo.ToString();
                AssetName_txt.Text = vo.AssetName;
                AssetModel_txt.Text = vo.AssetModel;
                AssetSupplier_txt.Text = vo.AssetSuppiler;
                AssetType_txt.Text = vo.AssetType;
                AssetInvoice_txt.Text = vo.AssetInvoice;
                Asset_PO_txt.Text = vo.AssetPO;
                AssetSerial_txt.Text = vo.AssetSerial;
                (AssetLife_txt.Text) = vo.AssetLife.ToString();
                Asset_Acquistion_Cost_txt.Text = vo.AcquistionCost.ToString();
                Asset_Acquistion_Date_dtp.Value = vo.AcquistionDate;
                AssetCode_txt.Enabled = false;
                AssetType_txt.Enabled = false;
                
                switch (vo.LabelStatus)
                {
                    case "Pasted":
                        Pasted_rdb.Checked = true;
                        break;
                    case "Not Paste":
                        NotPaste_rdb.Checked = true;
                        break;
                    default:
                        CannotPaste_rdb.Checked = true;
                        break;
                }
                    
                this.TitleText = Com.Nidec.Mes.GlobalMasterMaintenance.CommonConstants.MODE_UPDATE;

            }
            else
            {
                this.TitleText = Com.Nidec.Mes.GlobalMasterMaintenance.CommonConstants.MODE_ADD;
            }
        }
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkdate())
                {
                    AssetVo outvo = new AssetVo();
                    string lbStatus;
                    if (Pasted_rdb.Checked == true)
                    {
                        lbStatus = Pasted_rdb.Text;
                    }
                    else if (NotPaste_rdb.Checked == true)
                    {
                        lbStatus = NotPaste_rdb.Text;
                    }
                    else lbStatus = CannotPaste_rdb.Text;

                    AssetVo invo = new AssetVo
                    {
                        AssetId = vo.AssetId,
                        AssetNo = int.Parse(AssetNo_txt.Text),
                        AssetCode = AssetCode_txt.Text,
                        AssetName = AssetName_txt.Text,
                        AssetModel = AssetModel_txt.Text,
                        AssetSerial = AssetInvoice_txt.Text,
                        AssetInvoice = AssetInvoice_txt.Text,
                        AssetPO = Asset_PO_txt.Text,
                        AssetLife = double.Parse(AssetLife_txt.Text),
                        AcquistionDate = Asset_Acquistion_Date_dtp.Value,
                        AcquistionCost = double.Parse(Asset_Acquistion_Cost_txt.Text),
                        AssetSuppiler = AssetSupplier_txt.Text,
                        AssetType = AssetType_txt.Text,
                        FactoryCode = UserData.GetUserData().FactoryCode,
                        RegistrationUserCode = UserData.GetUserData().UserCode,
                        LabelStatus = lbStatus                        
                    };
                    try
                    {
                        if (invo.AssetId > 0)
                        {
                            outvo = (AssetVo)DefaultCbmInvoker.Invoke(new UpdateAssetCbm(), invo);
                        }
                        else
                        {

                            outvo = (AssetVo)DefaultCbmInvoker.Invoke(new AddAssetCbm(), invo);
                        }
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, AssetCode_lbl.Text + " : " + AssetCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);

                    }
                    catch (Framework.ApplicationException exception)
                    {
                        popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                        logger.Error(exception.GetMessageData());
                        return;
                    }
                    if ((IntSuccess > 0) || (IntSuccess == 0))
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }
        }
        private bool checkdate()
        {

            if (AssetCode_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, AssetCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                AssetCode_txt.Focus();
                return false;
            }
            if (AssetName_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, AssetName_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                AssetName_txt.Focus();
                return false;
            }
            if (AssetModel_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, AssetModel_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                AssetModel_txt.Focus();
                return false;
            }
            if (AssetSupplier_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, AssetSupplier_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                AssetSupplier_txt.Focus();
                return false;
            }
            if (AssetInvoice_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, AssetInvoice_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                AssetInvoice_txt.Focus();
                return false;
            }
            if (AssetLife_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, Life_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                AssetLife_txt.Focus();
                return false;
            }
            if (Asset_Acquistion_Cost_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, Acquistion_Cost_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                Asset_Acquistion_Cost_txt.Focus();
                return false;
            }
            if (AssetNo_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, AssetNo_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                AssetNo_txt.Focus();
                return false;
            }
            if (Asset_Acquistion_Date_dtp.Value > DateTime.Now)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, Acquistion_Date_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                Asset_Acquistion_Date_dtp.Focus();
                return false;
            }

            AssetCode_txt.Text = AssetCode_txt.Text.Trim();
            AssetNo_txt.Text = AssetNo_txt.Text.Trim();
            AssetName_txt.Text = AssetName_txt.Text.Trim();
            AssetModel_txt.Text = AssetModel_txt.Text.Trim();
            AssetSupplier_txt.Text = AssetSupplier_txt.Text.Trim();
            AssetInvoice_txt.Text = AssetInvoice_txt.Text.Trim();
            AssetSerial_txt.Text = AssetSerial_txt.Text.Trim();
            AssetLife_txt.Text = AssetLife_txt.Text.Trim();
            Asset_Acquistion_Cost_txt.Text = Asset_Acquistion_Cost_txt.Text.Trim();
            AssetVo outVo = new AssetVo(), inVo = new AssetVo { AssetNo = int.Parse(AssetNo_txt.Text), AssetCode = AssetCode_txt.Text };
            try
            {
                outVo = (AssetVo)DefaultCbmInvoker.Invoke(new CheckAssetCbm(), inVo);
                if (outVo.AffectedCount == 1)
                {
                    messageData = new MessageData("mmce00001", AssetCode_lbl.Text + " : " + AssetCode_txt.Text + " is duplicate !", AssetCode_lbl.Text + " : " + AssetCode_txt.Text);
                    logger.Warn(messageData);
                    popUpMessage.Information(messageData, Text);
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

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AssetCode_txt_TextChanged(object sender, EventArgs e)
        {

        }
        public void AssetTrim()
        {
            string str = AssetCode_txt.Text;
            string[] arrListStr = str.Split(',');
            AssetCode_txt.Text = arrListStr[0];
            AssetName_txt.Text = arrListStr[1];
            AssetModel_txt.Text = arrListStr[2];
            AssetSerial_txt.Text = arrListStr[3];
            AssetInvoice_txt.Text = arrListStr[4];
        }

        private void AssetName_txt_Click(object sender, EventArgs e)
        {

            if (AssetCode_txt.TextLength >10)
            {
                string textcheck = (AssetCode_txt.Text.Substring(0, 2));
                AssetTrim();
                if ((AssetCode_txt.Text.Substring(0, 1) == "M") && textcheck != "MC")
                {
                    AssetType_txt.Text = "MC_AST";
                }
                else if ((AssetCode_txt.Text.Substring(0, 1) == "E") && textcheck != "EQ")
                {

                    AssetType_txt.Text = "EQ_AST";
                }
                else if ((AssetCode_txt.Text.Substring(0, 1) == "J") && textcheck != "JG")
                {

                    AssetType_txt.Text = "JG_AST";
                }
                else if (textcheck == "MC")
                {
                    AssetType_txt.Text = "MC";
                }

                else if ((textcheck == "EQ"))
                {
                    AssetType_txt.Text = "EQ";

                }
                else if ((textcheck == "EE"))
                {
                    //tool new
                    AssetType_txt.Text = "EE";
                }
                else if ((textcheck == "EM"))
                {
                    //co
                    AssetType_txt.Text = "EM";
                }
                else if ((textcheck == "EA"))
                {
                    // khi
                    AssetType_txt.Text = "EA";
                }
                else if ((textcheck == "TL"))
                {
                    // khi
                    AssetType_txt.Text = "TL";
                }
                else if ((textcheck == "JG"))
                {
                    // khi
                    AssetType_txt.Text = "JG";
                }
                else
                {
                    AssetType_txt.Text = "";
                    AssetType_txt.Enabled = true;
                }
            }

        }

        private void AssetLife_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}