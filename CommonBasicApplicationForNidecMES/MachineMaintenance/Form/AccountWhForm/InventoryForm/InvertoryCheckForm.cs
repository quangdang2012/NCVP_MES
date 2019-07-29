using System;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Drawing;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.InvertoryCheckCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.InvertoryTimeCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.RankMasterCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.InventoryForm
{
    public partial class InvertoryCheckForm : FormCommonNCVP
    {
        public InvertoryCheckForm()
        {
            InitializeComponent();
            InvertoryCheck_dgv.AutoGenerateColumns = false;
        }


        private void InvertoryCheckForm_Load(object sender, EventArgs e)
        {
            AcceptButton = Invertory_btn;
            ValueObjectList<InvertoryVo> detailposition = (ValueObjectList<InvertoryVo>)DefaultCbmInvoker.Invoke(new GetInvertoryTimeCbm(), new InvertoryVo());
            InvertoryTimeCode_cbm.DisplayMember = "InvertoryTimeCode";
            InvertoryTimeCode_cbm.DataSource = detailposition.GetList();
            InvertoryTimeCode_cbm.Text = "";
            

            LocationVo Locationvo = (LocationVo)DefaultCbmInvoker.Invoke(new GetLocationMasterMntCbm(), new LocationVo());
            location_cbm.DisplayMember = "LocationCode";
            location_cbm.DataSource = Locationvo.LocationListVo;
            location_cbm.Text = "";
            asset_Code_cmb.Select();
            //  ValueObjectList<RankVo> rankcode = (ValueObjectList<RankVo>)DefaultCbmInvoker.Invoke(new GetRankCbm(), new RankVo());
            //InvertoryCheck_dgv.
            //    DisplayMember = "RankCode";
            //rank_code_cbm.DataSource = rankcode.GetList();
            //rank_code_cbm.Text = "";
        }
        // public InvertoryVo CheckoutVo = new InvertoryVo();
        public ValueObjectList<WareHouseMainVo> warehouseMainID = new ValueObjectList<WareHouseMainVo>();
    
        public string assetcodetrim;
        public string test = "a";


        void GridBind()
        {
            InvertoryVo inVo = new InvertoryVo()
            {
                AssetCode = assetcodetrim,
                InvertoryTimeCode = InvertoryTimeCode_cbm.Text,
                NowLocation = location_cbm.Text,
            };
            try
            {
                ValueObjectList<InvertoryVo> listvo = (ValueObjectList<InvertoryVo>)DefaultCbmInvoker.Invoke(new SearchInvertoryCheckCbm(), inVo);
                InvertoryCheck_dgv.DataSource = listvo.GetList();


            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            if (InvertoryCheck_dgv.RowCount > 0)
            {
                for (int i = 0; i < InvertoryCheck_dgv.RowCount; i++)
                {
                    if (InvertoryCheck_dgv.Rows[i].Cells["colBeforeLocation"].Value.ToString() != InvertoryCheck_dgv.Rows[i].Cells["colNowLocation"].Value.ToString())
                    {
                        InvertoryCheck_dgv.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                }               
            }
            if (thongbao >= 1)
            {
                MessageBox.Show(mess, "", MessageBoxButtons.OK);
                thongbao = 0;
            }
        }
        private void update_btn_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < InvertoryCheck_dgv.RowCount; i++)
            {

                //colRankNameNow
                DataGridViewComboBoxCell cell = InvertoryCheck_dgv.Rows[i].Cells["colRankNameNow"] as DataGridViewComboBoxCell;
                if (cell.Value != null)
                {
                    InvertoryVo outVo = new InvertoryVo();
                    InvertoryVo inVo = new InvertoryVo()
                    {
                        AssetId = int.Parse(InvertoryCheck_dgv.Rows[i].Cells["colAssetId"].Value.ToString()),
                        RankNameNow = cell.Value.ToString(),
                    };
                    outVo = (InvertoryVo)DefaultCbmInvoker.Invoke(new UpdateWHInvertoryRankCbm(), inVo);
                    outVo = (InvertoryVo)DefaultCbmInvoker.Invoke(new UpdateACCInvertoryRankCbm(), inVo);
                    if (i == InvertoryCheck_dgv.RowCount - 1)
                    {
                        if (outVo.AffectedCount == 1)
                        {
                            if (MessageBox.Show("Update Finish !", "Update", MessageBoxButtons.OK) == DialogResult.OK)
                            {
                                Search_btn_Click(sender, e);
                            }
                        }
                    }
                }
            }
            asset_Code_cmb.Select();
        }
        private void Invertory_btn_Click(object sender, EventArgs e)
        {
            test = "b";
            addandupdate();
            GridBind();
            asset_Code_cmb.Text = "";
            asset_Code_cmb.Select();
        }
        public int thongbao = 0;
        public string mess = "This machine: ";
        void addandupdate()
        {
            InvertoryVo checkvo = new InvertoryVo();
            asset_Code_cmb.Select();
            InvertoryCheck_dgv.DataSource = null;

            string str = asset_Code_cmb.Text;
            string[] arrListStr = str.Split(',');
            assetcodetrim = arrListStr[0];
            //sua lai, doi warehouse va accout id thanh asset_id
            //sua database t_invertory_equipments doi warehouse id thanh asset_id
            ValueObjectList<WareHouseMainVo> Wlistvo = (ValueObjectList<WareHouseMainVo>)DefaultCbmInvoker.Invoke(new GetWarehouseMainIdCbm(), new WareHouseMainVo() { AssetCode = assetcodetrim, });
            List<WareHouseMainVo> Wlist = Wlistvo.GetList();

            ValueObjectList<AccountMainVo> alistvo = (ValueObjectList<AccountMainVo>)DefaultCbmInvoker.Invoke(new GetAccountMainIdCbm(), new AccountMainVo() { AssetCode = assetcodetrim, });
            List<AccountMainVo> alist = alistvo.GetList();

            if (checkdata())
            {
                for (int i = 0; i < Wlist.Count; i++)
                {
                    WareHouseMainVo w = Wlist[i];
                    AccountMainVo a = alist[i];
                    InvertoryVo outVo = new InvertoryVo();
                    InvertoryVo inVo = new InvertoryVo()
                    {
                        WarehouseMainId = w.WareHouseMainId,
                        AccountMainId = a.AcountMainId,
                        InvertoryTimeId = ((InvertoryVo)this.InvertoryTimeCode_cbm.SelectedItem).InvertoryTimeId,
                        InvertoryValue = true,
                        RegistrationUserCode = UserData.GetUserData().UserName,
                        FactoryCode = UserData.GetUserData().FactoryCode,
                        LocationID = ((LocationVo)this.location_cbm.SelectedItem).LocationId,
                        //  RankID = ((RankVo)this.rank_name_cbm.SelectedItem).RankId,
                    };
                    try
                    {
                        checkvo = (InvertoryVo)DefaultCbmInvoker.Invoke(new CheckInvertoryRowCbm(), inVo);

                        if (checkvo.AffectedCount == 1)
                        {
                            mess +=  assetcodetrim + " is checked into " + InvertoryTimeCode_cbm.Text + "\n";
                            //if(i == Wlist.Count -1)
                            //{
                            //    MessageBox.Show(mess, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}
                            //MessageBox.Show("This machine:" + assetcodetrim + " is checked into " + InvertoryTimeCode_cbm.Text, "Messager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            thongbao++;
                        }
                        if (checkvo.AffectedCount == 0)
                        {
                            outVo = (InvertoryVo)DefaultCbmInvoker.Invoke(new AddInvertoryCheckCbm(), inVo);
                            outVo = (InvertoryVo)DefaultCbmInvoker.Invoke(new UpdateWHInvertoryCheckCbm(), inVo);
                            outVo = (InvertoryVo)DefaultCbmInvoker.Invoke(new UpdateACCInvertoryCheckCbm(), inVo);
                            //    outVo = (InvertoryVo)DefaultCbmInvoker.Invoke(new UpdateACCRankCheckCbm(), inVo);
                        }
                    }
                    catch (Framework.ApplicationException exception)
                    {
                        popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                        logger.Error(exception.GetMessageData());
                    }
                }


                if (test == "b")
                {
                    colRankNameNowTextBox.Visible = false;
                    colRankNameNow.Visible = true;
                    ValueObjectList<RankVo> rankcode = (ValueObjectList<RankVo>)DefaultCbmInvoker.Invoke(new GetRankCbm(), new RankVo());
                    colRankNameNow.DisplayMember = "RankName";
                    colRankNameNow.DataSource = rankcode.GetList();
                }
                else
                {
                    assetcodetrim = "";
                }

            }
        }
        private bool checkdata()
        {
            if (asset_Code_cmb.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, asset_code_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                asset_Code_cmb.Focus();
                return false;
            }
            if (InvertoryTimeCode_cbm.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, InvertoryTimeCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                InvertoryTimeCode_cbm.Focus();
                return false;
            }
            if (location_cbm.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, select_location_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                location_cbm.Focus();
                return false;
            }
            return true;
        }

        private void Inventory_Offline_btn_Click(object sender, EventArgs e)
        {
            if (location_cbm.Text != "" && InvertoryTimeCode_cbm.Text != "" )
            {
                thongbao = 0;
                test = "a";
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(linksave_txt.Text);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;
                int dem = 0;
                for (int i = 2; i <= rowCount; i++)
                {
                    if (xlRange.Cells[i, 1] != null && xlRange.Cells[i, 1].Value != null && InvertoryTimeCode_cbm.Text != "")
                    {
                        asset_Code_cmb.Text = (xlRange.Cells[i, 1].Value.ToString()).Substring(0, 10);
                        addandupdate();
                        GridBind();
                        colRankNameNowTextBox.Visible = true;
                        colRankNameNow.Visible = false;
                    }
                    if (InvertoryCheck_dgv.RowCount > 0)
                    {

                        for (int j = dem; j < InvertoryCheck_dgv.RowCount; j++)
                        {
                            ValueObjectList<RankVo> rankcode = (ValueObjectList<RankVo>)DefaultCbmInvoker.Invoke(new GetRankCbm(), new RankVo() { RankCode = (xlRange.Cells[i, 2].Value.ToString()) });
                            List<RankVo> rankname = new List<RankVo>();
                            rankname = rankcode.GetList();

                            InvertoryCheck_dgv.Rows[j].Cells["colRankNameNowTextBox"].Value = rankname[0].RankName;

                            InvertoryVo outVo = new InvertoryVo();
                            InvertoryVo inVo = new InvertoryVo()
                            {
                                AssetId = int.Parse(InvertoryCheck_dgv.Rows[j].Cells["colAssetId"].Value.ToString()),
                                RankNameNow = InvertoryCheck_dgv.Rows[j].Cells["colRankNameNowTextBox"].Value.ToString(),
                            };
                            outVo = (InvertoryVo)DefaultCbmInvoker.Invoke(new UpdateWHInvertoryRankCbm(), inVo);
                            outVo = (InvertoryVo)DefaultCbmInvoker.Invoke(new UpdateACCInvertoryRankCbm(), inVo);
                            dem = dem + 1;
                        }
                    }
                }
                asset_Code_cmb.Text = "";
                // GridBind();
                Search_btn_Click(sender, e);
                GC.Collect(); //can delete
                GC.WaitForPendingFinalizers();

                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);
            }
            if(thongbao >= 1)
            {
                MessageBox.Show(mess, "Messager", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            asset_Code_cmb.Select();
        }
        private void browser_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.xlsx)|*.csv|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                linksave_txt.Text = openFileDialog1.FileName;
            }
        }
        private void Search_btn_Click(object sender, EventArgs e)
        {
            assetcodetrim = "";
            GridBind();
            InvertoryCheck_dgv.Columns["colRankNameNowTextBox"].Visible = false;
            InvertoryCheck_dgv.Columns["colRankNameNow"].Visible = false;
            asset_Code_cmb.Select();
        }
        private void exportlink_btn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fl = new FolderBrowserDialog();
            fl.SelectedPath = "d:\\";
            fl.ShowNewFolderButton = true;
            if (fl.ShowDialog() == DialogResult.OK)
            {
                linkexport_txt.Text = fl.SelectedPath;
                directorySave = linkexport_txt.Text;
            }
        }
        private string directorySave = "";

        private void ExportExcel_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common.Excel_Class exportexcel = new Common.Excel_Class();
            exportexcel.exportexcel(ref InvertoryCheck_dgv, linkexport_txt.Text, this.Text);
        }


    }
}
