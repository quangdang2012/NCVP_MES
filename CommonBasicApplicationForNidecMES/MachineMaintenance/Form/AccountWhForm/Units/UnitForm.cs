using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.UnitMasterCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.Units
{
    public partial class UnitForm : FormCommonNCVP
    {
        public UnitForm()
        {
            InitializeComponent();
        }
        private void GridBind()
        {
            UnitDetails_dgv.DataSource = null;
            try
            {
                UnitVo vo = new UnitVo
                {
                    UnitCode = UnitCode_txt.Text,
                    UnitName = UnitName_txt.Text
                };

                ValueObjectList<UnitVo> volist = (ValueObjectList<UnitVo>)DefaultCbmInvoker.Invoke(new GetUnitCbm(), vo);
                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    UnitDetails_dgv.AutoGenerateColumns = false;
                    BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                    UnitDetails_dgv.DataSource = bindingsource;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                UnitDetails_dgv.ClearSelection();
                Update_btn.Enabled = false;
                Delete_btn.Enabled = false;
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        private void UnitForm_Load(object sender, EventArgs e)
        {

        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddUnitForm Formadd = new AddUnitForm();
            Formadd.vo = new UnitVo();
            if (Formadd.ShowDialog() == DialogResult.OK)
            {
                GridBind();
            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            UnitCode_txt.Text = string.Empty;
            UnitName_txt.Text = string.Empty;
            UnitDetails_dgv.DataSource = null;
            Update_btn.Enabled = Delete_btn.Enabled = false;
            UnitCode_txt.Select();

        }
        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (UnitDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }
        private void BindUpdateCavityData()
        {
            int selectedrowindex = UnitDetails_dgv.SelectedCells[0].RowIndex;

            UnitVo vo = (UnitVo)UnitDetails_dgv.Rows[selectedrowindex].DataBoundItem;

            AddUnitForm addform = new AddUnitForm();
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
            if (UnitDetails_dgv.SelectedRows.Count > 0)
            {
                int selectedrowindex = UnitDetails_dgv.SelectedCells[0].RowIndex;

                UnitVo vo = (UnitVo)UnitDetails_dgv.Rows[selectedrowindex].DataBoundItem;

                messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, vo.UnitCode);
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        UnitVo outVo = (UnitVo)DefaultCbmInvoker.Invoke(new DeleteUnitCbm(), vo);

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

        private void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind();
        }

        private void UnitDetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Update_btn.Enabled = Delete_btn.Enabled = UnitDetails_dgv.SelectedRows.Count > 0;
        }

        private void UnitDetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (UnitDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }
    }
}
