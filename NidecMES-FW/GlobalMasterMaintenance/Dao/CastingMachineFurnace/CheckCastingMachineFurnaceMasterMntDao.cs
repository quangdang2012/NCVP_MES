using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;


namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class CheckCastingMachineFurnaceMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            CastingMachineFurnaceVo inVo = (CastingMachineFurnaceVo)arg;

            CastingMachineFurnaceVo outVo = new CastingMachineFurnaceVo();

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("select Count(*) as CastFurCode from m_casting_machine_furnace ");
            sqlQuery.Append(" where factory_cd = :faccd ");

            if (inVo.CastingMachineFurnaceCode != null)
            {
                sqlQuery.Append(" and UPPER(casting_machine_furnace_cd) = UPPER(:castfurcode)");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            if (inVo.CastingMachineFurnaceCode != null)
            {
                sqlParameter.AddParameterString("castfurcode", inVo.CastingMachineFurnaceCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            outVo.AffectedCount = 0;

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["CastFurCode"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
