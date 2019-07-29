using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetGlobalItemSapItemDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldItemVo inVo = (MoldItemVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select ");
            sqlQuery.Append(" sit.global_local_item_id");
            sqlQuery.Append(" from m_global_item_local_item sit");
            
            sqlQuery.Append(" where sit.factory_cd = :factorycode ");
            sqlQuery.Append(" and sit.sap_item_cd = :sapitemcd ");

            if (inVo.GlobalItemId > 0)
            {
                sqlQuery.Append(" and sit.global_item_id = :globalid ");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.GlobalItemId > 0)
            {
                sqlParameter.AddParameterInteger("globalid", inVo.GlobalItemId);
            }
            
            sqlParameter.AddParameterString("sapitemcd", inVo.LocalItemCode);
            sqlParameter.AddParameterString("factorycode", trxContext.UserData.FactoryCode);

          
            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<MoldItemVo> outVo = null;

            while (dataReader.Read())
            {
                MoldItemVo currVo = new MoldItemVo
                {
                    GlobalLocalItemId = ConvertDBNull<int>(dataReader, "global_local_item_id"),
                };

                if (outVo == null)
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
