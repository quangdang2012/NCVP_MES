using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
   public class GetMoldbyItemDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldItemVo inVo = (MoldItemVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select");
            sqlQuery.Append("   mo.mold_id,");
            sqlQuery.Append("   mo.mold_name, ");
            sqlQuery.Append("   gi.global_item_cd, ");
            sqlQuery.Append("   gmi.std_cycle_time ");
            sqlQuery.Append(" from m_mold mo ");
            sqlQuery.Append(" inner join m_mold_item gmi on gmi.mold_id = mo.mold_id ");
            sqlQuery.Append(" inner join m_global_local_item gli on gli.global_item_id = gmi.global_item_id ");
            sqlQuery.Append(" inner join m_global_item  gi on gi.global_item_id = gli.global_item_id ");
            sqlQuery.Append(" inner join m_local_item li on li.item_id = gli.local_item_id  ");
            sqlQuery.Append(" where gmi.factory_cd = :factorycode ");
            sqlQuery.Append("       and gi.global_item_cd = :sapitemcd ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
                     
            sqlParameter.AddParameterString("sapitemcd", inVo.GlobalItemCode);    
            sqlParameter.AddParameterString("factorycode", trxContext.UserData.FactoryCode);

            // sqlQuery.Append(" order by gi.global_item_id ");
            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<MoldItemVo> outVo = null;

            while (dataReader.Read())
            {
                MoldItemVo currVo = new MoldItemVo
                {
                    MoldId = ConvertDBNull<int>(dataReader, "mold_id"),
                    MoldName = ConvertDBNull<string>(dataReader,"mold_name"),
                    GlobalItemCode = ConvertDBNull<string>(dataReader, "global_item_cd"),
                    StdCycleTime = ConvertDBNull<decimal>(dataReader, "std_cycle_time")
                };
                
                if(outVo == null)
                {
                    outVo = new ValueObjectList<MoldItemVo>();
                }
                outVo.add(currVo);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
