using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class AddMoldItemDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldItemVo inVo = (MoldItemVo)arg;
            MoldItemVo outVo = new MoldItemVo();

            // Building SQL 
            StringBuilder sql = new StringBuilder();

            sql.Append("Insert into m_mold_item");
            sql.Append("(");
            sql.Append(" mold_id,");
            sql.Append(" global_item_id,");
            sql.Append(" std_cycle_time,");
            sql.Append(" model_id,");
            sql.Append(" drawing_no,");
            sql.Append(" registration_user_cd,");
            sql.Append(" registration_date_time,");
            sql.Append(" factory_cd");
            sql.Append(") values (");
            sql.Append(" :moldid,");
            sql.Append(" :globalitemid,");
            sql.Append(" :stdcycletime,");
            sql.Append(" :modelid,");
            sql.Append(" :drawingno,");
            sql.Append(" :registrationusercd,");
            sql.Append(" :registrationdatetime,");
            sql.Append(" :factrycode ");
            sql.Append(" ) ");
            sql.Append("RETURNING mold_item_id;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("moldid", inVo.MoldId);
            sqlParameter.AddParameterInteger("globalitemid", inVo.GlobalItemId);
            sqlParameter.AddParameterDecimal("stdcycletime", inVo.StdCycleTime);
            sqlParameter.AddParameterInteger("modelid", inVo.ModelId);
            sqlParameter.AddParameterString("drawingno", inVo.DrawingNo);
            sqlParameter.AddParameterString("registrationusercd", trxContext.UserData.UserCode);
            sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factrycode", trxContext.UserData.FactoryCode);

            outVo.AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter);

            return outVo;
        }
    }
}
