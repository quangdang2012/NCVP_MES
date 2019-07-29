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
    public partial class UserMasterForm
    {

        #region Variables

        /// <summary>
        /// datatable for countrylanguage data
        /// </summary>
        private DataTable cntryLangDatatable;

        /// <summary>
        /// datatable for factory data
        /// </summary>
        private DataTable factoryDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(UserMasterForm));

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
        public UserMasterForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(UserVo conditionInVo)
        {
            Userdetails_dgv.DataSource = null;

            try
            {
                UserVo outVo = (UserVo)InvokeCbm(new GetUserMasterMntCbm(), conditionInVo, false);

                Userdetails_dgv.AutoGenerateColumns = false;

                outVo.UserListVo.ForEach(t => t.Country = t.Language + "-" + t.Country);

                BindingSource bindingSource1 = new BindingSource(outVo.UserListVo, null);

                if (bindingSource1.Count > 0)
                {
                    Userdetails_dgv.DataSource = bindingSource1;
                    colUserCode.SortMode = DataGridViewColumnSortMode.Automatic;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //user
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                Userdetails_dgv.ClearSelection();

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
        private UserVo FormConditionVo()
        {
            UserVo inVo = new UserVo();

            if (UserCode_txt.Text != string.Empty) { inVo.UserCode = UserCode_txt.Text; }

            if (UserName_txt.Text != string.Empty) { inVo.UserName = UserName_txt.Text; }

            if (Country_cmb.SelectedIndex > -1) { inVo.LocaleId = Convert.ToInt32(Country_cmb.SelectedValue.ToString()); }

            //if (Language_cmb.SelectedIndex > -1) { inVo.Language = Language_cmb.SelectedValue.ToString(); }

            if (FactoryCode_cmb.SelectedIndex > -1) { inVo.RegistrationFactoryCode = FactoryCode_cmb.SelectedValue.ToString(); }

            return inVo;

        }

        /// <summary>
        /// Handles Combobox loading for Country,Language and Factory
        /// </summary>
        /// <param name="pCombo"></param>
        /// <param name="pDatasource"></param>
        /// <param name="pDisplay"></param>
        /// <param name="pValue"></param>
        private void ComboBind(ComboBox pCombo, DataTable pDatasource, string pDisplay, string pValue)
        {
            pCombo.DataSource = pDatasource;
            pCombo.DisplayMember = pDisplay;
            pCombo.ValueMember = pValue;
            pCombo.SelectedIndex = -1;
            pCombo.Text = string.Empty;
        }

        /// <summary>
        /// Gets user data selected for update from Gridview
        /// </summary>
        /// <returns>Selected user record</returns>
        private DataGridViewRow GetSelectedUserData()
        {
            int selectedrowindex = Userdetails_dgv.SelectedCells[0].RowIndex;

            return Userdetails_dgv.Rows[selectedrowindex];
        }

        /// <summary>
        /// binds datasource
        /// </summary>
        /// <param name="outVo"></param>
        private void BindDataSource(List<UserVo> outVo)
        {
            Userdetails_dgv.AutoGenerateColumns = false;
            BindingSource bindingSource1 = new BindingSource(outVo, null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                Userdetails_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("tpci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            Userdetails_dgv.ClearSelection();
        }


        /// <summary>
        /// selects user record for updation and show user form
        /// </summary>
        private void BindUpdateUserData()
        {
            DataGridViewRow selectedUser = GetSelectedUserData();

            UserVo userUpdateVo = (UserVo)selectedUser.DataBoundItem;

            AddUserMasterForm newAddForm = new AddUserMasterForm(CommonConstants.MODE_UPDATE, userUpdateVo);

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
        /// form country and factory data for combo
        /// </summary>
        private void FormDatatableFromVo()
        {
            cntryLangDatatable = new DataTable();
            cntryLangDatatable.Columns.Add("LocaleId");
            cntryLangDatatable.Columns.Add("countrycode");

            factoryDatatable = new DataTable();
            factoryDatatable.Columns.Add("code");
            factoryDatatable.Columns.Add("Name");

            try
            {
                FactoryVo factoryOutVo = (FactoryVo)InvokeCbm(new GetFactoryMasterMntCbm(), new FactoryVo(), false);

                foreach (FactoryVo fac in factoryOutVo.FactoryListVo)
                {
                    factoryDatatable.Rows.Add(fac.FactoryCode, fac.FactoryName);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }


            try
            {
                CountryLanguageVo countryLangOutVo = (CountryLanguageVo)InvokeCbm(new GetCountryLanguageMasterMntCbm(), new CountryLanguageVo(), false);

                foreach (CountryLanguageVo cntry in countryLangOutVo.CountryLangListVo)
                {
                    cntryLangDatatable.Rows.Add(cntry.LocaleId, cntry.Language + "-" + cntry.Country);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// checks User relation to other tables in DB
        /// </summary>
        /// <param name="userVo"></param>
        /// <returns></returns>
        private UserVo CheckRelation(UserVo userVo)
        {
            UserVo outVo = new UserVo();

            try
            {
                outVo = (UserVo)base.InvokeCbm(new CheckUserRelationCbm(), userVo, false);
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
        /// Loads UserMasterMaintenanceForm
        /// Fill Country combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserMasterForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();

            ComboBind(Country_cmb, cntryLangDatatable, "countrycode", "LocaleId");

            ComboBind(FactoryCode_cmb, factoryDatatable, "code", "code");

            UserCode_txt.Select();

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
            UserCode_txt.Text = string.Empty;

            UserName_txt.Text = string.Empty;

            Country_cmb.SelectedIndex = -1;

            //Language_cmb.DataSource = null;

            //Language_cmb.Enabled = false;

            FactoryCode_cmb.SelectedIndex = -1;

            Userdetails_dgv.DataSource = null;

            UserCode_txt.Select();
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
            AddUserMasterForm newAddForm = new AddUserMasterForm(CommonConstants.MODE_ADD);

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

            int selectedrowindex = Userdetails_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = Userdetails_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colUserCode"].Value.ToString());

            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                UserVo inVo = new UserVo
                {
                    UserCode = selectedRow.Cells["colUserCode"].Value.ToString(),
                    RegistrationDateTime = Convert.ToDateTime(DateTime.Now.ToString(UserData.GetUserData().DateTimeFormat)),
                    RegistrationUserCode = UserData.GetUserData().UserCode
                };

                try
                {

                    UserVo checkVo = CheckRelation(inVo);

                    if (checkVo != null)
                    {
                        StringBuilder message = new StringBuilder();

                        if (checkVo.RoleCount > 0)
                        {
                            message.Append(UserRelationTables.UserRole);
                        }

                        if (checkVo.FactoryCount > 0)
                        {
                            if (message.Length > 0)
                            {
                                message.Append(" And ");
                            }

                            message.Append(UserRelationTables.UserFactory);
                        }

                        if (checkVo.ProcessCount > 0)
                        {
                            if (message.Length > 0)
                            {
                                message.Append(" And ");
                            }

                            message.Append(UserRelationTables.UserProcess);
                        }

                        if (message.Length > 0)
                        {
                            messageData = new MessageData("mmce00007", Properties.Resources.mmce00007, message.ToString());
                            popUpMessage.Information(messageData, Text);
                            return;
                        }
                    }

                    UserVo outVo = (UserVo)InvokeCbm(new DeleteUserMasterMntCbm(), inVo, false);

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
        /// Selects Language when choosing a Country in Combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Country_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (iscmbCountryLoading) { return; }

            //if (Country_cmb.SelectedIndex > -1)
            //{
            //    string selectedCountry = Country_cmb.SelectedValue.ToString();

            //    DataRow[] selectLanguage = cntryLangDatatable.Select("countrycode = '" + selectedCountry + "'");

            //    if (selectLanguage.Length != 0)
            //    {
            //        ComboBind(Language_cmb, selectLanguage.CopyToDataTable(), "langcode", "langcode");

            //        Language_cmb.Enabled = true;
            //    }
            //}
        }

        /// <summary>
        /// Handles outof focus of Country Comboxbox
        /// Deselecting Language combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Country_cmb_Leave(object sender, EventArgs e)
        {

            if (Country_cmb.SelectedIndex == -1)
            {
                //Language_cmb.SelectedIndex = -1;

                //Language_cmb.DataSource = null;

                //Language_cmb.Enabled = false;
            }

        }

        /// <summary>
        /// Handles user record selection for Update/Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableDetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Userdetails_dgv.SelectedRows.Count > 0)
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
        private void TableDetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Userdetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateUserData();
            }
        }


        /// <summary>
        /// sorting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Userdetails_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = Userdetails_dgv.Columns[e.ColumnIndex];

            if (Userdetails_dgv.DataSource == null) { return; }

            BindingSource currentDatagridSource = (BindingSource)Userdetails_dgv.DataSource;

            List<UserVo> dataSourceVo = (List<UserVo>)currentDatagridSource.DataSource;

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
                Userdetails_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;
            }
        }
     }
        #endregion

        public enum UserRelationTables
    {
        UserRole = 0,
        UserFactory = 1,
        UserProcess = 2
    }
}

