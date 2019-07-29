using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class CheckInvertoryTimeDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            InvertoryVo inVo = (InvertoryVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("Select Count(*) as InvertoryCount ");
            sql.Append(" from  m_invertory_time");
            sql.Append(" Where 1=1 ");
    
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (!string.IsNullOrEmpty(inVo.InvertoryTimeCode))
            {
                sql.Append(" and UPPER(invertory_time_cd) = UPPER(:invertory_time_cd) ");
                sqlParameter.AddParameterString("invertory_time_cd", inVo.InvertoryTimeCode);
            }
            if (inVo.InvertoryTimeId > 0)
            {
                sql.Append(" and invertory_time_id != :invertory_time_id "); ///?????
                sqlParameter.AddParameterInteger("invertory_time_id", inVo.InvertoryTimeId);
            }
          

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            InvertoryVo outVo = new InvertoryVo();
            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["InvertoryCount"].ToString());
            }
            dataReader.Close();
            return outVo;
        }
    }
}
