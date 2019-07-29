using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class GetRankDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            RankVo inVo = (RankVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<RankVo> voList = new ValueObjectList<RankVo>();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select rank_id, rank_cd, rank_name, registration_user_cd,registration_date_time,factory_cd from  m_rank");
            sql.Append(" Where 1=1 ");
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
            //DbCommandAdaptor 
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                RankVo outVo = new RankVo
                {
                    RankCode = dataReader["rank_cd"].ToString(),
                    RankId = int.Parse(dataReader["rank_id"].ToString()),
                    RankName =dataReader["rank_name"].ToString(),

                    RegistrationUserCode = dataReader["registration_user_cd"].ToString(),
                    RegistrationDateTime = DateTime.Parse(dataReader["registration_date_time"].ToString()),
                    FactoryCode = dataReader["factory_cd"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
