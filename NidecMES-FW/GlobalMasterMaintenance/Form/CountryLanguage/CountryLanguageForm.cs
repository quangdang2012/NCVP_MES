using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class CountryLanguageForm
    {
        #region Variables
        /// <summary>
        ///check for Country list is loaded or not
        /// </summary>
        private bool iscmbCountryLoading = false;

        /// <summary>
        /// data table for country and language
        /// </summary>
        private DataTable cntryLangDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(CountryLanguageForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        ///  get message data
        /// </summary>
        private const string User = "User";


        /// <summary>
        /// initialize SortOrder
        /// </summary>
        private SortOrder sortDirection;

        #endregion

        #region Constructor
        /// <summary>
        /// constructor
        /// </summary>
        public CountryLanguageForm()
        {
            InitializeComponent();
        }
        #endregion

        #region PrivateMethods

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
        /// binds datasource
        /// </summary>
        /// <param name="outVo"></param>
        private void BindDataSource(List<CountryLanguageVo> outVo)
        {
            CntryLang_dgv.AutoGenerateColumns = false;
            BindingSource bindingSource1 = new BindingSource(outVo, null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                CntryLang_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("tpci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }

            CntryLang_dgv.ClearSelection();
        }

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(CountryLanguageVo conditionInVo)
        {
            CntryLang_dgv.DataSource = null;

            try
            {
                CountryLanguageVo outVo = (CountryLanguageVo)base.InvokeCbm(new GetCountryLanguageMasterMntCbm(), conditionInVo, false);

                CntryLang_dgv.AutoGenerateColumns = false;

                BindingSource bindingSource1 = new BindingSource(outVo.CountryLangListVo, null);
                if (bindingSource1 != null && bindingSource1.Count > 0)
                {
                    CntryLang_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); // "country language"
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);

                }

                CntryLang_dgv.ClearSelection();

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
        /// Bind data for Country combobox
        /// </summary>
        private void BindCountry()
        {
            FormDatatableFromVo();
            iscmbCountryLoading = true;
            ComboBind(Country_cmb, cntryLangDatatable, "countrycode", "countrycode");
        }

        /// <summary>
        /// Creates seacrh condition as per user inputs 
        /// </summary>
        /// <returns>search condition</returns>
        private CountryLanguageVo FormConditionVo()
        {
            CountryLanguageVo inVo = new CountryLanguageVo();

            if (Country_cmb.SelectedIndex > -1)
            {
                inVo.Country = Country_cmb.SelectedValue.ToString();
            }

            if (Language_cmb.SelectedIndex > -1)
            {
                inVo.Language = Language_cmb.SelectedValue.ToString();
            }

            return inVo;
        }

        /// <summary>
        /// selects user record for updation and show user form
        /// </summary>
        private void BindUpdateUserData()
        {
            int selectedrowindex = CntryLang_dgv.SelectedCells[0].RowIndex;

            CountryLanguageVo cntVo = (CountryLanguageVo)CntryLang_dgv.Rows[selectedrowindex].DataBoundItem;

            AddCountryLanguageForm newAddForm = new AddCountryLanguageForm(CommonConstants.MODE_UPDATE, cntVo);

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
        /// loads country and language data table
        /// </summary>
        private void FormDatatableFromVo()
        {
            cntryLangDatatable = new DataTable();
            cntryLangDatatable.Columns.Add("countrycode");
            cntryLangDatatable.Columns.Add("langcode");

            CountryLanguageVo inVo = FormConditionVo();

            try
            {
                CountryLanguageVo countryLangOutVo = (CountryLanguageVo)base.InvokeCbm(new GetCountryLanguageMasterMntCbm(), inVo, false);

                foreach (CountryLanguageVo cntry in countryLangOutVo.CountryLangListVo)
                {
                    cntryLangDatatable.Rows.Add(cntry.Country, cntry.Language);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// To idenctify the relation ship with tables
        /// </summary>
        private CountryLanguageVo CheckCountryRelation(CountryLanguageVo inVo)
        {
            CountryLanguageVo outVo = new CountryLanguageVo();

            try
            {
                outVo = (CountryLanguageVo)base.InvokeCbm(new CheckCountryLanguagCheckRelationCbm(), inVo, false);
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
        /// form loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CountryLanguageForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();

            iscmbCountryLoading = true;

            ComboBind(Country_cmb, cntryLangDatatable, "countrycode", "countrycode");

            iscmbCountryLoading = false;

            Language_cmb.Enabled = false;

            Update_btn.Enabled = Delete_btn.Enabled = false;
            Country_cmb.Select();

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
            Country_cmb.SelectedIndex = -1;

            Language_cmb.DataSource = null;

            Language_cmb.Enabled = false;

            CntryLang_dgv.DataSource = null;
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
            AddCountryLanguageForm newAddForm = new AddCountryLanguageForm(CommonConstants.MODE_ADD, null);

            newAddForm.ShowDialog();

            if (newAddForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00001", Properties.Resources.mmci00001, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                GridBind(FormConditionVo());
                BindCountry();
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

            int selectedrowindex = CntryLang_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = CntryLang_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colCountry"].Value.ToString());
            logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                CountryLanguageVo inVo = new CountryLanguageVo
                {
                    Country = selectedRow.Cells["colCountry"].Value.ToString(),
                    Language = selectedRow.Cells["colLanguage"].Value.ToString(),
                    RegistrationDateTime = Convert.ToDateTime(DateTime.Now.ToString(UserData.GetUserData().DateTimeFormat)),
                    RegistrationUserCode = UserData.GetUserData().UserCode,
                };

                try
                {

                    inVo.Country = selectedRow.Cells["colCountry"].Value.ToString();
                    CountryLanguageVo tableCount = CheckCountryRelation(inVo);
                    if (tableCount.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00007", Properties.Resources.mmce00007, User.ToString());
                        popUpMessage.Information(messageData, Text);
                        return;
                    }

                    CountryLanguageVo outVo = (CountryLanguageVo)base.InvokeCbm(new DeleteCountryLanguageMasterMntCbm(), inVo, false);

                    if (outVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);

                        GridBind(FormConditionVo());
                        BindCountry();
                    }
                    else if (outVo.AffectedCount == 0)
                    {
                        messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                        GridBind(FormConditionVo());
                        BindCountry();
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
            if (iscmbCountryLoading == true) { return; }

            if (Country_cmb.SelectedIndex > -1)
            {
                string selectedCountry = Country_cmb.SelectedValue.ToString();

                DataRow[] selectLanguage = cntryLangDatatable.Select("countrycode = '" + selectedCountry + "'");

                if (selectLanguage.Length > 0)
                {
                    ComboBind(Language_cmb, selectLanguage.CopyToDataTable(), "langcode", "langcode");

                    Language_cmb.Enabled = true;
                }
            }

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
                Language_cmb.SelectedIndex = -1;
                Language_cmb.DataSource = null;
                Language_cmb.Enabled = false;
            }

        }

        /// <summary>
        /// Handles user record selection for Update/Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CntryLang_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CntryLang_dgv.SelectedRows.Count > 0)
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
        //private void CntryLang_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (CntryLang_dgv.SelectedRows.Count > 0)
        //    {
        //        BindUpdateUserData();
        //    }
        //}

        /// <summary>
        /// Disable selected row and Update/Delete buttons while sorting with header coulumn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CntryLang_dgv_Sorted(object sender, EventArgs e)
        {
            CntryLang_dgv.ClearSelection();

            Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        /// <summary>
        /// sorting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CntryLang_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = CntryLang_dgv.Columns[e.ColumnIndex];

            if (CntryLang_dgv.DataSource == null) { return; }

            BindingSource currentDatagridSource = (BindingSource)CntryLang_dgv.DataSource;

            List<CountryLanguageVo> dataSourceVo = (List<CountryLanguageVo>)currentDatagridSource.DataSource;

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
                CntryLang_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;
            }
        }

        #endregion
    }
}
