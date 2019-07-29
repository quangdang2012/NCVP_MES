using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckInspectionProcessWorkDisplayOrderDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionProcessVo inVo = (InspectionProcessVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select Count(*) as DisplayCount from m_inspection_process");
            sqlQuery.Append(" where factory_cd = :factcd ");

            if (inVo.InspectionFormatId > 0)
            {
                sqlQuery.Append(" and inspection_format_id = :inspectionformatid");
            }

            if (inVo.DisplayOrder > 0)
            {
                sqlQuery.Append(" and display_order = :displayorder");
            }
           
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("factcd", UserData.GetUserData().FactoryCode);

            if (inVo.InspectionFormatId > 0)
            {
                sqlParameter.AddParameterInteger("inspectionformatid", inVo.InspectionFormatId);
            }

            if (inVo.DisplayOrder > 0)
            {
                sqlParameter.AddParameterInteger("displayorder", inVo.DisplayOrder);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            InspectionProcessVo outVo = new InspectionProcessVo();

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["DisplayCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
