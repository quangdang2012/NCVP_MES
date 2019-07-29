using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class CastingMachineFurnaceForm
    {
        #region Variables

        /// <summary>
        /// for loading equipment details
        /// </summary>
        private DataTable equipmentDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(CastingMachineFurnaceForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        ///  get message data
        /// </summary>
        private const string CastingMachine = "CastingMachine";

        #endregion

        #region Constructor 

        /// <summary>
        /// constructor
        /// </summary>
        public CastingMachineFurnaceForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods 

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(CastingMachineFurnaceVo conditionInVo)
        {
            CastingMachineFurnaceDetails_dgv.DataSource = null;

            try
            {
                CastingMachineFurnaceVo outVo = (CastingMachineFurnaceVo)base.InvokeCbm(new GetCastingMachineFurnaceMasterMntCbm(), conditionInVo, false);

                BindingList<List<CastingMachineFurnaceVo>> userBind = new BindingList<List<CastingMachineFurnaceVo>>();

                CastingMachineFurnaceDetails_dgv.AutoGenerateColumns = false;

                BindingSource bindingSource1 = new BindingSource(outVo.CastingMachineFurnaceListVo, null);

                if (bindingSource1 != null && bindingSource1.Count > 0)
                {
                    CastingMachineFurnaceDetails_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //"casting machine furnace"
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                CastingMachineFurnaceDetails_dgv.ClearSelection();

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
        private CastingMachineFurnaceVo FormConditionVo()
        {
            CastingMachineFurnaceVo inVo = new CastingMachineFurnaceVo();

            if (CastingMachineFurnaceCode_txt.Text != string.Empty) { inVo.CastingMachineFurnaceCode = CastingMachineFurnaceCode_txt.Text; }

            if (CastingMachineFurnaceName_txt.Text != string.Empty)
            {
                inVo.CastingMachineFurnaceName = CastingMachineFurnaceName_txt.Text;
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
        private void BindUpdateCastingMachineFurnaceData()
        {
            int selectedrowindex = CastingMachineFurnaceDetails_dgv.SelectedCells[0].RowIndex;

            CastingMachineFurnaceVo castFurVo = (CastingMachineFurnaceVo)CastingMachineFurnaceDetails_dgv.Rows[selectedrowindex].DataBoundItem;

            AddCastingMachineFurnaceForm newAddForm = new AddCastingMachineFurnaceForm(CommonConstants.MODE_UPDATE, castFurVo);

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
            }
        }


        /// <summary>
        /// To idenctify the relation ship with tables
        /// </summary>
        private CastingMachineFurnaceVo CheckFurnaceRelationCbm(CastingMachineFurnaceVo inVo)
        {
            CastingMachineFurnaceVo outVo = new CastingMachineFurnaceVo();

            try
            {
                outVo = (CastingMachineFurnaceVo)base.InvokeCbm(new CheckCastingMachineFurnaceRelationCbm(), inVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }

        #endregion

        #region ButtonClick 

        /// <summary>
        /// insert  the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddCastingMachineFurnaceForm newAddForm = new AddCastingMachineFurnaceForm(CommonConstants.MODE_ADD, null);

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
        /// clear the condition control values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            CastingMachineFurnaceCode_txt.Text = string.Empty;

            CastingMachineFurnaceName_txt.Text = string.Empty;

            EquipmentId_cmb.SelectedIndex = -1;

            CastingMachineFurnaceDetails_dgv.DataSource = null;

            Update_btn.Enabled = Delete_btn.Enabled = false;
        }


        /// <summary>
        /// fetch record from db by condition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EquipmentId_cmb.Text) && !(EquipmentId_cmb.SelectedIndex > -1))
            {
                messageData = new MessageData("mmce00010", Properties.Resources.mmce00010, EquipmentCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                EquipmentId_cmb.Focus();
                return;
            }

            GridBind(FormConditionVo());
        }

        /// <summary>
        /// open the update form with selected record bind
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            BindUpdateCastingMachineFurnaceData();
        }

        /// <summary>
        /// delete the selected record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            int selectedrowindex = CastingMachineFurnaceDetails_dgv.SelectedCells[0].RowIndex;

            DataGridViewRow selectedRow = CastingMachineFurnaceDetails_dgv.Rows[selectedrowindex];

            messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, selectedRow.Cells["colCastingMachineFurnaceCode"].Value.ToString());
            // Logger.Info(messageData);
            DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

            if (dialogResult == DialogResult.OK)
            {

                CastingMachineFurnaceVo inVo = new CastingMachineFurnaceVo();

                inVo.CastingMachineFurnaceId = Convert.ToInt32(selectedRow.Cells["colCastingMachineFurnaceId"].Value.ToString());
                inVo.CastingMachineFurnaceCode = selectedRow.Cells["colCastingMachineFurnaceCode"].Value.ToString();
                try
                {

                    CastingMachineFurnaceVo tableCount = CheckFurnaceRelationCbm(inVo);
                    if(tableCount.AffectedCount >0)
                    {
                        messageData = new MessageData("mmce00007", Properties.Resources.mmce00007, CastingMachine.ToString());
                        popUpMessage.Information(messageData, Text);
                        return;
                    }

                    CastingMachineFurnaceVo outVo = (CastingMachineFurnaceVo)base.InvokeCbm(new DeleteCastingMachineFurnaceMasterMntCbm(), inVo, false);

                    if (outVo.AffectedCount > 0)
                    {
                        this.messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                        logger.Info(this.messageData);
                        popUpMessage.Information(this.messageData, Text);

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

        #region ControlEvents

        /// <summary>
        /// update, delete button enable  based on the record selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CastingMachineFurnaceDetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CastingMachineFurnaceDetails_dgv.SelectedRows.Count > 0)
            {
                Update_btn.Enabled = Delete_btn.Enabled = true;
            }
            else
            {
                Update_btn.Enabled = Delete_btn.Enabled = false;
            }
        }

        /// <summary>
        /// open update form on double click on the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CastingMachineFurnaceDetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CastingMachineFurnaceDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCastingMachineFurnaceData();
            }
        }

        #endregion

        #region FormEvents 
        /// <summary>
        /// load  the form with  combobox bind
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CastingMachineFurnaceMasterForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();

            ComboBind(EquipmentId_cmb, equipmentDatatable, "Name", "Id");

            CastingMachineFurnaceCode_txt.Select();

            Update_btn.Enabled = Delete_btn.Enabled = false;
        }

        #endregion

    }
}
