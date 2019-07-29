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
    public partial class ResponseMachineMasterForm : FormCommonNCVP
    {
        public ResponseMachineMasterForm()
        {
            InitializeComponent();
            RespMachine_dgv.AutoGenerateColumns = false;
        }
        private readonly GetProdutionWorkContentCbm getProdutionWorkContentCbm = new GetProdutionWorkContentCbm();
        private readonly GetMachineMasterMntCbm getMachineMasterMntCbm = new GetMachineMasterMntCbm();
        List<RespMachine> respmachine = new List<RespMachine>();
        private void ResponseMachineMasterForm_Load(object sender, EventArgs e)
        {
            try
            {
                ValueObjectList<ProdutionWorkContentVo> prodvo = (ValueObjectList<ProdutionWorkContentVo>)DefaultCbmInvoker.Invoke(getProdutionWorkContentCbm, new ProdutionWorkContentVo());
                foreach (ProdutionWorkContentVo vo in prodvo.GetList())
                {
                    respmachine.Add(new RespMachine { mvo = vo, Selected = false, RespMachineID = 0 });
                }
                BindingSource bds = new BindingSource(respmachine, null);
                RespMachine_dgv.DataSource = bds;
                MachineVo machinelist = (MachineVo)DefaultCbmInvoker.Invoke(getMachineMasterMntCbm, new MachineVo());
                machinename_cmb.DisplayMember = "MachineName";
                machinename_cmb.DataSource = machinelist.MachineListVo;
                machinename_cmb.SelectedIndex = -1;
            }
            catch { } //gfg
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (machinename_cmb.SelectedIndex >= 0)
            {
                MachineVo machinevo = (MachineVo)machinename_cmb.SelectedItem;
                ValueObjectList<ResponseMachineVo> deletelist = new ValueObjectList<ResponseMachineVo>();
                ValueObjectList<ResponseMachineVo> addlist = new ValueObjectList<ResponseMachineVo>();
                for (int i = 0; i < RespMachine_dgv.Rows.Count; i++)
                {

                    RespMachine mg = (RespMachine)RespMachine_dgv.Rows[i].DataBoundItem;
                    if (mg.RespMachineID > 0 && !mg.Selected)
                    {
                        deletelist.add(new ResponseMachineVo { ResponseMachineId = mg.RespMachineID });
                    }
                    else if (mg.RespMachineID == 0 && mg.Selected)
                    {
                        addlist.add(new ResponseMachineVo
                        {
                            MachineId = machinevo.MachineId,
                            ProdutionWorkContentId = mg.mvo.ProdutionWorkContentId,
                            FactoryCode = UserData.GetUserData().FactoryCode,
                            RegistrationUserCode = UserData.GetUserData().UserCode
                        });
                    }

                }
                if (deletelist.GetList().Count > 0)
                {
                    DefaultCbmInvoker.Invoke(new DeleteResponseMachineCbm(), deletelist);
                }
                if (addlist.GetList().Count > 0)
                {
                    DefaultCbmInvoker.Invoke(new AddResponseMachineCbm(), addlist);
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

            foreach (RespMachine item in respmachine)
            {
                item.Selected = false;
                item.RespMachineID = 0;
            }

            if (machinename_cmb.SelectedIndex >= 0)
            {
                MachineVo mm = (MachineVo)machinename_cmb.SelectedItem;
                ValueObjectList<ResponseMachineVo> mlv = (ValueObjectList<ResponseMachineVo>)DefaultCbmInvoker.Invoke(new Cbm.GetResponseMachineCbm(), new ResponseMachineVo { MachineId = mm.MachineId });

                foreach (ResponseMachineVo vo in mlv.GetList())
                {

                    RespMachine ml = respmachine.Find(x => x.mvo.ProdutionWorkContentId == vo.ProdutionWorkContentId);
                    if (ml != null)
                    {
                        ml.Selected = true;
                        ml.RespMachineID = vo.ResponseMachineId;
                    }
                }
            }
            RespMachine_dgv.Refresh();
        }


        private class RespMachine
        {
            public ProdutionWorkContentVo mvo { get; set; }
            public string ProdWorkContCode { get { return mvo == null ? "" : mvo.ProdutionWorkContentCode; } }
            public string ProdWorkContName { get { return mvo == null ? "" : mvo.ProdutionWorkContentName; } }
            public int RespMachineID { get; set; }
            public bool Selected { get; set; }
        }

        private void RespMachine_dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (machinename_cmb.SelectedIndex < 0)
            {
                e.Cancel = true;
            }
        }
    }
}
