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
    public partial class CustomerMasterForm
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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(CustomerMasterForm));

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
        public CustomerMasterForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all Customer records to gridview control
        /// </summary>
        private void GridBind(CustomerVo conditionInVo)
        {
            Customerdetails_dgv.DataSource = null;

            try
            {
                CustomerVo outVo = (CustomerVo)InvokeCbm(new GetCustomerMasterMntCbm(), conditionInVo, false);

                Customerdetails_dgv.AutoGenerateColumns = false;

                BindingSource bindingSource1 = new BindingSource(outVo.CustomerListVo, null);

                if (bindingSource1.Count > 0)
                {
                    Customerdetails_dgv.DataSource = bindingSource1;
                    colCustomerCode.SortMode = DataGridViewColumnSortMode.Automatic;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //Customer
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                Customerdetails_dgv.ClearSelection();

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
        /// Creates seacrh condition as per Customer inputs 
        /// </summary>
        /// <returns>search condition</returns>
        private CustomerVo FormConditionVo()
        {
            CustomerVo inVo = new CustomerVo();

            if (CustomerCode_txt.Text != string.Empty) { inVo.CustomerCode = CustomerCode_txt.Text; }

            if (CustomerName_txt.Text != string.Empty) { inVo.CustomerName = CustomerName_txt.Text; }

            if (Address1_txt.Text != string.Empty) { inVo.Address1 = Address1_txt.Text; }

            if (Address2_txt.Text != string.Empty) { inVo.Address2 = Address2_txt.Text; }

            if (EmailId_txt.Text != string.Empty) { inVo.EmailId = EmailId_txt.Text; }

            if (PhoneNo_txt.Text != string.Empty) { inVo.PhoneNo = PhoneNo_txt.Text; }

            return inVo;

        }

        /// <summary>
        /// Gets Customer data selected for update from Gridview
        /// </summary>
        /// <returns>Selected Customer record</returns>
        private DataGridViewRow GetSelectedCustomerData()
        {
            int selectedrowindex = Customerdetails_dgv.SelectedCells[0].RowIndex;

            return Customerdetails_dgv.Rows[selectedrowindex];
        }

        /// <summary>
        /// selects Customer record for updation and show Customer form
        /// </summary>
        private void BindUpdateCustomerData()
        {
            DataGridViewRow selectedCustomer = GetSelectedCustomerData();

            CustomerVo customerUpdateVo = (CustomerVo)selectedCustomer.DataBoundItem;

            AddCustomerMasterForm newAddForm = new AddCustomerMasterForm(CommonConstants.MODE_UPDATE, customerUpdateVo);

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
        /// binds datasource
        /// </summary>
        /// <param name="outVo"></param>
        private void BindDataSource(List<CustomerVo> outVo)
        {
            Customerdetails_dgv.AutoGenerateColumns = false;
            BindingSource targetWIPBindingSource = new BindingSource(outVo, null);

            if (targetWIPBindingSource == null || targetWIPBindingSource.Count == 0)
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return;
            }

            Customerdetails_dgv.DataSource = targetWIPBindingSource;
            Customerdetails_dgv.ClearSelection();
        }

        #endregion

        #region FormEvents

        /// <summary>
        /// Loads CustomerMasterMaintenanceForm
        /// Fill Country combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerMasterForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();

            CustomerCode_txt.Select();

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
            CustomerCode_txt.Text = string.Empty;

            CustomerName_txt.Text = string.Empty;

            Address1_txt.Text = string.Empty;

            Address2_txt.Text = string.Empty;

            PhoneNo_txt.Text = string.Empty;

            EmailId_txt.Text = string.Empty;

            Customerdetails_dgv.DataSource = null;

            CustomerCode_txt.Select();

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
            AddCustomerMasterForm newAddForm = new AddCustomerMasterForm(CommonConstants.MODE_ADD);

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
            BindUpdateCustomerData();
        }

        /// <summary>
        /// event to delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {

            int selectedrowindex = Customerdetails_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = Customerdetails_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colCustomerCode"].Value.ToString());

            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                CustomerVo inVo = new CustomerVo
                {
                    CustomerId = Convert.ToInt32(selectedRow.Cells["colCustomerId"].Value.ToString()),
                    RegistrationDateTime = Convert.ToDateTime(DateTime.Now.ToString(UserData.GetUserData().DateTimeFormat)),
                    RegistrationUserCode = UserData.GetUserData().UserCode
                };

                try
                {

                    CustomerVo outVo = (CustomerVo)InvokeCbm(new DeleteCustomerMasterMntCbm(), inVo, false);

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
        private void TableDetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Customerdetails_dgv.SelectedRows.Count > 0)
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
            if (Customerdetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCustomerData();
            }
        }

        //private void Customerdetails_dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    if (Customerdetails_dgv.Columns[e.ColumnIndex].DataPropertyName == "PhoneNo")
        //    {

        //        if (e.Value.ToString() == "0")
        //        {
        //            e.Value = string.Empty;
        //        }
        //    }
        //}

        /// <summary>
        /// sort DataGridView data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Customerdetails_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = Customerdetails_dgv.Columns[e.ColumnIndex];

            if (Customerdetails_dgv.DataSource == null) { return; }

            BindingSource currentDatagridSource = (BindingSource)Customerdetails_dgv.DataSource;

            List<CustomerVo> dataSourceVo = (List<CustomerVo>)currentDatagridSource.DataSource;

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
                Customerdetails_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;

            }
        }

        #endregion

    }
}

