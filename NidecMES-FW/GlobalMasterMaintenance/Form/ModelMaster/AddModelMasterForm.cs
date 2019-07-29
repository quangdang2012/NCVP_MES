using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddModelMasterForm : FormCommonNCVP
    {
        public AddModelMasterForm()
        {
            InitializeComponent();
        }

        public ModelVo vo = null;
        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        private void AddModelMasterForm_Load(object sender, EventArgs e)
        {
            ModelCode_txt.Select();
            if (vo.ModelId > 0)
            {
                ModelCode_txt.Text = vo.ModelCode;
                ModelName_txt.Text = vo.ModelName;
            }
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            if (CheckDate())
            {
                ModelVo outVo = new ModelVo();
                ModelVo inVo = new ModelVo
                {
                    ModelId = vo.ModelId,
                    ModelCode = ModelCode_txt.Text,
                    ModelName = ModelName_txt.Text,
                    FactoryCode = UserData.GetUserData().FactoryCode,
                    RegistrationUserCode = UserData.GetUserData().UserCode
                };
                try
                {
                    if (inVo.ModelId > 0)
                    { outVo = (ModelVo)DefaultCbmInvoker.Invoke( new UpdateModelCbm(), inVo); }
                    else
                    { outVo = (ModelVo)DefaultCbmInvoker.Invoke(new AddModelCbm(), inVo); }
                }
                catch (Com.Nidec.Mes.Framework.ApplicationException exception)
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

        private bool CheckDate()
        {
            if (ModelCode_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, ModelCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                ModelCode_txt.Focus();
                return false;
            }
            if (ModelName_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, ModelName_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                ModelName_txt.Focus();
                return false;
            }
            ModelCode_txt.Text = ModelCode_txt.Text.Trim();
            ModelName_txt.Text = ModelName_txt.Text.Trim();
            ModelVo outVo = new ModelVo(),
                inVo = new ModelVo { ModelId = vo.ModelId, ModelCode = ModelCode_txt.Text };
            try
            {
                outVo = (ModelVo)DefaultCbmInvoker.Invoke(new CheckModelCbm(), inVo);
                if (outVo.AffectedCount > 0)
                {
                    messageData = new MessageData("mmcc00006", Properties.Resources.mmcc00006, ModelCode_lbl.Text);
                    popUpMessage.Warning(messageData, Text);
                    ModelCode_txt.Focus();
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
    }
}
