using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.PQMConnectCbm.RateNGCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance
{
    public partial class RateNGForm : FormCommonNCVP
    {
        public RateNGForm()
        {
            InitializeComponent();
        }
        private void GridBind()
        {
            RateNG_dgv.DataSource = null;
            try
            {
                RateNGVo vo = new RateNGVo
                {
                    RateCode = RateNGCode_txt.Text,
                };

                RateNGVo volist = (RateNGVo)DefaultCbmInvoker.Invoke(new SearchRateNGCbm(), vo);
                if (volist.dt != null && volist.dt.Rows.Count > 0)
                {
                    RateNG_dgv.DataSource = volist.dt;
                    RateNG_dgv.Columns["rate_ng_id"].Visible = false;
                    RateNG_dgv.Columns["rate_ng_cd"].HeaderText = "Rate Code";
                    RateNG_dgv.Columns["rate_ng_model"].HeaderText = "Model";
                    RateNG_dgv.Columns["rate_ng_line"].HeaderText = "Line";
                    RateNG_dgv.Columns["rate_ng_ratio"].HeaderText = "Ratio";
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                RateNG_dgv.ClearSelection();
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
            AddRateNGForm Formadd = new AddRateNGForm("Add");
            Formadd.vo = new RateNGVo();
            Formadd.ShowDialog();
            GridBind();
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            RateNGCode_txt.Text = string.Empty;
            RateNG_dgv.DataSource = null;
            Update_btn.Enabled = Delete_btn.Enabled = false;
            RateNGCode_txt.Select();
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (RateNG_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }
        private void BindUpdateCavityData()
        {
            int selectedrowindex = RateNG_dgv.CurrentCell.RowIndex;

            AddRateNGForm addform = new AddRateNGForm("Update");
            addform.RatelId = int.Parse(RateNG_dgv.Rows[selectedrowindex].Cells["rate_ng_id"].Value.ToString());
            addform.RateCode = RateNG_dgv.Rows[selectedrowindex].Cells["rate_ng_cd"].Value.ToString();
            addform.RateModel = RateNG_dgv.Rows[selectedrowindex].Cells["rate_ng_model"].Value.ToString();
            addform.RateLine = RateNG_dgv.Rows[selectedrowindex].Cells["rate_ng_line"].Value.ToString();
            addform.RateRatio = RateNG_dgv.Rows[selectedrowindex].Cells["rate_ng_ratio"].Value.ToString();
            addform.ShowDialog();
            GridBind();
        }
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (RateNG_dgv.SelectedRows.Count > 0)
            {
                int selectedrowindex = RateNG_dgv.CurrentCell.RowIndex;

                //RateNGVo vo = (RateNGVo)RateNG_dgv.Rows[selectedrowindex].DataBoundItem;

                messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, RateNG_dgv.Rows[selectedrowindex].Cells["rate_ng_cd"].Value.ToString());
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        RateNGVo outVo = (RateNGVo)DefaultCbmInvoker.Invoke(new DeleteRateNGCbm(), new RateNGVo() { RatelId = int.Parse(RateNG_dgv.Rows[selectedrowindex].Cells["rate_ng_id"].Value.ToString()) });

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
            Update_btn.Enabled = Delete_btn.Enabled = RateNG_dgv.SelectedRows.Count > 0;
        }

        private void RankDetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (RateNG_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }
    }
}
