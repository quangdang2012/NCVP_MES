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
    public partial class ModelProcessMasterForm : FormCommonNCVP
    {
        public ModelProcessMasterForm()
        {
            InitializeComponent();
            Process_dgv.AutoGenerateColumns = false;
        }
        private readonly GetProcessMasterMntCbm getProcessMasterMntCbm = new GetProcessMasterMntCbm();
        private readonly GetModelCbm getModelCbm = new GetModelCbm();
        List<ModelProcess> modelprocess = new List<ModelProcess>();
        private void ModelProcessMasterForm_Load(object sender, EventArgs e)
        {
            try
            {
                ProcessVo processvo = (ProcessVo)DefaultCbmInvoker.Invoke(getProcessMasterMntCbm, new ProcessVo());
                ValueObjectList<ModelVo> modellist = (ValueObjectList<ModelVo>)DefaultCbmInvoker.Invoke(getModelCbm, new ModelVo());
                modelname_cmb.DisplayMember = "ModelName";                
                modelname_cmb.DataSource = modellist.GetList();

                modelname_cmb.SelectedIndex = -1;
                foreach (ProcessVo vo in processvo.ProcessListVo)
                {
                    modelprocess.Add(new ModelProcess { mvo = vo, Selected = false, ModelProcessId = 0 });
                }
                BindingSource bds = new BindingSource(modelprocess, null);
                Process_dgv.DataSource = bds;
          

            }
            catch { } //gfg
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (modelname_cmb.SelectedIndex >= 0)
            {
                ModelVo modelvo = (ModelVo)modelname_cmb.SelectedItem;
                ValueObjectList<ModelProcessVo> deletelist = new ValueObjectList<ModelProcessVo>();
                ValueObjectList<ModelProcessVo> addlist = new ValueObjectList<ModelProcessVo>();
                for (int i = 0; i < Process_dgv.Rows.Count; i++)
                {

                    ModelProcess mg = (ModelProcess)Process_dgv.Rows[i].DataBoundItem;
                    if (mg.ModelProcessId > 0 && !mg.Selected)
                    {
                        deletelist.add(new ModelProcessVo { ModelProcessID = mg.ModelProcessId });
                    }
                    else if (mg.ModelProcessId == 0 && mg.Selected)
                    {
                        addlist.add(new ModelProcessVo
                        {
                            ModelID = modelvo.ModelId,
                            ProcessID = mg.mvo.ProcessId,
                            FactoryCode = UserData.GetUserData().FactoryCode,
                            RegistrationUserCode = UserData.GetUserData().UserCode
                        });
                    }

                }
                if (deletelist.GetList().Count > 0)
                {
                    DefaultCbmInvoker.Invoke(new DeleteModelProcessCbm(), deletelist);
                }
                if (addlist.GetList().Count > 0)
                {
                    DefaultCbmInvoker.Invoke(new AddModelProcessCbm(), addlist);
                }
                if (addlist.GetList().Count > 0 || deletelist.GetList().Count > 0)
                {
                    messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                    logger.Info(messageData);
                    DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);

                    modelname_cmb_SelectedIndexChanged(null, null);
                }
            }
        }

        private void modelname_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (ModelProcess item in modelprocess)
            {
                item.Selected = false;
                item.ModelProcessId = 0;
            }

            if (modelname_cmb.SelectedIndex >= 0)
            {
                ModelVo mm = (ModelVo)modelname_cmb.SelectedItem;
                ValueObjectList<ModelProcessVo> mlv = (ValueObjectList<ModelProcessVo>)DefaultCbmInvoker.Invoke(new Cbm.GetModelProcessCbm(), new ModelProcessVo { ModelID = mm.ModelId });

                foreach (ModelProcessVo vo in mlv.GetList())
                {

                    ModelProcess ml = modelprocess.Find(x => x.mvo.ProcessId == vo.ProcessID);
                    if (ml != null)
                    {
                        ml.Selected = true;
                        ml.ModelProcessId = vo.ModelProcessID;
                    }
                }
            }
            Process_dgv.Refresh();
        }


        private class ModelProcess
        {
            public ProcessVo mvo { get; set; }
            public string ProcessCode { get { return mvo == null ? "" : mvo.ProcessCode; } }
            public string ProcessName { get { return mvo == null ? "" : mvo.ProcessName; } }
            public int ModelProcessId { get; set; }
            public bool Selected { get; set; }
        }

        private void Process_dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (modelname_cmb.SelectedIndex < 0)
            {
                e.Cancel = true;
            }
        }
    }
}
