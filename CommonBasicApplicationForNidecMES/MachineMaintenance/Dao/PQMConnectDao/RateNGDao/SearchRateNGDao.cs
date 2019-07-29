using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchRateNGDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            RateNGVo inVo = (RateNGVo)vo;
            StringBuilder sql = new StringBuilder();
            RateNGVo voList = new RateNGVo();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sql.Append("select rate_ng_id, rate_ng_model,rate_ng_line,rate_ng_cd, rate_ng_ratio from m_rate_ng where 1=1");
            if(!string.IsNullOrEmpty(inVo.RateCode))
            {
                sql.Append(" and rate_ng_cd = :rate_ng_cd ");
                sqlParameter.AddParameter("rate_ng_cd", inVo.RateCode);
            }

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DataSet ds = sqlCommandAdapter.ExecuteDataSet(sqlParameter);

            //execute SQL

            RateNGVo outVo1 = new RateNGVo
            {
               dt = ds.Tables[0],
            };
            return outVo1;
        }
    }
}