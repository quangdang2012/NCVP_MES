using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetAccountMainIdDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AccountMainVo inVo = (AccountMainVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList < AccountMainVo> voList = new ValueObjectList<AccountMainVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sql.Append(@"select g.account_main_id from t_account_main g
                      left join m_asset e on e.asset_id = g.asset_id
                      where 1=1 ");


            if (!String.IsNullOrEmpty(inVo.AssetCode))
            {
                sql.Append(@" and e.asset_cd  =:asset_cd");
                sqlParameter.AddParameterString("asset_cd", inVo.AssetCode);
            }
          
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());


            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                AccountMainVo outVo = new AccountMainVo
                {
                    //  , h., i., k., o.prodution_work_content_name
                    AcountMainId = int.Parse(dataReader["account_main_id"].ToString()),
                };
                voList.add(outVo);
            }
          
            dataReader.Close();
            return voList;
        }

    }
}
