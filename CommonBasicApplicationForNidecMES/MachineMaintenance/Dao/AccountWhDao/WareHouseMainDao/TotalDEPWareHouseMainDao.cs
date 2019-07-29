using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class TotalDEPWareHouseMainDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            WareHouseMainVo inVo = (WareHouseMainVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<WareHouseMainVo> voList = new ValueObjectList<WareHouseMainVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sql.Append(@"select * from (
select tam.account_code_name as Account_Name,sum(tam.acquistion_cost) as Total_AcquisitionCose,sum(tam.current_depreciation) as Total_CurrentDepreication,sum(tam.monthly_depreciation) as Total_MonthlyDepreication,sum(tam.accum_depreciation_now) 
as Total_AccumDepreication,sum(tam.net_value) as Total_NetBook from (select a.account_code_name, g.warehouse_main_id,
e.asset_cd, e.asset_no, e.asset_name, e.asset_model, e.asset_serial, e.asset_supplier, g.qty, a.account_code_cd, b.account_location_cd,
 f.rank_cd, b.account_location_name, g.comment_data, e.asset_life, e.acquistion_date, e.acquistion_cost, g.depreciation_start, g.depreciation_end,
 g.current_depreciation,g.monthly_depreciation, g.accum_depreciation_now, g.net_value, e.asset_invoice, g.registration_date_time, g.registration_user_cd from t_warehouse_main g
                           left join m_account_code a on a.account_code_id = g.account_code_id
                           left join m_account_location b on b.account_location_id = g.account_location_id
                            left join m_location c on c.location_id = g.before_location_id
                            left join m_user_location d on d.user_location_id = g.user_location_id
                            left join m_asset e on e.asset_id = g.asset_id
                            left join m_rank f on f.rank_id = g.rank_id) tam group by tam.account_code_name 
        union 
select 
	Case when sum(tbl.Total_AcquisitionCose) > -1 then 'Total'
	else 'Total'
	end codename,
	sum(tbl.Total_AcquisitionCose),sum(tbl.Total_CurrentDepreication), sum(tbl.Total_MonthlyDepreication), sum(tbl.Total_AccumDepreication), sum(tbl.Total_NetBook) from 
(select tam.account_code_name as Account_Name,sum(tam.acquistion_cost) as Total_AcquisitionCose,sum(tam.current_depreciation) as Total_CurrentDepreication,sum(tam.monthly_depreciation) as Total_MonthlyDepreication,sum(tam.accum_depreciation_now) 
as Total_AccumDepreication,sum(tam.net_value) as Total_NetBook from (select a.account_code_name, g.warehouse_main_id,
e.asset_cd, e.asset_no, e.asset_name, e.asset_model, e.asset_serial, e.asset_supplier, g.qty, a.account_code_cd, b.account_location_cd,
 f.rank_cd, b.account_location_name, g.comment_data, e.asset_life, e.acquistion_date, e.acquistion_cost, g.depreciation_start, g.depreciation_end,
 g.current_depreciation,g.monthly_depreciation, g.accum_depreciation_now, g.net_value, e.asset_invoice, g.registration_date_time, g.registration_user_cd from t_warehouse_main g
                           left join m_account_code a on a.account_code_id = g.account_code_id
                           left join m_account_location b on b.account_location_id = g.account_location_id
                            left join m_location c on c.location_id = g.before_location_id
                            left join m_user_location d on d.user_location_id = g.user_location_id
                            left join m_asset e on e.asset_id = g.asset_id
                            left join m_rank f on f.rank_id = g.rank_id) tam group by tam.account_code_name) tbl ) tbltotal order by tbltotal.account_name = 'Total'
        ");
           
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());


            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                WareHouseMainVo outVo = new WareHouseMainVo
                {
                    //  , h., i., k., o.prodution_work_content_name


                    TotalAccumDepreication = double.Parse(dataReader["Total_AccumDepreication"].ToString()),
                    TotalAcquisitionCose = double.Parse(dataReader["Total_AcquisitionCose"].ToString()),
                    TotalCurrentDepreication = double.Parse(dataReader["Total_CurrentDepreication"].ToString()),
                    TotalMonthlyDepreication = double.Parse(dataReader["Total_MonthlyDepreication"].ToString()),
                    TotalNetBook = double.Parse(dataReader["Total_NetBook"].ToString()),
                    AccountCodeName = dataReader["Account_Name"].ToString(),
                   

                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }

    }
}
