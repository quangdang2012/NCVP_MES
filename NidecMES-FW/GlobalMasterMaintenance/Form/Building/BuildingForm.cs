using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class BuildingForm
    {
        #region Variables

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(BuildingForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// declares factory data table
        /// </summary>
        private DataTable factoryDatatable;
        /// <summary>
        /// building
        /// </summary>
        private const string BUILDING = "BUILDING CODE";

        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public BuildingForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(BuildingVo conditionInVo)
        {
            Building_dgv.DataSource = null;

            try
            {
                BuildingVo outVo = (BuildingVo)base.InvokeCbm(new GetBuildingMasterMntCbm(), conditionInVo, false);

                Building_dgv.AutoGenerateColumns = false;

                BindingSource buildingSource1 = new BindingSource(outVo.BuildingListVo, null);

                if (buildingSource1 != null && buildingSource1.Count > 0)
                {
                    Building_dgv.DataSource = buildingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //"Building"
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                Building_dgv.ClearSelection();

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
        private BuildingVo FormConditionVo()
        {
            BuildingVo inVo = new BuildingVo();

            if (BuildingCode_txt.Text != string.Empty) { inVo.BuildingCode = BuildingCode_txt.Text; }

            if (BuildingName_txt.Text != string.Empty)
            {
                inVo.BuildingName = BuildingName_txt.Text;
            }

            if (FactoryCode_cmb.SelectedIndex > -1)
            {
                inVo.FactoryCode = FactoryCode_cmb.SelectedValue.ToString();
            }
            return inVo;

        }

        /// <summary>
        /// selects user record for updation and show user form
        /// </summary>
        private void BindUpdateBuildingData()
        {
            int selectedrowindex = Building_dgv.SelectedCells[0].RowIndex;

            BuildingVo cavInVo = (BuildingVo)Building_dgv.Rows[selectedrowindex].DataBoundItem;

            AddBuildingForm newAddForm = new AddBuildingForm(CommonConstants.MODE_UPDATE, cavInVo);

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
                messageData = new MessageData("mmci00007", Properties.Resources.mmci00004, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                GridBind(FormConditionVo());
            }
        }

        /// <summary>
        /// For binding factory controls
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
        /// loads factory data table
        /// </summary>
        private void FormDatatableFromVo()
        {
            factoryDatatable = new DataTable();
            factoryDatatable.Columns.Add("code");
            factoryDatatable.Columns.Add("Name");
            try
            {
                FactoryVo factoryOutVo = (FactoryVo)base.InvokeCbm(new GetFactoryMasterMntCbm(), new FactoryVo(), false);

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
        }

        /// <summary>
        /// checks authority control relation to other tables in DB
        /// </summary>
        /// <param name="autVo"></param>
        /// <returns></returns>
        private BuildingVo CheckRelation(BuildingVo autVo)
        {
            BuildingVo outVo = new BuildingVo();

            try
            {
                outVo = (BuildingVo)base.InvokeCbm(new CheckBuildingRelationCbm(), autVo, false);
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
        /// Loads Mold form
        /// Fill item combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildingForm_Load(object sender, EventArgs e)
        {
          
            BuildingCode_txt.Select();
            FormDatatableFromVo();
            ComboBind(FactoryCode_cmb, factoryDatatable, "code", "code");
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
            BuildingCode_txt.Text = string.Empty;

            BuildingName_txt.Text = string.Empty;

            Building_dgv.DataSource = null;

            BuildingCode_txt.Select();
            FactoryCode_cmb.SelectedIndex = -1;
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
            AddBuildingForm newAddForm = new AddBuildingForm(CommonConstants.MODE_ADD, null);

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
            BindUpdateBuildingData();
        }

        /// <summary>
        /// event to delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = Building_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = Building_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colBuildingCode"].Value.ToString());
            logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);


            if (dialogResult == DialogResult.OK)
            {
                BuildingVo inVo = new BuildingVo
                {
                    BuildingId = Convert.ToInt32(selectedRow.Cells["colBuildingId"].Value),
                    BuildingCode = selectedRow.Cells["colBuildingCode"].ToString()
                };

                try
                {
                    BuildingVo checkVo = CheckRelation(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00007", Properties.Resources.mmce00007, BUILDING.ToString());
                        popUpMessage.Information(messageData, Text);
                        return;
                    }
                   

                    BuildingVo outVo = (BuildingVo)base.InvokeCbm(new DeleteBuildingMasterMntCbm(), inVo, false);

                    if (outVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);

                        GridBind(FormConditionVo());
                    }
                    else if (outVo.AffectedCount == 0)
                    {
                        messageData = new MessageData("mmci00007", Properties.Resources.mmci00004, null);
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
        private void Building_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Building_dgv.SelectedRows.Count > 0)
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
        private void Building_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Building_dgv.SelectedRows.Count > 0)
            {
                BindUpdateBuildingData();
            }
        }

        #endregion

    }
}
