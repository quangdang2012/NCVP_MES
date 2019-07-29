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
    public class CheckJigResponseDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            JigResponseVo inVo = (JigResponseVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("Select Count(*) as JigResponseCount ");
            sql.Append(" from  public.m_jig_response");
            sql.Append(" Where 1=1 ");
    
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (!string.IsNullOrEmpty(inVo.JigResponseCode))
            {
                sql.Append(" and UPPER(jig_response_cd) = UPPER(:jig_response_cd) ");
                sqlParameter.AddParameterString("jig_response_cd", inVo.JigResponseCode);
            }
            if (inVo.JigResponseId > 0)
            {
                sql.Append(" and jig_response_id != :jig_response_id "); ///?????
                sqlParameter.AddParameterInteger("jig_response_id", inVo.JigResponseId);
            }
          

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            JigResponseVo outVo = new JigResponseVo();
            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["JigResponseCount"].ToString());
            }
            dataReader.Close();
            return outVo;
        }
    }
}
