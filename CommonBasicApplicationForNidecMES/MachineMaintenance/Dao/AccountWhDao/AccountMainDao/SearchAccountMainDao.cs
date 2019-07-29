using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchAccountMainDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AccountMainVo inVo = (AccountMainVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<AccountMainVo> voList = new ValueObjectList<AccountMainVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sql.Append(@"select m.invertory_time_cd,  m.invertory_time_id, k.unit_name, d.user_location_name,g.account_main_id,c.location_cd,e.asset_cd, e.asset_no, e.asset_name, e.asset_model, e.asset_serial, e.asset_supplier,e.asset_po, g.qty, a.account_code_cd, b.account_location_cd, f.rank_cd, b.account_location_name, g.comment_data, e.asset_life, e.acquistion_date, e.acquistion_cost, e.asset_type, g.depreciation_start, g.depreciation_end, g.current_depreciation,g.monthly_depreciation, g.accum_depreciation_now, g.net_value, e.asset_invoice, g.registration_date_time, g.registration_user_cd, e.label_status from t_account_main g
                           left join m_account_code a on a.account_code_id = g.account_code_id
                           left join m_account_location b on b.account_location_id = g.account_location_id
                            left join m_location c on c.location_id = g.location_id
                            left join m_user_location d on d.user_location_id = g.user_location_id
                            left join m_asset e on e.asset_id = g.asset_id
                            left join m_rank f on f.rank_id = g.rank_id
                            left join m_unit k on k.unit_id = g.unit_id
                             left join t_warehouse_main u on u.asset_id = g.asset_id
                            left join t_invertory_equipments l on l.warehouse_main_id = u.warehouse_main_id
                            left join m_invertory_time m on m.invertory_time_id = l.invertory_time_id
                      where 1=1  ");
  

            if (!String.IsNullOrEmpty(inVo.AssetCode))
            {
                sql.Append(@" and   e.asset_cd  =:asset_cd");
                sqlParameter.AddParameterString("asset_cd", inVo.AssetCode);
            }
            if (!String.IsNullOrEmpty(inVo.RankCode))
            {
                sql.Append(" and f.rank_cd  =:rank_cd");
                sqlParameter.AddParameterString("rank_cd", inVo.RankCode);
            }

            if (!String.IsNullOrEmpty(inVo.AssetModel))
            {
                sql.Append(" and e.asset_model =:asset_model");
                sqlParameter.AddParameterString("asset_model", inVo.AssetModel);
            }
            if (!String.IsNullOrEmpty(inVo.AssetName))
            {
                sql.Append(" and e.asset_name =:asset_name");
                sqlParameter.AddParameterString("asset_name", inVo.AssetName);
            }
            if (!String.IsNullOrEmpty(inVo.AssetType))
            {
                sql.Append(" and e.asset_type =:asset_type");
                sqlParameter.AddParameterString("asset_type", inVo.AssetType);
            }
            if (!String.IsNullOrEmpty(inVo.AssetInvoice))
            {
                sql.Append(" and e.asset_invoice =:asset_invoice");
                sqlParameter.AddParameterString("asset_invoice", inVo.AssetInvoice);
            }
            if (!String.IsNullOrEmpty(inVo.LocationCode))
            {
                sql.Append(" and c.location_cd =:location_cd");
                sqlParameter.AddParameterString("location_cd", inVo.LocationCode);
            }
            if (!String.IsNullOrEmpty(inVo.AccountCodeCode))
            {
                sql.Append(" and a.account_code_cd =:account_code_cd");
                sqlParameter.AddParameterString("account_code_cd", inVo.AccountCodeCode);
            }
            if (!String.IsNullOrEmpty(inVo.AccountLocationCode))
            {
                sql.Append(" and b.account_location_cd =:account_location_cd");
                sqlParameter.AddParameterString("account_location_cd", inVo.AccountLocationCode);
            }
            if (!String.IsNullOrEmpty(inVo.LabelStatus))//label status
            {
                sql.Append(" and e.label_status =:label_status");
                sqlParameter.AddParameterString("label_status", inVo.LabelStatus);
            }
            if (!String.IsNullOrEmpty(inVo.AssetPO))//label status
            {
                sql.Append(" and e.asset_po =:asset_po");
                sqlParameter.AddParameterString("asset_po", inVo.AssetPO);
            }
            if (!String.IsNullOrEmpty(inVo.Net_Value))//search theo net value
            {
                if (inVo.Net_Value == "0$")
                {
                    sql.Append(" and g.net_value = 0");
                }
                else if (inVo.Net_Value == "1$")
                {
                    sql.Append(" and g.net_value > 0 and g.net_value <2 ");
                }
            }
            sql.Append(" and l.invertory_equipments_id in (select max(invertory_equipments_id) from t_invertory_equipments group by warehouse_main_id) ");
            sql.Append(" order by  g.registration_date_time desc");
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());


            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                AccountMainVo outVo = new AccountMainVo
                {
                    //  , h., i., k., o.prodution_work_content_name
                    AcountMainId = int.Parse(dataReader["account_main_id"].ToString()),
                    LocationCode = dataReader["location_cd"].ToString(),
                    AssetCode = dataReader["asset_cd"].ToString(),
                    AssetNo = int.Parse(dataReader["asset_no"].ToString()),
                    AssetName = dataReader["asset_name"].ToString(),
                    AssetModel = dataReader["asset_model"].ToString(),
                    AssetSerial = dataReader["asset_serial"].ToString(),
                    AssetSupplier = dataReader["asset_supplier"].ToString(),
                    QTY = int.Parse(dataReader["qty"].ToString()),
                    UnitName = dataReader["unit_name"].ToString(),
                    UserLocationName = dataReader["user_location_name"].ToString(),
                    AccountCodeCode = dataReader["account_code_cd"].ToString(),
                    AccountLocationCode = dataReader["account_location_cd"].ToString(),
                    RankCode = dataReader["rank_cd"].ToString(),
                    AccountLocationName = dataReader["account_location_name"].ToString(),
                    CommnetsData = dataReader["comment_data"].ToString(),
                    AssetLife = int.Parse(dataReader["asset_life"].ToString()),
                    AcquisitionDate = DateTime.Parse(dataReader["acquistion_date"].ToString()),
                    AcquisitionCost = double.Parse(dataReader["acquistion_cost"].ToString()),
                    StartDepreciation = DateTime.Parse(dataReader["depreciation_start"].ToString()),
                    EndDepreciation = DateTime.Parse(dataReader["depreciation_end"].ToString()),
                    CurrentDepreciation = double.Parse(dataReader["current_depreciation"].ToString()),
                    MonthlyDepreciation = double.Parse(dataReader["monthly_depreciation"].ToString()),
                    AccumDepreciation = double.Parse(dataReader["accum_depreciation_now"].ToString()),
                    NetValue = double.Parse(dataReader["net_value"].ToString()),
                    AssetInvoice = (dataReader["asset_invoice"].ToString()),
                    AssetType = dataReader["asset_type"].ToString(),
                    LabelStatus = (dataReader["label_status"].ToString()),
                    AssetPO = dataReader["asset_po"].ToString(),
                    Invertory = dataReader["invertory_time_cd"].ToString(),
                    InvertoryId = int.Parse(dataReader["invertory_time_id"].ToString()),
                    RegistrationDateTime = DateTime.Parse(dataReader["registration_date_time"].ToString()),
                    RegistrationUserCode = (dataReader["registration_user_cd"].ToString()),
                    

                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }

    }
}
