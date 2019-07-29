using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class CheckItemLineInspectionFormatMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            ItemLineInspectionFormatVo inVo = (ItemLineInspectionFormatVo)arg;

            StringBuilder sql = new StringBuilder();

            //create SQL
            sql.Append("Select Count(*) as itemlineinspectionformatcount from m_item_line_inspection_format ilf");
            sql.Append(" inner join m_inspection_format if on if.inspection_format_id = ilf.inspection_format_id ");
            sql.Append(" where ilf.factory_cd = :faccd ");
            sql.Append(" and if.is_deleted = '0' ");

            if (inVo.SapItemCode != null)
            {
                sql.Append(" and sap_matnr_item_cd = :sapitemcd");
            }

            if (inVo.LineId > 0)
            {
                sql.Append(" and line_id = :lineid");
            }

            if (inVo.Mode.Equals(CommonConstants.MODE_UPDATE.ToString()) && inVo.ItemLineInspectionFormatId > 0)
            {
                sql.Append(" and item_line_inspection_format_id <> :itemlineinspectionformatid ");
            }

            if (inVo.InspectionFormatId > 0)
            {    
                sql.Append(" or ( ");
                if (inVo.Mode.Equals(CommonConstants.MODE_UPDATE.ToString()) && inVo.ItemLineInspectionFormatId > 0)
                {
                    sql.Append(" item_line_inspection_format_id <> :itemlineinspectionformatid and ");
                }
                sql.Append(" inspection_format_id = :inspectionformatid and factory_cd = :faccd) "); 
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.SapItemCode != null)
            {
                sqlParameter.AddParameterString("sapitemcd", inVo.SapItemCode);
            }

            if (inVo.LineId > 0)
            {
                sqlParameter.AddParameterInteger("lineid", inVo.LineId);
            }

            if (inVo.InspectionFormatId > 0)
            {
                sqlParameter.AddParameterInteger("inspectionformatid", inVo.InspectionFormatId);
            }

            if (inVo.Mode.Equals(CommonConstants.MODE_UPDATE.ToString()) && inVo.ItemLineInspectionFormatId > 0)
            {
                sqlParameter.AddParameterInteger("itemlineinspectionformatid", inVo.ItemLineInspectionFormatId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ItemLineInspectionFormatVo outVo = new ItemLineInspectionFormatVo { AffectedCount = 0 };

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["itemlineinspectionformatcount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
