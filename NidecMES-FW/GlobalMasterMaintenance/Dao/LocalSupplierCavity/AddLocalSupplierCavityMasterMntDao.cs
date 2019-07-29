using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddLocalSupplierCavityMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LocalSupplierCavityVo inVo = (LocalSupplierCavityVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" INSERT INTO m_local_supplier_cavity ");
            sqlQuery.Append("  ( ");
            sqlQuery.Append("  cavity_cd, ");
            sqlQuery.Append("  cavity_name, ");
            sqlQuery.Append("  local_supplier_id, ");
            sqlQuery.Append("  item_id, ");
            sqlQuery.Append("  registration_user_cd, ");
            sqlQuery.Append("  registration_date_time, ");
            sqlQuery.Append("  factory_cd ");
            sqlQuery.Append("  ) ");
            sqlQuery.Append(" VALUES ");
            sqlQuery.Append("  ( ");
            sqlQuery.Append("  :cavitycd, ");
            sqlQuery.Append("  :cavityname, ");
            sqlQuery.Append("  :localsupplierid, ");
            sqlQuery.Append("  :itemid, ");
            sqlQuery.Append("  :registrationusercode, ");
            sqlQuery.Append("  now(), ");
            sqlQuery.Append("  :factorycode ");
            sqlQuery.Append("  ) ; ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("cavitycd", inVo.LocalSupplierCavityCode);
            sqlParameter.AddParameterString("cavityname", inVo.LocalSupplierCavityName);
            sqlParameter.AddParameterInteger("localsupplierid", inVo.LocalSupplierId);
            sqlParameter.AddParameterInteger("itemid", inVo.ItemId);
            sqlParameter.AddParameterString("registrationusercode", inVo.RegistrationUserCode);
            sqlParameter.AddParameterString("factorycode", inVo.FactoryCode);

            LocalSupplierCavityVo outVo = new LocalSupplierCavityVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
