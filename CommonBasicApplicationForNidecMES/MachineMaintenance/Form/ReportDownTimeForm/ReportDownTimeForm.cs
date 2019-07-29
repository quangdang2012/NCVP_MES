using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.ReportDownTimeCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class ReportDownTimeForm : FormCommonNCVP
    {
        public ReportDownTimeForm()
        {
            InitializeComponent();
            reportdowntime_dgv.AutoGenerateColumns = false;
        }

        private void ReportDownTimeForm_Load(object sender, EventArgs e)
        {
            int usr_cd;

            //Load ComboBox
            ValueObjectList<ModelVo> modelvolist = (ValueObjectList<ModelVo>)DefaultCbmInvoker.Invoke(new GetModelCbm(), new ModelVo());
            model_cmb.DisplayMember = "ModelCode";
            BindingSource b1 = new BindingSource(modelvolist.GetList(), null);
            model_cmb.DataSource = b1;

            ProcessVo processvo = (ProcessVo)DefaultCbmInvoker.Invoke(new GetProcessMasterMntCbm(), new ProcessVo());
            assy_cmb.DisplayMember = "ProcessName";
            BindingSource b2 = new BindingSource(processvo.ProcessListVo, null);
            assy_cmb.DataSource = b2;

            MachineVo machinevo = (MachineVo)DefaultCbmInvoker.Invoke(new GetMachineMasterMntCbm(), new MachineVo());
            machine_cmb.DisplayMember = "MachineName";
            BindingSource b4 = new BindingSource(machinevo.MachineListVo, null);
            machine_cmb.DataSource = b4;

            ResetControlValues.ResetControlValue(Search_tbpnl);

            //Check Permission
            ReportDownTimeVo inVo = new ReportDownTimeVo
            {
                RegistrationUserCode = UserData.GetUserData().UserCode
            };

            ReportDownTimeVo usrvo = (ReportDownTimeVo)DefaultCbmInvoker.Invoke(new CheckPermissionCbm(), new ReportDownTimeVo { RegistrationUserCode = inVo.RegistrationUserCode });
            usr_cd = usrvo.AffectedCount;
            if (usr_cd == 1)
            {
                update_btn.Enabled = true;
                Delete_btn.Enabled = true;
            }
        }

        private void model_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (model_cmb.SelectedItem != null)
            {
                ModelVo mvo = (ModelVo)model_cmb.SelectedItem;
                ValueObjectList<LineVo> linevo = (ValueObjectList<LineVo>)DefaultCbmInvoker.Invoke(new GetLineMoCbm(), new LineVo { LineId = mvo.ModelId });
                line_cmb.DisplayMember = "LineCode";
                line_cmb.DataSource = linevo.GetList();
            }
        }

        private void machine_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (machine_cmb.SelectedItem != null)
            {
                MachineVo mvo = (MachineVo)machine_cmb.SelectedItem;
                ValueObjectList<DefectiveReasonVo> defectivereasonvo = (ValueObjectList<DefectiveReasonVo>)DefaultCbmInvoker.Invoke(new GetCauseAndDefectiveCbm(), new DefectiveReasonVo { DefectiveReasonCode = mvo.MachineName });
                cause_cmb.DisplayMember = "DefectiveReasonName";
                cause_cmb.DataSource = defectivereasonvo.GetList();

                ValueObjectList<ProdutionWorkContentVo> respmachinevolist = (ValueObjectList<ProdutionWorkContentVo>)DefaultCbmInvoker.Invoke(new GetActicAndContentCbm(), new ProdutionWorkContentVo { ProdutionWorkContentCode = mvo.MachineName });
                action_cmb.DisplayMember = "ProdutionWorkContentName";
                action_cmb.DataSource = respmachinevolist.GetList();
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            if (model_cmb.SelectedIndex == -1)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, model_lbl.Text);
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);
                return;
            }

            reportdowntime_dgv.DataSource = null;

            try
            {
                selectdata();
            }
            catch
            { }
        }

        private void selectdata()
        {
            ValueObjectList<ReportDownTimeVo> getList = (ValueObjectList<ReportDownTimeVo>)DefaultCbmInvoker.Invoke(new SearchReportDownTimeCbm(), new ReportDownTimeVo
            {
                ModelCode = model_cmb.Text,
                MachineName = machine_cmb.Text,
                ProcessName = assy_cmb.Text,
                LineCode = line_cmb.Text,
                DefectiveReasonName = cause_cmb.Text,
                ProductionWorkContentName = action_cmb.Text,
                TimeFrom = timefrom_dtp.Value,
                TimeTo = timeto_dtp.Value
            });
            reportdowntime_dgv.DataSource = getList.GetList();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            new AddUpdateReportDownTimeFrom().ShowDialog();
            selectdata();
        }
        private void update_btn_Click(object sender, EventArgs e)
        {
            if (reportdowntime_dgv.SelectedCells.Count > 0)
            {
                ReportDownTimeVo selectedvo = (ReportDownTimeVo)reportdowntime_dgv.CurrentRow.DataBoundItem;

                if (new AddUpdateReportDownTimeFrom { reportDownTimeVo = selectedvo }.ShowDialog() == DialogResult.OK)
                {
                    selectdata();
                }
            }
        }
        
        private void clear_btn_Click(object sender, EventArgs e)
        {
            reportdowntime_dgv.DataSource = null;
            ResetControlValues.ResetControlValue(Search_tbpnl);
        }

        private void export_btn_Click(object sender, EventArgs e)
        {
            Excel_Class export = new Excel_Class();
            export.Export(ref reportdowntime_dgv, "DownTime Data");
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            if (reportdowntime_dgv.SelectedRows.Count > 0)
            {
                int selectedrowindex = reportdowntime_dgv.SelectedCells[0].RowIndex;

                ReportDownTimeVo vo = (ReportDownTimeVo)reportdowntime_dgv.Rows[selectedrowindex].DataBoundItem;

                messageData = new MessageData("mmcc00004", Properties.Resources.mmcc00004, "This Report");
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

                if (dialogResult == DialogResult.OK)
                {
                    try
                    {
                        ReportDownTimeVo outVo = (ReportDownTimeVo)DefaultCbmInvoker.Invoke(new DeleteReportDownTimeCbm(), vo);

                        if (outVo.AffectedCount > 0)
                        {
                            messageData = new MessageData("mmci00003", Properties.Resources.mmci00003, null);
                            logger.Info(messageData);
                            popUpMessage.Information(messageData, Text);

                            selectdata();
                        }
                        else if (outVo.AffectedCount == 0)
                        {
                            messageData = new MessageData("mmci00007", Properties.Resources.mmci00007, null);
                            logger.Info(messageData);
                            popUpMessage.Information(messageData, Text);
                            selectdata();
                        }
                    }
                    catch (Framework.ApplicationException exception)
                    {
                        popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                        logger.Error(exception.GetMessageData());
                    }
                }
            }
        }
    }
}
