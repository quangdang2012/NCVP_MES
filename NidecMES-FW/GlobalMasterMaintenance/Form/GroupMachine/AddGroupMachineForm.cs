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
    public partial class AddGroupMachineForm : FormCommonNCVP
    {
        public AddGroupMachineForm()
        {
            InitializeComponent();
        }

        public GroupMachineVo vo = null;
        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;

        private void AddGroupMachineForm_Load(object sender, EventArgs e)
        {
            GroupMachineCode_txt.Select();
            if (vo.GroupMachineId > 0)
            {
                GroupMachineCode_txt.Text = vo.GroupMachineCode;
                GroupMachineName_txt.Text = vo.GroupMachineName;
            }

            MachineVo machinevo = (MachineVo)DefaultCbmInvoker.Invoke(new GetMachineMasterMntCbm(), new MachineVo());
            Machine_cmb.DisplayMember = "MachineName";
            BindingSource b4 = new BindingSource(machinevo.MachineListVo, null);
            Machine_cmb.DataSource = b4;
            Machine_cmb.Text = "";
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
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

        private bool CheckDate()
        {
            if (GroupMachineCode_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, GroupMachineCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                GroupMachineCode_txt.Focus();
                return false;
            }
            if (GroupMachineName_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, GroupMachineName_lbl.Text);
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
                    messageData = new MessageData("mmcc00006", Properties.Resources.mmcc00006, GroupMachineCode_lbl.Text);
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
