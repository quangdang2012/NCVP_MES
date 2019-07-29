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
    public partial class AddProdutionWorkContentForm : FormCommonMaster
    {
        public AddProdutionWorkContentForm()
        {
            InitializeComponent();
        }
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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(RoleAuthorityControlForm));

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        public ProdutionWorkContentVo vo;
        public ValueObjectList<ProdutionWorkContentTypeVo> volist;
        private void AddProdutionWorkContentMasterForm_Load(object sender, EventArgs e)
        {
            ProdutionWorkContentType_cmb.DataSource = volist.GetList();
            ProdutionWorkContentType_cmb.DisplayMember = "ProdutionWorkContentTypeName";
            ProdutionWorkContentType_cmb.ValueMember = "ProdutionWorkContentTypeId";
            if (vo.ProdutionWorkContentId > 0)
            {
                ProdutionWorkContentCode_txt.Text = vo.ProdutionWorkContentCode;
                ProdutionWorkContentName_txt.Text = vo.ProdutionWorkContentName;
                DisplayOrder_txt.Text = vo.DisplayOrder.ToString();
                Remark_txt.Text = vo.Remark;
                ProdutionWorkContentType_cmb.Enabled = false;
                ProdutionWorkContentCode_txt.ReadOnly = true;
            }
            else
            {
                DisplayOrder_txt.Enabled = false;
            }
            ProdutionWorkContentType_cmb.SelectedValue = vo.ProdutionWorkContentTypeId;
            ProdutionWorkContentType_cmb.Select();
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
                ProdutionWorkContentVo outVo = new ProdutionWorkContentVo();
                ProdutionWorkContentVo inVo = new ProdutionWorkContentVo
                {
                    ProdutionWorkContentId = vo.ProdutionWorkContentId,
                    ProdutionWorkContentCode = ProdutionWorkContentCode_txt.Text,
                    ProdutionWorkContentName = ProdutionWorkContentName_txt.Text,
                    ProdutionWorkContentTypeId = int.Parse(ProdutionWorkContentType_cmb.SelectedValue.ToString()),
                    Remark = Remark_txt.Text,                    
                };
                
                try
                {
                    int orderid = 0;
                    if (vo.ProdutionWorkContentId == 0)
                    {
                        outVo = (ProdutionWorkContentVo)base.InvokeCbm(new GetProdutionWorkContentNewOrderCbm(), inVo, false);
                        orderid = outVo.AffectedCount;
                    }
                    else
                    {
                        int.TryParse(DisplayOrder_txt.Text, out orderid);
                    }
                    inVo.DisplayOrder = orderid;
                    if (inVo.ProdutionWorkContentId > 0)
                    { outVo = (ProdutionWorkContentVo)base.InvokeCbm(new UpdateProdutionWorkContentCbm(), inVo, false); }
                    else
                    { outVo = (ProdutionWorkContentVo)base.InvokeCbm(new AddProdutionWorkContentCbm(), inVo, false); }
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
            if (ProdutionWorkContentType_cmb.SelectedValue == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, ProdutionWorkContentType_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                ProdutionWorkContentType_cmb.Focus();
                return false;
            }
            if (ProdutionWorkContentCode_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, ProdutionWorkContentCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                ProdutionWorkContentCode_txt.Focus();
                return false;
            }
            if (ProdutionWorkContentName_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, ProdutionWorkContentName_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                ProdutionWorkContentName_txt.Focus();
                return false;
            }            
            int orderid = 0;
            if(DisplayOrder_txt.Enabled &&!int.TryParse(DisplayOrder_txt.Text,out orderid))
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, DisplayOrder_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                DisplayOrder_txt.Focus();
                return false;
            }
            ProdutionWorkContentCode_txt.Text = ProdutionWorkContentCode_txt.Text.Trim();
            ProdutionWorkContentName_txt.Text = ProdutionWorkContentName_txt.Text.Trim();
            DisplayOrder_txt.Text = DisplayOrder_txt.Text.Trim();
            ProdutionWorkContentVo outVo = new ProdutionWorkContentVo(),
                inVo = new ProdutionWorkContentVo
                {
                    ProdutionWorkContentId = vo.ProdutionWorkContentId,
                    ProdutionWorkContentCode = ProdutionWorkContentCode_txt.Text,
                    ProdutionWorkContentName = ProdutionWorkContentName_txt.Text,
                    DisplayOrder = orderid,
                    ProdutionWorkContentTypeId = int.Parse(ProdutionWorkContentType_cmb.SelectedValue.ToString())
                };

            try
            {
                outVo = (ProdutionWorkContentVo)base.InvokeCbm(new CheckProdutionWorkContentCbm(), inVo, false);
                if (outVo.AffectedCount > 0)
                {
                    messageData = new MessageData("mmcc00006", Properties.Resources.mmcc00006, ProdutionWorkContentCode_lbl.Text+" & "+DisplayOrder_lbl.Text);
                    popUpMessage.Warning(messageData, Text);
                    ProdutionWorkContentCode_txt.Focus();
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
