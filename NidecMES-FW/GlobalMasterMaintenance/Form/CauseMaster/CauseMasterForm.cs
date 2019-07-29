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
    public partial class CauseMasterForm : FormCommonNCVP
    {
        public CauseMasterForm()
        {
            InitializeComponent();
            Cause_dgv.AutoGenerateColumns = false;
        }
        private readonly GetDefectiveReasonMasterMntCbm getDefectiveReasonMasterMntCmb = new GetDefectiveReasonMasterMntCbm();
        private readonly GetMachineMasterMntCbm getMachineMasterMntCbm = new GetMachineMasterMntCbm();
        List<Cause> cause = new List<Cause>();
        private void CauseMasterForm_Load(object sender, EventArgs e)
        {
            try
            {
                DefectiveReasonVo defectiveReasonvo = (DefectiveReasonVo)DefaultCbmInvoker.Invoke(getDefectiveReasonMasterMntCmb, new DefectiveReasonVo());
                foreach (DefectiveReasonVo vo in defectiveReasonvo.DefectiveReasonListVo)
                {
                    cause.Add(new Cause { dvo = vo, Selected = false, CauseId = 0 });
                }
                BindingSource bds = new BindingSource(cause, null);
                Cause_dgv.DataSource = bds;
                MachineVo machinelist = (MachineVo)DefaultCbmInvoker.Invoke(getMachineMasterMntCbm, new MachineVo());
                MachineName_cmb.DisplayMember = "MachineName";
                MachineName_cmb.DataSource = machinelist.MachineListVo;
                MachineName_cmb.SelectedIndex = -1;
                MachineName_cmb.Select();


            }
            catch { } //gfg
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (MachineName_cmb.SelectedIndex >= 0)
            {
                MachineVo machinevo = (MachineVo)MachineName_cmb.SelectedItem;
                ValueObjectList<CauseVo> deletelist = new ValueObjectList<CauseVo>();
                ValueObjectList<CauseVo> addlist = new ValueObjectList<CauseVo>();
                for (int i = 0; i < Cause_dgv.Rows.Count; i++)
                {

                    Cause mg = (Cause)Cause_dgv.Rows[i].DataBoundItem;
                    if (mg.CauseId > 0 && !mg.Selected)
                    {
                        deletelist.add(new CauseVo { CauseID = mg.CauseId });
                    }
                    else if (mg.CauseId == 0 && mg.Selected)
                    {
                        addlist.add(new CauseVo
                        {
                            MachineID = machinevo.MachineId,
                            DefectiveID = mg.dvo.DefectiveReasonId,
                            FactoryCode = UserData.GetUserData().FactoryCode,
                            RegistrationUserCode = UserData.GetUserData().UserCode
                        });
                    }

                }
                if (deletelist.GetList().Count > 0)
                {
                    DefaultCbmInvoker.Invoke(new DeleteCauseCbm(), deletelist);
                }
                if (addlist.GetList().Count > 0)
                {
                    DefaultCbmInvoker.Invoke(new AddCauseCbm(), addlist);
                }
                if (addlist.GetList().Count > 0 || deletelist.GetList().Count > 0)
                {
                    messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                    logger.Info(messageData);
                    DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

                    MachineName_cmb_SelectedIndexChanged(null, null);
                }
            }
        }

        private void MachineName_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (Cause item in cause)
            {
                item.Selected = false;
                item.CauseId = 0;
            }

            if (MachineName_cmb.SelectedIndex >= 0)
            {
                MachineVo mv = (MachineVo)MachineName_cmb.SelectedItem;
                ValueObjectList<CauseVo> mlv = (ValueObjectList<CauseVo>)DefaultCbmInvoker.Invoke(new Cbm.GetCauseCbm(), new CauseVo { MachineID = mv.MachineId });

                foreach (CauseVo vo in mlv.GetList())
                {

                    Cause ml = cause.Find(x => x.dvo.DefectiveReasonId == vo.DefectiveID);
                    if (ml != null)
                    {
                        ml.Selected = true;
                        ml.CauseId = vo.CauseID;
                    }
                }
            }
            Cause_dgv.Refresh();
        }


        private class Cause
        {
            public DefectiveReasonVo dvo { get; set; }
            public string DefectiveCode { get { return dvo == null ? "" : dvo.DefectiveReasonCode; } }
            public string DefectiveName { get { return dvo == null ? "" : dvo.DefectiveReasonName; } }
            public int CauseId { get; set; }
            public bool Selected { get; set; }
        }

        private void Cause_dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (MachineName_cmb.SelectedIndex < 0)
            {
                e.Cancel = true;
            }
        }
    }
}
