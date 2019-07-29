using Com.Nidec.Mes.Framework;
using System;
using System.Drawing;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.AccountCodeCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.AccountLocationCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.WareHouseMainCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.InvertoryTimeCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.AccountMainCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.RankMasterCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.TranferForm;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.AccountMainForm
{
    public partial class AccountMainForm : FormCommonNCVP
    {
        public AccountMainForm()
        {
            InitializeComponent();
            account_main_dgv.AutoGenerateColumns = false;
            account_depreciation_dgv.AutoGenerateColumns = false;
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            account_depreciation_dgv.Visible = false;
            account_main_dgv.Visible = true;
            account_main_dgv.DataSource = null;
            GridBind();
            full_asset_Code_txt.Text = "";
            //   updatedatatodatabase();
            invertory_alarm();
            counter();
        }
        void counter()
        {
            if (counter_dgv.RowCount > 0)
            {
                counter_dgv.Rows.RemoveAt(this.counter_dgv.Rows[0].Index);
            }
            double AcquisitionCost = 0, CurrentDepreciation = 0, MonthlyDepreciation = 0, AccumDepreciation = 0, NetValue = 0;
            int TotalMachine = 0, Inventory = 0;
            int j = 0;
            for (int i = 0; i < account_main_dgv.RowCount; i++)
            {
                AcquisitionCost += double.Parse(account_main_dgv.Rows[i].Cells["colAcquisitionCost"].Value.ToString());
                CurrentDepreciation += double.Parse(account_main_dgv.Rows[i].Cells["colCurrentDepreciation"].Value.ToString());
                MonthlyDepreciation += double.Parse(account_main_dgv.Rows[i].Cells["colMonthlyDepreciation"].Value.ToString());
                AccumDepreciation += double.Parse(account_main_dgv.Rows[i].Cells["colAccumDepreciation"].Value.ToString());
                NetValue += double.Parse(account_main_dgv.Rows[i].Cells["colNetValue"].Value.ToString());
                TotalMachine = i+1;
                if (account_main_dgv.Rows[i].Cells["colInvertory"].Value.ToString() == invertory_cmb.Text)
                {
                    Inventory += j+ 1;
                }
            }

            counter_dgv.Rows.Add(Math.Round(AcquisitionCost, 2).ToString(), Math.Round(CurrentDepreciation).ToString(), Math.Round(MonthlyDepreciation).ToString(), Math.Round(AccumDepreciation).ToString(), Math.Round(NetValue).ToString(), Inventory.ToString(), TotalMachine.ToString());
        }
        void updatedatatodatabase()
        {
            if (account_main_dgv.RowCount > 0)
            {
                AccountMainVo outVo = new AccountMainVo();
                for (int i = 0; i < account_main_dgv.RowCount; i++)
                {
                    AccountMainVo inVo = new AccountMainVo()
                    {
                        AcountMainId = int.Parse(account_main_dgv.Rows[i].Cells["colAcountMainId"].Value.ToString()),
                        CurrentDepreciation = double.Parse(account_main_dgv.Rows[i].Cells["colCurrentDepreciation"].Value.ToString()),
                        MonthlyDepreciation = double.Parse(account_main_dgv.Rows[i].Cells["colMonthlyDepreciation"].Value.ToString()),
                        AccumDepreciation = double.Parse(account_main_dgv.Rows[i].Cells["colAccumDepreciation"].Value.ToString()),
                        NetValue = double.Parse(account_main_dgv.Rows[i].Cells["colNetValue"].Value.ToString()),
                    };
                    outVo = (AccountMainVo)DefaultCbmInvoker.Invoke(new UpdateAccountMainDGVCbm(), inVo);
                }
            }
        }
        void invertory_alarm()
        {
            for (int i = 0; i < account_main_dgv.RowCount; i++)
            {
                if (int.Parse(account_main_dgv.Rows[i].Cells["colInvertoryId"].Value.ToString()) >= ((InvertoryVo)this.invertory_cmb.SelectedItem).InvertoryTimeId)
                {
                    account_main_dgv.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
                }
                else if (int.Parse(account_main_dgv.Rows[i].Cells["colInvertoryId"].Value.ToString()) < ((InvertoryVo)this.invertory_cmb.SelectedItem).InvertoryTimeId)
                {
                    account_main_dgv.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }
        private void GridBind()
        {
            try
            {
                AccountMainVo whvos = new AccountMainVo()
                {
                    AssetCode = asset_Code_txt.Text,
                    RankCode = rank_code_cbm.Text,
                    AssetType = asset_type_cbm.Text,
                    AccountCodeCode = account_code_cmb.Text,
                    AccountLocationCode = section_cd_cmb.Text,
                    AssetInvoice = invoice_cbm.Text,
                    AssetModel = asset_model_cbm.Text,
                    LocationCode = location_cbm.Text,
                    AssetName = asset_name_cbm.Text,
                    LabelStatus = labelstatus_cmb.Text,
                    Net_Value = net_value_cmb.Text,
                    AssetPO = AssetPO_cmb.Text,
                    //AssetNo = 
                };
                if (checkdata())
                {
                    ValueObjectList<AccountMainVo> listvo = (ValueObjectList<AccountMainVo>)DefaultCbmInvoker.Invoke(new SeachAccountMainCbm(), whvos);
                    account_main_dgv.DataSource = listvo.GetList();
                //    calculator();
                    // ReviewStatusLable();
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
        //public void ReviewStatusLable()
        //{
        //    if(account_main_dgv.RowCount > 0)
        //    {
        //        for (int i = 0; i < account_main_dgv.RowCount; i++)
        //        {
        //            if(account_main_dgv.Rows[i].Cells["colLabelStatus"].Value.ToString()== "Pasted") //Pasted
        //            {
        //                account_main_dgv.Rows[i].Cells["colLabelStatus"].Style.BackColor = Color.White;
        //            }
        //            else if (account_main_dgv.Rows[i].Cells["colLabelStatus"].Value.ToString() == "Not Paste") //Not Paste
        //            {
        //                account_main_dgv.Rows[i].Cells["colLabelStatus"].Style.BackColor = Color.Violet;
        //            }
        //            else if (account_main_dgv.Rows[i].Cells["colLabelStatus"].Value.ToString() == "Cannot Paste") //Cannot Paste
        //            {
        //                account_main_dgv.Rows[i].Cells["colLabelStatus"].Style.BackColor = Color.LightCoral;
        //            }
        //        }
        //    }
        //}
        public void calculator()
        {
            if (account_main_dgv.RowCount > 0)
            {
                for (int i = 0; i < account_main_dgv.RowCount; i++)
                {
                    DateTime Dep_Start = DateTime.Parse(account_main_dgv.Rows[i].Cells["colStartDepreciation"].Value.ToString());
                    DateTime Dep_End = DateTime.Parse(account_main_dgv.Rows[i].Cells["colEndDepreciation"].Value.ToString());
                    int Start_Year = Dep_Start.Year;
                    int Start_month = Dep_Start.Month;
                    int Current_Year = DateTime.Now.Year;
                    int Current_month = DateTime.Now.Month;

                    double mothcounter = ((Current_Year - Start_Year) * 12) + (Current_month - Start_month);
                    double monthlife = double.Parse(account_main_dgv.Rows[i].Cells["colAssetLife"].Value.ToString()) * 12;
                    double Acquisition = double.Parse(account_main_dgv.Rows[i].Cells["colAcquisitionCost"].Value.ToString());
                    double monthly_depr = Acquisition / monthlife;

                    //Monthly
                    account_main_dgv.Rows[i].Cells["colMonthlyDepreciation"].Value = Math.Round(monthly_depr, 3).ToString();

                    //Curent Depreciation
                    double current_depr = (mothcounter - 1) * monthly_depr;
                    account_main_dgv.Rows[i].Cells["colCurrentDepreciation"].Value = Math.Round(current_depr, 3).ToString();
                    if (current_depr > Acquisition)
                    {
                        account_main_dgv.Rows[i].Cells["colCurrentDepreciation"].Value = Acquisition.ToString();
                    }
                    if (current_depr < 0)
                    {
                        account_main_dgv.Rows[i].Cells["colCurrentDepreciation"].Value = 0.ToString();
                    }
                    //Accum
                    double Accum = (mothcounter * monthly_depr);
                    account_main_dgv.Rows[i].Cells["colAccumDepreciation"].Value = Math.Round(Accum, 3).ToString();
                    if (Accum > Acquisition)
                    {
                        account_main_dgv.Rows[i].Cells["colAccumDepreciation"].Value = Acquisition.ToString();
                    }
                    if (Accum < 0)
                    {
                        account_main_dgv.Rows[i].Cells["colAccumDepreciation"].Value = 0.ToString();
                    }

                    //Net Value
                    double net_value = (Acquisition - Accum);
                    account_main_dgv.Rows[i].Cells["colNetValue"].Value = Math.Round(net_value, 3).ToString();
                    if (net_value > Acquisition)
                    {
                        account_main_dgv.Rows[i].Cells["colNetValue"].Value = Acquisition.ToString();
                    }
                    if (net_value < 0)
                    {
                        account_main_dgv.Rows[i].Cells["colNetValue"].Value = 0.ToString();
                    }
                }
            }
        }
        private void add_btn_Click(object sender, EventArgs e)
        {
            AddAcountMainForm addaccountmain = new AddAcountMainForm();
            addaccountmain.ShowDialog();
        }

        private void AccountMainForm_Load(object sender, EventArgs e)
        {
            {
                account_depreciation_dgv.DefaultCellStyle.Font = new Font("Arial", 9);
                account_depreciation_dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
                account_main_dgv.DefaultCellStyle.Font = new Font("Arial", 9);
                account_main_dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
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
            ValueObjectList<AccountCodeVo> accountcodevo = (ValueObjectList<AccountCodeVo>)DefaultCbmInvoker.Invoke(new GetAccountCodeCbm(), new AccountCodeVo());
            account_code_cmb.DisplayMember = "AccountCodeCode";
            account_code_cmb.DataSource = accountcodevo.GetList();
            account_code_cmb.Text = "";

            //accountlocationcode
            ValueObjectList<AccountLocationVo> accountlocationcodevo = (ValueObjectList<AccountLocationVo>)DefaultCbmInvoker.Invoke(new GetAccountLocationCbm(), new AccountLocationVo());
            section_cd_cmb.DisplayMember = "AccountLocationCode";
            section_cd_cmb.DataSource = accountlocationcodevo.GetList();
            section_cd_cmb.Text = "";

            ValueObjectList<AssetVo> assetvoinvoice = (ValueObjectList<AssetVo>)DefaultCbmInvoker.Invoke(new GetAssetInvoiceCbm(), new AssetVo());
            invoice_cbm.DisplayMember = "AssetInvoice";
            invoice_cbm.DataSource = assetvoinvoice.GetList();
            invoice_cbm.Text = "";

            ValueObjectList<AssetVo> assetPO = (ValueObjectList<AssetVo>)DefaultCbmInvoker.Invoke(new GetAssetPOCbm(), new AssetVo());
            AssetPO_cmb.DisplayMember = "AssetPO";
            AssetPO_cmb.DataSource = assetPO.GetList();
            AssetPO_cmb.Text = "";

            ValueObjectList<InvertoryVo> invertory = (ValueObjectList<InvertoryVo>)DefaultCbmInvoker.Invoke(new GetInvertoryTimeCbm(), new InvertoryVo());
            invertory_cmb.DisplayMember = "InvertoryTimeCode";
            invertory_cmb.DataSource = invertory.GetList();

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
        }
        public void trimcode()
        {
            if (full_asset_Code_txt.TextLength >= 10)
            {
                //asset_Code_txt.Text = full_asset_Code_txt.Text.Substring(0, 10);
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
            if (account_main_dgv.SelectedCells.Count > 0)
            {
                AccountMainVo selectedvo = (AccountMainVo)account_main_dgv.CurrentRow.DataBoundItem;

                if (new AddAcountMainForm { accountmainVo = selectedvo, }.ShowDialog() == DialogResult.OK)
                { GridBind(); }
            }
        }

        private void depreciation_btn_Click(object sender, EventArgs e)
        {
            account_depreciation_dgv.Visible = true;
            account_main_dgv.Visible = false;
            account_depreciation_dgv.DataSource = null;

            account_depreciation_dgv.Columns[0].HeaderText = "Account Name";

            try
            {
                AccountMainVo whvos = new AccountMainVo()
                {

                };
                ValueObjectList<AccountMainVo> listvo = (ValueObjectList<AccountMainVo>)DefaultCbmInvoker.Invoke(new TotalDEPAccountMainCbm(), whvos);
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
            account_main_dgv.Visible = false;
            account_depreciation_dgv.DataSource = null;
            account_depreciation_dgv.Columns[0].HeaderText = "Rank Name";
            try
            {
                AccountMainVo whvos = new AccountMainVo()
                {

                };
                ValueObjectList<AccountMainVo> listvo = (ValueObjectList<AccountMainVo>)DefaultCbmInvoker.Invoke(new TotalRankDEPAccountMainCbm(), whvos);
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
            else if (account_main_dgv.Visible == true)
            {
                Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common.CSV_Class exportexcel = new Common.CSV_Class();
                exportexcel.exportcsv(ref account_main_dgv, linksave_txt.Text, account_main_dgv.Columns[0].HeaderText);

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

        private void Transfer_btn_Click(object sender, EventArgs e)
        {
            TranferInfoForm transinfo = new TranferInfoForm();
            transinfo.ShowDialog();
        }

        private void exportexcel1_btn_Click(object sender, EventArgs e)
        {
            Com.Nidec.Mes.Common.Basic.MachineMaintenance.Common.Excel_Class exportexcel = new Common.Excel_Class();
            exportexcel.exportexcel(ref account_main_dgv, linksave_txt.Text, this.Text);
        }
    }
}
