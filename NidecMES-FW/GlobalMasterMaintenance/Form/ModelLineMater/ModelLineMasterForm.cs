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
    public partial class ModelLineMasterForm : FormCommonNCVP
    {
        public ModelLineMasterForm()
        {
            InitializeComponent();
            Model_dgv.AutoGenerateColumns = false;
        }
        private readonly GetLineMasterMntCbm getLineMasterMntCbm = new GetLineMasterMntCbm();
        private readonly GetModelCbm getModelCbm = new GetModelCbm();
        List<ModelLine> modeline = new List<ModelLine>();
        private void ModelLineMasterForm_Load(object sender, EventArgs e)
        {
            try
            {
                LineVo linevo = (LineVo)DefaultCbmInvoker.Invoke(getLineMasterMntCbm, new LineVo());
                ValueObjectList<ModelVo> modellist = (ValueObjectList<ModelVo>)DefaultCbmInvoker.Invoke(getModelCbm, new ModelVo());
                modelname_cmb.DisplayMember = "ModelName";                
                modelname_cmb.DataSource = modellist.GetList();

                modelname_cmb.SelectedIndex = -1;
                foreach (LineVo vo in linevo.LineListVo)
                {
                    modeline.Add(new ModelLine { mvo = vo, Selected = false, ModelLineId = 0 });
                }
                BindingSource bds = new BindingSource(modeline, null);
                Model_dgv.DataSource = bds;
          

            }
            catch { } //gfg
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (modelname_cmb.SelectedIndex >= 0)
            {
                ModelVo modelvo = (ModelVo)modelname_cmb.SelectedItem;
                ValueObjectList<ModelLineVo> deletelist = new ValueObjectList<ModelLineVo>();
                ValueObjectList<ModelLineVo> addlist = new ValueObjectList<ModelLineVo>();
                for (int i = 0; i < Model_dgv.Rows.Count; i++)
                {

                    ModelLine mg = (ModelLine)Model_dgv.Rows[i].DataBoundItem;
                    if (mg.ModelLineId > 0 && !mg.Selected)
                    {
                        deletelist.add(new ModelLineVo { ModelLineID = mg.ModelLineId });
                    }
                    else if (mg.ModelLineId == 0 && mg.Selected)
                    {
                        addlist.add(new ModelLineVo
                        {
                            ModelID = modelvo.ModelId,
                            LineID = mg.mvo.LineId,
                            FactoryCode = UserData.GetUserData().FactoryCode,
                            RegistrationUserCode = UserData.GetUserData().UserCode
                        });
                    }

                }
                if (deletelist.GetList().Count > 0)
                {
                    DefaultCbmInvoker.Invoke(new DeleteModelLineCbm(), deletelist);
                }
                if (addlist.GetList().Count > 0)
                {
                    DefaultCbmInvoker.Invoke(new AddModelLineCbm(), addlist);
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

            foreach (ModelLine item in modeline)
            {
                item.Selected = false;
                item.ModelLineId = 0;
            }

            if (modelname_cmb.SelectedIndex >= 0)
            {
                ModelVo mm = (ModelVo)modelname_cmb.SelectedItem;
                ValueObjectList<ModelLineVo> mlv = (ValueObjectList<ModelLineVo>)DefaultCbmInvoker.Invoke(new Cbm.GetModelLineCbm(), new ModelLineVo { ModelID = mm.ModelId });

                foreach (ModelLineVo vo in mlv.GetList())
                {

                    ModelLine ml = modeline.Find(x => x.mvo.LineId == vo.LineID);
                    if (ml != null)
                    {
                        ml.Selected = true;
                        ml.ModelLineId = vo.ModelLineID;
                    }
                }
            }
            Model_dgv.Refresh();
        }


        private class ModelLine
        {
            public LineVo mvo { get; set; }
            public string LineCode { get { return mvo == null ? "" : mvo.LineCode; } }
            public string LineName { get { return mvo == null ? "" : mvo.LineName; } }
            public int ModelLineId { get; set; }
            public bool Selected { get; set; }
        }

        private void Model_dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (modelname_cmb.SelectedIndex < 0)
            {
                e.Cancel = true;
            }
        }

        private void modelname_lbl_Click(object sender, EventArgs e)
        {

        }

        private void Model_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
