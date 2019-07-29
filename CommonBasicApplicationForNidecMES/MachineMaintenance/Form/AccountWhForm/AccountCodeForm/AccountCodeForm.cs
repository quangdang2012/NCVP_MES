using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.AccountCodeCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.AccountCodeForm
{
    public partial class AccountCodeForm : FormCommonNCVP
    {
        public AccountCodeForm()
        {
            InitializeComponent();
        }
        private void GridBind()
        {
            AccountDetails_dgv.DataSource = null;
            try
            {
                AccountCodeVo vo = new AccountCodeVo
                {
                    AccountCodeCode = AccountCode_txt.Text,
                    AccountCodeName = AccountName_txt.Text
                };

                ValueObjectList<AccountCodeVo> volist = (ValueObjectList<AccountCodeVo>)DefaultCbmInvoker.Invoke(new GetAccountCodeCbm(), vo);
                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    AccountDetails_dgv.AutoGenerateColumns = false;
                    BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                    AccountDetails_dgv.DataSource = bindingsource;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                AccountDetails_dgv.ClearSelection();
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
          Form.AccountWhForm.AccountCodeForm.AddAccountCodeForm Formadd = new Form.AccountWhForm.AccountCodeForm.AddAccountCodeForm();
            Formadd.vo = new AccountCodeVo();
            if (Formadd.ShowDialog() == DialogResult.OK)
            {
                GridBind();
            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            AccountCode_txt.Text = string.Empty;
            AccountName_txt.Text = string.Empty;
            AccountDetails_dgv.DataSource = null;
            Update_btn.Enabled = Delete_btn.Enabled = false;
            AccountCode_txt.Select();
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (AccountDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }

        }
        private void BindUpdateCavityData()
        {
            int selectedrowindex = AccountDetails_dgv.SelectedCells[0].RowIndex;

            AccountCodeVo vo = (AccountCodeVo)AccountDetails_dgv.Rows[selectedrowindex].DataBoundItem;

            Form.AccountWhForm.AccountCodeForm.AddAccountCodeForm addform = new Form.AccountWhForm.AccountCodeForm.AddAccountCodeForm();
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

            if (AccountDetails_dgv.SelectedRows.Count > 0)
            {
                int selectedrowindex = AccountDetails_dgv.SelectedCells[0].RowIndex;

                AccountCodeVo vo = (AccountCodeVo)AccountDetails_dgv.Rows[selectedrowindex].DataBoundItem;

                messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, vo.AccountCodeCode);
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        AccountCodeVo outVo = (AccountCodeVo)DefaultCbmInvoker.Invoke(new DeleteAccountCodeCbm(), vo);

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

        private void AccountDetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Update_btn.Enabled = Delete_btn.Enabled = AccountDetails_dgv.SelectedRows.Count > 0;
        }

        private void AccountDetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (AccountDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }
    }
}
