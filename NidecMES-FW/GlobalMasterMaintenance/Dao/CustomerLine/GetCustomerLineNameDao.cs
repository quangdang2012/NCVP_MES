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
    public class GetCustomerLineNameDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            GroupMachineVo inVo = (GroupMachineVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<GroupMachineVo> voList = new ValueObjectList<GroupMachineVo>();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"select a.group_machine_cd, a.group_machine_name, b.machine_name,
a.registration_user_cd,a.registration_date_time,a.factory_cd from m_group_machine a
left join m_machine b on b.machine_id = a.machine_id");
            sql.Append(" Where 1=1");

            if (!String.IsNullOrEmpty(inVo.GroupMachineCode))
            {
                sql.Append(" and group_machine_cd = :group_machine_cd ");
                sqlParameter.AddParameterString("group_machine_cd", inVo.GroupMachineCode);
            }

            if (!String.IsNullOrEmpty(inVo.GroupMachineName))
            {
                sql.Append(" and group_machine_name = :group_machine_name ");
                sqlParameter.AddParameterString("group_machine_name", inVo.GroupMachineName);
            }

            if (!String.IsNullOrEmpty(inVo.MachineName))
            {
                sql.Append(" and machine_name = :machine_name ");
                sqlParameter.AddParameterString("machine_name", inVo.MachineName);
            }


            //create command
            //DbCommandAdaptor 
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                GroupMachineVo outVo = new GroupMachineVo
                {
                    // GroupMachineCode = dataReader["group_machine_cd"].ToString(),
                    GroupMachineName = dataReader["group_machine_name"].ToString(),

                    // RegistrationUserCode = dataReader["registration_user_cd"].ToString(),
                    //RegistrationDateTime = DateTime.Parse(dataReader["registration_date_time"].ToString()),
                    // FactoryCode = dataReader["factory_cd"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
