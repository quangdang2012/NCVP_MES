using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetSapItemMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            SapItemSearchVo inVo = (SapItemSearchVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("SELECT ");
            sqlQuery.Append("   si.sap_matnr_item_cd, ");
            sqlQuery.Append("   CONCAT(si.sap_matnr_item_cd, ' - ', si.sap_maktx_item_name) as sap_maktx_item_name");
            sqlQuery.Append(" FROM sap_item si");
            sqlQuery.Append(" WHERE si.factory_cd = :factorycode  ORDER BY si.sap_matnr_item_cd ");
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("factorycode", trxContext.UserData.FactoryCode);
            //execute SQL
            ValueObjectList<SapItemSearchVo> outVo = null;

            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                SapItemSearchVo currVo = new SapItemSearchVo();
                currVo.SapItemCode = ConvertDBNull<string>(dataReader, "sap_matnr_item_cd");
                currVo.SapItemName = ConvertDBNull<string>(dataReader, "sap_maktx_item_name");
                if (outVo == null)
                {
                    outVo = new ValueObjectList<SapItemSearchVo>();
                }

                outVo.add(currVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
