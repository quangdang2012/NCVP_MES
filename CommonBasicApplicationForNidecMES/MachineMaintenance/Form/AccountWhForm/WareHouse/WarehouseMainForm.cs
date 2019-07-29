using Com.Nidec.Mes.Framework;
using System;
using System.Drawing;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.WareHouseMainCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.DetailPositionCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.InvertoryTimeCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.TransferCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.RankMasterCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.TranferForm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.WareHouse
{
    public partial class WarehouseMainForm : FormCommonNCVP
    {
        public WarehouseMainForm()
        {
            InitializeComponent();
            warehouse_main_dgv.AutoGenerateColumns = false;
            account_depreciation_dgv.AutoGenerateColumns = false;
            counter_dgv.AutoGenerateColumns = false;
        }
        private void search_btn_Click(object sender, EventArgs e)
        {
            account_depreciation_dgv.Visible = false;
            warehouse_main_dgv.Visible = true;
            GridBind();
            full_asset_Code_txt.Text = "";
           // counter();
            // updatedatatodatabase();

        }
        void counter()
        {
            if (counter_dgv.RowCount >0)
            {
                counter_dgv.Rows.RemoveAt(this.counter_dgv.Rows[0].Index);
            }
            double AcquisitionCost = 0, CurrentDepreciation = 0, MonthlyDepreciation = 0, AccumDepreciation = 0, NetValue = 0;
            int TotalMachine = 0, Inventory = 0;
            int j = 0;
            for (int i = 0; i < warehouse_main_dgv.RowCount; i++)
            {
                AcquisitionCost += double.Parse(warehouse_main_dgv.Rows[i].Cells["colAcquisitionCost"].Value.ToString());
                CurrentDepreciation +=double.Parse(warehouse_main_dgv.Rows[i].Cells["colCurrentDepreciation"].Value.ToString());
                MonthlyDepreciation += double.Parse(warehouse_main_dgv.Rows[i].Cells["colMonthlyDepreciation"].Value.ToString());
                AccumDepreciation += double.Parse(warehouse_main_dgv.Rows[i].Cells["colAccumDepreciation"].Value.ToString());
                NetValue += double.Parse(warehouse_main_dgv.Rows[i].Cells["colNetValue"].Value.ToString());
                TotalMachine = i+1;
                if (warehouse_main_dgv.Rows[i].Cells["colIvertory"].Value.ToString() == invertory_cmb.Text)
                {
                    Inventory += j+1;
                }
            }
            
            counter_dgv.Rows.Add(Math.Round( AcquisitionCost,2).ToString(), Math.Round(CurrentDepreciation).ToString(), Math.Round(MonthlyDepreciation).ToString(), Math.Round(AccumDepreciation).ToString(), Math.Round(NetValue).ToString(), Inventory.ToString(), TotalMachine.ToString());
        }
        void updatedatatodatabase()
        {
            if (warehouse_main_dgv.RowCount > 0)
            {
                WareHouseMainVo outVo = new WareHouseMainVo();
                for (int i = 0; i < warehouse_main_dgv.RowCount; i++)
                {
                    WareHouseMainVo inVo = new WareHouseMainVo()
                    {
                        WareHouseMainId = int.Parse(warehouse_main_dgv.Rows[i].Cells["colAcountMainId"].Value.ToString()),
                        CurrentDepreciation = double.Parse(warehouse_main_dgv.Rows[i].Cells["colCurrentDepreciation"].Value.ToString()),
                        MonthlyDepreciation = double.Parse(warehouse_main_dgv.Rows[i].Cells["colMonthlyDepreciation"].Value.ToString()),
                        AccumDepreciation = double.Parse(warehouse_main_dgv.Rows[i].Cells["colAccumDepreciation"].Value.ToString()),
                        NetValue = double.Parse(warehouse_main_dgv.Rows[i].Cells["colNetValue"].Value.ToString()),
                    };
                    outVo = (WareHouseMainVo)DefaultCbmInvoker.Invoke(new UpdateWareHouseMainDGVCbm(), inVo); //update code
                }
            }
        }
        void invertory_alarm()
        {
            for (int i = 0; i < warehouse_main_dgv.RowCount; i++)
            {
                if (int.Parse(warehouse_main_dgv.Rows[i].Cells["colInvertoryId"].Value.ToString()) >= ((InvertoryVo)this.invertory_cmb.SelectedItem).InvertoryTimeId)
                {
                    warehouse_main_dgv.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                else if (int.Parse(warehouse_main_dgv.Rows[i].Cells["colInvertoryId"].Value.ToString()) < ((InvertoryVo)this.invertory_cmb.SelectedItem).InvertoryTimeId)
                {
                    warehouse_main_dgv.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
        private void GridBind()
        {
            try
            {
                WareHouseMainVo whvos = new WareHouseMainVo()
                {
                    AssetCode = asset_Code_txt.Text,
                    RankCode = rank_code_cbm.Text,
                    AssetType = asset_type_cbm.Text,
                    AccountCodeCode = detail_position_cmb.Text,
                    AccountLocationCode = select_search_cbm.Text,
                    AssetInvoice = invoice_cbm.Text,
                    AssetModel = asset_model_cbm.Text,
                    AfterLocationCd = location_cbm.Text,
                    AssetName = asset_name_cbm.Text,
                    DetailPositionCd = detail_position_cmb.Text,
                    LabelStatus = labelstatus_cmb.Text,
                    Net_Value = net_value_cmb.Text,
                    AssetPO = AssetPO_cmb.Text,
                };
                if (checkdata())
                {
                    if (select_search_cbm.Text == "Search History")
                    {
                        ValueObjectList<WareHouseMainVo> listvo = (ValueObjectList<WareHouseMainVo>)DefaultCbmInvoker.Invoke(new SearchWareHouseMainCbm(), whvos);
                        warehouse_main_dgv.DataSource = listvo.GetList();
                    }
                    else if (select_search_cbm.Text == "Search List")
                    {
                        ValueObjectList<WareHouseMainVo> listvo = (ValueObjectList<WareHouseMainVo>)DefaultCbmInvoker.Invoke(new SearchListWareHouseMainCbm(), whvos);
                        warehouse_main_dgv.DataSource = listvo.GetList();
                        invertory_alarm();
                        counter();
                    }
                    //   calculator();
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        bool checkdata()
        {
            if (invertory_cmb.Text == "")
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, "Invertory");
                popUpMessage.Warning(messageData, Text);
                invertory_cmb.Focus();
                return false;
            }
            return true;
        }
        public void calculator()
        {
            if (warehouse_main_dgv.RowCount > 0)
            {
                for (int i = 0; i < warehouse_main_dgv.RowCount; i++)
                {
                    DateTime Dep_Start = DateTime.Parse(warehouse_main_dgv.Rows[i].Cells["colStartDepreciation"].Value.ToString());
                    DateTime Dep_End = DateTime.Parse(warehouse_main_dgv.Rows[i].Cells["colEndDepreciation"].Value.ToString());
                    int Start_Year = Dep_Start.Year;
                    int Start_month = Dep_Start.Month;
                    int Current_Year = DateTime.Now.Year;
                    int Current_month = DateTime.Now.Month;

                    double mothcounter = ((Current_Year - Start_Year) * 12) + (Current_month - Start_month);
                    double monthlife = double.Parse(warehouse_main_dgv.Rows[i].Cells["colAssetLife"].Value.ToString()) * 12;
                    double Acquisition = double.Parse(warehouse_main_dgv.Rows[i].Cells["colAcquisitionCost"].Value.ToString());
                    double monthly_depr = Acquisition / monthlife;

                    //Monthly
                    warehouse_main_dgv.Rows[i].Cells["colMonthlyDepreciation"].Value = Math.Round(monthly_depr, 3).ToString();

                    //Curent Depreciation
                    double current_depr = (mothcounter - 1) * monthly_depr;
                    warehouse_main_dgv.Rows[i].Cells["colCurrentDepreciation"].Value = Math.Round(current_depr, 3).ToString();
                    if (current_depr > Acquisition)
                    {
                        warehouse_main_dgv.Rows[i].Cells["colCurrentDepreciation"].Value = Acquisition.ToString();
                    }
                    if (current_depr < 0)
                    {
                        warehouse_main_dgv.Rows[i].Cells["colCurrentDepreciation"].Value = 0.ToString();
                    }
                    //Accum
                    double Accum = (mothcounter * monthly_depr);
                    warehouse_main_dgv.Rows[i].Cells["colAccumDepreciation"].Value = Math.Round(Accum, 3).ToString();
                    if (Accum > Acquisition)
                    {
                        warehouse_main_dgv.Rows[i].Cells["colAccumDepreciation"].Value = Acquisition.ToString();
                    }
                    if (Accum < 0)
                    {
                        warehouse_main_dgv.Rows[i].Cells["colAccumDepreciation"].Value = 0.ToString();
                    }

                    //Net Value
                    double net_value = (Acquisition - Accum);
                    warehouse_main_dgv.Rows[i].Cells["colNetValue"].Value = Math.Round(net_value, 3);
                    if (net_value > Acquisition)
                    {
                        warehouse_main_dgv.Rows[i].Cells["colNetValue"].Value = Acquisition.ToString();
                    }
                    if (net_value < 0)
                    {
                        warehouse_main_dgv.Rows[i].Cells["colNetValue"].Value = 0.ToString();
                    }
                }
            }
        }
        private void add_btn_Click(object sender, EventArgs e)
        {
            AddWareHouseMainForm addaccountmain = new AddWareHouseMainForm();
            addaccountmain.ShowDialog();
        }

        private void WareHouseMainForm_Load(object sender, EventArgs e)
        {
            AcceptButton = search_btn;
            select_search_cbm.Items.Add("Search History");
            select_search_cbm.Items.Add("Search List");
            select_search_cbm.Text = "Search List";

            {
                account_depreciation_dgv.DefaultCellStyle.Font = new Font("Arial", 9);
                account_depreciation_dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                warehouse_main_dgv.DefaultCellStyle.Font = new Font("Arial", 9);
                warehouse_main_dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
            }


            AcceptButton = search_btn;
            ValueObjectList<RankVo> rankcode = (ValueObjectList<RankVo>)DefaultCbmInvoker.Invoke(new GetRankCbm(), new RankVo());
            rank_code_cbm.DisplayMember = "RankCode";
            rank_code_cbm.DataSource = rankcode.GetList();
            rank_code_cbm.Text = "";

            ValueObjectList<AssetVo> assetvotype = (ValueObjectList<AssetVo>)DefaultCbmInvoker.Invoke(new GetAssetTypeCbm(), new AssetVo());
            asset_type_cbm.DisplayMember = "AssetType";
            asset_type_cbm.DataSource = assetvotype.GetList();
            asset_type_cbm.Text = "";

            // account_code
            ValueObjectList<DetailPositionVo> detailposition = (ValueObjectList<DetailPositionVo>)DefaultCbmInvoker.Invoke(new GetDetailPositionCbm(), new DetailPositionVo());
            detail_position_cmb.DisplayMember = "DetailPositionCode";
            detail_position_cmb.DataSource = detailposition.GetList();
            detail_position_cmb.Text = "";



            ValueObjectList<AssetVo> assetvoinvoice = (ValueObjectList<AssetVo>)DefaultCbmInvoker.Invoke(new GetAssetInvoiceCbm(), new AssetVo());
            invoice_cbm.DisplayMember = "AssetInvoice";
            invoice_cbm.DataSource = assetvoinvoice.GetList();
            invoice_cbm.Text = "";

            ValueObjectList<AssetVo> assetPO = (ValueObjectList<AssetVo>)DefaultCbmInvoker.Invoke(new GetAssetPOCbm(), new AssetVo());
            AssetPO_cmb.DisplayMember = "AssetPO";
            AssetPO_cmb.DataSource = assetPO.GetList();
            AssetPO_cmb.Text = "";

            ValueObjectList<AssetVo> assetvomodel = (ValueObjectList<AssetVo>)DefaultCbmInvoker.Invoke(new GetAssetModelCbm(), new AssetVo());
            asset_model_cbm.DisplayMember = "AssetModel";
            asset_model_cbm.DataSource = assetvomodel.GetList();
            asset_model_cbm.Text = "";

            ValueObjectList<AssetVo> assetvoname = (ValueObjectList<AssetVo>)DefaultCbmInvoker.Invoke(new GetAssetNameCbm(), new AssetVo());
            asset_name_cbm.DisplayMember = "AssetName";
            asset_name_cbm.DataSource = assetvoname.GetList();
            asset_name_cbm.Text = "";

            LocationVo Locationvo = (LocationVo)DefaultCbmInvoker.Invoke(new GetLocationMasterMntCbm(), new LocationVo());
            location_cbm.DisplayMember = "LocationCode";
            location_cbm.DataSource = Locationvo.LocationListVo;
            location_cbm.Text = "";

            ValueObjectList<InvertoryVo> invertory = (ValueObjectList<InvertoryVo>)DefaultCbmInvoker.Invoke(new GetInvertoryTimeCbm(), new InvertoryVo());
            invertory_cmb.DisplayMember = "InvertoryTimeCode";
            invertory_cmb.DataSource = invertory.GetList();

        }
        private void location_cbm_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValueObjectList<DetailPositionVo> detailposition = (ValueObjectList<DetailPositionVo>)DefaultCbmInvoker.Invoke(new GetDetailPositionCbm(), new DetailPositionVo() { LocationCd = location_cbm.Text, });
            detail_position_cmb.DisplayMember = "DetailPositionCode";
            detail_position_cmb.DataSource = detailposition.GetList();
            detail_position_cmb.Text = "";
        }
        public void trimcode()
        {
            if (full_asset_Code_txt.TextLength >= 10)
            {
                // asset_Code_txt.Text = full_asset_Code_txt.Text.Substring(0, 10);
                string str = full_asset_Code_txt.Text;
                string[] arrListStr = str.Split(',');
                asset_Code_txt.Text = arrListStr[0];
                asset_Code_txt.Enabled = false;
            }
            else
            {
                asset_Code_txt.Enabled = true;
                asset_Code_txt.Text = "";
            }
        }

        private void full_asset_Code_txt_TextChanged(object sender, EventArgs e)
        {
            trimcode();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (warehouse_main_dgv.SelectedCells.Count > 0 && select_search_cbm.Text == "Search List")
            {
                WareHouseMainVo selectedvo = (WareHouseMainVo)warehouse_main_dgv.CurrentRow.DataBoundItem;

                if (new AddWareHouseMainForm { WareHouseMainVo = selectedvo, }.ShowDialog() == DialogResult.OK)
                { GridBind(); }
            }

        }

        private void depreciation_btn_Click(object sender, EventArgs e)
        {
            account_depreciation_dgv.Visible = true;
            warehouse_main_dgv.Visible = false;
            account_depreciation_dgv.DataSource = null;

            account_depreciation_dgv.Columns[0].HeaderText = "Account Name";

            try
            {
                WareHouseMainVo whvos = new WareHouseMainVo()
                { };
                ValueObjectList<WareHouseMainVo> listvo = (ValueObjectList<WareHouseMainVo>)DefaultCbmInvoker.Invoke(new TotalDEPWareHouseMainCbm(), whvos);
                account_depreciation_dgv.DataSource = listvo.GetList();

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        private void Rank_Dep_btn_Click(object sender, EventArgs e)
        {
            account_depreciation_dgv.Visible = true;
            warehouse_main_dgv.Visible = false;
            account_depreciation_dgv.DataSource = null;
            account_depreciation_dgv.Columns[0].HeaderText = "Rank Name";
            try
            {
                WareHouseMainVo whvos = new WareHouseMainVo()
                {

                };
                ValueObjectList<WareHouseMainVo> listvo = (ValueObjectList<WareHouseMainVo>)DefaultCbmInvoker.Invoke(new TotalRankDEPWareHouseMainCbm(), whvos);
                account_depreciation_dgv.DataSource = listvo.GetList();
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }

        }

        private void exportexcel_btn_Click(object sender, EventArgs e)
        {
            if (account_depreciation_dgv.Visible == true)
            {
                Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common.CSV_Class exportexcel = new Common.CSV_Class();
                exportexcel.exportcsv(ref account_depreciation_dgv, linksave_txt.Text, account_depreciation_dgv.Columns[0].HeaderText);
            }
            else if (warehouse_main_dgv.Visible == true)
            {
                Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common.CSV_Class exportexcel = new Common.CSV_Class();
                exportexcel.exportcsv(ref warehouse_main_dgv, linksave_txt.Text, this.Text);

            }
        }


        private void buttonCommon1_Click(object sender, EventArgs e)
        {

            //string text = System.IO.File.ReadAllText(@"D:\testfolder\received.txt");
            //asset_Code_txt.Text = text;
        }

        private void buttonCommon3_Click(object sender, EventArgs e)
        {
            //string[] text= { "",""};

            //int rowcount = warehouse_main_dgv.Rows.Count;
            //int columncount = warehouse_main_dgv.Columns.Count;

            //for (int i = 0; i < rowcount; i++)
            //{
            //                   for (int j = 0; j < columncount - 1; j++)
            //    {
            //        text =(warehouse_main_dgv.Rows[i].Cells[j].Value.ToString());
            //    }
            //}
            //System.IO.File.WriteAllText(@"D:\testfolder\transfer.txt", text);
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {

        }

        private void Transfer_btn_Click(object sender, EventArgs e)
        {
            TransferVo transOutVo = new TransferVo();
            TransferVo transVo = new TransferVo()
            {
                RegistrationUserCode = UserData.GetUserData().UserCode
            };
            try
            {
                transOutVo = (TransferVo)DefaultCbmInvoker.Invoke(new GetRoleCbm(), transVo);
                string role = transOutVo.RegistrationUserCode;

                if (role != "mgr")
                {
                    TranferRequestForm transre = new TranferRequestForm();
                    transre.ShowDialog();
                }
                else
                {
                    TranferInfoForm transinfo = new TranferInfoForm();
                    transinfo.ShowDialog();
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }
        private string directorySave = "";
        private void browser_btn_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fl = new FolderBrowserDialog();
            fl.SelectedPath = "d:\\";
            fl.ShowNewFolderButton = true;
            if (fl.ShowDialog() == DialogResult.OK)
            {
                linksave_txt.Text = fl.SelectedPath;
                directorySave = linksave_txt.Text;
            }
        }

        private void linksave_txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void exportexcel1_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common.Excel_Class exportexcel = new Common.Excel_Class();
            exportexcel.exportexcel(ref warehouse_main_dgv, linksave_txt.Text, this.Text);
        }
    }
}