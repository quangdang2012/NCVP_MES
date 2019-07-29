using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddCastingMachineFurnaceForm
    {
        #region Variables 

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly CastingMachineFurnaceVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        /// <summary>
        /// equipment details table
        /// </summary>
        private DataTable equipmentDatatable;

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
        public AddCastingMachineFurnaceForm(string pmode, CastingMachineFurnaceVo userItem = null)
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
            if (CastingMachineFurnaceCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, CastingMachineFurnaceCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                CastingMachineFurnaceCode_txt.Focus();

                return false;
            }

            if (CastingMachineFurnaceName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, CastingMachineFurnaceName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                CastingMachineFurnaceName_txt.Focus();

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
        /// <param name="dgvCastingMachineFurnace"></param>
        private void LoadCastingMachineFurnaceData(CastingMachineFurnaceVo dgvCastingMachineFurnace)
        {
            if (dgvCastingMachineFurnace != null)
            {
                //this.CastingMachineFurnaceId_lbl.Text = dgvCastingMachineFurnace.Cells["colCastingMachineFurnaceId"].Value.ToString();

                this.CastingMachineFurnaceCode_txt.Text = dgvCastingMachineFurnace.CastingMachineFurnaceCode;

                this.CastingMachineFurnaceName_txt.Text = dgvCastingMachineFurnace.CastingMachineFurnaceName;

                this.Equipment_cmb.SelectedValue = dgvCastingMachineFurnace.EquipmentId.ToString();
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
        /// checks duplicate Casting Machine Furnace code
        /// </summary>
        /// <returns></returns>
        private CastingMachineFurnaceVo DuplicateCheck(CastingMachineFurnaceVo castVo)
        {
            CastingMachineFurnaceVo outVo = new CastingMachineFurnaceVo();

            try
            {
                outVo = (CastingMachineFurnaceVo)base.InvokeCbm(new CheckCastingMachineFurnaceMasterMntCbm(), castVo, false);
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
        /// inserts new record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            CastingMachineFurnaceVo inVo = new CastingMachineFurnaceVo();
            var sch = StringCheckHelper.GetInstance();
            if (CheckMandatory() == true)
            {
                if (string.IsNullOrEmpty(CastingMachineFurnaceCode_txt.Text) || string.IsNullOrEmpty(CastingMachineFurnaceName_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

                    if (string.IsNullOrEmpty(CastingMachineFurnaceCode_txt.Text))
                    {
                        CastingMachineFurnaceCode_txt.Focus();
                    }
                    else if (string.IsNullOrEmpty(CastingMachineFurnaceName_txt.Text))
                    {
                        CastingMachineFurnaceName_txt.Focus();
                    }                  
                    return;
                }
                inVo.CastingMachineFurnaceCode = CastingMachineFurnaceCode_txt.Text.Trim();

                inVo.CastingMachineFurnaceName = CastingMachineFurnaceName_txt.Text.Trim();

                inVo.EquipmentId = Convert.ToInt32(Equipment_cmb.SelectedValue.ToString());

                inVo.RegistrationUserCode = UserData.GetUserData().UserCode;

                //inVo.RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                inVo.FactoryCode = UserData.GetUserData().FactoryCode;

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    CastingMachineFurnaceVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, CastingMachineFurnaceCode_lbl.Text + " : " + CastingMachineFurnaceCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ConfirmationOkCancel(messageData, Text);

                        return;
                    }
                }

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        CastingMachineFurnaceVo outVo = (CastingMachineFurnaceVo)base.InvokeCbm(new AddCastingMachineFurnaceMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        inVo.CastingMachineFurnaceId = updateData.CastingMachineFurnaceId;

                        CastingMachineFurnaceVo outVo = (CastingMachineFurnaceVo)base.InvokeCbm(new UpdateCastingMachineFurnaceMasterMntCbm(), inVo, false);

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
        /// form close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region FormEvents 
        /// <summary>
        /// form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCastingMachineFurnaceForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();

            ComboBind(Equipment_cmb, equipmentDatatable, "Name", "Id");

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadCastingMachineFurnaceData(updateData);

                CastingMachineFurnaceCode_txt.Enabled = false;

                CastingMachineFurnaceName_txt.Select();

            }

        }

        #endregion
    }
}
