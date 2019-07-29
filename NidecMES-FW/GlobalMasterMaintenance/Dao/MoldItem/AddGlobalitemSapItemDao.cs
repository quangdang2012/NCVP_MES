using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class AddGlobalitemSapItemDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldItemVo inVo = (MoldItemVo)arg;

            // Building SQL 
            StringBuilder sql = new StringBuilder();

            sql.Append("Insert into m_gtrs_global_item_sap_item");
            sql.Append("(");
            sql.Append(" global_item_id,");
            sql.Append(" sap_item_cd,");
            sql.Append(" registration_user_cd,");
            sql.Append(" registration_date_time,");
            sql.Append(" factory_cd");
            sql.Append(") values (");
            sql.Append(" :globalitemid,");
            sql.Append(" :sapitemcd,");
            sql.Append(" :registrationusercd,");
            sql.Append(" :registrationdatetime,");
            sql.Append(" :factrycode ");
            sql.Append(" ) ");
            sql.Append("RETURNING global_item_sap_item_id;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterInteger("globalitemid", inVo.GlobalItemId);
            sqlParameter.AddParameterString("sapitemcd", inVo.LocalItemCode);
            sqlParameter.AddParameterString("registrationusercd", trxContext.UserData.UserCode);
            sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factrycode", trxContext.UserData.FactoryCode);

            //execute SQL
            int outId = (int?)sqlCommandAdapter.ExecuteScalar(sqlParameter) ?? 0;

            MoldItemVo outVo = null;
            if (outId > 0)
            {
                outVo = new MoldItemVo();
                outVo.GlobalLocalItemId = outId;
            }


            return outVo;
        }
    }
}
