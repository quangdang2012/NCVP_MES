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
    public class UpdateJigResponseDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            JigResponseVo inVo = (JigResponseVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("update public.m_jig_response set jig_response_cd=:jig_response_cd,jig_response_name=:jig_response_name");
            sql.Append(" where jig_response_id =:jig_response_id");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("jig_response_cd", inVo.JigResponseCode);
            sqlParameter.AddParameterString("jig_response_name", inVo.JigResponseName);
            sqlParameter.AddParameterInteger("jig_response_id", inVo.JigResponseId);
           

            sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            sqlParameter.AddParameterString("registration_user_cd", inVo.RegistrationUserCode);
            //execute SQL

            JigResponseVo outVo = new JigResponseVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
