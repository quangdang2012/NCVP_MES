using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Text;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class AddMoldDrawingDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldDrawingVo inVo = (MoldDrawingVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_gtrs_mold_drawing");
            sqlQuery.Append(" ( ");
            sqlQuery.Append("   mold_id, ");
            sqlQuery.Append("   drawing_no, ");
            sqlQuery.Append("   registration_user_cd, ");
            sqlQuery.Append("   registration_date_time, ");
            sqlQuery.Append("   factory_cd ) ");
            sqlQuery.Append(" values (");
            sqlQuery.Append("   :moldid , ");
            sqlQuery.Append("   :drawingno , ");
            sqlQuery.Append("   :registrationusercode , ");
            sqlQuery.Append("   :registrationdatetime , ");
            sqlQuery.Append("   :factorycode );  ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterInteger("moldid", inVo.MoldId);
            sqlParameter.AddParameterString("drawingno", inVo.DrawingNo);

            UserData userdata = trxContext.UserData;
            sqlParameter.AddParameterString("registrationusercode", userdata.UserCode);
            sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycode", userdata.FactoryCode);

            MoldDrawingVo outVo = new MoldDrawingVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo;
        }
    }
}
