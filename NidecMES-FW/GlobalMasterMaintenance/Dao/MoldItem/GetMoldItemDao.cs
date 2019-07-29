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
    public class GetMoldItemDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldItemVo inVo = (MoldItemVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append(" select mo.mold_id, mo.mold_cd, mo.mold_name,gi.global_item_id, gi.global_item_cd, mi.std_cycle_time, si.sap_maktx_item_name ");
            sqlQuery.Append(" from m_mold mo ");
            sqlQuery.Append(" inner join m_mold_detail md on mo.mold_id = md.mold_id ");
            sqlQuery.Append(" inner join m_mold_item mi on mi.mold_id = mo.mold_id ");
            sqlQuery.Append(" inner join m_global_item gi on gi.global_item_id = mi.global_item_id ");
            sqlQuery.Append(" left join v_sap_item si on gi.global_item_cd = si.sap_matnr_item_cd ");
            sqlQuery.Append(" where mo.factory_cd = :factorycode ");

            if (inVo.MoldId > 0)
            {
                sqlQuery.Append("       and mo.mold_id = :moldid ");
            }
            if (inVo.GlobalItemId > 0)
            {
                sqlQuery.Append("       and gi.global_item_id = :globalitemid ");
            }
            sqlQuery.Append(" order by mo.mold_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterInteger("moldid", inVo.MoldId);
            sqlParameter.AddParameterInteger("globalitemid", inVo.GlobalItemId);
            sqlParameter.AddParameterString("factorycode", trxContext.UserData.FactoryCode);

            //sqlQuery.Append(" order by gi.global_item_id ");
            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<MoldItemVo> MoldItemListVo = null;

            while (dataReader.Read())
            {
                MoldItemVo currVo = new MoldItemVo
                {
                    MoldId = ConvertDBNull<int>(dataReader, "mold_id"),
                    MoldCode = ConvertDBNull<string>(dataReader, "mold_cd"),
                    MoldName = ConvertDBNull<string>(dataReader, "mold_name"),
                    GlobalItemId = ConvertDBNull<int>(dataReader, "global_item_id"),
                    GlobalItemCode = ConvertDBNull<string>(dataReader, "global_item_cd"),
                    GlobalItemName = ConvertDBNull<string>(dataReader, "sap_maktx_item_name"),
                    StdCycleTime = ConvertDBNull<decimal>(dataReader, "std_cycle_time")
                };

                if (MoldItemListVo == null)
                {
                    MoldItemListVo = new ValueObjectList<MoldItemVo>();
                }
                MoldItemListVo.add(currVo);
            }

            dataReader.Close();

            return MoldItemListVo;
        }
    }
}
