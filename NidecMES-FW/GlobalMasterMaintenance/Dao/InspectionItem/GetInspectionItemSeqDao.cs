using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspectionItemSeqDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionItemVo inVo = (InspectionItemVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select");
            sqlQuery.Append(" inspection_item_cd");
            sqlQuery.Append(" from m_inspection_item");
            sqlQuery.Append(" where factory_cd = :faccd ");
            sqlQuery.Append(" and inspection_process_id = :inspectionprocessid ");

            if (inVo.ParentInspectionItemId > 0)
            {
                sqlQuery.Append(" and parent_inspection_item_id = :parentinspectionitemid ");
            }

            sqlQuery.Append(" order by inspection_item_id desc ");
            sqlQuery.Append(" limit 1 ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterInteger("inspectionprocessid", inVo.InspectionProcessId);

            if (inVo.ParentInspectionItemId > 0)
            {
                sqlParameter.AddParameterInteger("parentinspectionitemid", inVo.ParentInspectionItemId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            InspectionItemVo currOutVo = new InspectionItemVo();

            while (dataReader.Read())
            {
                currOutVo.InspectionItemCode = ConvertDBNull<string>(dataReader, "inspection_item_cd");                
            }
            dataReader.Close();

            return currOutVo;
        }
    }
}
