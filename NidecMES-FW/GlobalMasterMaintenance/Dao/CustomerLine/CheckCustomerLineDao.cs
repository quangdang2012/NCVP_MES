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
    public class CheckCustomerLineDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            GroupMachineVo inVo = (GroupMachineVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("Select Count(*) as GroupMachineCount ");
            sql.Append(" from m_group_machine");
            sql.Append(" Where 1=1 ");
    
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (!string.IsNullOrEmpty(inVo.GroupMachineCode))
            {
                sql.Append(" and UPPER(group_machine_cd) = UPPER(:group_machine_cd) ");
                sqlParameter.AddParameterString("group_machine_cd", inVo.GroupMachineCode);
            }
            if (inVo.GroupMachineId > 0)
            {
                sql.Append(" and group_machine_id != :group_machine_id ");
                sqlParameter.AddParameterInteger("group_machine_id", inVo.GroupMachineId);
            }
          

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            GroupMachineVo outVo = new GroupMachineVo();
            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["GroupMachineCount"].ToString());
            }
            dataReader.Close();
            return outVo;
        }
    }
}
