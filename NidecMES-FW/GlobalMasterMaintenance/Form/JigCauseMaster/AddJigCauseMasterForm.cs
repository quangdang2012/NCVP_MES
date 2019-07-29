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
    public partial class AddJigCauseMasterForm : FormCommonNCVP
    {
        public AddJigCauseMasterForm()
        {
            InitializeComponent();
        }

        public JigCauseVo vo = null;
        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        private void AddJigCauseMasterForm_Load(object sender, EventArgs e)
        {
            JigCauseCode_txt.Select();
            if (vo.JigCauseId > 0)
            {
                JigCauseCode_txt.Text = vo.JigCauseCode;
                JigCauseName_txt.Text = vo.JigCauseName;
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
                JigCauseVo outVo = new JigCauseVo();
                JigCauseVo inVo = new JigCauseVo
                {
                    JigCauseId = vo.JigCauseId,
                    JigCauseCode = JigCauseCode_txt.Text,
                    JigCauseName = JigCauseName_txt.Text,
                    FactoryCode = UserData.GetUserData().FactoryCode,
                    RegistrationUserCode = UserData.GetUserData().UserCode
                };
                try
                {
                    if (inVo.JigCauseId > 0)
                    { outVo = (JigCauseVo)DefaultCbmInvoker.Invoke(new UpdateJigCauseCbm(), inVo); }
                    else
                    { outVo = (JigCauseVo)DefaultCbmInvoker.Invoke(new AddJigCauseCbm(), inVo); }
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
            if (JigCauseCode_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, JigCauseCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                JigCauseCode_txt.Focus();
                return false;
            }
            if (JigCauseName_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, JigCauseName_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                JigCauseName_txt.Focus();
                return false;
            }
            JigCauseCode_txt.Text = JigCauseCode_txt.Text.Trim();
            JigCauseName_txt.Text = JigCauseName_txt.Text.Trim();
            JigCauseVo outVo = new JigCauseVo(),
                inVo = new JigCauseVo { JigCauseId = vo.JigCauseId, JigCauseCode = JigCauseCode_txt.Text };
            try
            {
                outVo = (JigCauseVo)DefaultCbmInvoker.Invoke(new CheckJigCauseCbm(), inVo);
                if (outVo.AffectedCount > 0)
                {
                    messageData = new MessageData("mmcc00006", Properties.Resources.mmcc00006, JigCauseCode_lbl.Text);
                    popUpMessage.Warning(messageData, Text);
                    JigCauseCode_txt.Focus();
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
