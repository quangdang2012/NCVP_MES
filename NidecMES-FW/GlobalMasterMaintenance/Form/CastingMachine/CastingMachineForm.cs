using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class CastingMachineForm
    {
        #region Variables

        /// <summary>
        /// for loading equipment details
        /// </summary>
        private DataTable equipmentDatatable;

        /// <summary>
        /// casting machine furnace details table
        /// </summary>
        private DataTable castingMachineFurnaceDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(CastingMachineForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor
        /// </summary>
        public CastingMachineForm()
        {
            InitializeComponent();

        }

        #endregion

        #region PrivateMethods 

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(CastingMachineVo conditionInVo)
        {
            CastingMachineDetails_dgv.DataSource = null;

            try
            {
                CastingMachineVo outVo = (CastingMachineVo)base.InvokeCbm(new GetCastingMachineMasterMntCbm(), conditionInVo, false);

                CastingMachineDetails_dgv.AutoGenerateColumns = false;

                BindingSource bindingSource1 = new BindingSource(outVo.CastingMachineListVo, null);

                if (bindingSource1 != null && bindingSource1.Count > 0)
                {
                    CastingMachineDetails_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //"casting machine"
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);

                }

                CastingMachineDetails_dgv.ClearSelection();

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
        private CastingMachineVo FormConditionVo()
        {
            CastingMachineVo inVo = new CastingMachineVo();

            if (CastingMachineCode_txt.Text != string.Empty) { inVo.CastingMachineCode = CastingMachineCode_txt.Text; }

            if (CastingMachineName_txt.Text != string.Empty)
            {
                inVo.CastingMachineName = CastingMachineName_txt.Text;
            }

            if (CastingMachineFurnaceId_cmb.SelectedIndex > -1)
            {
                inVo.CastingMachineFurnaceId = Convert.ToInt32(CastingMachineFurnaceId_cmb.SelectedValue.ToString());
            }

            if (EquipmentId_cmb.SelectedIndex > -1)
            {
                inVo.EquipmentId = Convert.ToInt32(EquipmentId_cmb.SelectedValue.ToString());
            }

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
        /// passing update data to update form
        /// </summary>
        private void BindUpdateCastingMachineData()
        {
            int selectedrowindex = CastingMachineDetails_dgv.SelectedCells[0].RowIndex;

            CastingMachineVo castInVo = (CastingMachineVo)CastingMachineDetails_dgv.Rows[selectedrowindex].DataBoundItem;

            AddCastingMachineForm newAddForm = new AddCastingMachineForm(CommonConstants.MODE_UPDATE, castInVo);

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
        /// Loads data table for equipment 
        /// </summary>
        private void FormDatatableFromVo()
        {
            equipmentDatatable = new DataTable();
            equipmentDatatable.Columns.Add("Id");
            equipmentDatatable.Columns.Add("Name");

            try
            {
                EquipmentVo equipmentOutVo = (EquipmentVo)base.InvokeCbm(new GetEquipmentMasterMntCbm(), new EquipmentVo(), false);

                foreach (EquipmentVo fac in equipmentOutVo.EquipmentListVo)
                {
                    equipmentDatatable.Rows.Add(fac.EquipmentId, fac.EquipmentName);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }

            //CastingMachineFurnaceDatatable

            castingMachineFurnaceDatatable = new DataTable();
            castingMachineFurnaceDatatable.Columns.Add("Id");
            castingMachineFurnaceDatatable.Columns.Add("Name");

            try
            {
                CastingMachineFurnaceVo castingMachineFurnaceOutVo = 
                            (CastingMachineFurnaceVo)base.InvokeCbm(new GetCastingMachineFurnaceMasterMntCbm(), new CastingMachineFurnaceVo(), false);

                foreach (CastingMachineFurnaceVo castfur in castingMachineFurnaceOutVo.CastingMachineFurnaceListVo)
                {
                    castingMachineFurnaceDatatable.Rows.Add(castfur.CastingMachineFurnaceId, castfur.CastingMachineFurnaceName);
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
        /// handles form load
        /// binds combobox equipment and cast machie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CastingMachineForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();

            ComboBind(EquipmentId_cmb, equipmentDatatable, "Name", "Id");

            ComboBind(CastingMachineFurnaceId_cmb, castingMachineFurnaceDatatable, "Name", "Id");

            CastingMachineCode_txt.Select();

            Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        #endregion

        #region ButtonClick 

        /// <summary>
        /// clear the search condition control data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            CastingMachineCode_txt.Text = string.Empty;

            CastingMachineName_txt.Text = string.Empty;

            EquipmentId_cmb.SelectedIndex = -1;

            CastingMachineFurnaceId_cmb.SelectedIndex = -1;

            CastingMachineDetails_dgv.DataSource = null;

            Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        /// <summary>
        /// fetch the record from db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CastingMachineFurnaceId_cmb.Text) && !(CastingMachineFurnaceId_cmb.SelectedIndex > -1))
            {
                messageData = new MessageData("mmce00010", Properties.Resources.mmce00010, CastingMachineFurnaceId_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                CastingMachineFurnaceId_cmb.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(EquipmentId_cmb.Text) && !(EquipmentId_cmb.SelectedIndex > -1))
            {
                messageData = new MessageData("mmce00010", Properties.Resources.mmce00010, EquipmentId_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                EquipmentId_cmb.Focus();
                return;
            }

            GridBind(FormConditionVo());
        }

        /// <summary>
        /// add data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddCastingMachineForm newAddForm = new AddCastingMachineForm(CommonConstants.MODE_ADD, null);

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
        /// update screen with selected data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            BindUpdateCastingMachineData();
        }

        /// <summary>
        /// delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = CastingMachineDetails_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = CastingMachineDetails_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colCastingMachineCode"].Value.ToString());
            logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {

                CastingMachineVo inVo = new CastingMachineVo
                {
                    CastingMachineId = Convert.ToInt32(selectedRow.Cells["colCastingMachineId"].Value.ToString()),
                };

                try
                {
                    CastingMachineVo outVo = (CastingMachineVo)base.InvokeCbm(new DeleteCastingMachineMasterMntCbm(), inVo, false);

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
        /// close the screen
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
        /// update, delete button enable based on the grid  data selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CastingMachineDetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CastingMachineDetails_dgv.SelectedRows.Count > 0)
            {
                Update_btn.Enabled = Delete_btn.Enabled = true;
            }
            else
            {
                Update_btn.Enabled = Delete_btn.Enabled = false;
            }
        }

        /// <summary>
        /// bind update screen on datagrid double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CastingMachineDetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CastingMachineDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCastingMachineData();
            }
        }

        #endregion
    }
}
