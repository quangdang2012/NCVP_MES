using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AuthorityControlForm
    {
        #region Variables

        /// <summary>
        /// datatable for Parent Control data
        /// </summary>
        private DataTable parentDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AuthorityControlForm));

        /// <summary>
        /// get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// Role
        /// </summary>
        private const string ROLE = "ROLE";

        /// <summary>
        /// initialize SortOrder
        /// </summary>
        private SortOrder sortDirection;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor
        /// </summary>
        public AuthorityControlForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all authority records to gridview control
        /// </summary>
        private void GridBind(AuthorityControlVo conditionInVo)
        {
            AuthorityControldetails_dgv.DataSource = null;

            try
            {
                AuthorityControlVo outVo = (AuthorityControlVo)base.InvokeCbm(new GetAuthorityControlMasterMntCbm(), conditionInVo, false);

                BindingList<List<UserVo>> userBind = new BindingList<List<UserVo>>();

                AuthorityControldetails_dgv.AutoGenerateColumns = false;

                BindingSource bindingSource1 = new BindingSource(outVo.AuthorityControlListVo, null);

                if (bindingSource1 != null && bindingSource1.Count > 0)
                {
                    AuthorityControldetails_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);

                }
                AuthorityControldetails_dgv.ClearSelection();

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
        private AuthorityControlVo FormConditionVo()
        {
            AuthorityControlVo inVo = new AuthorityControlVo();

            if (AuthorityControlCode_txt.Text != string.Empty)
            {
                inVo.AuthorityControlCode = AuthorityControlCode_txt.Text;
            }

            if (AuthorityControlName_txt.Text != string.Empty)
            {
                inVo.AuthorityControlName = AuthorityControlName_txt.Text;
            }

            if (ParentControl_cmb.SelectedIndex > -1)
            {
                inVo.ParentControlCode = ParentControl_cmb.SelectedValue.ToString();
            }

            //if (FormName_txt.Text != string.Empty)
            //{
            //    inVo.FormName = FormName_txt.Text;
            //}

            //if (AssemblyName_txt.Text != string.Empty)
            //{
            //    inVo.AssemblyName = AssemblyName_txt.Text;
            //}

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
        /// selects authority record for updation and show authority form
        /// </summary>
        private void BindUpdateAuthorityData()
        {
            int selectedrowindex = AuthorityControldetails_dgv.SelectedCells[0].RowIndex;

            AuthorityControlVo autUpdateVo = (AuthorityControlVo)AuthorityControldetails_dgv.Rows[selectedrowindex].DataBoundItem;

            AddAuthorityControlForm newAddForm = new AddAuthorityControlForm(CommonConstants.MODE_UPDATE, autUpdateVo);

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
        private void BindDataSource(List<AuthorityControlVo> outVo)
        {
            AuthorityControldetails_dgv.AutoGenerateColumns = false;
            BindingSource bindingSource1 = new BindingSource(outVo, null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                AuthorityControldetails_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("tpci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            AuthorityControldetails_dgv.ClearSelection();
        }


        /// <summary>
        /// form country and factory data for combo
        /// </summary>
        private void FormDatatableFromVo()
        {
            parentDatatable = new DataTable();
            parentDatatable.Columns.Add("Code");
            parentDatatable.Columns.Add("Name");

            try
            {
                AuthorityControlVo authorityOutVo = (AuthorityControlVo)base.InvokeCbm(new GetAuthorityControlMasterMntCbm(), new AuthorityControlVo(), false);

                foreach (AuthorityControlVo auth in authorityOutVo.AuthorityControlListVo)
                {
                    parentDatatable.Rows.Add(auth.AuthorityControlCode, auth.AuthorityControlCode);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// checks authority control relation to other tables in DB
        /// </summary>
        /// <param name="autVo"></param>
        /// <returns></returns>
        private AuthorityControlVo CheckRelation(AuthorityControlVo autVo)
        {
            AuthorityControlVo outVo = new AuthorityControlVo();

            try
            {
                outVo = (AuthorityControlVo)base.InvokeCbm(new CheckAuthorityControlRelationCbm(), autVo, false);
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
        /// form load event,loads data table and binds combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AuthorityControlForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();

            ComboBind(ParentControl_cmb, parentDatatable, "Code", "Name");

            AuthorityControlCode_txt.Select();

            Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        #endregion

        #region ButtonClick

        /// <summary>
        /// clear the search condition control values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            AuthorityControlName_txt.Text = string.Empty;

            AuthorityControlCode_txt.Text = string.Empty;

            ParentControl_cmb.SelectedIndex = -1;

            AuthorityControldetails_dgv.DataSource = null;

            AuthorityControlCode_txt.Select();
            Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        /// <summary>
        /// search data using condition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind(FormConditionVo());
        }

        /// <summary>
        /// load add screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddAuthorityControlForm newAddForm = new AddAuthorityControlForm(CommonConstants.MODE_ADD);

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
        /// load update screen with selected add
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            BindUpdateAuthorityData();
        }

        /// <summary>
        /// delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = AuthorityControldetails_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = AuthorityControldetails_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colAuthorityControlCode"].Value.ToString());
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                AuthorityControlVo inVo = new AuthorityControlVo
                {
                    AuthorityControlCode = selectedRow.Cells["colAuthorityControlCode"].Value.ToString(),
                };

                try
                {
                    AuthorityControlVo checkVo = CheckRelation(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00007", Properties.Resources.mmce00007, ROLE.ToString());
                        popUpMessage.Information(messageData, Text);
                        return;
                    }

                    AuthorityControlVo outVo = (AuthorityControlVo)base.InvokeCbm(new DeleteAuthorityControlMasterMntCbm(), inVo, false);

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
        /// close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Control Events

        /// <summary>
        /// enable update,delete button on cell click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AuthorityControldetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (AuthorityControldetails_dgv.SelectedRows.Count > 0)
            {
                Update_btn.Enabled = Delete_btn.Enabled = true;
            }
            else
            {
                Update_btn.Enabled = Delete_btn.Enabled = false;
            }
        }

        /// <summary>
        /// load update screen on cell double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AuthorityControldetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (AuthorityControldetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateAuthorityData();
            }
        }

        
        /// <summary>
        /// sorting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AuthorityControldetails_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = AuthorityControldetails_dgv.Columns[e.ColumnIndex];

            if (AuthorityControldetails_dgv.DataSource == null) { return; }

            BindingSource currentDatagridSource = (BindingSource)AuthorityControldetails_dgv.DataSource;

            List<AuthorityControlVo> dataSourceVo = (List<AuthorityControlVo>)currentDatagridSource.DataSource;

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
                AuthorityControldetails_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;
            }
        }

        #endregion
    }
}
