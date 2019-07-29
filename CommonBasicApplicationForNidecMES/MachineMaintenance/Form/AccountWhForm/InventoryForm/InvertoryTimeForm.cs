using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.InvertoryTimeCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.InventoryForm
{
    public partial class InvertoryTimeForm : FormCommonNCVP
    {
        public InvertoryTimeForm()
        {
            InitializeComponent();
        }
        private void GridBind()
        {
            InvertoryTimeDetails_dgv.DataSource = null;
            try
            {
                InvertoryVo vo = new InvertoryVo
                {
                    InvertoryTimeCode = InvertoryTimeCode_txt.Text,
                    InvertoryTimeName = InvertoryTimeName_txt.Text
                };

                ValueObjectList<InvertoryVo> volist = (ValueObjectList<InvertoryVo>)DefaultCbmInvoker.Invoke(new GetInvertoryTimeCbm(), vo);
                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    InvertoryTimeDetails_dgv.AutoGenerateColumns = false;
                    BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                    InvertoryTimeDetails_dgv.DataSource = bindingsource;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                InvertoryTimeDetails_dgv.ClearSelection();
                Update_btn.Enabled = false;
                Delete_btn.Enabled = false;
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddInvertoryTimeForm Formadd = new AddInvertoryTimeForm();
            Formadd.vo = new InvertoryVo();
            if (Formadd.ShowDialog() == DialogResult.OK)
            {
                GridBind();
            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {

            InvertoryTimeCode_txt.Text = string.Empty;
            InvertoryTimeName_txt.Text = string.Empty;
            InvertoryTimeDetails_dgv.DataSource = null;
            Update_btn.Enabled = Delete_btn.Enabled = false;
            InvertoryTimeCode_txt.Select();

        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (InvertoryTimeDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }
        private void BindUpdateCavityData()
        {
            int selectedrowindex = InvertoryTimeDetails_dgv.SelectedCells[0].RowIndex;

            InvertoryVo vo = (InvertoryVo)InvertoryTimeDetails_dgv.Rows[selectedrowindex].DataBoundItem;

            AddInvertoryTimeForm addform = new AddInvertoryTimeForm();
            addform.vo = vo;
            addform.ShowDialog();
            if (addform.IntSuccess > 0)
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
        private void Delete_btn_Click(object sender, EventArgs e)
        {

            if (InvertoryTimeDetails_dgv.SelectedRows.Count > 0)
            {
                int selectedrowindex = InvertoryTimeDetails_dgv.SelectedCells[0].RowIndex;

                InvertoryVo vo = (InvertoryVo)InvertoryTimeDetails_dgv.Rows[selectedrowindex].DataBoundItem;

                messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, vo.InvertoryTimeCode);
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        InvertoryVo outVo = (InvertoryVo)DefaultCbmInvoker.Invoke(new DeleteInvertoryTimeCbm(), vo);

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

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RankForm_Load(object sender, EventArgs e)
        {

        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind();
        }

        private void RankDetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Update_btn.Enabled = Delete_btn.Enabled = InvertoryTimeDetails_dgv.SelectedRows.Count > 0;
        }

        private void RankDetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (InvertoryTimeDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }
    }
}
