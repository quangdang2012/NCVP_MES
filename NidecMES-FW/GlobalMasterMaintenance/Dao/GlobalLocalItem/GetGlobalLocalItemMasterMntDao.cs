using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetGlobalLocalItemMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            GlobalLocalItemVo inVo = (GlobalLocalItemVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select gl.global_local_item_id, gl.global_item_id, gl.local_item_id ");
            sqlQuery.Append(" from m_global_local_item gl ");
            sqlQuery.Append(" where gl.factory_cd = :faccd ");

            if (inVo.GlobalItemId > 0)
            {
                sqlQuery.Append(" and gl.global_item_id = :globalitemid ");
            }

            if (inVo.LocalItemId > 0)
            {
                sqlQuery.Append(" and gl.local_item_id = :localitemid ");
            }

            sqlQuery.Append(" order by gl.global_local_item_id ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.GlobalItemId > 0)
            {
                sqlParameter.AddParameterInteger("globalitemid", inVo.GlobalItemId);
            }

            if (inVo.LocalItemId > 0)
            {
                sqlParameter.AddParameterInteger("localitemid", inVo.LocalItemId);
            }         

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            GlobalLocalItemVo outVo = new GlobalLocalItemVo();

            while (dataReader.Read())
            {
                GlobalLocalItemVo currOutVo = new GlobalLocalItemVo();

                currOutVo.GlobalLocalItemId = ConvertDBNull<Int32>(dataReader, "global_local_item_id");
                currOutVo.GlobalItemId = ConvertDBNull<Int32>(dataReader, "global_item_id");
                currOutVo.LocalItemId = ConvertDBNull<Int32>(dataReader, "local_item_id");

                outVo.GlobalLocalItemListVo.Add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
