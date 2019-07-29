using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetEmployeeWithoutLikeSearchMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            EmployeeVo inVo = (EmployeeVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select em.employee_cd, em.employee_name, em.department, em.is_active ");
            sqlQuery.Append(" from m_employee em ");
            sqlQuery.Append(" where em.factory_cd = :fact ");

            if (inVo.EmployeeCode != null)
            {
                sqlQuery.Append(" and employee_cd = :empcd ");
            }

            if (inVo.EmployeeName != null)
            {
                sqlQuery.Append(" and employee_name like :empname ");
            }

            sqlQuery.Append(" order by em.employee_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("fact", trxContext.UserData.FactoryCode);
            sqlParameter.AddParameterString("empcd", inVo.EmployeeCode );

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            EmployeeVo outVo = new EmployeeVo();

            while (dataReader.Read())
            {
                EmployeeVo currOutVo = new EmployeeVo();

                currOutVo.EmployeeCode = ConvertDBNull<string>(dataReader, "employee_cd");
                currOutVo.EmployeeName = ConvertDBNull<string>(dataReader, "employee_name");
                currOutVo.Department = ConvertDBNull<string>(dataReader, "department");
                currOutVo.IsActive = ConvertDBNull<int>(dataReader, "is_active");

                outVo.EmployeeListVo.Add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
