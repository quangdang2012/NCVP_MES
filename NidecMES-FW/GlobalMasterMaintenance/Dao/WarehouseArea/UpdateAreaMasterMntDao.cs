using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateAreaMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            AreaVo inVo = (AreaVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_area");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" area_name = :areaname, ");
            sqlQuery.Append(" location_id = :locationid ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" area_id = :areaid ;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("areaid", inVo.AreaId);
            sqlParameter.AddParameterString("areaname", inVo.AreaName);
            sqlParameter.AddParameterInteger("locationid", inVo.LocationId);

            AreaVo outVo = new AreaVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }

  


    }
}
