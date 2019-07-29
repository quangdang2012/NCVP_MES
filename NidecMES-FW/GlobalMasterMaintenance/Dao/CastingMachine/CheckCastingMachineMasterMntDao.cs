using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class CheckCastingMachineMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            CastingMachineVo inVo = (CastingMachineVo)arg;

            CastingMachineVo outVo = new CastingMachineVo();

            StringBuilder sql = new StringBuilder();

            //create SQL
            sql.Append("Select Count(*) as CastMachCount from m_casting_machine ");
            sql.Append(" where factory_cd = :faccd ");

            if (inVo.CastingMachineCode != null)
            {
                sql.Append(" and UPPER(casting_machine_cd) = UPPER(:castcode)");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            if (inVo.CastingMachineCode != null)
            {
                sqlParameter.AddParameterString("castcode", inVo.CastingMachineCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            outVo.AffectedCount = 0;

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["CastMachCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
