using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class RoleForm
    {

        #region Variables
        
        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(RoleForm));

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
        public RoleForm()
        {
            InitializeComponent();
        }
        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(RoleVo conditionInVo)
        {
            RoleData_dgv.DataSource = null;

            try
            {
                RoleVo outVo = (RoleVo)base.InvokeCbm(new GetRoleMasterMntCbm(), conditionInVo, false);

                RoleData_dgv.AutoGenerateColumns = false;
                BindingSource bindingSource1 = new BindingSource(outVo.RoleListVo, null);

                if (bindingSource1.Count > 0)
                {
                    RoleData_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //role
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                RoleData_dgv.ClearSelection();

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
        private RoleVo FormConditionVo()
        {
            RoleVo inVo = new RoleVo();

            if (RoleCode_txt.Text != string.Empty)
            {
                inVo.RoleCode = RoleCode_txt.Text;
            }

            if (RoleName_txt.Text != string.Empty)
            {
                inVo.RoleName = RoleName_txt.Text;
            }

            return inVo;
        }

        /// <summary>
        /// selects user record for updation and show user form
        /// </summary>
        private void BindUpdateUserData()
        {
            int selectedrowindex = RoleData_dgv.SelectedCells[0].RowIndex;

            RoleVo selectedData = (RoleVo)RoleData_dgv.Rows[selectedrowindex].DataBoundItem;

            AddRoleForm newAddForm = new AddRoleForm(CommonConstants.MODE_UPDATE, selectedData);

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
        private void BindDataSource(List<RoleVo> outVo)
        {
            RoleData_dgv.AutoGenerateColumns = false;
            BindingSource bindingSource1 = new BindingSource(outVo, null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                RoleData_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("tpci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            RoleData_dgv.ClearSelection();
        }

        /// <summary>
        /// checks role relation to other tables in DB
        /// </summary>
        /// <param name="rolVo"></param>
        /// <returns></returns>
        private RoleVo CheckRelation(RoleVo rolVo)
        {
            RoleVo outVo = new RoleVo();

            try
            {
                outVo = (RoleVo)base.InvokeCbm(new CheckRoleRelationCbm(), rolVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }
        #endregion

        #region FormEvents
        /// <summary>
        /// form loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoleForm_Load(object sender, EventArgs e)
        {
            Update_btn.Enabled = Delete_btn.Enabled = false;
            RoleCode_txt.Select();
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
            RoleCode_txt.Text = string.Empty;
            RoleName_txt.Text = string.Empty;
            RoleData_dgv.DataSource = null;
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
            AddRoleForm newAddForm = new AddRoleForm(CommonConstants.MODE_ADD, null);

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
            int selectedrowindex = RoleData_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = RoleData_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colRoleCode"].Value.ToString());
            // Logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);
            // DialogResult dialogResult = MessageBox.Show("Are you sure want to delete the role = " + selectedRow.Cells["colRoleCode"].Value.ToString(), "", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.OK)
            {
                RoleVo inVo = new RoleVo
                {
                    RoleCode = selectedRow.Cells["colRoleCode"].Value.ToString()
                };

                try
                {
                    RoleVo checkVo = CheckRelation(inVo);

                    if (checkVo != null)
                    {
                        StringBuilder message = new StringBuilder();

                        if (checkVo.UserCount > 0)
                        {
                            message.Append(RoleRelationTables.UserRole);
                        }

                        if (checkVo.AuthorityCount > 0)
                        {
                            if (message.Length > 0)
                            {
                                message.Append(" And ");
                            }

                            message.Append(RoleRelationTables.RoleAuthorityControl);
                        }

                        if (message.Length > 0)
                        {
                            messageData = new MessageData("mmce00007", Properties.Resources.mmce00007, message.ToString());
                            popUpMessage.Information(messageData, Text);
                            return;
                        }
                    }

                    RoleVo outVo = (RoleVo)base.InvokeCbm(new DeleteRoleMasterMntCbm(), inVo, false);

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
            this.Close();
        }

        #endregion

        #region ControlEvents

        /// <summary>
        /// Handles user record selection for Update/Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoleData_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (RoleData_dgv.SelectedRows.Count > 0)
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
        private void RoleData_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (RoleData_dgv.SelectedRows.Count > 0)
            {
                BindUpdateUserData();
            }
        }
       
        /// <summary>
        /// sorting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoleData_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = RoleData_dgv.Columns[e.ColumnIndex];

            if (RoleData_dgv.DataSource == null) { return; }

            BindingSource currentDatagridSource = (BindingSource)RoleData_dgv.DataSource;

            List<RoleVo> dataSourceVo = (List<RoleVo>)currentDatagridSource.DataSource;

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
                RoleData_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;
            }
        }

        #endregion
    }

    public enum RoleRelationTables
    {
        UserRole = 0,
        RoleAuthorityControl = 1
    }
}
