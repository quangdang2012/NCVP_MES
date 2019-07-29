using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateMoldTypeMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldTypeVo inVo = (MoldTypeVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_mold_type");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" mold_type_name = :moldtypename, ");
            sqlQuery.Append(" item_id = :itemid ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" mold_type_id = :moldtypeid ");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterInteger("moldtypeid", inVo.MoldTypeId);
            sqlParameter.AddParameterString("moldtypename", inVo.MoldTypeName);
            sqlParameter.AddParameterInteger("itemid", inVo.ItemId);

            MoldTypeVo outVo = new MoldTypeVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
