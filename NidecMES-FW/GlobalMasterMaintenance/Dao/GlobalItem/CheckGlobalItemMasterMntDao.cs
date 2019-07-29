using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckGlobalItemMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            GlobalItemVo inVo = (GlobalItemVo)arg;         

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select Count(*) as ItemCount, global_item_id, global_item_cd from m_global_item ");

            sqlQuery.Append(" where factory_cd = :faccd ");

            if (inVo.GlobalItemCode != null)
            {
                sqlQuery.Append(" and UPPER(global_item_cd) = UPPER(:globalitemcd)");
            }

            sqlQuery.Append(" group by global_item_id, global_item_cd ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.GlobalItemCode != null)
            {
                sqlParameter.AddParameterString("globalitemcd", inVo.GlobalItemCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            GlobalItemVo outVo = new GlobalItemVo();

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["ItemCount"]);

                GlobalItemVo currOutVo = new GlobalItemVo();

                currOutVo.GlobalItemId = ConvertDBNull<Int32>(dataReader, "global_item_id");
                currOutVo.GlobalItemCode = ConvertDBNull<string>(dataReader, "global_item_cd");

                outVo.GlobalItemListVo.Add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
