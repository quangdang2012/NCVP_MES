using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddGetMoldIdMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldVo inVo = (MoldVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_mold");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" mold_cd, ");
            sqlQuery.Append(" mold_name, ");
            sqlQuery.Append(" mold_type_id, ");
            sqlQuery.Append(" width , depth , height , weight , ");
            sqlQuery.Append(" production_date_time , life_shot_count, ");
            sqlQuery.Append(" comment, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :moldcd ,");
            sqlQuery.Append(" :moldname ,");
            sqlQuery.Append(" :moldtypeid ,");
            sqlQuery.Append(" :width , :depth , :height , :weight, ");
            sqlQuery.Append(" :pdt, :lfscount ,");
            sqlQuery.Append(" :comment ,");
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" now() ,");
            sqlQuery.Append(" :factorycode ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append(" RETURNING mold_id ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("moldcd", inVo.MoldCode);
            sqlParameter.AddParameterString("moldname", inVo.MoldName);
            sqlParameter.AddParameterInteger("moldtypeid", inVo.MoldTypeId);
            sqlParameter.AddParameter("width", inVo.Width);
            sqlParameter.AddParameter("depth", inVo.Depth);
            sqlParameter.AddParameter("height", inVo.Height);
            sqlParameter.AddParameter("weight", inVo.Weight);

            if (inVo.ProductionDate != System.DateTime.MinValue)
            { sqlParameter.AddParameterDateTime("pdt", inVo.ProductionDate); }
            else { sqlParameter.AddParameter("pdt", System.DBNull.Value); }

            sqlParameter.AddParameter("lfscount", inVo.LifeShotCount);
            sqlParameter.AddParameter("comment", inVo.Comment);

            sqlParameter.AddParameterString("registrationusercode", UserData.GetUserData().UserCode);
           sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycode", UserData.GetUserData().FactoryCode);

            MoldVo outVo = new MoldVo();// {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            outVo.MoldId = (int?)sqlCommandAdapter.ExecuteScalar(sqlParameter) ?? 0;

            if (outVo != null && outVo.MoldId > 0)
            {
                outVo.AffectedCount = 1;
            }

            return outVo;

        }
    }
}
