using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateEmployeeMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            EmployeeVo inVo = (EmployeeVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_employee");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" employee_name = :empname, ");
            sqlQuery.Append(" department = :department, ");
            sqlQuery.Append(" is_active = :isactive ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" employee_cd = :empcd ;");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("empname", inVo.EmployeeName);
            sqlParameter.AddParameterString("empcd", inVo.EmployeeCode);
            sqlParameter.AddParameterString("department", inVo.Department);
            sqlParameter.AddParameterInteger("isactive", inVo.IsActive);
            EmployeeVo outVo = new EmployeeVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
