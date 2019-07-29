using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class DeleteRateNGDao : AbstractDataAccessObject
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

            sql.Append("delete from m_rate_ng where 1=1");
            if (inVo.RatelId > 0)
            {
                sql.Append(" and rate_ng_id = :rate_ng_id");
                sqlParameter.AddParameter("rate_ng_id", inVo.RatelId);
            }
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