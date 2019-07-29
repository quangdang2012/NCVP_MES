using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class SapUserMasterForm
    {

        #region Variables
        

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(SapUserMasterForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// initialize SortOrder
        /// </summary>
        private SortOrder sortDirection;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public SapUserMasterForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// For binding combo box
        /// </summary>
        /// <param name="pCombo"></param>
        /// <param name="pDatasource"></param>
        /// <param name="pDisplay"></param>
        /// <param name="pValue"></param>
        private void ComboBind<T>(ComboBox pCombo, List<T> pDatasource, string pDisplay, string pValue)
        {
            pCombo.DataSource = pDatasource;
            pCombo.DisplayMember = pDisplay;
            pCombo.ValueMember = pValue;
            pCombo.SelectedIndex = -1;
            pCombo.Text = string.Empty;
        }

        /// <summary>
        /// Loads Process Work
        /// </summary>
        private void LoadMesUser()
        {
            UserVo outVo = new UserVo();

            try
            {
                outVo = (UserVo)base.InvokeCbm(new GetUserMasterMntCbm(), new UserVo(), false);
                outVo.UserListVo.ForEach(u => u.UserName = u.UserCode + " " + u.UserName);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }

            ComboBind(UserName_cmb, outVo.UserListVo.OrderBy(u => u.UserName).ToList(), "UserName", "UserCode");
        }

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(SapUserVo conditionInVo)
        {
            SapUserdetails_dgv.DataSource = null;

            try
            {
                SapUserVo outVo = (SapUserVo)InvokeCbm(new GetSapUsersMasterMntCbm(), conditionInVo, false);

                SapUserdetails_dgv.AutoGenerateColumns = false;

                BindingSource bindingSource1 = new BindingSource(outVo.SapUserListVo, null);

                if (bindingSource1.Count > 0)
                {
                    SapUserdetails_dgv.DataSource = bindingSource1;
                    colSapUserId.SortMode = DataGridViewColumnSortMode.Automatic;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //Sap user
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                SapUserdetails_dgv.ClearSelection();

                Update_btn.Enabled = false;

                Delete_btn.Enabled = false;
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// Creates seacrh condition as per user inputs 
        /// </summary>
        /// <returns>search condition</returns>
        private SapUserVo FormConditionVo()
        {
            SapUserVo inVo = new SapUserVo();

            if (SapUserName_txt.Text != string.Empty) { inVo.SapUser = SapUserName_txt.Text.Trim(); }

            if (UserName_cmb.SelectedIndex > -1) { inVo.MesUserCode = UserName_cmb.SelectedValue.ToString(); }

            return inVo;

        }                

        /// <summary>
        /// Gets user data selected for update from Gridview
        /// </summary>
        /// <returns>Selected user record</returns>
        private DataGridViewRow GetSelectedUserData()
        {
            int selectedrowindex = SapUserdetails_dgv.SelectedCells[0].RowIndex;

            return SapUserdetails_dgv.Rows[selectedrowindex];
        }


        /// <summary>
        /// selects user record for updation and show user form
        /// </summary>
        private void BindUpdateUserData()
        {
            DataGridViewRow selectedUser = GetSelectedUserData();

            SapUserVo userUpdateVo = (SapUserVo)selectedUser.DataBoundItem;

            AddSapUserMasterForm newAddForm = new AddSapUserMasterForm(CommonConstants.MODE_UPDATE, userUpdateVo);

            newAddForm.ShowDialog(this);

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                GridBind(FormConditionVo());
            }
            else if (newAddForm.IntSuccess == 0)
            {
                messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                GridBind(FormConditionVo());
            }
        }

        /// <summary>
        /// binds datasource
        /// </summary>
        /// <param name="outVo"></param>
        private void BindDataSource(List<SapUserVo> outVo)
        {
            SapUserdetails_dgv.AutoGenerateColumns = false;
            BindingSource bindingSource1 = new BindingSource(outVo, null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                SapUserdetails_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            SapUserdetails_dgv.ClearSelection();
        }

        #endregion

        #region FormEvents

        /// <summary>
        /// Loads UserMasterMaintenanceForm
        /// Fill Country combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SapUserMasterForm_Load(object sender, EventArgs e)
        {
            LoadMesUser();            

            UserName_cmb.Select();

            Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        #endregion

        #region ButtonClick

        /// <summary>
        /// event to clear the controls of search criteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            SapUserName_txt.Text = string.Empty;

            UserName_cmb.SelectedIndex = -1;

            SapUserdetails_dgv.DataSource = null;

            UserName_cmb.Select();
            Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        /// <summary>
        /// event to get the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind(FormConditionVo());
        }

        /// <summary>
        /// event to open the  add screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddSapUserMasterForm newAddForm = new AddSapUserMasterForm(CommonConstants.MODE_ADD);

            newAddForm.ShowDialog();

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00001", Properties.Resources.mmci00001, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                GridBind(FormConditionVo());
            }
        }

        /// <summary>
        /// event to open the  updatescreen 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            BindUpdateUserData();
        }

        /// <summary>
        /// event to delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {

            int selectedrowindex = SapUserdetails_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = SapUserdetails_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colSapUserId"].Value.ToString());

            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                SapUserVo inVo = new SapUserVo
                {
                    SapUserId = Convert.ToInt32(selectedRow.Cells["colSapUserId"].Value),                    
                };

                try
                {
                    SapUserVo outVo = (SapUserVo)InvokeCbm(new DeleteSapUserMasterMntCbm(), inVo, false);

                    if (outVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);

                        GridBind(FormConditionVo());
                    }
                    else if (outVo.AffectedCount == 0)
                    {
                        messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                        GridBind(FormConditionVo());
                    }
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                }
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                //do something else
            }
        }

        /// <summary>
        /// close form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region ControlEvents                     

        /// <summary>
        /// Handles user record selection for Update/Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SapUserdetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SapUserdetails_dgv.SelectedRows.Count > 0)
            {
                Update_btn.Enabled = Delete_btn.Enabled = true;
            }
            else
            {
                Update_btn.Enabled = Delete_btn.Enabled = false;
            }
        }

        /// <summary>
        /// Handles update user form show on row double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SapUserdetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SapUserdetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateUserData();
            }
        }

        /// <summary>
        /// SapUserdetails_dgv ColumnHeaderMouseClick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SapUserdetails_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = SapUserdetails_dgv.Columns[e.ColumnIndex];

            if (SapUserdetails_dgv.DataSource == null) { return; }

            BindingSource currentDatagridSource = (BindingSource)SapUserdetails_dgv.DataSource;

            List<SapUserVo> dataSourceVo = (List<SapUserVo>)currentDatagridSource.DataSource;

            if (!string.IsNullOrEmpty(column.DataPropertyName) && dataSourceVo.Count > 0 &&
                                                   column.CellType != typeof(DataGridViewButtonCell))
            {
                switch (sortDirection)
                {
                    case SortOrder.None:
                        sortDirection = SortOrder.Ascending;
                        break;
                    case SortOrder.Ascending:
                        sortDirection = SortOrder.Descending;
                        break;
                    case SortOrder.Descending:
                        sortDirection = SortOrder.Ascending;
                        break;
                }

                if (sortDirection == SortOrder.Ascending)
                {
                    dataSourceVo = dataSourceVo.OrderBy(t => t.GetType().GetProperty(column.DataPropertyName).GetValue(t)).ToList();
                }
                else if (sortDirection == SortOrder.Descending)
                {
                    dataSourceVo = dataSourceVo.OrderByDescending(t => t.GetType().GetProperty(column.DataPropertyName).GetValue(t)).ToList();
                }

                BindDataSource(dataSourceVo);
                SapUserdetails_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;
            }
        }

        #endregion
        
    }

}

