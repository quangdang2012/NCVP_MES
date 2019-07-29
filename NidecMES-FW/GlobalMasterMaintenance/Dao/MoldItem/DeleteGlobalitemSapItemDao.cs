using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class DeleteGlobalitemSapItemDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldItemVo inVo = (MoldItemVo)arg;

            // Building SQL 
            StringBuilder sql = new StringBuilder();

            sql.Append("DELETE FROM m_gtrs_global_item_sap_item ");
            sql.Append(" WHERE global_item_sap_item_id=:globalitemsapitemid");
            sql.Append(" AND factory_cd=:factorycd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterInteger("globalitemsapitemid", inVo.GlobalLocalItemId);
            sqlParameter.AddParameterString("factorycd", trxContext.UserData.FactoryCode);

            //execute SQL

            MoldItemVo outVo = new MoldItemVo();
            outVo.AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter);

            return outVo;
        }
    }
}
