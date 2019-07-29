using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.IO;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class LocalUserMasterForm
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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(LocalUserMasterForm));

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
        public LocalUserMasterForm()
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
                UserVo outVo = (UserVo)InvokeCbm(new GetLocalUserMasterMntCbm(), conditionInVo, false);

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

            AddLocalUserMasterForm newAddForm = new AddLocalUserMasterForm(CommonConstants.MODE_UPDATE, userUpdateVo);

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

        /// <summary>
        /// Binds data for excel export
        /// </summary>
        /// <returns></returns>
        private DataTable BindDataForExcel()
        {

            AuthorityControlVo authorityOutVo = null;
            UserVo userOutVo = null;
            UserRoleVo userRoleOutVo = null;

            try
            {
                authorityOutVo = (AuthorityControlVo)DefaultCbmInvoker.Invoke(new GetAuthorityControlMasterMntCbm(), new AuthorityControlVo());

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            try
            {
                userOutVo = (UserVo)DefaultCbmInvoker.Invoke(new GetUserMasterMntCbm(), new UserVo());

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            try
            {
                userRoleOutVo = (UserRoleVo)DefaultCbmInvoker.Invoke(new GetUserAuthorityCbm(), new UserRoleVo());

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            DataTable dt = new DataTable();
            DataRow dr;

            dt.Columns.Add("AuthorityName");
            dt.Columns.Add("SubAuthorityName");
            dt.Columns.Add("FormName");

            if (userOutVo != null && userOutVo.UserListVo.Count > 0)
            {
                foreach (UserVo user in userOutVo.UserListVo)
                {
                    dt.Columns.Add(user.UserCode);
                }

                //dr = dt.NewRow();
                //dr["AuthorityName"] = "Authority Name";
                //dr["SubAuthorityName"] = "SubAuthority Name";
                //dr["FormName"] = "Form Name";

                //foreach (UserVo user in userOutVo.UserListVo)
                //{
                //    dr[user.UserCode] = user.UserName;
                //}

                //dt.Rows.Add(dr);
            }


            if (authorityOutVo != null && authorityOutVo.AuthorityControlListVo.Count > 0)
            {

                foreach (AuthorityControlVo authorityVo in authorityOutVo.AuthorityControlListVo)
                {
                    if (string.IsNullOrWhiteSpace(authorityVo.ParentControlCode))
                    {
                        dr = dt.NewRow();

                        dr["AuthorityName"] = authorityVo.AuthorityControlName;
                        dt.Rows.Add(dr);

                        List<AuthorityControlVo> controlList = authorityOutVo.AuthorityControlListVo.
                                            Where(t => t.ParentControlCode == authorityVo.AuthorityControlCode).ToList();

                        if (controlList != null && controlList.Count > 0)
                        {
                            foreach (AuthorityControlVo controlVo in controlList)
                            {
                                dr = dt.NewRow();
                                dr["SubAuthorityName"] = controlVo.AuthorityControlName;
                                dt.Rows.Add(dr);

                                List<AuthorityControlVo> childControlList = authorityOutVo.AuthorityControlListVo.
                                            Where(t => t.ParentControlCode == controlVo.AuthorityControlCode).ToList();

                                if (childControlList != null && childControlList.Count > 0)
                                {
                                    foreach (AuthorityControlVo childControlVo in childControlList)
                                    {
                                        dr = dt.NewRow();
                                        dr["FormName"] = childControlVo.AuthorityControlName;

                                        List<UserRoleVo> userRoleList = userRoleOutVo.UserRoleListVo.
                                        Where(t => t.AuthorityControlCode == childControlVo.AuthorityControlCode).ToList();

                                        foreach (UserRoleVo userRole in userRoleList)
                                        {
                                            dr[userRole.UserCode] = ((char)0x221A).ToString();
                                        }
                                        dt.Rows.Add(dr);
                                    }

                                }
                            }
                        }
                    }
                }
            }

            return dt;
        }
        #endregion

        #region FormEvents
        /// <summary>
        /// Loads UserMasterMaintenanceForm
        /// Fill Country combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocalUserMasterForm_Load(object sender, EventArgs e)
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
            AddLocalUserMasterForm newAddForm = new AddLocalUserMasterForm(CommonConstants.MODE_ADD);

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

                    UserVo outVo = (UserVo)InvokeCbm(new DeleteLocalUserMasterMntCbm(), inVo, false);

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

        /// <summary>
        /// exports excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Export_btn_Click(object sender, EventArgs e)
        {
            //string xlsFileName = Application.StartupPath + "\\" + Properties.Settings.Default.EXPORT_TEMPLATE_FILE;

            //if (!System.IO.File.Exists(xlsFileName))
            //{
            //    return;
            //}

            SaveFileDialog ExcelExport_dlg = new SaveFileDialog();

            ExcelExport_dlg.FileName = string.Empty;
            ExcelExport_dlg.Filter = "Excel Files(*.xls) |*.xls";

            if (ExcelExport_dlg.ShowDialog() == DialogResult.OK)
            {

                //System.IO.FileInfo fileInfo = new System.IO.FileInfo(ExcelExport_dlg.FileName);

                //if (string.Equals(fileInfo.Name, Properties.Settings.Default.EXPORT_TEMPLATE_FILE))
                //{
                //    return;
                //}

                //System.IO.File.Copy(xlsFileName, ExcelExport_dlg.FileName, true);
                //exportData.ExportDataToExcel(ExcelExport_dlg.FileName, BindDataForExcel(), Properties.Settings.Default.EXCEL_SHEET_USER_ROLE_AUTHORITY, true);
                this.Cursor = Cursors.WaitCursor;

                DataTable mesUserDt = getMesUser();

                DataTable userRoleAutyDt = BindDataForExcel();

                ExportExcelProcess exportData = new ExportExcelProcess();

                DataSet dsExport = new DataSet();

                if (mesUserDt != null && mesUserDt.Rows.Count > 0)
                {
                    mesUserDt.TableName = Properties.Settings.Default.EXCEL_SHEET_SAP_USER;

                    dsExport.Tables.Add(mesUserDt);

                }

                if (userRoleAutyDt != null && userRoleAutyDt.Rows.Count > 0)
                {
                    userRoleAutyDt.TableName = Properties.Settings.Default.EXCEL_SHEET_USER_ROLE_AUTHORITY;

                    dsExport.Tables.Add(userRoleAutyDt);

                }

                bool created = exportData.WriteToExcel(dsExport, ExcelExport_dlg.FileName);

                this.Cursor = Cursors.Default;
                if (created)
                {
                    MessageData messageData = new MessageData("mmci00012", Properties.Resources.mmci00012, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
            }
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

            //if (Country_cmb.SelectedIndex == -1)
            //{
            //    Language_cmb.SelectedIndex = -1;

            //    Language_cmb.DataSource = null;

            //    Language_cmb.Enabled = false;
            //}

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

        #endregion


        private DataTable getMesUser()
        {
            SapUserVo conditionInVo = new SapUserVo();

            DataTable sapUserdataTable = null;

            SapUserVo outVo = null;

            try
            {
                outVo = (SapUserVo)InvokeCbm(new GetLocalUsersMasterMntCbm(), conditionInVo, false);
            }

            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            if (outVo != null && outVo.SapUserListVo.Count() > 0)
            {
                sapUserdataTable = new DataTable();
                sapUserdataTable.Columns.Add("MesUserCode");
                sapUserdataTable.Columns.Add("UserName");
                sapUserdataTable.Columns.Add("SapUser");

                foreach (SapUserVo vo in outVo.SapUserListVo)
                {
                    DataRow dr = sapUserdataTable.NewRow();
                    dr["MesUserCode"] = vo.MesUserCode.ToString();
                    dr["UserName"] = vo.UserName.ToString();
                    if (!string.IsNullOrEmpty(vo.SapUser))
                    {
                        dr["SapUser"] = vo.SapUser.ToString();
                    }
                    sapUserdataTable.Rows.Add(dr);
                }
            }
            else
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //Sap user
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }

            return sapUserdataTable;
        }
        private void ExcelExport()
        {
            string xlsFileName = Application.StartupPath + "\\" + Properties.Settings.Default.TEMPLATE_FILE_MASTER;

            if (!File.Exists(xlsFileName))
            {
                return;
            }

            DataTable exportTable = PrepareExportData();

            SaveFileDialog saveDialog_dlg = new SaveFileDialog();

            saveDialog_dlg.Filter = "Excel Files(*.xls) |*.xls";

            if (saveDialog_dlg.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(saveDialog_dlg.FileName);

                if (string.Equals(fileInfo.Name, Properties.Settings.Default.TEMPLATE_FILE_MASTER))
                {
                    return;
                }

                File.Copy(xlsFileName, saveDialog_dlg.FileName, true);

                ExportExcelProcess exportData = new ExportExcelProcess();

                exportData.ExportDataToExcel(saveDialog_dlg.FileName, exportTable, Properties.Settings.Default.EXCEL_SHEET_USER_MASTER);
            }
        }

        private DataTable PrepareExportData()
        {
            if (Userdetails_dgv.DataSource == null)
            {
                MessageData messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return null;
            }

            BindingSource bs = (BindingSource)Userdetails_dgv.DataSource;
            List<UserVo> detailsList = (List<UserVo>)bs.List;

            if (detailsList == null || detailsList.Count == 0)
            {
                MessageData messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return null;
            }

            DataTable dt = new DataTable();

            dt.Columns.Add("UserCode");
            dt.Columns.Add("UserName");
            dt.Columns.Add("Country");
            dt.Columns.Add("MultiLoginFlag");
            dt.Columns.Add("RegistrationFactoryCode");


            foreach (UserVo curVo in detailsList)
            {
                DataRow row = dt.NewRow();

                row["UserCode"] = curVo.UserCode;
                row["UserName"] = curVo.UserName;
                row["Country"] = curVo.Country;
                row["MultiLoginFlag"] = curVo.MultiLoginFlag;
                row["RegistrationFactoryCode"] = curVo.RegistrationFactoryCode;

                dt.Rows.Add(row);
            }

            return dt;
        }
    }

}

