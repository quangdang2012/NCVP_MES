using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.RankMasterCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.Rank
{
    public partial class RankForm : FormCommonNCVP
    {
        public RankForm()
        {
            InitializeComponent();
        }
        private void GridBind()
        {
            RankDetails_dgv.DataSource = null;
            try
            {
                RankVo vo = new RankVo
                {
                    RankCode = RankCode_txt.Text,
                    RankName = RankName_txt.Text
                };

                ValueObjectList<RankVo> volist = (ValueObjectList<RankVo>)DefaultCbmInvoker.Invoke(new GetRankCbm(), vo);
                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    RankDetails_dgv.AutoGenerateColumns = false;
                    BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                    RankDetails_dgv.DataSource = bindingsource;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                RankDetails_dgv.ClearSelection();
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
            AddRankForm Formadd = new AddRankForm();
            Formadd.vo = new RankVo();
            if (Formadd.ShowDialog() == DialogResult.OK)
            {
                GridBind();
            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {

            RankCode_txt.Text = string.Empty;
            RankName_txt.Text = string.Empty;
            RankDetails_dgv.DataSource = null;
            Update_btn.Enabled = Delete_btn.Enabled = false;
            RankCode_txt.Select();

        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (RankDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }
        private void BindUpdateCavityData()
        {
            int selectedrowindex = RankDetails_dgv.SelectedCells[0].RowIndex;

            RankVo vo = (RankVo)RankDetails_dgv.Rows[selectedrowindex].DataBoundItem;

            AddRankForm addform = new AddRankForm();
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
            if (RankDetails_dgv.SelectedRows.Count > 0)
            {
                int selectedrowindex = RankDetails_dgv.SelectedCells[0].RowIndex;

                RankVo vo = (RankVo)RankDetails_dgv.Rows[selectedrowindex].DataBoundItem;

                messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, vo.RankCode);
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        RankVo outVo = (RankVo)DefaultCbmInvoker.Invoke(new DeleteRankCbm(), vo);

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
            Update_btn.Enabled = Delete_btn.Enabled = RankDetails_dgv.SelectedRows.Count > 0;
        }

        private void RankDetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (RankDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }
    }
}
