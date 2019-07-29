using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspectionSpecificationSeqDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionSpecificationVo inVo = (InspectionSpecificationVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select");
            sqlQuery.Append(" max(inspection_specification_seq) + 1 as seqnumber");
            sqlQuery.Append(" from m_inspection_specification");
            sqlQuery.Append(" where factory_cd = :faccd ");
            sqlQuery.Append(" and inspection_item_id = :inspectionitemid ");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterInteger("inspectionitemid", inVo.InspectionItemId);
            
            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            InspectionSpecificationVo currOutVo = new InspectionSpecificationVo();

            while (dataReader.Read())

            {
                currOutVo.AffectedCount = ConvertDBNull<int>(dataReader, "seqnumber");                
            }
            dataReader.Close();

            return currOutVo;
        }
    }
}
