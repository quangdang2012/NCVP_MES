using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddCastingMachineForm
    {
        #region Variables 

        /// <summary>
        /// set mode based on insert/update 
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly CastingMachineVo updateData;

        /// <summary>
        /// Check for Database operation success 
        /// </summary>
        public int IntSuccess = -1;

        /// <summary>
        /// equipment details table
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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddAuthorityControlForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;
        #endregion

        #region Constructor 
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="userItem"></param>
        public AddCastingMachineForm(string pmode, CastingMachineVo userItem = null)
        {
            InitializeComponent();

            mode = pmode;           
            updateData = userItem;

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                this.Text = UpdateText_lbl.Text;
            }
        }

        #endregion

        #region PrivateMethods 

        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {
            if (CastingMachineCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, CastingMachineCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                CastingMachineCode_txt.Focus();

                return false;
            }

            if (CastingMachineName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, CastingMachineName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                CastingMachineName_txt.Focus();

                return false;
            }

            if (CastingMachineFurnaceName_cmb.Text == string.Empty || CastingMachineFurnaceName_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, CastingMachineFurnaceName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                CastingMachineFurnaceName_cmb.Focus();

                return false;
            }

            if (Equipment_cmb.Text == string.Empty || Equipment_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Equipment_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                Equipment_cmb.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// Loads selected data from data grid
        /// </summary>
        /// <param name="dgvCastingMachine"></param>
        private void LoadCastingMachineData(CastingMachineVo dgvCastingMachine)
        {
            if (dgvCastingMachine != null)
            {
                this.CastingMachineCode_txt.Text = dgvCastingMachine.CastingMachineCode;

                this.CastingMachineName_txt.Text = dgvCastingMachine.CastingMachineName;

                this.CastingMachineFurnaceName_cmb.SelectedValue = dgvCastingMachine.CastingMachineFurnaceId.ToString();

                this.Equipment_cmb.SelectedValue = dgvCastingMachine.EquipmentId.ToString();
            }
        }

        /// <summary>
        /// Loads equipment details to datatable
        /// </summary>
        private void FormDatatableFromVo()
        {
            equipmentDatatable = new DataTable();
            equipmentDatatable.Columns.Add("Id");
            equipmentDatatable.Columns.Add("Name");

            try
            {
                EquipmentVo equipmentOutVo = (EquipmentVo)base.InvokeCbm(new GetEquipmentMasterMntCbm(), new EquipmentVo() , false);

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

        /// <summary>
        /// For binding Country and Language controls from XML file
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
        /// checks duplicate Casting Machine Code
        /// </summary>
        /// <param name="castMacVo"></param>
        /// <returns></returns>
        private CastingMachineVo DuplicateCheck(CastingMachineVo castMacVo)
        {
            CastingMachineVo outVo = new CastingMachineVo();

            try
            {
                outVo = (CastingMachineVo)base.InvokeCbm(new CheckCastingMachineMasterMntCbm(), castMacVo, false);
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
        /// form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCastingMachineForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();

            ComboBind(Equipment_cmb, equipmentDatatable, "Name", "Id");

            ComboBind(CastingMachineFurnaceName_cmb, castingMachineFurnaceDatatable, "Name", "Id");

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadCastingMachineData(updateData);

                CastingMachineCode_txt.Enabled = false;

                CastingMachineName_txt.Select();

            }
        }

        #endregion

        #region ButtonClick

        /// <summary>
        /// handles insert/update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            CastingMachineVo inVo = new CastingMachineVo();
            var sch = StringCheckHelper.GetInstance();

            if (CheckMandatory())
            {
                if (string.IsNullOrEmpty(CastingMachineCode_txt.Text) || string.IsNullOrEmpty(CastingMachineName_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

                    if (string.IsNullOrEmpty(CastingMachineCode_txt.Text))
                    {
                        CastingMachineCode_txt.Focus();
                    }
                    else if (string.IsNullOrEmpty(CastingMachineName_txt.Text))
                    {
                        CastingMachineName_txt.Focus();
                    }                   
                    return;
                }
                inVo.CastingMachineCode = CastingMachineCode_txt.Text.Trim();

                inVo.CastingMachineName = CastingMachineName_txt.Text.Trim();

                inVo.EquipmentId = Convert.ToInt32(Equipment_cmb.SelectedValue.ToString());

                inVo.CastingMachineFurnaceId = Convert.ToInt32(CastingMachineFurnaceName_cmb.SelectedValue.ToString());

                inVo.RegistrationUserCode = UserData.GetUserData().UserCode;

                //inVo.RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                inVo.FactoryCode = UserData.GetUserData().FactoryCode;

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    CastingMachineVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, CastingMachineCode_lbl.Text + " : " + CastingMachineCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ConfirmationOkCancel(messageData, Text);

                        return;
                    }
                }

                if (updateData != null)
                {
                    inVo.CastingMachineId = updateData.CastingMachineId;
                }

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        CastingMachineVo outVo = (CastingMachineVo)base.InvokeCbm(new AddCastingMachineMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                    {
                        CastingMachineVo outVo = (CastingMachineVo)base.InvokeCbm(new UpdateCastingMachineMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }

                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }

                if ((IntSuccess > 0) || (IntSuccess == 0))
                {
                    this.Close();
                }
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

    }
}
