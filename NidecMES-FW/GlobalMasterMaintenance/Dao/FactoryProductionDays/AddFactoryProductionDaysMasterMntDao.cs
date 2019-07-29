using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddFactoryProductionDaysMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            FactoryProductionDaysVo inVo = (FactoryProductionDaysVo)arg;
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" INSERT ");
            sqlQuery.Append("  INTO m_factory_production_days ");
            sqlQuery.Append("  ( ");
            sqlQuery.Append("   year, ");
            sqlQuery.Append("   month, ");
            sqlQuery.Append("   days, ");
            sqlQuery.Append("   building_id, ");
            sqlQuery.Append("   registration_user_cd, ");
            sqlQuery.Append("   registration_date_time, ");
            sqlQuery.Append("   factory_cd ");
            sqlQuery.Append("  ) ");
            sqlQuery.Append(" VALUES ");
            sqlQuery.Append("  ( ");
            sqlQuery.Append("   :iyear, ");
            sqlQuery.Append("   :imonth, ");
            sqlQuery.Append("   :idays, ");
            sqlQuery.Append("   :buildingid, ");
            sqlQuery.Append("   :registrationusercd, ");
            sqlQuery.Append("   now(), ");
            sqlQuery.Append("   :factorycode ");
            sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterInteger("iyear", inVo.iYear);
            sqlParameter.AddParameterInteger("imonth", inVo.iMonth);
            sqlParameter.AddParameterInteger("idays", inVo.iDays);
            sqlParameter.AddParameterInteger("buildingid", inVo.BuildingId);
            sqlParameter.AddParameterString("registrationusercd", inVo.RegistrationUserCode);
            sqlParameter.AddParameterString("factorycode", inVo.FactoryCode);

            FactoryProductionDaysVo outVo = new FactoryProductionDaysVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
