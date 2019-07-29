using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddCustomerLineForm : FormCommonNCVP
    {

        #region Variables

        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly FactoryProductionDaysVo updateData;

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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddCustomerLineForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        #endregion

        #region Constructor

        public AddCustomerLineForm()
        {
            InitializeComponent();
        }

        public AddCustomerLineForm(string pmode, FactoryProductionDaysVo customerLineItem = null)
        {
            InitializeComponent();

            mode = pmode;
            updateData = customerLineItem; // Need to change Vo

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                this.Text = UpdateText_lbl.Text;
            }
        }

        #endregion

        public GroupMachineVo vo = null;

        #region FormEvent

        private void AddGroupMachineForm_Load(object sender, EventArgs e)
        {
            // Create method which get Line and Customer information for combo box
            Customer_cmb.Select();

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadCustomerLinesData(updateData);
                Customer_cmb.Enabled = false;
                Line_cmb.Select();
            }
        }

        #endregion

        private void LoadCustomerLinesData(FactoryProductionDaysVo dgvCustomerLine)
        {
            if (dgvCustomerLine != null)
            {
                Customer_cmb.Text = dgvCustomerLine.BuildingName; //Need to change Vo and name
            }
        }


        #region Button Click

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Ok_btn_Click(object sender, EventArgs e)
        {
            if (CheckDate())
            {
                GroupMachineVo outVo = new GroupMachineVo();
                GroupMachineVo inVo = new GroupMachineVo
                {
                    GroupMachineId = vo.GroupMachineId,
                    GroupMachineCode = GroupMachineCode_txt.Text,
                    GroupMachineName = GroupMachineName_txt.Text,
                    FactoryCode = UserData.GetUserData().FactoryCode,
                    RegistrationUserCode = UserData.GetUserData().UserCode
                };
                try
                {
                    if (inVo.GroupMachineId > 0)
                    { outVo = (GroupMachineVo)DefaultCbmInvoker.Invoke(new UpdateGroupMachineCbm(), inVo); }
                    else
                    { outVo = (GroupMachineVo)DefaultCbmInvoker.Invoke(new AddGroupMachineCbm(), inVo); }
                }
                catch (Com.Nidec.Mes.Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }
                if ((IntSuccess > 0) || (IntSuccess == 0))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
        }

        #endregion

        private bool CheckDate()
        {
            if (GroupMachineCode_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, Customer_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                GroupMachineCode_txt.Focus();
                return false;
            }
            if (GroupMachineName_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, Line_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                GroupMachineName_txt.Focus();
                return false;
            }
            GroupMachineCode_txt.Text = GroupMachineCode_txt.Text.Trim();
            GroupMachineName_txt.Text = GroupMachineName_txt.Text.Trim();
            GroupMachineVo outVo = new GroupMachineVo(),
                inVo = new GroupMachineVo { GroupMachineId = vo.GroupMachineId, GroupMachineCode = GroupMachineCode_txt.Text };
            try
            {
                outVo = (GroupMachineVo)DefaultCbmInvoker.Invoke(new CheckGroupMachineCbm(), inVo);
                if (outVo.AffectedCount > 0)
                {
                    messageData = new MessageData("mmcc00006", Properties.Resources.mmcc00006, Customer_lbl.Text);
                    popUpMessage.Warning(messageData, Text);
                    GroupMachineCode_txt.Focus();
                    return false;
                }
            }
            catch (Com.Nidec.Mes.Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return false;
            }
            return true;
        }
    }
}
