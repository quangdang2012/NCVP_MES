using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Text.RegularExpressions;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddProcessWorkForm
    {

        #region Variables

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private ProcessWorkVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        /// <summary>
        /// datatable for item data
        /// </summary>
        private DataTable processDatatable;

        /// <summary>
        /// datatable for item data
        /// </summary>
        private DataTable LneMchneSltn;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddProcessWorkForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for the  form
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="userItem"></param>
        public AddProcessWorkForm()
        {
            InitializeComponent();

        }
        public AddProcessWorkForm CreateForm(string pmode, ProcessWorkVo userItem = null)
        {
            mode = pmode;

            updateData = userItem;

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                this.Text = UpdateText_lbl.Text;
            }

            return new AddProcessWorkForm();

        }



        #endregion

        #region PrivateMethods
        /// <summary>
        /// Loads Phantom
        /// </summary>
        private void LoadPhantom()
        {
            DataTable dtPhantom = new DataTable();
            dtPhantom = new DataTable();
            dtPhantom.Columns.Add("name");
            dtPhantom.Columns.Add("id");

            foreach (System.Configuration.SettingsProperty property in Properties.Settings.Default.Properties)
            {
                if (property.Name == PhantomType.Phantom.ToString())
                {
                    dtPhantom.Rows.Add(property.Name, property.DefaultValue);
                }

                if (property.Name == PhantomType.Standard.ToString())
                {
                    dtPhantom.Rows.Add(property.Name, property.DefaultValue);
                }
            }

             ComboBind(isPhantom_cmb, dtPhantom, "name", "id");
        }

        /// <summary>
        /// Loads LineMachineSelection
        /// </summary>
        private void LoadLneMchneSltn()
        {
            //modeDt = new DataTable();
            DataTable LneMchneSltn = new DataTable();
            LneMchneSltn = new DataTable();
            LneMchneSltn.Columns.Add("name");
            LneMchneSltn.Columns.Add("id");


            LneMchneSltn.Rows.Add(GlobalMasterDataTypeEnum.SINGLE_LINE.ToString(), GlobalMasterDataTypeEnum.SINGLE_LINE.GetValue());
            LneMchneSltn.Rows.Add(GlobalMasterDataTypeEnum.SINGLE_MACHINE.ToString(), GlobalMasterDataTypeEnum.SINGLE_MACHINE.GetValue());
            LneMchneSltn.Rows.Add(GlobalMasterDataTypeEnum.SINGLE_LINE_MACHINE.ToString(), GlobalMasterDataTypeEnum.SINGLE_LINE_MACHINE.GetValue());

            ComboBind(LineMachineSltn_cmb, LneMchneSltn, "name", "id");
        }



        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {
            if (ProcessWorkCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ProcessWorkCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                ProcessWorkCode_txt.Focus();

                return false;
            }
            if (ProcessWorkName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ProcessWorkName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                ProcessWorkName_txt.Focus();

                return false;
            }
            if (Process_cmb.Text == string.Empty || Process_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Process_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                Process_cmb.Focus();

                return false;
            }

            //if (isPhantom_cmb.Text == string.Empty || isPhantom_cmb.SelectedIndex < 0)
            //{
            //    messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, IsPhantom_lbl.Text);
            //    popUpMessage.Warning(messageData, Text);

            //    Process_cmb.Focus();

            //    return false;
            //}

            if (LineMachineSltn_cmb.Text == string.Empty || LineMachineSltn_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, LineMachineSltn_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                LineMachineSltn_cmb.Focus();

                return false;
            }
            if (DisplayOrder_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, DisplayOrder_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                DisplayOrder_txt.Focus();

                return false;
            }
            return true;
        }

        /// <summary>
        /// For binding item
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
        /// For setting selected user record into respective controls(textbox and combobox) for update operation
        /// passing selected user data as parameter 
        /// </summary>
        /// <param name="dgvMoldType"></param>
        private void LoadUserData(ProcessWorkVo dgvMoldType)
        {
            if (dgvMoldType != null)
            {
                this.ProcessWorkCode_txt.Text = dgvMoldType.ProcessWorkCode;

                this.ProcessWorkName_txt.Text = dgvMoldType.ProcessWorkName;

                this.Process_cmb.SelectedValue = dgvMoldType.ProcessId.ToString();

                // this.isPhantom_cmb.Text = dgvMoldType.IsPhantomDisplay;

                if (!string.IsNullOrWhiteSpace(dgvMoldType.LineMachineSelectionDisplay))
                {
                    this.LineMachineSltn_cmb.Text = dgvMoldType.LineMachineSelectionDisplay.ToString();
                }
                this.DisplayOrder_txt.Text = dgvMoldType.DisplayOrder.ToString();
            }
        }

        /// <summary>
        /// form country and factory data for combo
        /// </summary>
        private void FormDatatableFromVo()
        {
            processDatatable = new DataTable();
            processDatatable.Columns.Add("id");
            processDatatable.Columns.Add("code");

            try
            {
                ProcessVo processOutVo = (ProcessVo)base.InvokeCbm(new GetProcessMasterMntCbm(), new ProcessVo(), false);

                foreach (ProcessVo process in processOutVo.ProcessListVo)
                {
                    processDatatable.Rows.Add(process.ProcessId, process.ProcessCode);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// checks duplicate Process Work Code
        /// </summary>
        /// <param name="prsWorkVo"></param>
        /// <returns></returns>
        private ProcessWorkVo DuplicateCheck(ProcessWorkVo prsWorkVo)
        {
            ProcessWorkVo outVo = new ProcessWorkVo();

            try
            {
                outVo = (ProcessWorkVo)base.InvokeCbm(new CheckProcessWorkMasterMntCbm(), prsWorkVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }

        /// <summary>
        /// checks duplicate Display Record
        /// </summary>
        /// <param name="defectVo"></param>
        /// <returns></returns>
        private ProcessWorkVo DuplicateDisplayCheck(ProcessWorkVo defectVo)
        {
            ProcessWorkVo outVo = new ProcessWorkVo();

            try
            {
                outVo = (ProcessWorkVo)base.InvokeCbm(new CheckProcessWorkDisplayMasterMntCbm(), defectVo, false);
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
        /// Handles Load event for mold data Insert/Update operations 
        /// Loading mold data for update mold data and binding controls with selected mold record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddProcessWorkForm_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                FormDatatableFromVo();

                ComboBind(Process_cmb, processDatatable, "code", "id");
                LoadPhantom();

                //LoadLneMchneSltn();
                ComboBind(LineMachineSltn_cmb, LneMchneSltn, "name", "id");
                LoadLneMchneSltn();

                ProcessWorkCode_txt.Select();

                if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                {
                    LoadUserData(updateData);

                    ProcessWorkCode_txt.Enabled = false;

                    ProcessWorkName_txt.Select();
                }
                else
                {
                    ProcessWorkVo outVo = (ProcessWorkVo)base.InvokeCbm(new GetDisplayOrderNextValCbm(), null, false);
                    if (outVo != null)
                    {
                        DisplayOrder_txt.Text = outVo.DisplayOrder.ToString();
                    }
                    else
                    {
                        DisplayOrder_txt.Text = "1";
                    }

                }

            }
        }

        #endregion

        #region ButtonClick

        /// <summary>
        /// update data to db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Ok_btn_Click(object sender, EventArgs e)
        {
            if (CheckMandatory())
            {
                string processwrkName = ProcessWorkName_txt.Text;
                processwrkName = Regex.Replace(processwrkName, @"\s", "");

                var sch = StringCheckHelper.GetInstance();
                if (!sch.IsASCII(ProcessWorkCode_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);
                    ProcessWorkCode_txt.Focus();
                    return;
                }
                //else if (!sch.IsASCII(processwrkName))
                //{
                //    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                //    logger.Info(messageData);
                //    popUpMessage.ConfirmationOkCancel(messageData, Text);
                //    ProcessWorkName_txt.Focus();
                //    return;
                //}
                ProcessWorkVo inVo = new ProcessWorkVo
                {
                    ProcessWorkCode = ProcessWorkCode_txt.Text.Trim(),
                    ProcessWorkName = ProcessWorkName_txt.Text.Trim(),
                    ProcessId = Convert.ToInt32(Process_cmb.SelectedValue),
                    //RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    // IsPhantom = isPhantom_cmb.SelectedValue.ToString(),
                    IsPhantom = "0",
                    LineMachineSelection = Convert.ToInt32(LineMachineSltn_cmb.SelectedValue.ToString()),
                    DisplayOrder = Convert.ToInt32(DisplayOrder_txt.Text),
                    RegistrationUserCode = UserData.GetUserData().UserCode,
                    FactoryCode = UserData.GetUserData().FactoryCode
                };

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    ProcessWorkVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, ProcessWorkCode_lbl.Text + " : " + ProcessWorkCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ApplicationError(messageData, Text);
                        return;
                    }

                    ProcessWorkVo checkDisplayVo = DuplicateDisplayCheck(inVo);
                    if (checkDisplayVo != null && checkDisplayVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, DisplayOrder_lbl.Text + " : " + DisplayOrder_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ConfirmationOkCancel(messageData, Text);
                        DisplayOrder_txt.Focus();
                        return;
                    }

                }

                else if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                {
                    if (updateData.DisplayOrder != Convert.ToInt32(DisplayOrder_txt.Text))
                    {
                        ProcessWorkVo checkDisplayVo = DuplicateDisplayCheck(inVo);
                        if (checkDisplayVo != null && checkDisplayVo.AffectedCount > 0)
                        {
                            messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, DisplayOrder_lbl.Text + " : " + DisplayOrder_txt.Text);
                            logger.Info(messageData);
                            popUpMessage.ConfirmationOkCancel(messageData, Text);
                            DisplayOrder_txt.Focus();
                            return;
                        }
                    }
                }

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        ProcessWorkVo outVo = (ProcessWorkVo)base.InvokeCbm(new AddProcessWorkMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        inVo.ProcessWorkId = updateData.ProcessWorkId;

                        ProcessWorkVo outVo = (ProcessWorkVo)base.InvokeCbm(new UpdateProcessWorkMasterMntCbm(), inVo, false);

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
        /// close the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Exit_btn_Click(object sender, EventArgs e)
        {
            IntSuccess = -1;
            this.Close();
        }
        #endregion

        private void labelCommon2_Click(object sender, EventArgs e)
        {

        }
    }

    public enum PhantomType
    {
        Phantom = 1,
        Standard = 0
    }

    public enum LineMachineSelection
    {
        SingleLine = 1,
        SingleMachine = 2,
        SingleLineandSingleMachine = 3
    }

}
