using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class DeleteRankDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            RankVo inVo = (RankVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("delete from  m_rank Where 1=1 ");
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (inVo.RankId > 0)
            {
                sql.Append(" and rank_id = :rank_id ");
                sqlParameter.AddParameterInteger("rank_id", inVo.RankId);
            }
            if (!string.IsNullOrEmpty(inVo.RankCode))
            {
                sql.Append(" and rank_cd = :rank_cd ");
                sqlParameter.AddParameterString("rank_cd", inVo.RankCode);
            }
            if (!string.IsNullOrEmpty(inVo.RankName))
            {
                sql.Append(" and rank_name = :rank_name ");
                sqlParameter.AddParameterString("rank_name", inVo.RankName);
            }

           

            //create command
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());


            //execute SQL

            RankVo outVo = new RankVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
