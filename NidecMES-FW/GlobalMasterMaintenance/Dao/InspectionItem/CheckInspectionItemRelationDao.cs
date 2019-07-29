using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;
namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckInspectionItemRelationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionItemVo inVo = (InspectionItemVo)arg;

            InspectionItemVo outVo = null;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append(" select ti.inspection_item_id as testinstructionitemid, isp.inspection_item_id as specificationitemid, ");
            sqlQuery.Append("  iit.inspection_item_id, parenttable.cnt ");
            sqlQuery.Append(" from m_inspection_item iit left join m_inspection_test_instruction ti ");
            sqlQuery.Append(" on ti.inspection_item_id = iit.inspection_item_id left join m_inspection_specification isp on  ");
            sqlQuery.Append(" isp.inspection_item_id = iit.inspection_item_id ");
            sqlQuery.Append(" left join ");
            sqlQuery.Append("          (select cast(count(inspection_item_id) as Integer) as cnt,inspection_process_id ");
            sqlQuery.Append("           from m_inspection_item ");
            sqlQuery.Append("           where parent_inspection_item_id = :inspectionitemid ");
            sqlQuery.Append("           group by inspection_process_id ");
            sqlQuery.Append("          ) parenttable on parenttable.inspection_process_id = iit.inspection_process_id ");

            sqlQuery.Append(" where iit.factory_cd = :faccd ");
            sqlQuery.Append(" and iit.inspection_item_cd  = :inspectionitemcode ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterString("inspectionitemcode", inVo.InspectionItemCode);
            sqlParameter.AddParameterInteger("inspectionitemid", inVo.InspectionItemId);


            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                if (outVo == null)
                {
                    outVo = new InspectionItemVo();
                }
                outVo.InspectionItemId = ConvertDBNull<int>(dataReader, "testinstructionitemid");
                if (outVo.InspectionItemId == 0)
                {
                    outVo.InspectionItemId = ConvertDBNull<int>(dataReader, "specificationitemid");
                }
                if (outVo.InspectionItemId == 0)
                {
                    outVo.AffectedCount = ConvertDBNull<int>(dataReader, "cnt");
                }
            }
            dataReader.Close();

            return outVo;
        }

    }
}
