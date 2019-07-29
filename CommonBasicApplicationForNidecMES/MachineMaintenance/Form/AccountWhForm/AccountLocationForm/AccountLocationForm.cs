using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.AccountLocationCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.AccountLocationForm
{
    public partial class AccountLocationForm : FormCommonNCVP
    {
        public AccountLocationForm()
        {
            InitializeComponent();
        }
        private void GridBind()
        {
            AccountLocationDetails_dgv.DataSource = null;
            try
            {
                AccountLocationVo vo = new AccountLocationVo
                {
                    AccountLocationCode = AccountLocationCode_txt.Text,
                    AccountLocationName = AccountLocationName_txt.Text
                };

                ValueObjectList<AccountLocationVo> volist = (ValueObjectList<AccountLocationVo>)DefaultCbmInvoker.Invoke(new GetAccountLocationCbm(), vo);
                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    AccountLocationDetails_dgv.AutoGenerateColumns = false;
                    BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                    AccountLocationDetails_dgv.DataSource = bindingsource;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                AccountLocationDetails_dgv.ClearSelection();
                Update_btn.Enabled = false;
                Delete_btn.Enabled = false;
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind();
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            Form.AccountWhForm.AccountLocationForm.AddAccountLocationForm acclForm = new Form.AccountWhForm.AccountLocationForm.AddAccountLocationForm();
            acclForm.vo = new AccountLocationVo();
            if (acclForm.ShowDialog() == DialogResult.OK)
            {
                GridBind();
            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            AccountLocationCode_txt.Text = string.Empty;
            AccountLocationName_txt.Text = string.Empty;
            AccountLocationDetails_dgv.DataSource = null;
            Update_btn.Enabled = Delete_btn.Enabled = false;
            AccountLocationCode_txt.Select();
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (AccountLocationDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }
        private void BindUpdateCavityData()
        {
            int selectedrowindex = AccountLocationDetails_dgv.SelectedCells[0].RowIndex;

            AccountLocationVo vo = (AccountLocationVo)AccountLocationDetails_dgv.Rows[selectedrowindex].DataBoundItem;

            Form.AccountWhForm.AccountLocationForm.AddAccountLocationForm addform = new Form.AccountWhForm.AccountLocationForm.AddAccountLocationForm();
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

            if (AccountLocationDetails_dgv.SelectedRows.Count > 0)
            {
                int selectedrowindex = AccountLocationDetails_dgv.SelectedCells[0].RowIndex;

                AccountLocationVo vo = (AccountLocationVo)AccountLocationDetails_dgv.Rows[selectedrowindex].DataBoundItem;

                messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, vo.AccountLocationCode);
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        AccountLocationVo outVo = (AccountLocationVo)DefaultCbmInvoker.Invoke(new DeleteAccountLocationCbm(), vo);

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

        private void AccountLocationDetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Update_btn.Enabled = Delete_btn.Enabled = AccountLocationDetails_dgv.SelectedRows.Count > 0;
        }

        private void AccountLocationDetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (AccountLocationDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }

        }
    }
}
