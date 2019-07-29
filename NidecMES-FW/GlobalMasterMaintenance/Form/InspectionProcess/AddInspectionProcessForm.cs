using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddInspectionProcessForm
    {
        #region Variables 

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly InspectionProcessVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        /// <summary>
        /// inspectionformat details table
        /// </summary>
        private DataTable inspectionformatDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddInspectionProcessForm));

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
        public AddInspectionProcessForm(string pmode, InspectionProcessVo userItem = null)
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
            if (InspectionProcessCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionProcessCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InspectionProcessCode_txt.Focus();

                return false;
            }

            if (InspectionProcessName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionProcessName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InspectionProcessName_txt.Focus();

                return false;
            }

            if (InspectionFormat_cmb.Text == string.Empty || InspectionFormat_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionFormat_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InspectionFormat_cmb.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// Loads selected data from data grid
        /// </summary>
        /// <param name="dgvInspectionProcess"></param>
        private void LoadInspectionProcessData(InspectionProcessVo dgvInspectionProcess)
        {
            if (dgvInspectionProcess != null)
            {                
                this.InspectionProcessCode_txt.Text = dgvInspectionProcess.InspectionProcessCode;

                this.InspectionProcessName_txt.Text = dgvInspectionProcess.InspectionProcessName;

                this.InspectionFormat_cmb.SelectedValue = dgvInspectionProcess.InspectionFormatId.ToString();
            }
        }

        /// <summary>
        /// Loads inspectionformat details to datatable
        /// </summary>
        private void FormDatatableFromVo()
        {
            inspectionformatDatatable = new DataTable();
            inspectionformatDatatable.Columns.Add("Id");
            inspectionformatDatatable.Columns.Add("Name");

            ValueObjectList<InspectionFormatVo> inspectionFormatOutVo = null;

            try
            {
                
                inspectionFormatOutVo = (ValueObjectList<InspectionFormatVo>)base.InvokeCbm(new GetInspectionFormatMasterMntCbm(),new InspectionFormatVo(), false);
                                
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            if (inspectionFormatOutVo == null || inspectionFormatOutVo.GetList() == null || inspectionFormatOutVo.GetList().Count == 0)
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return;
            }

            foreach (InspectionFormatVo fac in inspectionFormatOutVo.GetList())
            {
                inspectionformatDatatable.Rows.Add(fac.InspectionFormatId, fac.InspectionFormatName);
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
        /// checks duplicate Inspection Process code
        /// </summary>
        /// <returns></returns>
        private InspectionProcessVo DuplicateCheck(InspectionProcessVo InsProcessVo)
        {
            InspectionProcessVo outVo = new InspectionProcessVo();

            try
            {
                outVo = (InspectionProcessVo)base.InvokeCbm(new CheckInspectionProcessMasterMntCbm(), InsProcessVo, false);
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
            InspectionProcessVo inVo = new InspectionProcessVo();
            var sch = StringCheckHelper.GetInstance();
            if (CheckMandatory() == true)
            {
                if (string.IsNullOrEmpty(InspectionProcessCode_txt.Text) || string.IsNullOrEmpty(InspectionProcessName_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);

                    if (string.IsNullOrEmpty(InspectionProcessCode_txt.Text))
                    {
                        InspectionProcessCode_txt.Focus();
                    }
                    else if (string.IsNullOrEmpty(InspectionProcessName_txt.Text))
                    {
                        InspectionProcessName_txt.Focus();
                    }                  
                    return;
                }
                inVo.InspectionProcessCode = InspectionProcessCode_txt.Text.Trim();

                inVo.InspectionProcessName = InspectionProcessName_txt.Text.Trim();

                inVo.InspectionFormatId = Convert.ToInt32(InspectionFormat_cmb.SelectedValue.ToString());
                
                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    InspectionProcessVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, InspectionProcessCode_lbl.Text + " : " + InspectionProcessCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ConfirmationOkCancel(messageData, Text);

                        return;
                    }
                }

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        InspectionProcessVo outVo = (InspectionProcessVo)base.InvokeCbm(new AddInspectionProcessMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        inVo.InspectionProcessId = updateData.InspectionProcessId;

                        InspectionProcessVo outVo = (InspectionProcessVo)base.InvokeCbm(new UpdateInspectionProcessMasterMntCbm(), inVo, false);

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
        private void AddInspectionProcessForm_Load(object sender, EventArgs e)
        {
            FormDatatableFromVo();

            ComboBind(InspectionFormat_cmb, inspectionformatDatatable, "Name", "Id");

            InspectionProcessCode_txt.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadInspectionProcessData(updateData);

                InspectionProcessCode_txt.Enabled = false;

                InspectionProcessName_txt.Select();

            }
        }

        #endregion
        
    }
}
