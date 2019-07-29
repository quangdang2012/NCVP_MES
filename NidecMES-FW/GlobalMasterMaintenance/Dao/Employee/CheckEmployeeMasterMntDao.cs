using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckEmployeeMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            EmployeeVo inVo = (EmployeeVo)arg;
       
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select Count(*) as EmpCount from m_employee ");
            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.EmployeeCode != null)
            {
                sqlQuery.Append(" and UPPER(employee_cd) = UPPER(:empcd)");
            }
                        
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.EmployeeCode != null)
            {
                sqlParameter.AddParameterString("empcd", inVo.EmployeeCode);
            }
            
            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            EmployeeVo outVo = new EmployeeVo();

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["EmpCount"]);
            }

            dataReader.Close();

            return outVo;
        } 
    }
}
