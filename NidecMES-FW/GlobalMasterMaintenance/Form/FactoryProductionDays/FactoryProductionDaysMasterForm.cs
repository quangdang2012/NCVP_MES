using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class FactoryProductionDaysMasterForm
    {

        #region Variables

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(FactoryProductionDaysMasterForm));

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
        public FactoryProductionDaysMasterForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(FactoryProductionDaysVo conditionInVo)
        {
            FactoryProductionDays_dgv.DataSource = null;
            FactoryProductionDaysVo outVo = null;
            try
            {
                outVo = (FactoryProductionDaysVo)DefaultCbmInvoker.Invoke(new GetFactoryProductionDaysMasterMntCbm(), conditionInVo);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            FactoryProductionDays_dgv.AutoGenerateColumns = false;
            BindingSource factoryProductionDaysBindingSource = new BindingSource(outVo.FactoryProductionDaysListVo, null);
            if (factoryProductionDaysBindingSource.Count == 0)
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return;
            }

            FactoryProductionDays_dgv.DataSource = factoryProductionDaysBindingSource;
            FactoryProductionDays_dgv.ClearSelection();
        }

        /// <summary>
        /// Creates seacrh condition as per user inputs 
        /// </summary>
        /// <returns>search condition</returns>
        private FactoryProductionDaysVo FormConditionVo()
        {
            FactoryProductionDaysVo inVo = new FactoryProductionDaysVo();

            if (Building_cmb.SelectedIndex > -1)
            {
                inVo.BuildingId = Convert.ToInt32(Building_cmb.SelectedValue);
            }
            if (!string.IsNullOrEmpty(Year_txt.Text))
            {
                inVo.iYear = Convert.ToInt32(Year_txt.Text);
            }

            return inVo;
        }

        /// <summary>
        /// selects user record for updation and show factory form
        /// </summary>
        private void BindUpdateFactoryProductionDaysData()
        {
            int selectedrowindex = FactoryProductionDays_dgv.SelectedCells[0].RowIndex;

            FactoryProductionDaysVo selectedFactoryProductionDays = (FactoryProductionDaysVo)FactoryProductionDays_dgv.Rows[selectedrowindex].DataBoundItem;

            AddFactoryProductionDaysMasterForm addFactoryProductionDaysMasterForm = new AddFactoryProductionDaysMasterForm(CommonConstants.MODE_UPDATE, selectedFactoryProductionDays);

            addFactoryProductionDaysMasterForm.ShowDialog(this);

            if (addFactoryProductionDaysMasterForm.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                GridBind(FormConditionVo());
            }
            else if (addFactoryProductionDaysMasterForm.IntSuccess == 0)
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
        private void BindDataSource(List<FactoryProductionDaysVo> outVo)
        {
            FactoryProductionDays_dgv.AutoGenerateColumns = false;
            BindingSource bindingSource1 = new BindingSource(outVo, null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                FactoryProductionDays_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("tpci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            FactoryProductionDays_dgv.ClearSelection();
        }

        #endregion

        #region FormEvents
        /// <summary>
        /// form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FactoryProductionDaysMasterForm_Load(object sender, EventArgs e)
        {
            GetBuildingInfomation();
            Year_txt.Text = Convert.ToString(DateTime.Now.Year);
            Building_cmb.Select();
            Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        #endregion

        #region ButtonClick

        /// <summary>
        /// event to clear the controls of search criteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Clear_btn_Click(object sender, EventArgs e)
        {
            Building_cmb.SelectedIndex = -1;
            Building_cmb.Text = string.Empty;
           // Year_txt.Text = string.Empty;
            FactoryProductionDays_dgv.DataSource = null;
            Building_cmb.Select();
        }

        /// <summary>
        /// event to get the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param
        protected virtual void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind(FormConditionVo());
        }

        /// <summary>
        /// event to open the  add screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Add_btn_Click(object sender, EventArgs e)
        {
            AddFactoryProductionDaysMasterForm addFactoryProductionDaysMasterForm = new AddFactoryProductionDaysMasterForm(CommonConstants.MODE_ADD, null);

            addFactoryProductionDaysMasterForm.ShowDialog();

            if (addFactoryProductionDaysMasterForm.IntSuccess > 0)
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
        protected virtual void Update_btn_Click(object sender, EventArgs e)
        {
            BindUpdateFactoryProductionDaysData();
        }

        /// <summary>
        /// event to delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Delete_btn_Click(object sender, EventArgs e)
        {

            int selectedrowindex = FactoryProductionDays_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = FactoryProductionDays_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colBuildingName"].Value.ToString() + " : " +
                selectedRow.Cells["coliYear"].Value.ToString() + " / " + selectedRow.Cells["coliMonth"].Value.ToString() +" / "+ selectedRow.Cells["coliDays"].Value.ToString());
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {
                FactoryProductionDaysVo inVo = new FactoryProductionDaysVo
                {
                    FactoryProductionDaysId = Convert.ToInt32(selectedRow.Cells["colFactoryProductionId"].Value.ToString())
                };

                try
                {

                FactoryProductionDaysVo outVo = (FactoryProductionDaysVo)base.InvokeCbm(new DeleteFactoryProductionDaysMasterMntCbm(), inVo, false);

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
        protected virtual void Exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region ControlEvents

        /// <summary>
        /// Handles factory record selection for Update/Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void FactoryDetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (FactoryProductionDays_dgv.SelectedRows.Count > 0)
            {
                Update_btn.Enabled = Delete_btn.Enabled = true;
            }
            else
            {
                Update_btn.Enabled = Delete_btn.Enabled = false;
            }
        }

        /// <summary>
        /// Handles update factory form show on row double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void FactoryDetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (FactoryProductionDays_dgv.SelectedRows.Count > 0)
            {
                BindUpdateFactoryProductionDaysData();
            }
        }

        /// <summary>
        /// sorting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void FactoryDetails_dgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn column = FactoryProductionDays_dgv.Columns[e.ColumnIndex];

            if (FactoryProductionDays_dgv.DataSource == null) { return; }

            BindingSource currentDatagridSource = (BindingSource)FactoryProductionDays_dgv.DataSource;

            List<FactoryProductionDaysVo> dataSourceVo = (List<FactoryProductionDaysVo>)currentDatagridSource.DataSource;

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
                FactoryProductionDays_dgv.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = sortDirection;
            }
        }

        /// <summary>
        /// Get Building Information and set it in combo box
        /// </summary>
        private void GetBuildingInfomation()
        {
            BuildingVo buildinginVo = new BuildingVo();
            BuildingVo buildingoutVo = new BuildingVo();
            buildinginVo.FactoryCode = UserData.GetUserData().FactoryCode;

            try
            {
                buildingoutVo = (BuildingVo)DefaultCbmInvoker.Invoke(new GetBuildingMasterMntCbm(), buildinginVo);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            if (buildingoutVo != null && buildingoutVo.BuildingListVo.Count > 0)
            {
                ComboBind(Building_cmb, buildingoutVo.BuildingListVo, "BuildingName", "BuildingId");
            }
        }

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

        #endregion

    }
}
