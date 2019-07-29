using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AreaForm
    {
        #region Variables

        /// <summary>
        /// datatable for item data
        /// </summary>
        private DataTable locationDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AreaForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public AreaForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(AreaVo conditionInVo)
        {
            Area_dgv.DataSource = null;

            try
            {
                AreaVo outVo = (AreaVo)base.InvokeCbm(new GetAreaMasterMntCbm(), conditionInVo, false);

                Area_dgv.AutoGenerateColumns = false;

                BindingSource bindingSource1 = new BindingSource(outVo.AreaListVo, null);

                if (bindingSource1 != null && bindingSource1.Count > 0)
                {
                    Area_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                Area_dgv.ClearSelection();

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
        private AreaVo FormConditionVo()
        {
            AreaVo inVo = new AreaVo();

            if (AreaCode_txt.Text != string.Empty) { inVo.AreaCode = AreaCode_txt.Text; }

            if (AreaName_txt.Text != string.Empty)
            {
                inVo.AreaName = AreaName_txt.Text;
            }

            if (Location_cmb.SelectedIndex > -1)
            {
                inVo.LocationId = Convert.ToInt32(Location_cmb.SelectedValue);
            }

            return inVo;

        }


        /// <summary>
        /// Handles Combobox loading for Item
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
        /// selects user record for updation and show user form
        /// </summary>
        private void BindUpdateAreaData()
        {
            int selectedrowindex = Area_dgv.SelectedCells[0].RowIndex;

            AreaVo cavInVo = (AreaVo)Area_dgv.Rows[selectedrowindex].DataBoundItem;

            AddAreaForm newAddForm = new AddAreaForm(CommonConstants.MODE_UPDATE, cavInVo);

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
            locationDatatable = new DataTable();
            locationDatatable.Columns.Add("id");
            locationDatatable.Columns.Add("name");

            try
            {
                LocationVo locationOutVo = (LocationVo)base.InvokeCbm(new GetLocationMasterMntCbm(), new LocationVo(), false);

                foreach (LocationVo location in locationOutVo.LocationListVo)
                {
                    locationDatatable.Rows.Add(location.LocationId, location.LocationName);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }


        #endregion

        #region FormEvents
        /// <summary>
        /// Loads location form
        /// Fill item combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AreaForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();

            ComboBind(Location_cmb, locationDatatable, "name", "id");

            AreaCode_txt.Select();

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
            AreaCode_txt.Text = string.Empty;

            AreaName_txt.Text = string.Empty;

            Location_cmb.SelectedIndex = -1;

            Area_dgv.DataSource = null;

            AreaCode_txt.Select();
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
            AddAreaForm newAddForm = new AddAreaForm(CommonConstants.MODE_ADD, null);

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
            BindUpdateAreaData();
        }

        /// <summary>
        /// event to delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = Area_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = Area_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colAreaCode"].Value.ToString());
            logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);


            if (dialogResult == DialogResult.OK)
            {
                AreaVo inVo = new AreaVo();

                inVo.AreaId = Convert.ToInt32(selectedRow.Cells["colAreaId"].Value);


                try
                {
                    AreaVo outVo = (AreaVo)base.InvokeCbm(new DeleteAreaMasterMntCbm(), inVo, false);

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
        private void Area_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Area_dgv.SelectedRows.Count > 0)
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
        private void Area_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Area_dgv.SelectedRows.Count > 0)
            {
                BindUpdateAreaData();
            }
        }

        #endregion




    }
}
