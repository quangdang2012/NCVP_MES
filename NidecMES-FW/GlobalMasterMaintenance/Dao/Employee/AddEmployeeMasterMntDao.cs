using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddEmployeeMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            EmployeeVo inVo = (EmployeeVo)arg;

            StringBuilder sqlQuery = new StringBuilder();


            sqlQuery.Append("Insert into m_employee");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" employee_cd, ");
            sqlQuery.Append(" employee_name, ");
            sqlQuery.Append(" department, ");
            sqlQuery.Append(" is_active, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :empcd ,");
            sqlQuery.Append(" :empname ,");
            sqlQuery.Append(" :department ,");
            sqlQuery.Append(" :isactive ,");
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" :registrationdatetime ,");
            sqlQuery.Append(" :factorycode ");
            sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("empcd", inVo.EmployeeCode);
            sqlParameter.AddParameterString("empname", inVo.EmployeeName);
            sqlParameter.AddParameterString("department", inVo.Department);
            sqlParameter.AddParameterInteger("isactive", inVo.IsActive);
            sqlParameter.AddParameterString("registrationusercode", inVo.RegistrationUserCode);
            sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycode", inVo.FactoryCode);

            EmployeeVo outVo = new EmployeeVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
