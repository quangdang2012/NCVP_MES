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
    public partial class MachineAndEquipmentMaster : FormCommonNCVP
    {
        public MachineAndEquipmentMaster()
        {
            InitializeComponent();
            Equipment_dgv.AutoGenerateColumns = false;
        }
        private readonly GetEquipmentMasterMntCbm getEquipmentMasterMntCbm = new GetEquipmentMasterMntCbm();
        private readonly GetMachineMasterMntCbm getMachineMasterMntCbm = new GetMachineMasterMntCbm();
        List<MachineEquipment> machinequip = new List<MachineEquipment>();
        private readonly GetMachineEquipmentCbm getMachineEquipmentCbm = new GetMachineEquipmentCbm();
        EquipmentVo equipvo = null; MachineVo machinelist = null;
        private void MachineAndEquipmentMaster_Load(object sender, EventArgs e)
        {
            try
            {
                equipvo = (EquipmentVo)DefaultCbmInvoker.Invoke(getEquipmentMasterMntCbm, new EquipmentVo());
                machinelist = (MachineVo)DefaultCbmInvoker.Invoke(getMachineMasterMntCbm, new MachineVo());
                machinename_cmb.DisplayMember = "MachineName";                
                machinename_cmb.DataSource = machinelist.MachineListVo;

                machinename_cmb.SelectedIndex = -1;
                foreach (EquipmentVo vo in equipvo.EquipmentListVo)
                {
                    machinequip.Add(new MachineEquipment { evo = vo, Selected = false, MachineEquipmentId = 0 });
                }

                BindingSource bds = new BindingSource(machinequip, null);
                Equipment_dgv.DataSource = bds;
          

            }
            catch { } //gfg
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (machinename_cmb.SelectedIndex >= 0)
            {
                MachineVo machinevo = (MachineVo)machinename_cmb.SelectedItem;
                ValueObjectList<MachineAndEquipmentVo> deletelist = new ValueObjectList<MachineAndEquipmentVo>();
                ValueObjectList<MachineAndEquipmentVo> addlist = new ValueObjectList<MachineAndEquipmentVo>();
                for (int i = 0; i < Equipment_dgv.Rows.Count; i++)
                {

                    MachineEquipment mg = (MachineEquipment)Equipment_dgv.Rows[i].DataBoundItem;
                    if (mg.MachineEquipmentId > 0 && !mg.Selected)
                    {
                        deletelist.add(new MachineAndEquipmentVo { MachineAndEquipmentID = mg.MachineEquipmentId });
                    }
                    else if (mg.MachineEquipmentId == 0 && mg.Selected)
                    {
                        addlist.add(new MachineAndEquipmentVo
                        {
                            MachineID = machinevo.MachineId,
                            EquipmentID = mg.evo.EquipmentId,
                        });
                    }

                }
                if (deletelist.GetList().Count > 0)
                {
                    DefaultCbmInvoker.Invoke(new DeleteMachineEquipmentCbm(), deletelist);
                }
                if (addlist.GetList().Count > 0)
                {
                    DefaultCbmInvoker.Invoke(new AddMachineEquipmentCbm(), addlist);
                }
                if (addlist.GetList().Count > 0 || deletelist.GetList().Count > 0)
                {
                    messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                    logger.Info(messageData);
                    DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

                    machinename_cmb_SelectedIndexChanged(null, null);
                }
            }
        }

        private void machinename_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (MachineEquipment item in machinequip)
            {
                item.Selected = false;
                item.MachineEquipmentId = 0;
                item.mvo = null;
            }

            ValueObjectList<MachineAndEquipmentVo> mlv = (ValueObjectList<MachineAndEquipmentVo>)DefaultCbmInvoker.Invoke(getMachineEquipmentCbm, new MachineAndEquipmentVo());
            foreach (MachineAndEquipmentVo mvo in mlv.GetList())
            {
                MachineEquipment m = machinequip.Find(x => x.evo.EquipmentId == mvo.EquipmentID);
                if (m != null)
                {
                    MachineVo machineVo = machinelist.MachineListVo.Find(x => x.MachineId == mvo.MachineID);
                    if (machineVo != null)
                    {
                        m.mvo = machineVo;
                    }
                }
            }
            if (machinename_cmb.SelectedIndex >= 0)
            {
                MachineVo mm = (MachineVo)machinename_cmb.SelectedItem;
                List<MachineAndEquipmentVo> mlv1 = mlv.GetList().FindAll(x=>x.MachineID == mm.MachineId);

                foreach (MachineAndEquipmentVo vo in mlv1)
                {

                    MachineEquipment ml = machinequip.Find(x => x.evo.EquipmentId == vo.EquipmentID);
                    if (ml != null)
                    {
                        ml.Selected = true;
                        ml.MachineEquipmentId = vo.MachineAndEquipmentID;
                    }
                }
            }
            Equipment_dgv.Refresh();
        }


        private class MachineEquipment
        {
            public EquipmentVo evo { get; set; }
            public string EquipmentCode { get { return evo == null ? "" : evo.EquipmentCode; } }
            public string EquipmentName { get { return evo == null ? "" : evo.EquipmentName; } }
            public MachineVo mvo { get; set; }
            public string MachineName { get { return mvo == null ? "" : mvo.MachineName; } }
            public int MachineEquipmentId { get; set; }
            public bool Selected { get; set; }
        }

        private void Equipment_dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (machinename_cmb.SelectedIndex < 0)
            {
                e.Cancel = true;
            }
        }
    }
}
