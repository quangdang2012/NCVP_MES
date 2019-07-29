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
    public class GetJigCauseDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            JigCauseVo inVo = (JigCauseVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<JigCauseVo> voList = new ValueObjectList<JigCauseVo>();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select jig_cause_id,jig_cause_cd,jig_cause_name, registration_user_cd,registration_date_time,factory_cd from public.m_jig_cause");
            sql.Append(" Where 1=1 ");
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
            //DbCommandAdaptor 
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                JigCauseVo outVo = new JigCauseVo
                {
                    JigCauseCode = dataReader["jig_cause_cd"].ToString(),
                    JigCauseId = int.Parse(dataReader["jig_cause_id"].ToString()),
                    JigCauseName = dataReader["jig_cause_name"].ToString(),

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
