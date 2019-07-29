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
    public class GetSapItemForMESItemDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldItemVo inVo = (MoldItemVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("SELECT ");
            sqlQuery.Append("   si.sap_matnr_item_cd, ");
            sqlQuery.Append("   si.sap_maktx_item_name, ");
            sqlQuery.Append("   gi.global_item_id ");
            sqlQuery.Append(" FROM v_sap_item si");
            sqlQuery.Append(" inner join m_global_item gi on gi.global_item_cd = si.sap_matnr_item_cd ");
            sqlQuery.Append(" WHERE gi.factory_cd = :factorycode  ORDER BY si.sap_matnr_item_cd ");
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("factorycode", trxContext.UserData.FactoryCode);
            //execute SQL
            ValueObjectList<MoldItemVo> outVo = null;

            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                MoldItemVo currVo = new MoldItemVo();
                currVo.GlobalItemId = ConvertDBNull<int>(dataReader, "global_item_id");
                currVo.GlobalItemCode = ConvertDBNull<string>(dataReader, "sap_matnr_item_cd");
                currVo.GlobalItemName = ConvertDBNull<string>(dataReader, "sap_maktx_item_name");
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
