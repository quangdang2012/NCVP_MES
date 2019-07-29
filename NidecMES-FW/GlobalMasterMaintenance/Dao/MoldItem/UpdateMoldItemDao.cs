using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class UpdateMoldItemDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldItemVo inVo = (MoldItemVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" Update m_mold_item");
            sqlQuery.Append(" Set std_cycle_time = :stdcycletime, ");
            sqlQuery.Append("     model_id = :modelid, ");
            sqlQuery.Append("     drawing_no = :drawingno ");
            sqlQuery.Append(" Where factory_cd = :factcode");
            sqlQuery.Append("   and mold_id = :moldid ");
            sqlQuery.Append("   and global_item_id = :globalitemid ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("moldid", inVo.MoldId);
            sqlParameter.AddParameterInteger("globalitemid", inVo.GlobalItemId);
            sqlParameter.AddParameterDecimal("stdcycletime", inVo.StdCycleTime);
            sqlParameter.AddParameterInteger("modelid", inVo.ModelId);
            sqlParameter.AddParameterString("drawingno", inVo.DrawingNo);
            
            
            sqlParameter.AddParameterString("factcode", trxContext.UserData.FactoryCode);

            MoldItemVo outVo = new MoldItemVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo;
        }
    }
}
