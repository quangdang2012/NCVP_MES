using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form;
using Com.Nidec.Mes.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.ReportDownTimeCbm.ProcessWork;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance
{
    public partial class AddProcessWForm : FormCommonNCVP
    {
        public AddProcessWForm()
        {
            InitializeComponent();
        }
        public ProcessWorksVo vo = null;
        public int IntSuccess = -1;
        private void Ok_btn_Click(object sender, EventArgs e)
        {
            ProcessWorksVo outvo = new ProcessWorksVo();
            ProcessWorksVo invo = new ProcessWorksVo
            {
                ProcessWorkId = vo.ProcessWorkId,
                ProcessWorkCode = ProcessCode_txt.Text,
                ProcessWorkName = ProcessName_txt.Text,
                ModelID = ((ModelVo)Model_cmb.SelectedItem).ModelId,
                AssyID = ((ProcessVo)Assy_cmb.SelectedItem).ProcessId,
                MachineID = ((MachineVo)Machine_cmb.SelectedItem).MachineId,
                IsPhantom = "0",
                FactoryCode = UserData.GetUserData().FactoryCode,
                RegistrationUserCode = UserData.GetUserData().UserCode
            };
            try
            {
                if (invo.ProcessWorkId > 0)
                {
                    outvo = (ProcessWorksVo)DefaultCbmInvoker.Invoke(new UpdateProcessWorkCbm(), invo);
                }
                else
                {
                    outvo = (ProcessWorksVo)DefaultCbmInvoker.Invoke(new AddProcessWorkCbm(), invo);
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }

            if (outvo.AffectedCount > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void AddProcessWForm_Load(object sender, EventArgs e)
        {
            ValueObjectList<ModelVo> modelvolist = (ValueObjectList<ModelVo>)DefaultCbmInvoker.Invoke(new GetModelCbm(), new ModelVo());
            Model_cmb.DisplayMember = "ModelCode";
            BindingSource b1 = new BindingSource(modelvolist.GetList(), null);
            Model_cmb.DataSource = b1;
            Model_cmb.Text = "";

            ProcessVo processvo = (ProcessVo)DefaultCbmInvoker.Invoke(new GetProcessMasterMntCbm(), new ProcessVo());
            Assy_cmb.DisplayMember = "ProcessName";
            BindingSource b2 = new BindingSource(processvo.ProcessListVo, null);
            Assy_cmb.DataSource = b2;
            Assy_cmb.Text = "";

            MachineVo machinevo = (MachineVo)DefaultCbmInvoker.Invoke(new GetMachineMasterMntCbm(), new MachineVo());
            Machine_cmb.DisplayMember = "MachineName";
            BindingSource b4 = new BindingSource(machinevo.MachineListVo, null);
            Machine_cmb.DataSource = b4;
            Machine_cmb.Text = "";

            ProcessCode_txt.Select();
            Model_cmb.ResetText();
            Assy_cmb.ResetText();
            Machine_cmb.ResetText();

            if (vo.ProcessWorkId > 0)
            {
                ProcessCode_txt.Text = vo.ProcessWorkCode;
                ProcessName_txt.Text = vo.ProcessWorkName;
                Model_cmb.Text = vo.Model;
                Assy_cmb.Text = vo.Assy;
                Machine_cmb.Text = vo.Machine;
            }
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
