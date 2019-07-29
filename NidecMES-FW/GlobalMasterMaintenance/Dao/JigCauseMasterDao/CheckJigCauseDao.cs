using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckJigCauseDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            JigCauseVo inVo = (JigCauseVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("Select Count(*) as JigCauseCount ");
            sql.Append(" from  public.m_jig_cause");
            sql.Append(" Where 1=1 ");
    
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (!string.IsNullOrEmpty(inVo.JigCauseCode))
            {
                sql.Append(" and UPPER(jig_cause_cd) = UPPER(:jig_cause_cd) ");
                sqlParameter.AddParameterString("jig_cause_cd", inVo.JigCauseCode);
            }
            if (inVo.JigCauseId > 0)
            {
                sql.Append(" and jig_cause_id != :jig_cause_id "); ///?????
                sqlParameter.AddParameterInteger("jig_cause_id", inVo.JigCauseId);
            }
          

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            JigCauseVo outVo = new JigCauseVo();
            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["JigCauseCount"].ToString());
            }
            dataReader.Close();
            return outVo;
        }
    }
}
