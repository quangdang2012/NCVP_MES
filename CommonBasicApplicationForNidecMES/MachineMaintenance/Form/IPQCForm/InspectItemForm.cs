using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.IPQCCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.IPQCForm
{
    public partial class InspectItemForm : FormCommonNCVP
    {
        public delegate void RefreshEventHandler(object sender, EventArgs e);
        public event RefreshEventHandler RefreshEvent;
        public static readonly string connectionIPQC = "Server=192.168.145.4;Port=5432;UserId=pqm;Password=dbuser;Database=ip_pqmdb;";

        public InspectItemForm()
        {
            InitializeComponent();
            dgvMeasureItem.AutoGenerateColumns = false;
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {
            ValueObjectList<IPQCVo> volist = null;
            try
            {
                volist = (ValueObjectList<IPQCVo>)DefaultCbmInvoker.Invoke(new GetMdlCbm(), new IPQCVo(), connectionIPQC);
            }
            catch (Framework.ApplicationException ex)
            {
                logger.Error(ex.GetMessageData());
                popUpMessage.ApplicationError(ex.GetMessageData(), Text);
                return;
            }
            cmbModel.DisplayMember = "Model";
            BindingSource b1 = new BindingSource(volist.GetList(), null);
            cmbModel.DataSource = b1;
            cmbModel.Text = "";

            if (cmbModel.Items.Count > 0)
                cmbModel.SelectedIndex = 0;
            SelectData();
        }
        public void SelectData()
        {
            ValueObjectList<IPQCVo> getList = (ValueObjectList<IPQCVo>)DefaultCbmInvoker.Invoke(new GetInspectItemCbm(), new IPQCVo
            {
                Model = cmbModel.Text
            }, connectionIPQC);
            dgvMeasureItem.DataSource = getList.GetList();
        }
        
        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectData();
        }

        private void dgvMeasureItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            int i = e.RowIndex;
            string instrument = dgvMeasureItem["instrument", i].Value.ToString();
            int curRow = int.Parse(e.RowIndex.ToString());
            string model = cmbModel.Text;
            string process = dgvMeasureItem["process", i].Value.ToString();
            string inspect = dgvMeasureItem["inspect", i].Value.ToString();

            if (dgvMeasureItem["description", i].Selected && cmbModel.Text != "")
            {
                if (instrument == "push" || instrument == "pull")
                {
                    PushPull fP = new PushPull();
                    fP.updateControls(model, process, inspect);
                    fP.ShowDialog(fP);
                }
                else if (instrument == "hr-20")
                {
                    Scale fS = new Scale();
                    fS.updateControls(model, process, inspect);
                    fS.ShowDialog(fS);
                }
                else if (instrument == "hiohm")
                {
                    Hioki fH = new Hioki();
                    fH.updateControls(model, process, inspect);
                    fH.ShowDialog(fH);
                }
                else
                {
                    Manual fM = new Manual();
                    fM.updateControls(model, process, inspect);
                    fM.ShowDialog(fM);
                }
            }
            else
            {
                MessageBox.Show("Model is empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnEditMaster_Click(object sender, EventArgs e)
        {
            InspectItemMaster fM = new InspectItemMaster(cmbModel.Text);
            fM.RefreshEvent += delegate (object sndr, EventArgs excp)
            {
                SelectData();
            };
            fM.ShowDialog();
        }
    }
}