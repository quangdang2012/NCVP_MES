using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckDefectiveReasonRelationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            DefectiveReasonVo inVo = (DefectiveReasonVo)arg;

            DefectiveReasonVo outVo = new DefectiveReasonVo();

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("select Count(dfr.defective_reason_cd) as DefRsnCount from m_defective_reason as dfr ");
            sqlQuery.Append(" inner join m_process_work_defective_reason as pwdr on dfr.defective_reason_id = pwdr.defective_reason_id ");
            sqlQuery.Append(" where dfr.factory_cd = :faccd ");

            if (inVo.DefectiveReasonCode != null)
            {
                sqlQuery.Append(" and UPPER(defective_reason_cd) = UPPER(:defectivereasoncd)");
            }
           
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.DefectiveReasonCode != null)
            {
                sqlParameter.AddParameterString("defectivereasoncd", inVo.DefectiveReasonCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            outVo.AffectedCount = 0;

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["DefRsnCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
