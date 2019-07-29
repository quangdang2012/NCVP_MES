using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckGlobalLocalItemMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            GlobalLocalItemVo inVo = (GlobalLocalItemVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select gl.global_local_item_id ");
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

            ValueObjectList<GlobalLocalItemVo> outVo = null;

            while (dataReader.Read())
            {
                GlobalLocalItemVo currOutVo = new GlobalLocalItemVo();

                currOutVo.GlobalLocalItemId = ConvertDBNull<Int32>(dataReader, "global_local_item_id");

                if (outVo == null)
                {
                    outVo = new ValueObjectList<GlobalLocalItemVo>();
                }

                outVo.add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
