using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetRatioNGDao : AbstractDataAccessObject
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

            sql.Append("select count(*) from m_rate_ng where 1=1");
            if(!string.IsNullOrEmpty(inVo.RateCode))
            {
                sql.Append(" and rate_ng_cd = :rate_ng_cd ");
                sqlParameter.AddParameter("rate_ng_cd", inVo.RateCode);
            }
            if (!string.IsNullOrEmpty(inVo.RateModel))
            {
                sql.Append(" and rate_ng_model = :rate_ng_model ");
                sqlParameter.AddParameter("rate_ng_model", inVo.RateModel);
            }
            if (!string.IsNullOrEmpty(inVo.RateLine))
            {
                sql.Append(" and rate_ng_line = :rate_ng_line ");
                sqlParameter.AddParameter("rate_ng_line", inVo.RateLine);
            }

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            int a = int.Parse(sqlCommandAdapter.ExecuteScalar(sqlParameter).ToString());

            //execute SQL

            RateNGVo outVo1 = new RateNGVo
            {
               AffectedCount = a,
            };
            return outVo1;
        }
    }
}