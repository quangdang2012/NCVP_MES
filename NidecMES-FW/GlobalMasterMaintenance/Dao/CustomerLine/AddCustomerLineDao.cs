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
    public class AddCustomerLineDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            GroupMachineVo inVo = (GroupMachineVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into m_group_machine(group_machine_cd, group_machine_name, machine_id, registration_user_cd, registration_date_time, factory_cd) ");
            sql.Append("values(:group_machine_cd,:group_machine_name, :machine_id, :registration_user_cd,now(),:factory_cd)");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("group_machine_cd", inVo.GroupMachineCode);
            sqlParameter.AddParameterString("group_machine_name", inVo.GroupMachineName);
            sqlParameter.AddParameterInteger("machine_id", inVo.MachineId);
        
            sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            sqlParameter.AddParameterString("registration_user_cd", inVo.RegistrationUserCode);
            //execute SQL

            GroupMachineVo outVo = new GroupMachineVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
