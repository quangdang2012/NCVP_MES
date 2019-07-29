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
    public class GetJigResponseDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            JigResponseVo inVo = (JigResponseVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<JigResponseVo> voList = new ValueObjectList<JigResponseVo>();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select jig_response_id,jig_response_cd,jig_response_name, registration_user_cd,registration_date_time,factory_cd from m_jig_response");
            sql.Append(" Where 1=1 ");
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (inVo.JigResponseId > 0)
            {
                sql.Append(" and jig_response_id = :jig_response_id ");
                sqlParameter.AddParameterInteger("jig_response_id", inVo.JigResponseId);
            }
            if (!string.IsNullOrEmpty(inVo.JigResponseCode))
            {
                sql.Append(" and jig_response_cd = :jig_response_cd ");
                sqlParameter.AddParameterString("jig_response_cd", inVo.JigResponseCode);
            }
            if (!string.IsNullOrEmpty(inVo.JigResponseName))
            {
                sql.Append(" and jig_response_name = :jig_response_name ");
                sqlParameter.AddParameterString("jig_response_name", inVo.JigResponseName);
            }
           

            //create command
            //DbCommandAdaptor 
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                JigResponseVo outVo = new JigResponseVo
                {
                    JigResponseCode = dataReader["jig_response_cd"].ToString(),
                    JigResponseId = int.Parse(dataReader["jig_response_id"].ToString()),
                    JigResponseName = dataReader["jig_response_name"].ToString(),

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
