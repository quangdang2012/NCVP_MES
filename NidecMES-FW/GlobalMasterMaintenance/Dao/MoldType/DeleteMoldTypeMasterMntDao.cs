using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteMoldTypeMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldTypeVo inVo = (MoldTypeVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete From m_mold_type");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" mold_type_id = :moldtypeid ");
            sqlQuery.Append(" and factory_cd = :faccd ;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("moldtypeid", inVo.MoldTypeId);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            MoldTypeVo outVo = new MoldTypeVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
