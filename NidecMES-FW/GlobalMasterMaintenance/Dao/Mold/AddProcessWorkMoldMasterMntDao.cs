using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddProcessWorkMoldMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessWorkMoldVo inVo = (ProcessWorkMoldVo)arg;
            ProcessWorkMoldVo outVo = new ProcessWorkMoldVo();

            // Building SQL 
            StringBuilder sql = new StringBuilder();

            sql.Append("Insert into m_gtrs_process_work_mold");
            sql.Append("(");
            sql.Append(" process_work_id,");
            sql.Append(" mold_id,");
            sql.Append(" registration_user_cd,");
            sql.Append(" registration_date_time,");
            sql.Append(" factory_cd ");
            sql.Append(") values (");
            sql.Append(" :processworkid,");
            sql.Append(" :moldid,");
            sql.Append(" :registrationusercd,");
            sql.Append(" :registrationdatetime,");
            sql.Append(" :factrycode ");
            sql.Append(" ); ");
            
                //create command
                DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

                //create parameter
                DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

                sqlParameter.AddParameterInteger("processworkid", inVo.ProcessWorkId);
                sqlParameter.AddParameterInteger("moldid", inVo.MoldId);
                sqlParameter.AddParameterString("registrationusercd", UserData.GetUserData().UserCode);
                sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
                sqlParameter.AddParameterString("factrycode", UserData.GetUserData().FactoryCode);

                //outVo.ProcessWorkMoldId = (int?)sqlCommandAdapter.ExecuteScalar(sqlParameter) ?? 0;
                outVo.AffectedCount += sqlCommandAdapter.ExecuteNonQuery(sqlParameter);
            
            return outVo;

        }
    }
}
