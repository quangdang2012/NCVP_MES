using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddFactoryMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            // arguments from Factory form
            FactoryVo inVo = (FactoryVo)arg;

            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Clear();
            sqlQuery.Append("insert into m_factory");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" factory_cd, ");
            sqlQuery.Append(" factory_name, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :factcd,");
            sqlQuery.Append(" :factnm,");
            sqlQuery.Append(" :regusercd,");
            sqlQuery.Append(" now()");
            sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("factcd", inVo.FactoryCode);
            sqlParameter.AddParameterString("factnm", inVo.FactoryName);
            sqlParameter.AddParameterString("regusercd", inVo.RegistrationUserCode);
            //sqlParameter.AddParameterDateTime("regdt ", inVo.RegistrationDateTime);

            FactoryVo outVo = new FactoryVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
