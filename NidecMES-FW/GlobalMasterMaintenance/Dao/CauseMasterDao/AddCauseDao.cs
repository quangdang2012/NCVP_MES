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
    public class AddCauseDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            CauseVo inVo = (CauseVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into m_cause(machine_id,defective_reason_id,registration_user_cd,registration_date_time,factory_cd) ");
            sql.Append("values");
            sql.Append("    (");
            sql.Append("    :machine_id,");
            sql.Append("    :defective_reason_id,");
            sql.Append("    :registrationusercode,");
            sql.Append("    :registrationdatetime,");
            sql.Append("    :factorycode ");
            sql.Append("    ) ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            //
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("machine_id", inVo.MachineID);
            sqlParameter.AddParameterInteger("defective_reason_id", inVo.DefectiveID);

            sqlParameter.AddParameterString("registrationusercode", UserData.GetUserData().UserCode);
            sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycode", UserData.GetUserData().FactoryCode);

            //execute SQL

            CauseVo outVo = new CauseVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
