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
    public class UpdateGroupMachineDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            GroupMachineVo inVo = (GroupMachineVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("update m_group_machine set group_machine_cd=:group_machine_cd,group_machine_name=:group_machine_name,machine_id=:machine_id");
            sql.Append(" where group_machine_id =:group_machine_id");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("group_machine_cd", inVo.GroupMachineCode);
            sqlParameter.AddParameterString("group_machine_name", inVo.GroupMachineName);
            sqlParameter.AddParameterInteger("group_machine_id", inVo.GroupMachineId);
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
