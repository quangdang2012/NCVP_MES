using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class GroupMachineForm : FormCommonNCVP
    {
        public GroupMachineForm()
        {
            InitializeComponent();
        }
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {
            Machine_dgv.DataSource = null;

            GroupMachine_cmb.ResetText();
        }
        private void GridBind()
        {
            Machine_dgv.DataSource = null;

            try
            {
                GroupMachineVo vo = new Vo.GroupMachineVo
                {
                    GroupMachineName = GroupMachine_cmb.Text
                };
                ValueObjectList<GroupMachineVo> volist = (ValueObjectList<GroupMachineVo>)DefaultCbmInvoker.Invoke(new GetGroupMachineCbm(), vo);
                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    Machine_dgv.AutoGenerateColumns = false;
                    BindingSource bindingSource1 = new BindingSource(volist.GetList(), null);
                    Machine_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                Machine_dgv.ClearSelection();

                Update_btn.Enabled = false;

                Delete_btn.Enabled = false;
            }
            catch (Com.Nidec.Mes.Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddGroupMachineForm newAddForm = new AddGroupMachineForm();
            newAddForm.vo = new GroupMachineVo();
            if (newAddForm.ShowDialog() == DialogResult.OK)
            {
                GridBind();
            }
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (Machine_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (Machine_dgv.SelectedRows.Count > 0)
            {
                int selectedrowindex = Machine_dgv.SelectedCells[0].RowIndex;

                GroupMachineVo vo = (GroupMachineVo)Machine_dgv.Rows[selectedrowindex].DataBoundItem;

                messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, vo.GroupMachineCode);
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);


                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        GroupMachineVo outVo = (GroupMachineVo)DefaultCbmInvoker.Invoke(new DeleteGroupMachineCbm(), vo);

                        if (outVo.AffectedCount > 0)
                        {
                            messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                            logger.Info(messageData);
                            popUpMessage.Information(messageData, Text);

                            GridBind();
                        }
                        else if (outVo.AffectedCount == 0)
                        {
                            messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                            logger.Info(messageData);
                            popUpMessage.Information(messageData, Text);
                            GridBind();
                        }
                    }
                    catch (Com.Nidec.Mes.Framework.ApplicationException exception)
                    {
                        popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                        logger.Error(exception.GetMessageData());
                    }
                }
            }
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind();
        }

        private void Machine_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Update_btn.Enabled = Delete_btn.Enabled = Machine_dgv.SelectedRows.Count > 0;
        }

        private void Machine_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Machine_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }
        /// <summary>
        /// selects user record for updation and show user form
        /// </summary>
        private void BindUpdateCavityData()
        {
            int selectedrowindex = Machine_dgv.SelectedCells[0].RowIndex;

            GroupMachineVo vo = (GroupMachineVo)Machine_dgv.Rows[selectedrowindex].DataBoundItem;

            AddGroupMachineForm addform = new AddGroupMachineForm();
            addform.vo = vo;

            if (addform.IntSuccess > 0)
            {
                messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);

                GridBind();
            }
            else if (addform.IntSuccess == 0)
            {
                messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                GridBind();
            }
        }

        private void GroupMachineForm_Load(object sender, EventArgs e)
        {
            ValueObjectList<GroupMachineVo> machinevo = (ValueObjectList<GroupMachineVo>)DefaultCbmInvoker.Invoke(new GetGroupMachineNameCbm(), new GroupMachineVo());
            GroupMachine_cmb.DisplayMember = "GroupMachineName";
            BindingSource b4 = new BindingSource(machinevo.GetList(), null);
            GroupMachine_cmb.DataSource = b4;
            GroupMachine_cmb.ResetText();

            Machine_dgv.ClearSelection();

            Update_btn.Enabled = false;

            Delete_btn.Enabled = false;
        }
    }
}
