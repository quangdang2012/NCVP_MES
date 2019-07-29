using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Diagnostics;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.DrawCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class DrawForm : FormCommonNCVP
    {
        DataGridViewButtonColumn Open;
        public DrawForm()
        {
            InitializeComponent();
            draw_dgv.AutoGenerateColumns = false;
        }

        private void JigDrawForm_Load(object sender, EventArgs e)
        {
            ValueObjectList<ModelVo> modelvolist = (ValueObjectList<ModelVo>)DefaultCbmInvoker.Invoke(new GetModelCbm(), new ModelVo());
            model_cmb.DisplayMember = "ModelCode";
            BindingSource b1 = new BindingSource(modelvolist.GetList(), null);
            model_cmb.DataSource = b1;
            model_cmb.Text = "";

            ValueObjectList<DrawingVo> userlist = (ValueObjectList<DrawingVo>)DefaultCbmInvoker.Invoke(new GetUserCbm(), new DrawingVo());
            user_cmb.DisplayMember = "RegistrationUserCode";
            BindingSource u1 = new BindingSource(userlist.GetList(), null);
            user_cmb.DataSource = u1;
            user_cmb.Text = "";

            ValueObjectList<DrawingVo> dpmlist = (ValueObjectList<DrawingVo>)DefaultCbmInvoker.Invoke(new GetDepartmentCbm(), new DrawingVo());
            depart_cmb.DisplayMember = "Department";
            BindingSource d1 = new BindingSource(dpmlist.GetList(), null);
            depart_cmb.DataSource = d1;
            depart_cmb.Text = "";

            addButtonTodgv(draw_dgv);
        }

        private void model_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (model_cmb.SelectedItem != null)
            {
                ModelVo mvo = (ModelVo)model_cmb.SelectedItem;
                ValueObjectList<DrawingVo> drawvolist = (ValueObjectList<DrawingVo>)DefaultCbmInvoker.Invoke(new GetDrawingModelCbm(), new DrawingVo { ModelId = mvo.ModelId});
                drawing_cmb.DisplayMember = "DrawType";
                drawing_cmb.DataSource = drawvolist.GetList();
                drawing_cmb.Text = "";

                ModelVo mdvo = (ModelVo)model_cmb.SelectedItem;
                ValueObjectList<DrawingVo> machinevolist = (ValueObjectList<DrawingVo>)DefaultCbmInvoker.Invoke(new GetMachineModelCbm(), new DrawingVo { ModelId = mdvo.ModelId });
                Machine_cmb.DisplayMember = "MachineName";
                Machine_cmb.DataSource = machinevolist.GetList();
                Machine_cmb.Text = "";
            }
        }

        private void drawing_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drawing_cmb.SelectedItem != null)
            {
                DrawingVo dvo = (DrawingVo)drawing_cmb.SelectedItem;
                ValueObjectList<DrawingVo> drawvolist = (ValueObjectList<DrawingVo>)DefaultCbmInvoker.Invoke(new GetDrawingCbm(), new DrawingVo { DrawType = dvo.DrawType, ModelId = ((ModelVo)this.model_cmb.SelectedItem).ModelId });
                version_cmb.DisplayMember = "DrawCode";
                version_cmb.DataSource = drawvolist.GetList();
                version_cmb.Text = "";
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            Open.Visible = true;
            if (model_cmb.SelectedIndex == -1)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, model_lbl.Text);
                logger.Info(messageData);
                DialogResult dialogResult = popUpMessage.ConfirmationOkCancel(messageData, Text);
                return;
            }

            draw_dgv.DataSource = null;

            try
            {
                selectdata();
            }
            catch
            { }
        }

        private void selectdata()
        {
            ValueObjectList<DrawingVo> getList = (ValueObjectList<DrawingVo>)DefaultCbmInvoker.Invoke(new SearchDrawingCbm(), new DrawingVo
            {
                DeviceCode = device_code_txt.Text,
                ModelCode = model_cmb.Text,
                ModelId = ((ModelVo)this.model_cmb.SelectedItem).ModelId,
                DrawType = drawing_cmb.Text,
                DrawCode = version_cmb.Text,
                MachineName = Machine_cmb.Text,
                Department = depart_cmb.Text,
                RegistrationUserCode = user_cmb.Text,
                TimeFrom = timefrom_dtp.Value,
                TimeTo = timeto_dtp.Value
            });
            draw_dgv.DataSource = getList.GetList();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (new AddDrawForm().ShowDialog() == DialogResult.OK)
            {
                add_btn_Click(null, null);
            }
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (draw_dgv.SelectedCells.Count > 0)
            {
                DrawingVo selectedvo = (DrawingVo)draw_dgv.CurrentRow.DataBoundItem;
                if (new AddDrawForm { vo = selectedvo }.ShowDialog() != DialogResult.OK)
                {
                    selectdata();
                }
            }
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            device_code_txt.ResetText();
            model_cmb.ResetText();
            drawing_cmb.ResetText();
            version_cmb.ResetText();
            Machine_cmb.ResetText();
            depart_cmb.ResetText();
            user_cmb.ResetText();
        }
        public void addButtonTodgv (DataGridView dgv)
        {
            Open = new DataGridViewButtonColumn();
            Open.Text = "Open";
            Open.UseColumnTextForButtonValue = true;
            Open.Width = 45;
            Open.Visible = false;
            dgv.Columns.Add(Open);
        }
        private void draw_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int curRow = int.Parse(e.RowIndex.ToString());
            string mc = draw_dgv[3, curRow].Value.ToString();
            if (draw_dgv.Columns[e.ColumnIndex] == Open)
            {
                Process prc = new Process();
                prc.StartInfo.FileName = "Z:\\(01)Motor\\(02)Engineering\\(03)FA\\1. PRIVATE DOCUMENTS\\1. MECHANIC\\MES\\" + mc;
                prc.Start();
            }
        }
        
        private void browser_btn_Click(object sender, EventArgs e)
        {
            string directorySave = "";
            FolderBrowserDialog fl = new FolderBrowserDialog();
            fl.SelectedPath = "d:\\";
            fl.ShowNewFolderButton = true;
            if (fl.ShowDialog() == DialogResult.OK)
            {
                linksave_txt.Text = fl.SelectedPath;
                directorySave = linksave_txt.Text;
            }
        }

        private void exportexcel_btn_Click(object sender, EventArgs e)
        {
            Excel_Class exportexcel = new Excel_Class();
            exportexcel.exportexcel(ref draw_dgv, linksave_txt.Text, this.Text);
        }
    }
}
