using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class DeleteAndAddMoldItemDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldItemVo inVo = (MoldItemVo)arg;
            MoldItemVo outVo = new MoldItemVo();

            /// Delete sql
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" Delete From m_mold_item");
            sqlQuery.Append(" Where	global_item_id = :globalitemid ");
            sqlQuery.Append(" and factory_cd = :factorycode ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterInteger("globalitemid", inVo.GlobalItemId);

            sqlParameter.AddParameterString("factorycode", trxContext.UserData.FactoryCode);

            MoldItemVo moldItemOutVo = new MoldItemVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            // Building SQL 
            StringBuilder sql = new StringBuilder();

            sql.Append("Insert into m_mold_item");
            sql.Append("(");
            sql.Append(" mold_id,");
            sql.Append(" global_item_sap_item_id,");
            sql.Append(" std_cycle_time,");
            sql.Append(" registration_user_cd,");
            sql.Append(" registration_date_time,");
            sql.Append(" factory_cd");
            sql.Append(") values (");
            sql.Append(" :moldid,");
            sql.Append(" :globalitemsapitemid,");
            sql.Append(" :stdcycletime,");
            sql.Append(" :registrationusercd,");
            sql.Append(" :registrationdatetime,");
            sql.Append(" :factrycode ");
            sql.Append(" ) ");
            sql.Append("RETURNING mold_item_id;");

            foreach (MoldItemVo curVo in inVo.MoldItemListVo)
            {
                //create command
                sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

                //create parameter
                sqlParameter = sqlCommandAdapter.CreateParameterList();
                sqlParameter.AddParameterInteger("moldid", curVo.MoldId);
                sqlParameter.AddParameterInteger("globalitemsapitemid", inVo.GlobalLocalItemId);
                sqlParameter.AddParameterDecimal("stdcycletime", curVo.StdCycleTime);
                sqlParameter.AddParameterString("registrationusercd", trxContext.UserData.UserCode);
                sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
                sqlParameter.AddParameterString("factrycode", trxContext.UserData.FactoryCode);

                //outVo.AffectedCount = (int?)sqlCommandAdapter.ExecuteScalar(sqlParameter) ?? 0;
                outVo.AffectedCount += sqlCommandAdapter.ExecuteNonQuery(sqlParameter);
            }

            return outVo;
        }
    }
}
