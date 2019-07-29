using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetMoldTypeMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldTypeVo inVo = (MoldTypeVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select mt.mold_type_id, mt.mold_type_cd, mt.mold_type_name, li.item_id, li.item_cd ");
            sqlQuery.Append("from m_mold_type mt ");
            sqlQuery.Append("inner join m_local_item li on  li.item_id = mt.item_id ");
            sqlQuery.Append(" where mt.factory_cd = :faccd ");

            if (inVo.MoldTypeCode != null)
            {
                sqlQuery.Append(" and mt.mold_type_cd like :moldtypecd ");
            }

            if (inVo.MoldTypeName != null)
            {
                sqlQuery.Append(" and mt.mold_type_name like :moldtypename ");
            }

            if (inVo.ItemId != 0)
            {
                sqlQuery.Append(" and mt.item_id = :itemid ");
            }

            sqlQuery.Append(" order by mt.mold_type_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.MoldTypeCode != null)
            {
                sqlParameter.AddParameterString("moldtypecd", inVo.MoldTypeCode + "%");
            }

            if (inVo.MoldTypeName != null)
            {
                sqlParameter.AddParameterString("moldtypename", inVo.MoldTypeName + "%");
            }
            if (inVo.ItemId != 0)
            {
                sqlParameter.AddParameterInteger("itemid", inVo.ItemId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            MoldTypeVo outVo = new MoldTypeVo();

            while (dataReader.Read())
            {
                MoldTypeVo currOutVo = new MoldTypeVo
                {
                    MoldTypeId = Convert.ToInt32(dataReader["mold_type_id"]),
                    MoldTypeCode = dataReader["mold_type_cd"].ToString(),
                    MoldTypeName = dataReader["mold_type_name"].ToString(),
                    ItemId = Convert.ToInt32(dataReader["item_id"]),
                    ItemCode = dataReader["item_cd"].ToString()
                };
               outVo.MoldTypeListVo.Add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
