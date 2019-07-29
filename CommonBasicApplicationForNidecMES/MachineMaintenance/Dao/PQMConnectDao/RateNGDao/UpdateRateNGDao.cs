using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class UpdateRateNGDao : AbstractDataAccessObject
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

            sql.Append("update m_rate_ng set rate_ng_cd = :rate_ng_cd, rate_ng_model=:rate_ng_model, rate_ng_line=:rate_ng_line , rate_ng_ratio = :rate_ng_ratio ");
            sql.Append("where rate_ng_id = :rate_ng_id ");

            sqlParameter.AddParameter("rate_ng_id", inVo.RatelId);
            sqlParameter.AddParameter("rate_ng_model", inVo.RateModel);
            sqlParameter.AddParameter("rate_ng_line", inVo.RateLine);
            sqlParameter.AddParameter("rate_ng_cd", inVo.RateCode);
            sqlParameter.AddParameter("rate_ng_ratio", inVo.RateRatio);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            voList = new RateNGVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter),
            };
            return voList;
        }
    }
}