using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class CheckRankDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            RankVo inVo = (RankVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("Select Count(*) as RankCount ");
            sql.Append(" from  m_rank");
            sql.Append(" Where 1=1 ");
    
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (!string.IsNullOrEmpty(inVo.RankCode))
            {
                sql.Append(" and UPPER(rank_cd) = UPPER(:rank_cd) ");
                sqlParameter.AddParameterString("rank_cd", inVo.RankCode);
            }
            if (inVo.RankId > 0)
            {
                sql.Append(" and rank_id != :rank_id "); ///?????
                sqlParameter.AddParameterInteger("rank_id", inVo.RankId);
            }
          

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            RankVo outVo = new RankVo();
            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["RankCount"].ToString());
            }
            dataReader.Close();
            return outVo;
        }
    }
}
