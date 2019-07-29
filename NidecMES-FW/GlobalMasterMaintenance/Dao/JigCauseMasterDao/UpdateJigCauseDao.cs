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
    public class UpdateJigCauseDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            JigCauseVo inVo = (JigCauseVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("update public.m_jig_cause set jig_cause_cd=:jig_cause_cd,jig_cause_name=:jig_cause_name");
            sql.Append(" where jig_cause_id =:jig_cause_id");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("jig_cause_cd", inVo.JigCauseCode);
            sqlParameter.AddParameterString("jig_cause_name", inVo.JigCauseName);
            sqlParameter.AddParameterInteger("jig_cause_id", inVo.JigCauseId);
           

            sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            sqlParameter.AddParameterString("registration_user_cd", inVo.RegistrationUserCode);
            //execute SQL

            JigCauseVo outVo = new JigCauseVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
