using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.OvenBarcodeCbm.RangeCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.OvenBarcodeLS12Cbm.RangeLS12Cbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance
{
    public partial class RangeLS12Form : FormCommonNCVP
    {
        public RangeLS12Form()
        {
            InitializeComponent();
        }
        private void GridBind()
        {
            RangeOven_dgv.DataSource = null;
            try
            {
                RangeVo vo = new RangeVo
                {
                    Model = range_model_cbm.Text,
                    Process = range_process_cbm.Text
                };

                ValueObjectList<RangeVo> volist = (ValueObjectList<RangeVo>)DefaultCbmInvoker.Invoke(new SearchRangeLS12Cbm(), vo);
                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    RangeOven_dgv.AutoGenerateColumns = false;
                    BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                    RangeOven_dgv.DataSource = bindingsource;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                RangeOven_dgv.ClearSelection();
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
            AddRangeLS12Form Formadd = new AddRangeLS12Form();
            Formadd.vo = new RangeVo();
            if (Formadd.ShowDialog() == DialogResult.OK)
            {
                GridBind();
            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            RangeOven_dgv.DataSource = null;
            Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (RangeOven_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }
        private void BindUpdateCavityData()
        {
            int selectedrowindex = RangeOven_dgv.SelectedCells[0].RowIndex;

            RangeVo vo = (RangeVo)RangeOven_dgv.Rows[selectedrowindex].DataBoundItem;
            
            AddRangeLS12Form addform = new AddRangeLS12Form();
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

            if (RangeOven_dgv.SelectedRows.Count > 0)
            {
                int selectedrowindex = RangeOven_dgv.SelectedCells[0].RowIndex;

                RangeVo vo = (RangeVo)RangeOven_dgv.Rows[selectedrowindex].DataBoundItem;

                messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, vo.Model + " and process = "+vo.Process);
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        RangeVo outVo = (RangeVo)DefaultCbmInvoker.Invoke(new DeleteRangeCbm(), vo);

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
            ValueObjectList<RangeVo> rangevo = (ValueObjectList<RangeVo>)DefaultCbmInvoker.Invoke(new GetModelRangeLS12Cbm(),new RangeVo());
            range_model_cbm.DisplayMember = "Model";
            range_model_cbm.DataSource = rangevo.GetList();
            range_model_cbm.Text = "";
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind();
        }

        private void RankDetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Update_btn.Enabled = Delete_btn.Enabled = RangeOven_dgv.SelectedRows.Count > 0;
        }

        private void RankDetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (RangeOven_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }

        private void range_model_cbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValueObjectList<RangeVo> rangevo = (ValueObjectList<RangeVo>)DefaultCbmInvoker.Invoke(new GetProcessRangeLS12Cbm(), new RangeVo() { Model = range_model_cbm.Text, });
            range_process_cbm.DisplayMember = "Process";
            range_process_cbm.DataSource = rangevo.GetList();
            range_process_cbm.Text = "";
        }
    }
}
