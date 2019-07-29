using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance;
using Com.Nidec.Mes.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.ReportDownTimeCbm.ProcessWork;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance
{
    public partial class ProcessWForm : FormCommonNCVP
    {
        public ProcessWForm()
        {
            InitializeComponent();
        }
        private void GridBind()
        {
            ProcessWDetails_dgv.DataSource = null;
            try
            {
                ValueObjectList<ProcessWorksVo> volist;
                if (!String.IsNullOrEmpty(Machine_cmb.Text))
                {
                    volist = (ValueObjectList<ProcessWorksVo>)DefaultCbmInvoker.Invoke(new GetAllProcessWorkCbm(), new ProcessWorksVo
                    {
                        ProcessWorkCode = ProcessWorkCode_txt.Text,
                        ProcessWorkName = ProcessWorkName_txt.Text,
                        MachineID = ((MachineVo)Machine_cmb.SelectedItem).MachineId
                    });
                }
                else
                {
                    volist = (ValueObjectList<ProcessWorksVo>)DefaultCbmInvoker.Invoke(new GetAllProcessWorkCbm(), new ProcessWorksVo
                    {
                        ProcessWorkCode = ProcessWorkCode_txt.Text,
                        ProcessWorkName = ProcessWorkName_txt.Text,
                        //MachineID = ((MachineVo)Machine_cmb.SelectedItem).MachineId
                    });
                }

                if (volist.GetList() != null && volist.GetList().Count > 0)
                {
                    ProcessWDetails_dgv.AutoGenerateColumns = false; 
                    ProcessWDetails_dgv.DataSource = volist.GetList();
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }
                ProcessWDetails_dgv.ClearSelection();
                Update_btn.Enabled = false;
                Delete_btn.Enabled = false;
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        private void Add_btn_Click(object sender, EventArgs e)
        {
            AddProcessWForm Formadd = new AddProcessWForm();
            Formadd.vo = new ProcessWorksVo();
            if (Formadd.ShowDialog() == DialogResult.OK)
            {
                GridBind();
            }
        }

        private void Clear_btn_Click(object sender, EventArgs e)
        {

            ProcessWorkCode_txt.Text = string.Empty;
            ProcessWorkName_txt.Text = string.Empty;
            ProcessWDetails_dgv.DataSource = null;
            Update_btn.Enabled = Delete_btn.Enabled = false;
            ProcessWorkCode_txt.Select();
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (ProcessWDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }
        private void BindUpdateCavityData()
        {
            int selectedrowindex = ProcessWDetails_dgv.SelectedCells[0].RowIndex;

            ProcessWorksVo vo = (ProcessWorksVo)ProcessWDetails_dgv.Rows[selectedrowindex].DataBoundItem;

            AddProcessWForm addform = new AddProcessWForm();
            addform.vo = vo;
            addform.ShowDialog();
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
        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (ProcessWDetails_dgv.SelectedRows.Count > 0)
            {
                int selectedrowindex = ProcessWDetails_dgv.SelectedCells[0].RowIndex;

                ProcessWorksVo vo = (ProcessWorksVo)ProcessWDetails_dgv.Rows[selectedrowindex].DataBoundItem;

                messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, vo.ProcessWorkCode);
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        ProcessWorksVo outVo = (ProcessWorksVo)DefaultCbmInvoker.Invoke(new DeleteProcessWorkCbm(), vo);

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

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProcessWForm_Load(object sender, EventArgs e)
        {
            MachineVo machinevo = (MachineVo)DefaultCbmInvoker.Invoke(new GetMachineMasterMntCbm(), new MachineVo());
            Machine_cmb.DisplayMember = "MachineName";
            BindingSource b4 = new BindingSource(machinevo.MachineListVo, null);
            Machine_cmb.DataSource = b4;
            Machine_cmb.Text = "";
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind();
        }

        private void RankDetails_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Update_btn.Enabled = Delete_btn.Enabled = ProcessWDetails_dgv.SelectedRows.Count > 0;
        }

        private void RankDetails_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ProcessWDetails_dgv.SelectedRows.Count > 0)
            {
                BindUpdateCavityData();
            }
        }
    }
}
