using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddLocalSupplierMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LocalSupplierVo inVo = (LocalSupplierVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_local_supplier");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" local_supplier_cd, ");
            sqlQuery.Append(" local_supplier_name, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :localsuppliercd ,");
            sqlQuery.Append(" :localsuppliername ,");
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" now() ,");
            sqlQuery.Append(" :factorycode ");
            sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("localsuppliercd", inVo.LocalSupplierCode);
            sqlParameter.AddParameterString("localsuppliername", inVo.LocalSupplierName);
            sqlParameter.AddParameterString("registrationusercode", inVo.RegistrationUserCode);
            //sqlParameter.AddParameterDateTime("registrationdatetime", inVo.RegistrationDateTime);
            sqlParameter.AddParameterString("factorycode", inVo.FactoryCode);

            LocalSupplierVo outVo = new LocalSupplierVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
