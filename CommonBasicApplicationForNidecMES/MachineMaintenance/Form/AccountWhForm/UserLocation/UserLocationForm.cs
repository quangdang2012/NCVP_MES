using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.UserLocationMasterCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.UserLocation
{
    public partial class UserLocationForm : FormCommonNCVP
    {
        public UserLocationForm()
        {
            InitializeComponent();
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            UserLocationCode_txt.Text = string.Empty;

            UserLocationName_txt.Text = string.Empty;

            UserLocationDetails_dgv.DataSource = null;

            UserLocationCode_txt.Select();
        }
        private void GridBind()
        {
            UserLocationDetails_dgv.DataSource = null;
            try
            {
              
                UserLocationVo vo = new UserLocationVo
                {
                    UserLocationCode = UserLocationCode_txt.Text,
                    
                    UserLocationName = UserLocationName_txt.Text
                };

                ValueObjectList<UserLocationVo> volist = (ValueObjectList<UserLocationVo>)DefaultCbmInvoker.Invoke(new GetUserLocationCbm(), vo);
                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    UserLocationDetails_dgv.AutoGenerateColumns = false;
                    BindingSource bindingsource = new BindingSource(volist.GetList(), null);
                    UserLocationDetails_dgv.DataSource = bindingsource;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                UserLocationDetails_dgv.ClearSelection();
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
            AddUserLocationForm Formadd = new AddUserLocationForm();
            Formadd.vo = new UserLocationVo();
            if (Formadd.ShowDialog() == DialogResult.OK)
            {
                GridBind();
            }
        }
        private void Update_btn_Click(object sender, EventArgs e)
        {

            if (UserLocationDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }
        private void BindUpdateCavityData()
        {
            int selectedrowindex = UserLocationDetails_dgv.SelectedCells[0].RowIndex;

            UserLocationVo vo = (UserLocationVo)UserLocationDetails_dgv.Rows[selectedrowindex].DataBoundItem;

            AddUserLocationForm addform = new AddUserLocationForm();
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
            if (UserLocationDetails_dgv.SelectedRows.Count > 0)
            {
                int selectedrowindex = UserLocationDetails_dgv.SelectedCells[0].RowIndex;

                UserLocationVo vo = (UserLocationVo)UserLocationDetails_dgv.Rows[selectedrowindex].DataBoundItem;

                messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, vo.UserLocationCode);
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        UserLocationVo outVo = (UserLocationVo)DefaultCbmInvoker.Invoke(new DeleteUserLocationCbm(), vo);

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

        private void UserLocationDetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Update_btn.Enabled = Delete_btn.Enabled = UserLocationDetails_dgv.SelectedRows.Count > 0;
        }

        private void UserLocationDetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (UserLocationDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }
    }
}
