using Com.Nidec.Mes.Framework;
using System;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.AccountMainCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.UnitMasterCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.AssetMasterCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.AccountCodeCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.AccountLocationCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.RankMasterCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.AccountWhCbm.UserLocationMasterCbm;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form.AccountWhForm.AccountMainForm
{
    public partial class AddAcountMainForm : FormCommonNCVP
    {
        public AddAcountMainForm()
        {
            InitializeComponent();
        }
        public AccountMainVo accountmainVo = new AccountMainVo(); //dv
        private void AddAcountMainForm_Load(object sender, EventArgs e)
        {       
            //rank
            ValueObjectList<RankVo> rankname = (ValueObjectList<RankVo>)DefaultCbmInvoker.Invoke(new GetRankCbm(), new RankVo());
            rank_code_cmb.DisplayMember = "RankCode";
            rank_code_cmb.DataSource = rankname.GetList();
            rank_code_cmb.Text = "";


            //location 
            LocationVo Locationvo = (LocationVo)DefaultCbmInvoker.Invoke(new GetLocationMasterMntCbm(), new LocationVo());
            location_cmb.DataSource = Locationvo.LocationListVo;
            location_cmb.DisplayMember = "LocationCode";
            location_cmb.Text = "";

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

            //cau cua dang
            ValueObjectList<AssetVo> assetmodelvo = (ValueObjectList<AssetVo>)DefaultCbmInvoker.Invoke(new GetAssetCbm(), new AssetVo());
            no_cbm.DisplayMember = "AssetNo";
            no_cbm.ValueMember = "AssetId";
            no_cbm.DataSource = assetmodelvo.GetList();
            //end

            ValueObjectList<UnitVo> unit = (ValueObjectList<UnitVo>)DefaultCbmInvoker.Invoke(new GetUnitCbm(), new UnitVo());
            unit_cmb.DisplayMember = "UnitCode";
            unit_cmb.DataSource = unit.GetList();
            unit_cmb.Text = "";

            {
                user_location_name_cmb.Enabled = false;
                asset_model_cmb.Enabled = false;
                end_depreciation_dtp.Enabled = false;
                asset_life_cmb.Enabled = false;
                acquisition_cost_cmb.Enabled = false;
                current_depreciation_txt.Enabled = false;
                monthl_depreciation_txt.Enabled = false;
                accum_depreciation_txt.Enabled = false;
                net_value_txt.Enabled = false;

            }
            if (accountmainVo.AcountMainId > 0)
            {
                asset_code_txt.Enabled = false;
                no_cbm.Enabled = false;
                no_cbm.Text = accountmainVo.AssetNo.ToString();
                asset_code_txt.Text = accountmainVo.AssetCode;
                asset_model_cmb.Text = accountmainVo.AssetModel;
                rank_code_cmb.Text = accountmainVo.RankCode;
                account_code_cmb.Text = accountmainVo.AccountCodeCode;
                section_cd_cmb.Text = accountmainVo.AccountLocationCode;
                location_cmb.Text = accountmainVo.AccountLocationName;
                qty_txt.Text = accountmainVo.QTY.ToString();
                unit_cmb.Text = accountmainVo.UnitName;
                start_depreciation_dtp.Value = accountmainVo.StartDepreciation;
                end_depreciation_dtp.Value = accountmainVo.EndDepreciation;
                asset_life_cmb.Text = accountmainVo.AssetLife.ToString();
                acquisition_cost_cmb.Text = accountmainVo.AcquisitionCost.ToString();
                current_depreciation_txt.Text = accountmainVo.CurrentDepreciation.ToString();
                monthl_depreciation_txt.Text = accountmainVo.MonthlyDepreciation.ToString();
                accum_depreciation_txt.Text = accountmainVo.AccumDepreciation.ToString();
                net_value_txt.Text = accountmainVo.NetValue.ToString();


                this.TitleText = Com.Nidec.Mes.GlobalMasterMaintenance.CommonConstants.MODE_UPDATE;
            }
            else
            {
                comments_txt.Text = "Add";
                this.TitleText = Com.Nidec.Mes.GlobalMasterMaintenance.CommonConstants.MODE_ADD;
            }
        }

        private void ok_btn_Click(object sender, EventArgs e)
        {
            if (Checkdata())
            {
                AccountMainVo outVo = new AccountMainVo();
                AccountMainVo inVo = new AccountMainVo()
                {

                    AcountMainId = accountmainVo.AcountMainId,
                    ///

                    AssetId = ((AssetVo)this.no_cbm.SelectedItem).AssetId,
                    QTY = Int16.Parse(qty_txt.Text),
                    UnitId = ((UnitVo)unit_cmb.SelectedItem).UnitId,
                    AssetNo = Int16.Parse(no_cbm.Text),
                    AccountCodeId = ((AccountCodeVo)this.account_code_cmb.SelectedItem).AccountCodeId,
                    AccountLocationId = ((AccountLocationVo)this.section_cd_cmb.SelectedItem).AccountLocationId,
                    RankId = ((RankVo)this.rank_code_cmb.SelectedItem).RankId,
                    CommnetsData = comments_txt.Text,
                    StartDepreciation = start_depreciation_dtp.Value,
                    EndDepreciation = end_depreciation_dtp.Value,
                    CurrentDepreciation = double.Parse(current_depreciation_txt.Text),
                    MonthlyDepreciation = double.Parse(monthl_depreciation_txt.Text),
                    AccumDepreciation = double.Parse(accum_depreciation_txt.Text),
                    NetValue = double.Parse(net_value_txt.Text),
                    LocationId = ((LocationVo)this.location_cmb.SelectedItem).LocationId,
                    UserLocationId = ((UserLocationVo)this.user_location_name_cmb.SelectedItem).UserLocationId,
                    RegistrationDateTime = DateTime.Now,
                    FactoryCode = UserData.GetUserData().FactoryCode,
                    RegistrationUserCode = UserData.GetUserData().UserCode
                };
                try
                {
                    if (inVo.AcountMainId > 0)
                    {
                        outVo = (AccountMainVo)DefaultCbmInvoker.Invoke(new UpdateAccountMainCbm(), inVo);
                        //  outVo = (WareHouseVo)DefaultCbmInvoker.Invoke(new Cbm.AddWareHouseCbm(), inVo);

                    }
                    else
                    {
                        outVo = (AccountMainVo)DefaultCbmInvoker.Invoke(new AddAccountMainCbm(), inVo);

                    }
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }
                if (outVo.AffectedCount > 0)
                {
                    messageData = new MessageData("mmce00001", Properties.Resources.mmce00001, asset_code_lbl.Text + " : " + asset_code_txt.Text);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                    return;
                }

                unit_cmb.Text = "";
            }
        }

        private void user_location_code_txt_TextChanged(object sender, EventArgs e)
        {
            if ((user_location_code_txt.Text.Length == 13) || (user_location_code_txt.Text.Length == 10))
            {
                AccountMainVo inVo = new AccountMainVo()
                {
                    UserTem = user_location_code_txt.Text
                };
                ValueObjectList<UserLocationVo> userlocationvo = (ValueObjectList<UserLocationVo>)DefaultCbmInvoker.Invoke(new GetUserLocationCbm(), new UserLocationVo { UserLocationCode = inVo.UserTem });
                user_location_name_cmb.DisplayMember = "UserLocationName";
                user_location_name_cmb.DataSource = userlocationvo.GetList();
            }
            else
            {
                user_location_name_cmb.Text = "";
                user_location_name_cmb.SelectedItem = null;
            }
        }

        private void unit_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                callvaluecost(sender, e);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }
        }
       public string assetcodetrim = "";
        private void asset_code_txt_TextChanged(object sender, EventArgs e)
        {     
            if (accountmainVo.AcountMainId > 0)
            {

            }
            else
            {
              //  if (asset_code_txt.Text.Length >= 10)
                {
                    //assetcodetrim = asset_code_txt.Text.Substring(0, 10);
                    string str = asset_code_txt.Text;
                    string[] arrListStr = str.Split(',');
                    assetcodetrim = arrListStr[0];
                }
                ValueObjectList<AssetVo> assetmodelvo = (ValueObjectList<AssetVo>)DefaultCbmInvoker.Invoke(new GetAssetCbm(), new AssetVo { AssetNo = 10000, AssetCode = assetcodetrim });
                no_cbm.DisplayMember = "AssetNo";
                no_cbm.DataSource = assetmodelvo.GetList();
                no_cbm.Text = "";

            }
        }

        private void callvaluecost(object sender, EventArgs e)
        {
            //call asset model ok
            ValueObjectList<AssetVo> assetmodelvo = (ValueObjectList<AssetVo>)DefaultCbmInvoker.Invoke(new GetAssetCbm(), new AssetVo { AssetCode = assetcodetrim, AssetNo = int.Parse(no_cbm.Text) });

            asset_model_cmb.DisplayMember = "AssetModel";
            asset_model_cmb.DataSource = assetmodelvo.GetList();
            //life                    
            asset_life_cmb.DisplayMember = "AssetLife";
            asset_life_cmb.DataSource = assetmodelvo.GetList();
            //AcquistionCost                    
            acquisition_cost_cmb.DisplayMember = "AcquistionCost";
            acquisition_cost_cmb.DataSource = assetmodelvo.GetList();
            //call again datetime
            start_depreciation_dtp_CloseUp(sender, e);
            //call vaule
        }

        private void start_depreciation_dtp_CloseUp(object sender, EventArgs e)
        {
            DateTime dt = start_depreciation_dtp.Value.Date.AddMonths(int.Parse(asset_life_cmb.Text) * 12);
            end_depreciation_dtp.Value = dt.AddDays(-1);

            // WareHouseMainVo
            int YearNow = int.Parse(datetime_view_dtp.Value.ToString("yyyy"));
            int MonthNow = int.Parse(datetime_view_dtp.Value.ToString("MM"));
            int YearStart = int.Parse(start_depreciation_dtp.Value.ToString("yyyy"));
            int MonthStart = int.Parse(start_depreciation_dtp.Value.ToString("MM"));
            accountmainVo.MonthCounter = ((YearNow - YearStart) * 12) + (MonthNow - MonthStart);

            //callmonthly dep 
            double monthl_value = double.Parse(acquisition_cost_cmb.Text) / (double.Parse(asset_life_cmb.Text) * 12);
            monthl_depreciation_txt.Text = Math.Round(monthl_value, 3).ToString();

            //call current_depreciation_txt
            double current_depr = (accountmainVo.MonthCounter - 1) * monthl_value;
            current_depreciation_txt.Text = Math.Round(current_depr, 3).ToString();
            if (current_depr > double.Parse(acquisition_cost_cmb.Text))
            {
                current_depreciation_txt.Text = acquisition_cost_cmb.Text;
            }
            if (current_depr < 0)
            {
                current_depreciation_txt.Text = 0.ToString();
            }
            //call accum_depreciation_txt
            double accum_depr = accountmainVo.MonthCounter * monthl_value;
            accum_depreciation_txt.Text = Math.Round(accum_depr, 3).ToString();
            if (accum_depr > double.Parse(acquisition_cost_cmb.Text))
            {
                accum_depreciation_txt.Text = acquisition_cost_cmb.Text;
            }
            if (accum_depr < 0)
            {
                accum_depreciation_txt.Text = 0.ToString();
            }
            //call net_value_txt
            double net_value = (double.Parse(acquisition_cost_cmb.Text) - accum_depr);
            net_value_txt.Text = Math.Round(net_value, 3).ToString();
            if (net_value < 0)
            {
                net_value_txt.Text = 0.ToString();
            }
            if (net_value > double.Parse(acquisition_cost_cmb.Text))
            {
                net_value_txt.Text = acquisition_cost_cmb.Text;
            }
        }
        /*
        thuat toan
        A = acquisition_cost_cmb.Text
        B = current_depreciation_txt.Text
        C =  monthl_depreciation_txt.Text
        D = accum_depreciation_txt.Text
        E = net_value_txt.Text
        accountmainVo.MonthCounter = y nhu tren
        TL = asset_life_cmb.Text
        ==>
        C= A/(TL*12)
        B = accountmainVo.MonthCounter*c
        D = B+ C
        E = A -D
        */
        bool Checkdata()
        {
            if (user_location_code_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, UserCode_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                user_location_code_txt.Focus();
                return false;
            }
            if (asset_code_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, asset_code_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                asset_code_txt.Focus();
                return false;
            }
            if (rank_code_cmb.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, rank_code_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                rank_code_cmb.Focus();
                return false;
            }
            if (account_code_cmb.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, account_code_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                account_code_cmb.Focus();
                return false;
            }
            if (section_cd_cmb.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, section_cd_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                section_cd_cmb.Focus();
                return false;
            }
            if (location_cmb.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, location_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                location_cmb.Focus();
                return false;
            }
            if (unit_cmb.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, unit_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                unit_cmb.Focus();
                return false;
            }
            if (user_location_name_cmb.SelectedItem == null)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, user_location_name_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                user_location_name_cmb.Focus();
                return false;
            }
            if (qty_txt.Text.Trim().Length == 0)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, qty_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                qty_txt.Focus();
                return false;
            }
            if (end_depreciation_dtp.Value <= start_depreciation_dtp.Value)
            {
                messageData = new MessageData("mmcc00005", Properties.Resources.mmcc00005, end_depreciation_lbl.Text);
                popUpMessage.Warning(messageData, Text);
                end_depreciation_dtp.Focus();
                return false;
            }

            return true;
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }




    }
}
