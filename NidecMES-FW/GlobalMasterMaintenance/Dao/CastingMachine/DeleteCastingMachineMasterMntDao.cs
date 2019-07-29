using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class DeleteCastingMachineMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            CastingMachineVo inVo = (CastingMachineVo)arg;

            CastingMachineVo outVo = new CastingMachineVo();

            StringBuilder sql = new StringBuilder();

            sql.Append("Delete from m_casting_machine");
            sql.Append(" where ");
            sql.Append(" casting_machine_id = :castid ");
            sql.Append(" and factory_cd = :faccd ;");
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterInteger("castid", inVo.CastingMachineId);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            outVo.AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter);

            return outVo;
        }
        
    }
}
