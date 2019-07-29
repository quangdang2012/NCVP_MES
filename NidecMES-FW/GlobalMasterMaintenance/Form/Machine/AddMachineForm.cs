using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class AddMachineForm
    {
        #region Variables
        /// <summary>
        /// set mode based on insert/update
        /// </summary>
        private readonly string mode;

        /// <summary>
        /// user record selected for update
        /// </summary>
        private readonly MachineVo updateData;

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
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(AddProcessForm));

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;
        #endregion

        #region Constructor
        /// <summary>
        /// constructor for the form
        /// </summary>
        /// <param name="pmode"></param>
        /// <param name="dataItem"></param>
        public AddMachineForm(string pmode, MachineVo dataItem = null)
        {
            InitializeComponent();

            mode = pmode;
          
            updateData = dataItem;

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
            if (MachineCode_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, MachineCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                MachineCode_txt.Focus();

                return false;
            }
            if (MachineName_txt.Text == string.Empty)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, MachineName_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                MachineName_txt.Focus();

                return false;
            }

            return true;
        }

        /// <summary>
        /// For setting selected user record into respective controls(textbox and combobox) for update operation
        /// passing selected user data as parameter 
        /// </summary>
        /// <param name="dgvData"></param>
        private void LoadUserData(MachineVo dgvData)
        {
            if (dgvData != null)
            {
                MachineCode_txt.Text = dgvData.MachineCode;

                MachineName_txt.Text = dgvData.MachineName;
            }
        }

        /// <summary>
        /// checks duplicate Process Code
        /// </summary>
        /// <param name="processVo"></param>
        /// <returns></returns>
        private MachineVo DuplicateCheck(MachineVo machineVo)
        {
            MachineVo outVo = new MachineVo();

            try
            {
                outVo = (MachineVo)base.InvokeCbm(new CheckMachineMasterMntCbm(), machineVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            return outVo;
        }


        private void LoadProcessWork(int pMachineId)
        {
            ProcessWorkVo outVo = null;

            try
            {
                outVo = (ProcessWorkVo)DefaultCbmInvoker.Invoke(new GetProcessWorkMasterMntCbm(), new ProcessWorkVo());

                outVo.ProcessWorkListVo.ForEach(t => t.ProcessWorkName = string.Concat(t.ProcessWorkCode + "  ", t.ProcessWorkName));
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

            ProcessWorkMachineVo processMachineLineInVo = new ProcessWorkMachineVo();
            processMachineLineInVo.MachineId = pMachineId;

            ProcessWorkMachineVo processWorkMachineOutVo = (ProcessWorkMachineVo)DefaultCbmInvoker.Invoke(new GetProcessWorkMachineMasterMntCbm (), processMachineLineInVo);

            if (processWorkMachineOutVo != null && pMachineId > 0)
            {
                foreach (ProcessWorkVo item in outVo.ProcessWorkListVo)
                {
                    item.IsExists = processWorkMachineOutVo.ProcessWorkMachineListVo.Exists(t => t.ProcessWorkId == item.ProcessWorkId) ? "True" : "False";
                }
            }

            BindingSource bindingSource = new BindingSource(outVo.ProcessWorkListVo, null);
            ProcessWork_dgv.AutoGenerateColumns = false;
            ProcessWork_dgv.DataSource = bindingSource;
        }

        private ProcessWorkMachineVo GetSelectedProcessWork()
        {
            BindingSource bsProcessWork = (BindingSource)ProcessWork_dgv.DataSource;
            ProcessWorkMachineVo processWorkMachineInVo = new ProcessWorkMachineVo();

            if (bsProcessWork != null && bsProcessWork.List.Count > 0)
            {
                foreach (ProcessWorkVo processWorkVo in bsProcessWork.List)
                {
                    if (processWorkVo.IsExists == "True")
                    {
                        ProcessWorkMachineVo addVo = new ProcessWorkMachineVo()
                        {
                            ProcessWorkId = processWorkVo.ProcessWorkId
                        };
                        processWorkMachineInVo.ProcessWorkMachineListVo.Add(addVo);
                    }
                }
            }

            return processWorkMachineInVo;
        }
        #endregion

        #region FormEvents
        /// <summary>
        /// load the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddMachineForm_Load(object sender, EventArgs e)
        {
            MachineCode_txt.Select();

            int machineId = 0;

            if (string.Equals(mode, CommonConstants.MODE_UPDATE))
            {
                LoadUserData(updateData);

                machineId = updateData.MachineId;

                MachineCode_txt.Enabled = false;

                MachineName_txt.Select();

            }

            LoadProcessWork(machineId);
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
            if (CheckMandatory())
            {
                

                var sch = StringCheckHelper.GetInstance();

                if (!sch.IsASCII(MachineCode_txt.Text))
                {
                    messageData = new MessageData("mmce00003", Properties.Resources.mmce00003);
                    logger.Info(messageData);
                    popUpMessage.ConfirmationOkCancel(messageData, Text);
                    MachineCode_txt.Focus();
                    return;
                }

                MachineVo inVo = new MachineVo
                {
                    MachineCode = MachineCode_txt.Text.Trim(),
                    MachineName = MachineName_txt.Text.Trim(),
                    //RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                    RegistrationUserCode = UserData.GetUserData().UserCode,
                    FactoryCode = UserData.GetUserData().FactoryCode
                };

                if (string.Equals(mode, CommonConstants.MODE_ADD))
                {
                    MachineVo checkVo = DuplicateCheck(inVo);

                    if (checkVo != null && checkVo.AffectedCount > 0)
                    {
                        messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, MachineCode_lbl.Text + " : " + MachineCode_txt.Text);
                        logger.Info(messageData);
                        popUpMessage.ApplicationError(messageData, Text);

                        return;
                    }
                }

                ValueObjectList<ValueObject> inVoList = new ValueObjectList<ValueObject>();


                try
                {
                    this.StartProgress(Properties.Resources.mmci00009);

                    if (string.Equals(mode, CommonConstants.MODE_ADD))
                    {
                        inVoList.add(inVo);
                        inVoList.add(GetSelectedProcessWork());

                        MachineVo outVo = (MachineVo)base.InvokeCbm(new AddMachineMasterAndProcessworkCbm(), inVoList, false);

                        IntSuccess = (outVo.MachineId > 0) ? 1 : 0;
                    }
                    else if (mode.Equals(CommonConstants.MODE_UPDATE))
                    {
                        inVo.MachineId = updateData.MachineId;

                        inVoList.add(inVo);
                        inVoList.add(GetSelectedProcessWork());

                        MachineVo outVo = (MachineVo)base.InvokeCbm(new UpdateMachineMasterAndProcessworkCbm(), inVoList, false);

                        IntSuccess = (outVo.AffectedCount > 0) ? 1 : 0;
                    }

                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }
                finally
                {
                    this.CompleteProgress();
                }

                if ((IntSuccess > 0) || (IntSuccess == 0))
                {
                    this.Close();
                }
            }
        }
        #endregion

        /// <summary>
        /// Select and Deselect all Processwork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void CheckAll_chk_CheckedChanged(object sender, EventArgs e)
        {
            if (!CheckAll_chk.Checked)
            {
                foreach (DataGridViewRow row in ProcessWork_dgv.Rows)
                {
                    if (row.Cells["colSelect"].ReadOnly == false)
                    {
                        row.Cells["colSelect"].Value = null;
                    }

                }
            }
            else
            {
                foreach (DataGridViewRow row in ProcessWork_dgv.Rows)
                {
                    if (row.Cells["colSelect"].ReadOnly == false)
                    {
                        row.Cells["colSelect"].Value = "True";
                    }

                }
            }
        }
    }
}
