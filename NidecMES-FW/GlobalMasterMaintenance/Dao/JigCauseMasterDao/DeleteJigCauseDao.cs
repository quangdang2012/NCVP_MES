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
    public class DeleteJigCauseDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            JigCauseVo inVo = (JigCauseVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("delete from  public.m_jig_cause Where 1=1 ");
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (inVo.JigCauseId > 0)
            {
                sql.Append(" and jig_cause_id = :jig_cause_id ");
                sqlParameter.AddParameterInteger("jig_cause_id", inVo.JigCauseId);
            }
            if (!string.IsNullOrEmpty(inVo.JigCauseCode))
            {
                sql.Append(" and jig_cause_cd = :jig_cause_cd ");
                sqlParameter.AddParameterString("jig_cause_cd", inVo.JigCauseCode);
            }
            if (!string.IsNullOrEmpty(inVo.JigCauseName))
            {
                sql.Append(" and jig_cause_name = :jig_cause_name ");
                sqlParameter.AddParameterString("jig_cause_name", inVo.JigCauseName);
            }

            //create command
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL

            JigCauseVo outVo = new JigCauseVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
