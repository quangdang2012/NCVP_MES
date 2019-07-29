using System;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Resources;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Drawing;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class ProcessWorkMachineForm
    {
        #region Variables
       
        /// <summary>
        /// Check for Database operation success
        /// </summary>
        public int IntSuccess = -1;
        public int IntDelSuccess = -1;

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddProcessForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        private bool isProcessListLoading = false;
        #endregion

        #region Constructor
        /// <summary>
        /// constructor for the form
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="dataItem"></param>
        public ProcessWorkMachineForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods


        private void LoadProcessWorkListBox()
        {
            isProcessListLoading = true;
            ProcessWorkVo outPwVo = (ProcessWorkVo)DefaultCbmInvoker.Invoke(new GetProcessWorkMasterMntCbm(), new ProcessWorkVo());
            
            if (outPwVo.ProcessWorkListVo.Count > 0)
            {
                outPwVo.ProcessWorkListVo.ForEach(p => p.ProcessWorkName = p.ProcessWorkCode + " " + p.ProcessWorkName);

                ProcessWork_lst.DataSource = outPwVo.ProcessWorkListVo;
                ProcessWork_lst.DisplayMember = "ProcessWorkName";
                ProcessWork_lst.ValueMember = "ProcessWorkId";
                ProcessWork_lst.SelectedIndex = -1;
                isProcessListLoading = false;
                Update_btn.Enabled = true;
            }
            else
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, ProcessWork_lbl.Text);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                Update_btn.Enabled = false;

            }
        }


        private void LoadMachineListBox()
        {

            MachineVo outMVo = (MachineVo)DefaultCbmInvoker.Invoke(new GetMachineMasterMntCbm(), new MachineVo());


            if (outMVo.MachineListVo.Count > 0)
            {
                outMVo.MachineListVo.ForEach(l => l.MachineName = l.MachineCode + " " + l.MachineName);
                Machine_chlst.DataSource = outMVo.MachineListVo;
                Machine_chlst.DisplayMember = "MachineName";
                Machine_chlst.ValueMember = "MachineId";
                Update_btn.Enabled = true;
            }
            else
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, Machine_lbl.Text);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                Update_btn.Enabled = false;

            }
        }

        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {
            if (ProcessWork_lst.SelectedValue == null || ProcessWork_lst.SelectedValue.ToString() == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, ProcessWork_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                ProcessWork_lst.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// checks duplicate Process Code
        /// </summary>
        /// <param name="processVo"></param>
        /// <returns></returns>
        private ProcessWorkMachineVo DuplicateCheck(ProcessWorkMachineVo pwmachineVo)
        {
            ProcessWorkMachineVo outVo = new ProcessWorkMachineVo();

            try
            {
                outVo = (ProcessWorkMachineVo)base.InvokeCbm(new CheckProcessWorkMachineMasterMntCbm(), pwmachineVo, false);
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
        /// load the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessWorkMachineForm_Load(object sender, EventArgs e)
        {
            LoadProcessWorkListBox();

            ProcessWork_lst.ClearSelected();
           
        }
        #endregion

        #region ButtonClick

        /// <summary>
        /// closes form on exit click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// inserts/updates process on ok click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if(CheckMandatory())
                {
                    ProcessWorkMachineVo inVo = new ProcessWorkMachineVo();

                    inVo.ProcessWorkId = Convert.ToInt32(ProcessWork_lst.SelectedValue);

                    ProcessWorkMachineVo outDeleteCheckVo = (ProcessWorkMachineVo)base.InvokeCbm(new GetProcessWorkMachineMasterMntCbm(), inVo, false);

                    if (outDeleteCheckVo.ProcessWorkMachineListVo.Count > 0)
                    {
                        ProcessWorkMachineVo outDeleteVo = (ProcessWorkMachineVo)base.InvokeCbm(new DeleteProcessWorkMachineMasterMntCbm(), inVo, false);
                        IntDelSuccess = outDeleteVo.AffectedCount;
                    }

                    ProcessWorkMachineVo outVo = new ProcessWorkMachineVo();

                    inVo.FactoryCode = UserData.GetUserData().FactoryCode;
                    inVo.RegistrationUserCode = UserData.GetUserData().UserCode;

                   

                    foreach (var item in Machine_chlst.CheckedItems)
                    {
                        var machine = (MachineVo)item;

                        inVo.MachineId = machine.MachineId;

                        if (Properties.Settings.Default.MACHINE_PER_PROCESSWORK_CONSTRAINT)
                        {
                            ProcessWorkMachineVo checkVo = DuplicateCheck(inVo);

                            if (checkVo != null && checkVo.AffectedCount > 0)
                            {
                                messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, Machine_lbl.Text + " : " + Machine_chlst.Text);
                                logger.Info(messageData);
                                popUpMessage.ApplicationError(messageData, Text);
                                return;
                            }
                        }

                        outVo = (ProcessWorkMachineVo)base.InvokeCbm(new AddProcessWorkMachineMasterMntCbm(), inVo, false);
                    }

                    IntSuccess = outVo.AffectedCount;

                    if ((IntSuccess > 0) || (IntDelSuccess > 0))
                    {
                        messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                        logger.Info(messageData);
                        popUpMessage.Information(messageData, Text);
                    }
                }

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }
            
        }
        #endregion


        private void ProcessWork_lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isProcessListLoading) return;
            if(ProcessWork_lst.SelectedIndex < 0) { return; }

            if (Machine_chlst.Items.Count == 0) { LoadMachineListBox(); }
            this.Cursor = Cursors.WaitCursor;
            
            ProcessWorkMachineVo inVo = new ProcessWorkMachineVo();
            //inVo.ProcessWorkId = Convert.ToInt32(ProcessWork_lst.SelectedIndex);
            inVo.ProcessWorkId = Convert.ToInt32(ProcessWork_lst.SelectedValue.ToString());
            ProcessWorkMachineVo checkVo = (ProcessWorkMachineVo)base.InvokeCbm(new GetProcessWorkMachineMasterMntCbm(), new ProcessWorkMachineVo(), false);

            Machine_chlst.ClearSelected();

            //for (int i = 0; i < Machine_chlst.Items.Count - 1; i++)
            //{
            //    var machine = (MachineVo)Machine_chlst.Items[i];
            //    if (checkVo.ProcessWorkMachineListVo.Exists(x => x.MachineId == machine.MachineId))
            //    {
            //        Machine_chlst.SetItemCheckState(i, CheckState.Indeterminate);
            //    }
            //}

            ProcessWorkMachineVo outVo = (ProcessWorkMachineVo)base.InvokeCbm(new GetProcessWorkMachineMasterMntCbm(), inVo, false);

            for (int i = 0; i < Machine_chlst.Items.Count; i++)
            {
                var machine = (MachineVo)Machine_chlst.Items[i];
                Machine_chlst.SetItemChecked(i, outVo.ProcessWorkMachineListVo.Exists(x => x.MachineId == machine.MachineId));
            }

            this.Cursor = Cursors.Default;
        }
    }
}
