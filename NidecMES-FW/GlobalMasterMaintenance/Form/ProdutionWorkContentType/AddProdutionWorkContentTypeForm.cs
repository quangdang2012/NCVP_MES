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
    public partial class AddProdutionWorkContentTypeForm : FormCommonMaster
    {
        public AddProdutionWorkContentTypeForm()
        {
            InitializeComponent();
        }
        public ProdutionWorkContentTypeVo vo = null;
        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddProdutionWorkContentTypeForm));

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();
        private void AddProdutionWorkContentTypeMasterForm_Load(object sender, EventArgs e)
        {
            if (vo.ProdutionWorkContentTypeId > 0)
            {
                ProdutionWorkContentTypeCode_txt.Text = vo.ProdutionWorkContentTypeCode;
                ProdutionWorkContentTypeName_txt.Text = vo.ProdutionWorkContentTypeName;
            }
            ProdutionWorkContentTypeCode_txt.Select();
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
                ProdutionWorkContentTypeVo outVo = new ProdutionWorkContentTypeVo();
                ProdutionWorkContentTypeVo inVo = new ProdutionWorkContentTypeVo
                {
                    ProdutionWorkContentTypeId = vo.ProdutionWorkContentTypeId,
                    ProdutionWorkContentTypeCode = ProdutionWorkContentTypeCode_txt.Text,
                    ProdutionWorkContentTypeName = ProdutionWorkContentTypeName_txt.Text,                    
                };
                try
                {
                    if (inVo.ProdutionWorkContentTypeId > 0)
                    { outVo = (ProdutionWorkContentTypeVo)base.InvokeCbm(new UpdateProdutionWorkContentTypeCbm(), inVo, false); }
                    else
                    { outVo = (ProdutionWorkContentTypeVo)base.InvokeCbm(new AddProdutionWorkContentTypeCbm(), inVo, false); }
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
            if (ProdutionWorkContentTypeCode_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, ProdutionWorkContentTypeCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                ProdutionWorkContentTypeCode_txt.Focus();
                return false;
            }
            if (ProdutionWorkContentTypeName_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, ProdutionWorkContentTypeName_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                ProdutionWorkContentTypeName_txt.Focus();
                return false;
            }
            ProdutionWorkContentTypeCode_txt.Text = ProdutionWorkContentTypeCode_txt.Text.Trim();
            ProdutionWorkContentTypeName_txt.Text = ProdutionWorkContentTypeName_txt.Text.Trim();
            ProdutionWorkContentTypeVo outVo = new ProdutionWorkContentTypeVo(),
                inVo = new ProdutionWorkContentTypeVo { ProdutionWorkContentTypeId = vo.ProdutionWorkContentTypeId, ProdutionWorkContentTypeCode = ProdutionWorkContentTypeCode_txt.Text };
            try
            {
                outVo = (ProdutionWorkContentTypeVo)base.InvokeCbm(new CheckProdutionWorkContentTypeCbm(), inVo, false);
                if (outVo.AffectedCount > 0)
                {
                    messageData = new MessageData("mmcc00006", Properties.Resources.mmcc00006, ProdutionWorkContentTypeCode_lbl.Text);
                    popUpMessage.Warning(messageData, Text);
                    ProdutionWorkContentTypeCode_txt.Focus();
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
