using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddInspectionTestInstructionForm
    {
        #region Variables 

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly InspectionTestInstructionVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        /// <summary>
        /// inspectionformat details table
        /// </summary>
        private DataTable inspectionitemDatatable;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddInspectionTestInstructionForm));

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
        public AddInspectionTestInstructionForm(string pmode, InspectionTestInstructionVo userItem = null)
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
            if (InspectionTestInstructionCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionTestInstructionCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InspectionTestInstructionCode_txt.Focus();

                return false;
            }

            if (InspectionTestInstructionText_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionTestInstructionText_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InspectionTestInstructionText_txt.Focus();

                return false;
            }

            if (InspectionItem_cmb.Text == string.Empty || InspectionItem_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionItem_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InspectionItem_cmb.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// Loads selected data from data grid
        /// </summary>
        /// <param name="dgvInspectionTestInstruction"></param>
        private void LoadInspectionTestInstructionData(InspectionTestInstructionVo dgvInspectionTestInstruction)
        {
            if (dgvInspectionTestInstruction != null)
            {
                this.InspectionTestInstructionCode_txt.Text = dgvInspectionTestInstruction.InspectionTestInstructionCode;

                this.InspectionTestInstructionText_txt.Text = dgvInspectionTestInstruction.InspectionTestInstructionText;
                
                this.InspectionItem_cmb.SelectedValue = dgvInspectionTestInstruction.InspectionItemId.ToString();
            }
        }

        /// <summary>
        /// Loads inspectionitem details to datatable
        /// </summary>
        private void FormDatatableFromVo()
        {
            inspectionitemDatatable = new DataTable();
            inspectionitemDatatable.Columns.Add("Id");
            inspectionitemDatatable.Columns.Add("Name");

            ValueObjectList<InspectionItemVo> inspectionItemOutVo = null;

            try
            {

                inspectionItemOutVo = (ValueObjectList<InspectionItemVo>)base.InvokeCbm(new GetInspectionItemMasterCbm(), new InspectionItemVo(), false);

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            if (inspectionItemOutVo == null || inspectionItemOutVo.GetList() == null || inspectionItemOutVo.GetList().Count == 0)
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return;
            }

            foreach (InspectionItemVo fac in inspectionItemOutVo.GetList())
            {
                inspectionitemDatatable.Rows.Add(fac.InspectionItemId, fac.InspectionItemName);
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
        /// checks duplicate Inspection Specification code
        /// </summary>
        /// <returns></returns>
        private InspectionTestInstructionVo DuplicateCheck(InspectionTestInstructionVo InsSpecVo)
        {
            InspectionTestInstructionVo outVo = new InspectionTestInstructionVo();

            try
            {
                outVo = (InspectionTestInstructionVo)base.InvokeCbm(new CheckInspectionTestInstructionMasterMntCbm(), InsSpecVo, false);
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
            InspectionTestInstructionVo inVo = new InspectionTestInstructionVo();
            var sch = StringCheckHelper.GetInstance();
            if (CheckMandatory() == true)
            {                
                inVo.InspectionTestInstructionCode = InspectionTestInstructionCode_txt.Text.Trim();

                inVo.InspectionTestInstructionText = InspectionTestInstructionText_txt.Text.Trim();
                
                inVo.InspectionItemId = Convert.ToInt32(InspectionItem_cmb.SelectedValue.ToString());

                inVo.Mode = mode;

                if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                {
                    inVo.InspectionTestInstructionId = updateData.InspectionTestInstructionId;
                }

                InspectionTestInstructionVo checkVo = DuplicateCheck(inVo);

                if (checkVo != null && checkVo.AffectedCount > 0)
                {
                    messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, InspectionTestInstructionCode_lbl.Text + " : " + InspectionTestInstructionCode_txt.Text +
                                                                                Environment.NewLine + " OR " + Environment.NewLine + InspectionItem_lbl.Text + " : " + InspectionItem_cmb.Text);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);

                    return;
                }

                try
                {
                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        InspectionTestInstructionVo outVo = (InspectionTestInstructionVo)base.InvokeCbm(new AddInspectionTestInstructionMasterMntCbm(), inVo, false);

                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        InspectionTestInstructionVo outVo = (InspectionTestInstructionVo)base.InvokeCbm(new UpdateInspectionTestInstructionMasterMntCbm(), inVo, false);

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

            ComboBind(InspectionItem_cmb, inspectionitemDatatable, "Name", "Id");

            InspectionTestInstructionCode_txt.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadInspectionTestInstructionData(updateData);

                InspectionTestInstructionCode_txt.Enabled = false;

                InspectionTestInstructionText_txt.Select();

            }
        }

        #endregion
        
    }
}
