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
    public partial class ProdutionWorkContentForm : FormCommonMaster
    {
        public ProdutionWorkContentForm()
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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(ProdutionWorkContentForm));

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();
        ValueObjectList<ProdutionWorkContentTypeVo> volist;
        private void ProdutionWorkContentForm_Load(object sender, EventArgs e)
        {
            try
            {
                volist = (ValueObjectList<ProdutionWorkContentTypeVo>)base.InvokeCbm(new GetProdutionWorkContentTypeCbm(), new ProdutionWorkContentTypeVo(), false);
                ProdutionWorkContentType_cmb.DataSource = volist.GetList();
                ProdutionWorkContentType_cmb.DisplayMember = "ProdutionWorkContentTypeName";
                ProdutionWorkContentType_cmb.ValueMember = "ProdutionWorkContentTypeId";
                ProdutionWorkContentType_cmb.SelectedIndex = -1;
                ProdutionWorkContentType_cmb.Text = string.Empty;
                ProdutionWorkContentCode_txt.Select();


            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            ProdutionWorkContentCode_txt.Select();
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            ProdutionWorkContentCode_txt.Text = string.Empty;

            ProdutionWorkContentName_txt.Text = string.Empty;

            ProdutionWorkContent_dgv.DataSource = null;

            ProdutionWorkContentType_cmb.SelectedIndex = -1;
            ProdutionWorkContentType_cmb.Text = string.Empty;

            Update_btn.Enabled = Delete_btn.Enabled = false;

            ProdutionWorkContentCode_txt.Select();
        }
        private void GridBind()
        {
            ProdutionWorkContent_dgv.DataSource = null;
            try
            {
                ProdutionWorkContentVo vo = new Vo.ProdutionWorkContentVo();

                vo.ProdutionWorkContentCode = ProdutionWorkContentCode_txt.Text;
                vo.ProdutionWorkContentName = ProdutionWorkContentName_txt.Text;
                if (ProdutionWorkContentType_cmb.SelectedIndex > -1)
                {
                    vo.ProdutionWorkContentTypeId = int.Parse(ProdutionWorkContentType_cmb.SelectedValue.ToString());
                }
                ValueObjectList<ProdutionWorkContentVo> volist = (ValueObjectList<ProdutionWorkContentVo>)base.InvokeCbm(new GetProdutionWorkContentCbm(), vo, false);
                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    ProdutionWorkContent_dgv.AutoGenerateColumns = false;
                    BindingSource bindingSource1 = new BindingSource(volist.GetList(), null);
                    ProdutionWorkContent_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                ProdutionWorkContent_dgv.ClearSelection();

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
            AddProdutionWorkContentForm newAddForm = new AddProdutionWorkContentForm();
            newAddForm.vo = new ProdutionWorkContentVo
            {
                ProdutionWorkContentTypeId = ProdutionWorkContentType_cmb.SelectedValue == null ? 0 : int.Parse(ProdutionWorkContentType_cmb.SelectedValue.ToString())
            };
            newAddForm.volist = volist;

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
            if (ProdutionWorkContent_dgv.SelectedRows.Count > 0)
            {
                UpdateWorkContent();
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (ProdutionWorkContent_dgv.SelectedRows.Count > 0)
            {
                int selectedrowindex = ProdutionWorkContent_dgv.SelectedCells[0].RowIndex;

                ProdutionWorkContentVo vo = (ProdutionWorkContentVo)ProdutionWorkContent_dgv.Rows[selectedrowindex].DataBoundItem;

                messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, vo.ProdutionWorkContentCode);
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);


                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        ProdutionWorkContentVo outVo = (ProdutionWorkContentVo)base.InvokeCbm(new DeleteProdutionWorkContentCbm(), vo, false);

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

            //else
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ProdutionWorkContentType_lbl.Text);
            //    logger.Info(messageData);
            //    popUpMessage.Information(messageData, Text);
            //}
        }

        private void ProdutionWorkContent_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Update_btn.Enabled = Delete_btn.Enabled = ProdutionWorkContent_dgv.SelectedRows.Count > 0;
        }

        private void ProdutionWorkContent_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ProdutionWorkContent_dgv.SelectedRows.Count > 0)
            {
                UpdateWorkContent();
            }
        }
        /// <summary>
        /// selects user record for updation and show user form
        /// </summary>
        private void UpdateWorkContent()
        {
            int selectedrowindex = ProdutionWorkContent_dgv.SelectedCells[0].RowIndex;

            ProdutionWorkContentVo vo = (ProdutionWorkContentVo)ProdutionWorkContent_dgv.Rows[selectedrowindex].DataBoundItem;

            AddProdutionWorkContentForm addform = new AddProdutionWorkContentForm();
            addform.vo = vo;
            addform.volist = volist;

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
