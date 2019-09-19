using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.PQMDataViewerCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class PQMDataViewerForm : FormCommonNCVP
    {
        public string connection = Properties.Settings.Default.PQM_CONNECTION_STRING;
        PQMDataViewerVo Vo = new PQMDataViewerVo();
        List<PQMDataViewerVo> process = new List<PQMDataViewerVo>();
        List<PQMDataViewerVo> inspect = new List<PQMDataViewerVo>();

        public PQMDataViewerForm()
        {
            InitializeComponent();
        }
        //****************************************************************************************************************//
        //                                            LOAD COMBOBOX MODEL                                                 //
        //****************************************************************************************************************//
        private void PQMDataViewerForm_Load(object sender, EventArgs e)
        {
            ValueObjectList<PQMDataViewerVo> model = (ValueObjectList<PQMDataViewerVo>)DefaultCbmInvoker
                                                   .Invoke(new GetModelPQMCbm(), new PQMDataViewerVo(), connection);
            cmbModel.DisplayMember = "Model";
            cmbModel.DataSource = model.GetList();
            cmbModel.Text = "-----Select Model-----";
        }
        //****************************************************************************************************************//
        //                                            LOAD INSPECT TREEVIEW                                               //
        //****************************************************************************************************************//
        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            trInspect.Nodes.Clear();
            process = (List<PQMDataViewerVo>)DefaultCbmInvoker
                                                     .Invoke(new GetProcessPQMCbm(), new PQMDataViewerVo(), connection);
            inspect = (List<PQMDataViewerVo>)DefaultCbmInvoker
                                                     .Invoke(new GetInspectPQMCbm(), new PQMDataViewerVo(), connection);
            foreach (PQMDataViewerVo root in process)
            {
                TreeNode Root = new TreeNode(root.Process);
                trInspect.Nodes.Add(root.Process);
                GetNodes(Root, inspect);
            }
        }

        private void GetNodes(TreeNode root, List<PQMDataViewerVo> nodeslist)
        {
            foreach (PQMDataViewerVo node in nodeslist)
                root.Nodes.Add(node.Inspect);
        }

        private void trInspect_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CheckedNode(e.Node, e.Node.Checked);
        }

        private void CheckedNode(TreeNode Root, bool check)
        {
            foreach (TreeNode node in Root.Nodes)
            {
                if (node.Checked != check) node.Checked = check;
                if (Root.Nodes.Count > 0) CheckedNode(node, node.Checked);
            }
        }
        //****************************************************************************************************************//
        //                                            LOAD INSPECT LIST                                                   //
        //****************************************************************************************************************//
        private void SelectedNode(TreeNode Root)
        {
            List<string> inslist = (from i in inspect
                                    where i.Inspect == (from n in Root.Nodes.Cast<TreeNode>().ToList() select n.Text).ToString()
                                    select i.Inspect).ToList();
            Vo.InspectList = "'" + inslist[0] + "'";
            foreach (string i in inslist)
            {
                Vo.InspectList += ",'" + i + "'";
            }
        }
        //****************************************************************************************************************//
        //                                    LOAD SERIAL NO FROM TEXTBOX TO LIST                                         //
        //****************************************************************************************************************//
        private void txtBarcode_TextChanged_1(object sender, EventArgs e)
        {
            Vo.SernoList = "0";
            foreach (string s in txtBarcode.Lines)
                Vo.SernoList += ",'" + s + "'";
            lbSerRows.Text = txtBarcode.Lines.Length.ToString() + " rows";
        }
        //****************************************************************************************************************//
        //                                     LOAD SERIAL NO FROM CSV TO LIST                                            //
        //****************************************************************************************************************//
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            ofCSV = new OpenFileDialog();
            ofCSV.Title = "LOAD SERIAL NUMBER FROM CSV FILE";
            ofCSV.Filter = "csv file(*.csv)|*.csv|text file(*.txt)|*.txt|All file(*.*)|*.*";
            if (ofCSV.ShowDialog() == DialogResult.OK)
            {
                txtURL.Text = ofCSV.FileName;
                Vo.OpenPath = txtURL.Text;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Vo.SernoList = "";
            List<string> listserno = new List<string>();
            CSV_Class csv = new CSV_Class();
            csv.ReadLineCSVtoList(Vo.OpenPath, ref listserno);
            Vo.SernoList += "'" + listserno[0] + "'";
            listserno.RemoveAt(0);
            foreach (string s in listserno)
                Vo.SernoList += ",'" + s + "'";
        }
        //****************************************************************************************************************//
        //                                            GET DATA TO TABLE                                                   //
        //****************************************************************************************************************//
        private void getTableName()
        {
            string name = "";
            Vo.SernoDBList.Clear();
            Vo.DateTimeFrom = dtDatef.GetDateTime();
            Vo.DateTimeTo = dtDatet.GetDateTime();
            for (int i = Vo.DateTimeFrom.Month; i <= Vo.DateTimeTo.Month; i++)
            {
                name = cmbModel.Text + Vo.DateTimeFrom.Year.ToString("0000") + i.ToString("00");
                Vo.SernoDBList.Add(name);
            }
        }

        private void GetDataToTable()
        {
            getTableName();
            Vo = (PQMDataViewerVo)DefaultCbmInvoker
                .Invoke(new GetInspectDataTablePQMCbm(), new PQMDataViewerVo(), connection);
            Vo = (PQMDataViewerVo)DefaultCbmInvoker
                .Invoke(new GetSernoDataTablePQMCbm(), new PQMDataViewerVo(), connection);

            DataTable pivot = new DataTable();
            pivot = LinQ_Class.Pivot(Vo.InspectDataTable, Vo.InspectDataTable.Columns["inspect"]
                    , Vo.InspectDataTable.Columns["inspectdata"]);
            Vo.JoinedTable = LinQ_Class.Joined(Vo.SernoDataTable, pivot);
            Vo.ThreadComplete = true;
        }
        //****************************************************************************************************************//
        //                                            SEARCH DATA                                                         //
        //****************************************************************************************************************//
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Vo.Timer_Counter = 0;
                timer1.Enabled = true;
                //CREATE THREAD TO RUN IN BACKGROUND
                Thread GetTable = new Thread(GetDataToTable);
                GetTable.Start();
                GetTable.IsBackground = true;
                tsProcessing.Text = "processing...";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NoInspect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int c = Vo.Timer_Counter;
            c++;
            tsTime.Text = (c / 100).ToString() + "," + ((c % 100) / 10).ToString() + " s";
            if (Vo.ThreadComplete)
            {
                Vo.ThreadComplete = false;
                dgvdt.DataSource = Vo.JoinedTable;
                tsProcessing.Text = dgvdt.Rows.Count.ToString() + " Rows";
                timer1.Enabled = false;
            }
        }
        //----------------------------------------------------------------------------------------------------------------//
        //------------------------------------------EXPORT TO CSV---------------------------------------------------------//
        //----------------------------------------------------------------------------------------------------------------//
        private void btnCSV_Click(object sender, EventArgs e)
        {
            try
            {
                Vo.Timer_Counter = 0;
                timer2.Enabled = true;
                //File.Create("data.csv");
                sfSaveCSV = new SaveFileDialog();
                sfSaveCSV.RestoreDirectory = true;
                sfSaveCSV.Title = "Save file...";
                sfSaveCSV.Filter = "csv file(*.csv)|*.csv|text file(*.txt)|*.txt|All file(*.*)|*.*";
                if (sfSaveCSV.ShowDialog() == DialogResult.OK)
                {
                    Vo.SavePath = sfSaveCSV.FileName;
                    //CREATE THREAD TO RUN IN BACKGROUND
                    Thread GetTable = new Thread(GetDataToTable);
                    GetTable.Start();
                    GetTable.IsBackground = true;
                    tsProcessing.Text = "processing...";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "NoInspect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int c = Vo.Timer_Counter;
            c++;
            tsTime.Text = (c / 100).ToString() + "," + ((c % 100) / 10).ToString() + " s";
            if (Vo.ThreadComplete)
            {
                Vo.ThreadComplete = false;
                //ds.ToCSV(@"D:\data.csv");
                CSV_Class csv = new CSV_Class();
                DataTable dt = new DataTable();
                dt = Vo.JoinedTable;
                csv.exportcsv(ref dt, Vo.SavePath);
                tsProcessing.Text = Vo.JoinedTable.Rows.Count + " Rows";
                timer2.Enabled = false;
            }
        }
    }
}