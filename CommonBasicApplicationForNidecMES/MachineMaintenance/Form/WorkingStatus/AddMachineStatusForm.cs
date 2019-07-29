using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System;
using System.Data;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.WorkingStatusCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class AddMachineStatusForm : FormCommonNCVP
    {
        public AddMachineStatusVo AddmachineStatus = new AddMachineStatusVo();
        public AddMachineStatusForm()
        {
            InitializeComponent();
        }

        private void AddMachineStatusForm_Load(object sender, EventArgs e)
        {
            LocationVo Locationvo = (LocationVo)DefaultCbmInvoker.Invoke(new GetLocationMasterMntCbm(), new LocationVo());
            section_cbm.DataSource = Locationvo.LocationListVo;
            section_cbm.DisplayMember = "LocationCode";
        }
        public DataGridView dgv;
        public void callSection(string name)
        {

            if (name == "ST")
            {
                SeachMachineWorkingStatusVo callmachine = new SeachMachineWorkingStatusVo();
                insert_ST_machine_status_dvg.AutoGenerateColumns = false;
                ValueObjectList<SeachMachineWorkingStatusVo> listvo = null;
                listvo = (ValueObjectList<SeachMachineWorkingStatusVo>)DefaultCbmInvoker.Invoke(new SearchSTWorkingStatusCbm(), callmachine);
                insert_ST_machine_status_dvg.DataSource = listvo.GetList();

            }
            else if (name == "CUTTING")
            {
                // listvo = (ValueObjectList<AddMachineStatusVo>)DefaultCbmInvoker.Invoke(new Cbm.SearchMACWorkingStatusCbm(), callmachine);
            }
            else if (name == "MOLD")
            {
                //  listvo = (ValueObjectList<AddMachineStatusVo>)DefaultCbmInvoker.Invoke(new Cbm.SearchMOLDWorkingStatusCbm(), callmachine);
            }
            else if (name == "TD")
            {
                //  listvo = (ValueObjectList<AddMachineStatusVo>)DefaultCbmInvoker.Invoke(new Cbm.SearchTDWorkingStatusCbm(), callmachine);
            }
            else if (name == "SP")
            {
                // listvo = (ValueObjectList<AddMachineStatusVo>)DefaultCbmInvoker.Invoke(new Cbm.SearchSPWorkingStatusCbm(), callmachine);
            }
            else return;
        }

        private void section_cbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            callSection(section_cbm.Text);
        }
        private void insert_btn_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            insert_ST_machine_status_dvg.DataSource = dt1;
            AddMachineStatusVo outVo = new AddMachineStatusVo();
            AddMachineStatusVo inVo = new AddMachineStatusVo()
            {
                StatusId = AddmachineStatus.StatusId,
                Molde = "ALUMITE",
                Site = "NCVP",
                Factory = "2A",
                Line = "L01",
                Process = "IOT",
                InspectItem = "STATUS",
                Date = DateTime.Now,
                Time = DateTime.Now,
                TJudge = "0",
                Tstatus = "INITIAL",
                dt = dt1,
            };
            try
            {               
                outVo = (AddMachineStatusVo)DefaultCbmInvoker.Invoke(new AddSTWorkingStatusCbm(), inVo);
            }
            catch
            { }
        }
    }
}
