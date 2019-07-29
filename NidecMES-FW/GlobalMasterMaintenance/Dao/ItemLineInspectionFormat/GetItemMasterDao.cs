using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetItemMasterDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ItemVo inVo = (ItemVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select li.item_id, li.item_cd, li.item_name,li.unit_type, ");
            sqlQuery.Append(" CASE li.unit_type WHEN '1' THEN 'Weight'");
            sqlQuery.Append(" WHEN '0' THEN 'Count' End as unittype_value ");
            sqlQuery.Append("from m_local_item li ");
            sqlQuery.Append(" where li.factory_cd = :faccd ");

            if (inVo.ItemCode != null)
            {
                sqlQuery.Append(" and item_cd like :itemcd ");
            }

            if (inVo.ItemName != null)
            {
                sqlQuery.Append(" and item_name like :itemname ");
            }

            sqlQuery.Append(" order by item_cd ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (!string.IsNullOrEmpty(inVo.FactoryCode))
            {
                sqlParameter.AddParameterString("faccd", inVo.FactoryCode);
            }
            else
            {
                sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            }
            

            if (inVo.ItemCode != null)
            {
                sqlParameter.AddParameterString("itemcd", inVo.ItemCode + "%");
            }

            if (inVo.ItemName != null)
            {
                sqlParameter.AddParameterString("itemname", inVo.ItemName + "%");
            }         

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<ItemVo> outVo = null;

            while (dataReader.Read())

            {
                ItemVo currOutVo = new ItemVo();
                currOutVo.ItemId = ConvertDBNull<Int32>(dataReader, "item_id");
                currOutVo.ItemCode = ConvertDBNull<string>(dataReader, "item_cd");
                currOutVo.ItemName = ConvertDBNull<string>(dataReader, "item_name");
                currOutVo.UnitType = ConvertDBNull<Int32>(dataReader, "unit_type");
                currOutVo.UnitType_Display = ConvertDBNull<string>(dataReader, "unittype_value");
                
                if (outVo == null)
                {
                    outVo = new ValueObjectList<ItemVo>();
                }
                outVo.add(currOutVo);
            }
            dataReader.Close();
            
            return outVo;
        }
    }
}
