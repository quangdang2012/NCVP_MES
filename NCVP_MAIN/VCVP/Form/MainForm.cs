using Com.Nidec.Mes.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Com.Nidec.Mes.GlobalMasterMaintenance;



namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    //  public partial class MainForm : Com.Nidec.Mes.Common.Basic.MachineMaintenance.VCVP.Form.FormCommonNCVP
    public partial class MainForm : FormCommonNCVP

    {
        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Main form loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            SystemMaster_gpb.Visible = false;
            NcvpMaster_gpb.Visible = false;
        }
        /// <summary>
        /// System Master Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SystemMaster_btn_Click(object sender, EventArgs e)
        {
            SystemMaster_gpb.Visible = true;
            NcvpMaster_gpb.Visible = false;
        }
        /// <summary>
        /// NCVP Master Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NcvpMaster_btn_Click(object sender, EventArgs e)
        {
            NcvpMaster_gpb.Visible = true;
            SystemMaster_gpb.Visible = false;
        }
        
        
        private void DownTime_bt_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.DownTimeForm.ReportDownTimeForm reportdowntimeform = new DownTimeForm.ReportDownTimeForm();
            reportdowntimeform.Show();
        }

        #region System Master
        private void user_bt_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.UserMasterForm usermasterform = new UserMasterForm();
            usermasterform.Show();
        }

        private void language_bt_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.CountryLanguageForm conlang = new CountryLanguageForm();
            conlang.Show();
        }

        private void factory_bt_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.FactoryMasterForm factory = new FactoryMasterForm();
            factory.Show();
        }

        private void userfac_bt_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.UserFactoryForm userfact = new UserFactoryForm();
            userfact.Show();
        }

        private void auth_cotrol_bt_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.AuthorityControlForm authorityctr = new AuthorityControlForm();
            authorityctr.Show();
        }

        private void Role_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.RoleForm roleform = new RoleForm();
            roleform.Show();
        }

        private void UserRoles_btn_Click(object sender, EventArgs e)
        {

            Com.Nidec.Mes.GlobalMasterMaintenance.UserRoleForm userrole = new UserRoleForm();
            userrole.Show();
        }

        private void RoleAuthorityControl_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.RoleAuthorityControlForm roleauthor = new RoleAuthorityControlForm();
            roleauthor.Show();
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region NCVP Master
        private void Equipment_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.EquipmentForm equipmasterform = new EquipmentForm();
            equipmasterform.Show();
        }

        private void Process_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.ProcessForm processmasterform = new ProcessForm();
            processmasterform.Show();
        }

        private void Model_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.ModelMasterForm modelmasterform = new ModelMasterForm();
            modelmasterform.Show();
        }

        private void DefectiveReason_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.DefectiveReasonForm defectmasterform = new DefectiveReasonForm();
            defectmasterform.Show();
        }

        private void ProcessWork_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.ProcessWorkForm procworkmasterform = new ProcessWorkForm();
            procworkmasterform.Show();
        }

        private void ProductionWorkContent_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.ProdutionWorkContentForm prodworkcontmasterform = new ProdutionWorkContentForm();
            prodworkcontmasterform.Show();
        }

        private void Line_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.LineMasterForm linemasterform = new LineMasterForm();
            linemasterform.Show();
        }

        private void Machine_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.MachineForm machinemasterform = new MachineForm();
            machinemasterform.Show();
        }

        private void modellinemaster_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.ModelLineMasterForm modelline = new ModelLineMasterForm();
            modelline.Show();
        }

        private void response_machine_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.ResponseMachineMasterForm respmachine = new ResponseMachineMasterForm();
            respmachine.Show();
        }

        private void JigCause_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.JigCauseMasterForm jigcause = new JigCauseMasterForm();
            jigcause.Show();
        }

        private void JigResponse_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.JigResponseMasterForm jigrespform = new JigResponseMasterForm();
            jigrespform.Show();
        }

        private void CauseMaster_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.CauseMasterForm causeform = new CauseMasterForm();
            causeform.Show();
        }
        private void ProductionWorkContType_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.ProdutionWorkContentTypeForm prodworkconttypeform = new ProdutionWorkContentTypeForm();
            prodworkconttypeform.Show();
        }
        private void ProcessModel_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.ModelProcessMasterForm modelprocess = new ModelProcessMasterForm();
            modelprocess.Show();
        }
        private void Draw_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.DrawMasterForm draw = new DrawMasterForm();
            draw.Show();
        }
        #endregion

        private void jig_repair_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.JigRepairInformationForm reportdowntimeform = new JigRepairInformationForm();
            reportdowntimeform.Show();
        }

        private void Supplier_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.GlobalMasterMaintenance.LocalSupplierForm supplierform = new LocalSupplierForm();
            supplierform.Show();
        }

        private void DrawRegist_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.JigDrawForm jigdrawform = new JigDrawForm();
            jigdrawform.Show();
        }
    }
}
