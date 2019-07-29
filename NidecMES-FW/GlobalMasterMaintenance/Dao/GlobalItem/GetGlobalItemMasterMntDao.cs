using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetGlobalItemMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            GlobalItemVo inVo = (GlobalItemVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select gi.global_item_id, gi.global_item_cd, gi.global_item_name ");
            sqlQuery.Append(" from m_global_item gi ");
            sqlQuery.Append(" where gi.factory_cd = :faccd ");

            if (inVo.GlobalItemId > 0)
            {
                sqlQuery.Append(" AND gi.global_item_id = :globalitemid");
            }

            if (inVo.GlobalItemCode != null)
            {
                sqlQuery.Append(" and global_item_cd like :globalitemcd ");
            }

            if (inVo.GlobalItemName != null)
            {
                sqlQuery.Append(" and global_item_name like :globalitemname ");
            }

            sqlQuery.Append(" order by global_item_cd ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.GlobalItemId > 0)
            {
                sqlParameter.AddParameterInteger("globalitemid", inVo.GlobalItemId);
            }

            if (inVo.GlobalItemCode != null)
            {
                sqlParameter.AddParameterString("globalitemcd", inVo.GlobalItemCode + "%");
            }

            if (inVo.GlobalItemName != null)
            {
                sqlParameter.AddParameterString("globalitemname", inVo.GlobalItemName + "%");
            }         

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            GlobalItemVo outVo = new GlobalItemVo();

            while (dataReader.Read())
            {
                GlobalItemVo currOutVo = new GlobalItemVo();

                currOutVo.GlobalItemId = ConvertDBNull<Int32>(dataReader, "global_item_id");
                currOutVo.GlobalItemCode = ConvertDBNull<string>(dataReader, "global_item_cd");
                currOutVo.GlobalItemName = ConvertDBNull<string>(dataReader, "global_item_name");

                outVo.GlobalItemListVo.Add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
