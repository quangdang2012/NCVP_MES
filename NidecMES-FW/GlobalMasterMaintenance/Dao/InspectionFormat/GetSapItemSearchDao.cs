using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetSapItemSearchDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            SapItemSearchVo inVo = (SapItemSearchVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("SELECT ");
            sqlQuery.Append("   si.sap_matnr_item_cd, ");
            sqlQuery.Append("   si.sap_maktx_item_name, ");
            sqlQuery.Append("   si.sap_matkl_material_grp_id");
            sqlQuery.Append(" FROM sap_item si");
            sqlQuery.Append(" WHERE si.factory_cd = :factorycode ");

            if (inVo.SapItemCode != null)
            {
                sqlQuery.Append(" and UPPER(sap_matnr_item_cd) like UPPER(:sapmatnritemcd) ");
            }

            if (inVo.SapItemName != null)
            {
                sqlQuery.Append(" and UPPER(sap_maktx_item_name) like UPPER(:sapmaktxitemname) ");
            }

            sqlQuery.Append(" ORDER BY si.sap_matnr_item_cd ");
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("factorycode", trxContext.UserData.FactoryCode);

            if (inVo.SapItemCode != null)
            {
                sqlParameter.AddParameterString("sapmatnritemcd", inVo.SapItemCode + "%");
            }

            if (inVo.SapItemName != null)
            {
                sqlParameter.AddParameterString("sapmaktxitemname", inVo.SapItemName + "%");
            }

            //execute SQL
            ValueObjectList<SapItemSearchVo> outVo = null;

            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                SapItemSearchVo currVo = new SapItemSearchVo();
                currVo.SapItemCode = ConvertDBNull<string>(dataReader, "sap_matnr_item_cd");
                currVo.SapItemName = ConvertDBNull<string>(dataReader, "sap_maktx_item_name");
                currVo.SapMaterialGroupId = ConvertDBNull<string>(dataReader, "sap_matkl_material_grp_id");
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
