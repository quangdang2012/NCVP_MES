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
    public partial class AddJigResponseMasterForm : FormCommonNCVP
    {
        public AddJigResponseMasterForm()
        {
            InitializeComponent();
        }

        public JigResponseVo vo = null;
        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        private void AddJigResponseMasterForm_Load(object sender, EventArgs e)
        {
            JigResponseCode_txt.Select();
            if (vo.JigResponseId > 0)
            {
                JigResponseCode_txt.Text = vo.JigResponseCode;
                JigResponseName_txt.Text = vo.JigResponseName;
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
                JigResponseVo outVo = new JigResponseVo();
                JigResponseVo inVo = new JigResponseVo
                {
                    JigResponseId = vo.JigResponseId,
                    JigResponseCode = JigResponseCode_txt.Text,
                    JigResponseName = JigResponseName_txt.Text,
                    FactoryCode = UserData.GetUserData().FactoryCode,
                    RegistrationUserCode = UserData.GetUserData().UserCode
                };
                try
                {
                    if (inVo.JigResponseId > 0)
                    { outVo = (JigResponseVo)DefaultCbmInvoker.Invoke(new UpdateJigResponseCbm(), inVo); }
                    else
                    { outVo = (JigResponseVo)DefaultCbmInvoker.Invoke(new AddJigResponseCbm(), inVo); }
                    IntSuccess = outVo.AffectedCount;
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
            if (JigResponseCode_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, JigResponseCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                JigResponseCode_txt.Focus();
                return false;
            }
            if (JigResponseName_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, JigResponseName_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                JigResponseName_txt.Focus();
                return false;
            }
            JigResponseCode_txt.Text = JigResponseCode_txt.Text.Trim();
            JigResponseName_txt.Text = JigResponseName_txt.Text.Trim();
            JigResponseVo outVo = new JigResponseVo(),
                inVo = new JigResponseVo { JigResponseId = vo.JigResponseId, JigResponseCode = JigResponseCode_txt.Text };
            try
            {
                outVo = (JigResponseVo)DefaultCbmInvoker.Invoke(new CheckJigResponseCbm(), inVo);
                if (outVo.AffectedCount > 0)
                {
                    messageData = new MessageData("mmcc00006", Properties.Resources.mmcc00006, JigResponseCode_lbl.Text);
                    popUpMessage.Warning(messageData, Text);
                    JigResponseCode_txt.Focus();
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
