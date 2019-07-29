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
    public partial class ProdutionWorkContentTypeForm : FormCommonMaster
    {
        public ProdutionWorkContentTypeForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(ProdutionWorkContentTypeForm));

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            ProdutionWorkContentTypeCode_txt.Text = string.Empty;

            ProdutionWorkContentTypeName_txt.Text = string.Empty;

            ProdutionWorkContentType_dgv.DataSource = null;

            Delete_btn.Enabled = Update_btn.Enabled = false;

            ProdutionWorkContentTypeCode_txt.Select();
        }
        private void GridBind()
        {
            ProdutionWorkContentType_dgv.DataSource = null;

            try
            {
                ProdutionWorkContentTypeVo vo = new Vo.ProdutionWorkContentTypeVo
                {
                    ProdutionWorkContentTypeCode = ProdutionWorkContentTypeCode_txt.Text,
                    ProdutionWorkContentTypeName = ProdutionWorkContentTypeName_txt.Text
                };
                ValueObjectList<ProdutionWorkContentTypeVo> volist = (ValueObjectList<ProdutionWorkContentTypeVo>)base.InvokeCbm(new GetProdutionWorkContentTypeCbm(), vo, false);
                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    ProdutionWorkContentType_dgv.AutoGenerateColumns = false;
                    BindingSource bindingSource1 = new BindingSource(volist.GetList(), null);
                    ProdutionWorkContentType_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                ProdutionWorkContentType_dgv.ClearSelection();

                Update_btn.Enabled = false;

                Delete_btn.Enabled = false;
            }
            catch (Com.Nidec.Mes.Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddProdutionWorkContentTypeForm newAddForm = new AddProdutionWorkContentTypeForm();
            newAddForm.vo = new ProdutionWorkContentTypeVo();
            if (newAddForm.ShowDialog() == DialogResult.OK)
            {
                messageData = new MessageData("mmci00001", Properties.Resources.mmci00001, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                GridBind();
            }
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (ProdutionWorkContentType_dgv.SelectedRows.Count > 0)
            {
                UpdateWorkContentType();
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (ProdutionWorkContentType_dgv.SelectedRows.Count > 0)
            {
                int selectedrowindex = ProdutionWorkContentType_dgv.SelectedCells[0].RowIndex;

                ProdutionWorkContentTypeVo vo = (ProdutionWorkContentTypeVo)ProdutionWorkContentType_dgv.Rows[selectedrowindex].DataBoundItem;

                messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, vo.ProdutionWorkContentTypeCode);
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);


                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        ProdutionWorkContentTypeVo outVo = (ProdutionWorkContentTypeVo)base.InvokeCbm(new DeleteProdutionWorkContentTypeCbm(), vo, false);

                        if (outVo.AffectedCount > 0)
                        {
                            messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                            logger.Info(messageData);
                            popUpMessage.Information(messageData, Text);

                            GridBind();
                        }
                        else if (outVo.AffectedCount == 0)
                        {
                            messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                            logger.Info(messageData);
                            popUpMessage.Information(messageData, Text);
                            GridBind();
                        }
                    }
                    catch (Com.Nidec.Mes.Framework.ApplicationException exception)
                    {
                        popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                        logger.Error(exception.GetMessageData());
                    }
                }
            }
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind();
        }

        private void ProdutionWorkContentType_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Update_btn.Enabled = Delete_btn.Enabled = ProdutionWorkContentType_dgv.SelectedRows.Count > 0;
        }

        private void ProdutionWorkContentType_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ProdutionWorkContentType_dgv.SelectedRows.Count > 0)
            {
                UpdateWorkContentType();
            }
        }
        /// <summary>
        /// selects user record for updation and show user form
        /// </summary>
        private void UpdateWorkContentType()
        {
            int selectedrowindex = ProdutionWorkContentType_dgv.SelectedCells[0].RowIndex;
            
            ProdutionWorkContentTypeVo vo = (ProdutionWorkContentTypeVo)ProdutionWorkContentType_dgv.Rows[selectedrowindex].DataBoundItem;

            AddProdutionWorkContentTypeForm addform = new AddProdutionWorkContentTypeForm();
            addform.vo = vo;

            if (addform.ShowDialog() == DialogResult.OK)
            {
                messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                GridBind();
            }
            else if (addform.IntSuccess == 0)
            {
                messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                GridBind();
            }
        }
    }
}
