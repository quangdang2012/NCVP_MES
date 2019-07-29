using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateMoldDetailMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldDetailVo inVo = (MoldDetailVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_mold_detail");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" mold_category_id = :moldcategoryid, ");
            sqlQuery.Append(" life_alarm_shot_count = :lfacount ,");
            sqlQuery.Append(" periodic_mnt_alarm_shot_count1 = :pascount1 ,");
            sqlQuery.Append(" periodic_mnt_alarm_shot_count2 = :pascount2 , ");
            sqlQuery.Append(" periodic_mnt_alarm_shot_count3 = :pascount3 ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" mold_id = :moldid;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("moldid", inVo.MoldId);
            sqlParameter.AddParameterInteger("moldcategoryid", inVo.MoldCategoryId);
            sqlParameter.AddParameter("lfacount", inVo.LifeAlarmShotCount);
            sqlParameter.AddParameter("pascount1", inVo.PeriodicAlarmShotCount1);
            sqlParameter.AddParameter("pascount2", inVo.PeriodicAlarmShotCount2);
            sqlParameter.AddParameter("pascount3", inVo.PeriodicAlarmShotCount3);

            MoldDetailVo outVo = new MoldDetailVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }

  


    }
}
