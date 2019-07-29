using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class TotalRankDEPAccountMainDao : AbstractDataAccessObject
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

            sql.Append(@"select * from (
select tam.rank_name as Account_Name,sum(tam.acquistion_cost) as Total_AcquisitionCose,sum(tam.current_depreciation) as Total_CurrentDepreication,
        sum(tam.monthly_depreciation) as Total_MonthlyDepreication,sum(tam.accum_depreciation_now) as Total_AccumDepreication,sum(tam.net_value) as Total_NetBook
 from (select a.account_code_name, f.rank_name,g.account_main_id,c.location_cd,e.asset_cd, e.asset_no, e.asset_name, e.asset_model, e.asset_serial, e.asset_supplier, 
 g.qty, a.account_code_cd, b.account_location_cd, f.rank_cd, b.account_location_name, g.comment_data, e.asset_life, e.acquistion_date, e.acquistion_cost, 
 g.depreciation_start, g.depreciation_end, g.current_depreciation,g.monthly_depreciation, g.accum_depreciation_now, g.net_value, e.asset_invoice, 
 g.registration_date_time, g.registration_user_cd from t_account_main g
                           left join m_account_code a on a.account_code_id = g.account_code_id
                           left join m_account_location b on b.account_location_id = g.account_location_id
                            left join m_location c on c.location_id = g.location_id
                            left join m_user_location d on d.user_location_id = g.user_location_id
                            left join m_asset e on e.asset_id = g.asset_id
                            left join m_rank f on f.rank_id = g.rank_id) tam group by tam.rank_name 

                        union
                            select Case when sum(tam.acquistion_cost) > -1 then 'Total' else 'Total'
	end codename,  sum(tam.acquistion_cost) as Total_AcquisitionCose,sum(tam.current_depreciation) as Total_CurrentDepreication,
        sum(tam.monthly_depreciation) as Total_MonthlyDepreication,sum(tam.accum_depreciation_now) as Total_AccumDepreication,sum(tam.net_value) as Total_NetBook
 from (select a.account_code_name, f.rank_name,g.account_main_id,c.location_cd,e.asset_cd, e.asset_no, e.asset_name, e.asset_model, e.asset_serial, e.asset_supplier, 
 g.qty, a.account_code_cd, b.account_location_cd, f.rank_cd, b.account_location_name, g.comment_data, e.asset_life, e.acquistion_date, e.acquistion_cost, 
 g.depreciation_start, g.depreciation_end, g.current_depreciation,g.monthly_depreciation, g.accum_depreciation_now, g.net_value, e.asset_invoice, 
 g.registration_date_time, g.registration_user_cd from t_account_main g
                           left join m_account_code a on a.account_code_id = g.account_code_id
                           left join m_account_location b on b.account_location_id = g.account_location_id
                            left join m_location c on c.location_id = g.location_id
                            left join m_user_location d on d.user_location_id = g.user_location_id
                            left join m_asset e on e.asset_id = g.asset_id
                            left join m_rank f on f.rank_id = g.rank_id) tam ) tbl order by account_name = 'Total'
");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());


            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                AccountMainVo outVo = new AccountMainVo
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
