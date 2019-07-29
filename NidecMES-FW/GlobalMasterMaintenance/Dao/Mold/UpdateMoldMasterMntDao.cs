using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateMoldMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldVo inVo = (MoldVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_mold");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" mold_name = :moldname, ");
            sqlQuery.Append(" mold_type_id = :moldtypeid, ");
            sqlQuery.Append(" width = :width ,");
            sqlQuery.Append(" depth = :depth ,");
            sqlQuery.Append(" height = :height ,");
            sqlQuery.Append(" weight = :weight ,");
            sqlQuery.Append(" production_date_time = :pdt ,");
            sqlQuery.Append(" life_shot_count = :lfscount ,");
            sqlQuery.Append(" comment = :comment");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" mold_id = :moldid");
            sqlQuery.Append(" and factory_cd = :faccd;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("moldid", inVo.MoldId);
            sqlParameter.AddParameterString("moldname", inVo.MoldName);
            sqlParameter.AddParameterInteger("moldtypeid", inVo.MoldTypeId);
            sqlParameter.AddParameter("width", inVo.Width);
            sqlParameter.AddParameter("depth", inVo.Depth);
            sqlParameter.AddParameter("height", inVo.Height);
            sqlParameter.AddParameter("weight", inVo.Weight);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.ProductionDate != System.DateTime.MinValue)
            { sqlParameter.AddParameterDateTime("pdt", inVo.ProductionDate); }
            else { sqlParameter.AddParameter("pdt", System.DBNull.Value); }

            sqlParameter.AddParameter("lfscount", inVo.LifeShotCount);
            sqlParameter.AddParameterString("comment", inVo.Comment);

            MoldVo outVo = new MoldVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
