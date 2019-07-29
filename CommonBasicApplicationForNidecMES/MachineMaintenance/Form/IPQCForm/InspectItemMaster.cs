using System;
using System.Data;
using System.Windows.Forms;
using System.Security.Permissions;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.IPQCCbm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.IPQCForm
{
    public partial class InspectItemMaster : FormCommonNCVP
    {
        public delegate void RefreshEventHandler(object sender, EventArgs e);
        public event RefreshEventHandler RefreshEvent;

        DataSet ds;
        DataTable dt;
        string conStringIPQC = @"Server=192.168.145.4;Port=5432;User Id=pqm;Password=dbuser;Database=ip_pqmdb; CommandTimeout=100; Timeout=100;";
        string model;

        public InspectItemMaster(string p_model)
        {
            InitializeComponent();
            model = p_model;
            dgvTester.AutoGenerateColumns = false;
            dgvTester.AllowUserToAddRows = false;
        }

        private void Form7_2_Load(object sender, EventArgs e)
        {
            this.Left = 30;
            this.Top = 30;
            defineAndReadTable();
        }
        private void defineAndReadTable()
        {
            ValueObjectList<IPQCVo> getList = (ValueObjectList<IPQCVo>)DefaultCbmInvoker.Invoke(new GetItemMasterCbm(), new IPQCVo
            {
                Model = model
            }, conStringIPQC);

            dgvTester.DataSource = getList.GetList();
            dgvTester.ReadOnly = true;
            btnSave.Enabled = false;
            dgvTester.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTester.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvTester.ReadOnly = false;
            dgvTester.AllowUserToAddRows = true;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Do you want to delete this row ?", "Delete", MessageBoxButtons.YesNo);
            if (dlg == DialogResult.No) return;

            try
            {
                dgvTester.Rows.RemoveAt(dgvTester.SelectedRows[0].Index);
                IPQCVo vo = (IPQCVo)DefaultCbmInvoker.Invoke(new DeleteItemCbm(), new IPQCVo
                {
                    No = dgvTester.CurrentRow.Cells["no"].Value.ToString(),
                    Model = dgvTester.CurrentRow.Cells["col_model"].Value.ToString(),
                    Process = dgvTester.CurrentRow.Cells["process"].Value.ToString(),
                    Inspect = dgvTester.CurrentRow.Cells["inspect"].Value.ToString()
                }, conStringIPQC);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                IPQCVo delvo = (IPQCVo)DefaultCbmInvoker.Invoke(new DeleteBeforeAddCbm(), new IPQCVo
                {
                    Model = model
                }, conStringIPQC);

                for (int i = 0; i < dgvTester.Rows.Count; i++)
                {
                    IPQCVo vo = (IPQCVo)DefaultCbmInvoker.Invoke(new AddItemCbm(), new IPQCVo
                    {
                        No = dgvTester["no", i].Value.ToString(),
                        Model = model,
                        Process = dgvTester["process", i].Value.ToString(),
                        Inspect = dgvTester["inspect", i].Value.ToString(),
                        Description = dgvTester["description", i].Value.ToString(),
                        Upper = double.Parse(dgvTester["upper", i].Value.ToString()),
                        Lower = double.Parse(dgvTester["lower", i].Value.ToString()),
                        Instrument = dgvTester["instrument", i].Value.ToString(),
                        ClmSet = int.Parse(dgvTester["clmset", i].Value.ToString()),
                        RowSet = int.Parse(dgvTester["rowset", i].Value.ToString())
                    }, conStringIPQC);
                }
                MessageBox.Show(Properties.Resources.mmci00002, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                dgvTester.ReadOnly = true;
                dgvTester.AllowUserToAddRows = false;
                btnSave.Enabled = false;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x112;
            const long SC_CLOSE = 0xF060L;
            if (m.Msg == WM_SYSCOMMAND && (m.WParam.ToInt64() & 0xFFF0L) == SC_CLOSE) { return; }
            base.WndProc(ref m);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.RefreshEvent(this, new EventArgs());
            this.Close();
        }
    }
}