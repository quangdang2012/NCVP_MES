using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.Framework;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddInspectionItemForm
    {
        #region Variables

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly InspectionItemVo updateData;

        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;
        
        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddInspectionItemForm));

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
        /// <param name="InspectionItem"></param>
        public AddInspectionItemForm(string pmode, InspectionItemVo InspectionItem = null)
        {
            InitializeComponent();

            mode = pmode;
            updateData = InspectionItem;


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
            if (InspectionItemCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionItemCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InspectionItemCode_txt.Focus();

                return false;
            }

            if (InspectionItemName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, InspectionItemName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                InspectionItemName_txt.Focus();

                return false;
            }
            
            return true;
        }
        
        /// <summary>
        /// For setting selected user record into respective controls(textbox and combobox) for update operation
        /// passing selected user data as parameter 
        /// </summary>
        /// <param name="InspectioninVo"></param>
        private void LoadInspectionItemData(InspectionItemVo InspectioninVo)
        {
            if (InspectioninVo != null)
            {
                InspectionItemCode_txt.Text = InspectioninVo.InspectionItemCode;
                InspectionItemName_txt.Text = InspectioninVo.InspectionItemName;
                ParentItemCode_cmb.SelectedValue = InspectioninVo.ParentInspectionItemId;
                InspectionProcess_cmb.SelectedValue = InspectioninVo.InspectionProcessId;
                InspectionItemMandatory_chk.Checked = Convert.ToBoolean(InspectioninVo.InspectionItemMandatory);
                InspectionEmployeeMandatory_chk.Checked = Convert.ToBoolean(InspectioninVo.InspectionEmployeeMandatory);
                InspectionMachineMandatory_chk.Checked = Convert.ToBoolean(InspectioninVo.InspectionMachineMandatory);
            }
        }

        /// <summary>
        /// Load Inspection Process
        /// </summary>
        private void LoadInspectionProcessCombo()
        {
            ValueObjectList<InspectionProcessVo> outVo = null;
            try
            {
                outVo = (ValueObjectList<InspectionProcessVo>)base.InvokeCbm(new GetInsepctionProcessMasterMntCbm(), new InspectionProcessVo(), false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            if (outVo == null || outVo.GetList() == null || outVo.GetList().Count == 0)
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return;
            }
            InspectionProcess_cmb.DataSource = outVo.GetList();
            InspectionProcess_cmb.DisplayMember = "InspectionProcessName";
            InspectionProcess_cmb.ValueMember = "InspectionProcessId";
            InspectionProcess_cmb.SelectedIndex = -1;
        }

        /// <summary>
        /// Load Parent Inspection Data
        /// </summary>
        private void LoadParentInspectionCombo()
        {
            ValueObjectList<InspectionItemVo> outVo = null;
            try
            {
                outVo = (ValueObjectList<InspectionItemVo>)base.InvokeCbm(new GetParentInspectionItemIdMasterMntCbm(), new InspectionItemVo(), false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            if (outVo == null || outVo.GetList() == null || outVo.GetList().Count == 0)
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return;
            }
            ParentItemCode_cmb.DataSource = outVo.GetList();
            ParentItemCode_cmb.DisplayMember = "InspectionItemCode";
            ParentItemCode_cmb.ValueMember = "InspectionItemId";
            ParentItemCode_cmb.SelectedIndex = -1;
        }


        /// <summary>
        /// checks duplicate Inspection item
        /// </summary>
        /// <param name="InspectionVo"></param>
        /// <returns></returns>
        private InspectionItemVo DuplicateCheck(InspectionItemVo InspectionVo)
        {
            InspectionItemVo outVo = new InspectionItemVo();

            try
            {
                outVo = (InspectionItemVo)base.InvokeCbm(new CheckInspectionItemMasterMntCbm(), InspectionVo, false);
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
        /// load data from db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddInspectionItemForm_Load(object sender, EventArgs e)
        {

            LoadInspectionProcessCombo();

            LoadParentInspectionCombo();

            InspectionItemCode_txt.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadInspectionItemData(updateData);

                InspectionItemCode_txt.Enabled = false;

                InspectionItemName_txt.Select();

            }
        }

        #endregion

        #region ButtonClick

        /// <summary>
        /// update data to db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            var sch = StringCheckHelper.GetInstance();

            InspectionItemVo inVo = new InspectionItemVo();

            if (CheckMandatory())
            {
                if (string.IsNullOrEmpty(InspectionItemCode_txt.Text))
                {
                    messageData = new MessageData("mmce00006", Properties.Resources.mmce00006, InspectionItemCode_lbl.Text);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);
                    InspectionItemCode_txt.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(InspectionItemName_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);
                    InspectionItemName_txt.Focus();
                    return;
                }
                inVo.InspectionItemCode = InspectionItemCode_txt.Text.Trim();

                inVo.InspectionItemName = InspectionItemName_txt.Text.Trim();

                if (ParentItemCode_cmb.SelectedIndex > -1)
                {
                    inVo.ParentInspectionItemId =Convert.ToInt32(ParentItemCode_cmb.SelectedValue.ToString());
                }
                if (InspectionProcess_cmb.SelectedIndex > -1)
                {
                    inVo.InspectionProcessId = Convert.ToInt32(InspectionProcess_cmb.SelectedValue);
                }
                inVo.InspectionItemMandatory = Convert.ToInt32(InspectionItemMandatory_chk.Checked);

                inVo.InspectionEmployeeMandatory = Convert.ToInt32(InspectionEmployeeMandatory_chk.Checked);

                inVo.InspectionMachineMandatory = Convert.ToInt32(InspectionMachineMandatory_chk.Checked);
                
                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    InspectionItemVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, InspectionItemCode_lbl.Text + " : " + InspectionItemCode_txt.Text);
                        popUpMessage.ConfirmationOkCancel(messageData, Text);

                        return;
                    }
                }

                try
                {

                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        InspectionItemVo outVo = (InspectionItemVo)base.InvokeCbm(new AddInspectionItemMasterMntCbm(), inVo, false);
                        IntSuccess = outVo.AffectedCount;
                    }
                    else if (string.Equals(mode, CommonConstants.MODE_UPDATE))
                    {
                        InspectionItemVo outVo = (InspectionItemVo)base.InvokeCbm(new UpdateInspectionItemMasterMntCbm(), inVo, false);
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
        /// close the form
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
