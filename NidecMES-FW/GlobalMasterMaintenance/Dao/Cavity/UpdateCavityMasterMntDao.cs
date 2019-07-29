using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateCavityMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            CavityVo inVo = (CavityVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_cavity");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" cavity_name = :cavityname, ");
            sqlQuery.Append(" mold_id = :moldid ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" cavity_id = :cavityid ");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("cavityid", inVo.CavityId);
            sqlParameter.AddParameterString("cavityname", inVo.CavityName);
            sqlParameter.AddParameterInteger("moldid", inVo.MoldId);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            CavityVo outVo = new CavityVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }

  


    }
}
