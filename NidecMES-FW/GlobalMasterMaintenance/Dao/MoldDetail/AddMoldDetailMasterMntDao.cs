using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddMoldDetailMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldDetailVo inVo = (MoldDetailVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_mold_detail");
            sqlQuery.Append(" ( ");
            sqlQuery.Append("   mold_id, ");
            sqlQuery.Append("   mold_category_id, ");
            sqlQuery.Append("   life_alarm_shot_count, ");
            sqlQuery.Append("   periodic_mnt_alarm_shot_count1, ");
            sqlQuery.Append("   periodic_mnt_alarm_shot_count2, ");
            sqlQuery.Append("   periodic_mnt_alarm_shot_count3, ");
            sqlQuery.Append("   registration_user_cd, ");
            sqlQuery.Append("   registration_date_time, ");
            sqlQuery.Append("   factory_cd ) ");
            sqlQuery.Append(" values (");
            sqlQuery.Append("   :moldid , ");
            sqlQuery.Append("   :moldcategoryid , ");
            sqlQuery.Append("   :lfacount , ");
            sqlQuery.Append("   :pascount1 , ");
            sqlQuery.Append("   :pascount2 , ");
            sqlQuery.Append("   :pascount3 , ");
            sqlQuery.Append("   :registrationusercode , ");
            sqlQuery.Append("   :registrationdatetime , ");
            sqlQuery.Append("   :factorycode );  ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterInteger("moldid", inVo.MoldId);
            sqlParameter.AddParameter("moldcategoryid", inVo.MoldCategoryId);
            sqlParameter.AddParameter("lfacount", inVo.LifeAlarmShotCount);
            sqlParameter.AddParameter("pascount1", inVo.PeriodicAlarmShotCount1);
            sqlParameter.AddParameter("pascount2", inVo.PeriodicAlarmShotCount2);
            sqlParameter.AddParameter("pascount3", inVo.PeriodicAlarmShotCount3);

            UserData userdata = trxContext.UserData;
            sqlParameter.AddParameterString("registrationusercode", userdata.UserCode);
            sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycode", userdata.FactoryCode);

            MoldDetailVo outVo = new MoldDetailVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo;
        }
    }
}
