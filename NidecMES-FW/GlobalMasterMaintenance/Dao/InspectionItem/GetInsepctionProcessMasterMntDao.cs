using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInsepctionProcessMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionProcessVo inVo = (InspectionProcessVo)arg;          

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select * from m_inspection_process ");

            sqlQuery.Append(" where factory_cd = :faccd ");

            if (inVo.InspectionProcessCode != null)
            {
                sqlQuery.Append(" and UPPER(inspection_process_cd) like UPPER(:Insprocesscd) ");
            }

            if (inVo.InspectionProcessName != null)
            {
                sqlQuery.Append(" and UPPER(inspection_process_name) like UPPER(:Insprocessname) ");
            }

            if (inVo.InspectionFormatId >0)
            {
                sqlQuery.Append(" and inspection_format_id = :inspectionformatid ");
            }

            sqlQuery.Append(" order by display_order, inspection_process_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.InspectionProcessCode != null)
            {
                sqlParameter.AddParameterString("Insprocesscd", inVo.InspectionProcessCode + "%");
            }

            if (inVo.InspectionProcessName != null)
            {
                sqlParameter.AddParameterString("Insprocessname", inVo.InspectionProcessName + "%");
            }

            if (inVo.InspectionFormatId > 0)
            {
                sqlParameter.AddParameterInteger("inspectionformatid", inVo.InspectionFormatId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<InspectionProcessVo> outVo = null;

            while (dataReader.Read())
            {
                InspectionProcessVo currOutVo = new InspectionProcessVo
                {
                    InspectionProcessId = ConvertDBNull<int>( dataReader, "inspection_process_id"),
                    InspectionProcessName = ConvertDBNull<string>(dataReader, "inspection_process_name"),
                    InspectionProcessCode = ConvertDBNull<string>(dataReader, "inspection_process_cd"),
                };
                if (outVo == null)
                {
                    outVo = new ValueObjectList<InspectionProcessVo>();
                }
                outVo.add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }

 
    }
}
