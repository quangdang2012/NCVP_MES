using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetDefectiveReasonMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            DefectiveReasonVo inVo = (DefectiveReasonVo)arg;

            DefectiveReasonVo outVo = new DefectiveReasonVo();

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select distinct dr.*, dc.defective_category_name from m_defective_reason dr ");

            if (inVo.ProcessId > 0)
            {
                sqlQuery.Append(" inner join m_process_work_defective_reason pwdr on pwdr.defective_reason_id = dr.defective_reason_id ");
                sqlQuery.Append(" inner join m_process_work pw on pw.process_work_id = pwdr.process_work_id");
                
            }
            sqlQuery.Append(" left join m_defective_category dc on dc.defective_category_id = dr.defective_category_id ");
            sqlQuery.Append(" where dr.factory_cd = :faccd ");

            if (inVo.DefectiveReasonCode != null)
            {
                sqlQuery.Append(" and defective_reason_cd like :defectivereasoncd ");
            }

            if (inVo.DefectiveReasonName != null)
            {
                sqlQuery.Append(" and defective_reason_name like :defectivereasonname ");
            }

            if (inVo.DefectiveCategoryId > 0)
            {
                sqlQuery.Append(" and dr.defective_category_id = :defectivecategoryid ");
            }

            if (inVo.ProcessId > 0)
            {
                sqlQuery.Append(" and pw.process_id = :processid ");
            }

            sqlQuery.Append(" order by dr.display_order ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.DefectiveReasonCode != null)
            {
                sqlParameter.AddParameterString("defectivereasoncd", inVo.DefectiveReasonCode + "%");
            }

            if (inVo.DefectiveReasonName != null)
            {
                sqlParameter.AddParameterString("defectivereasonname", inVo.DefectiveReasonName + "%");
            }

            if (inVo.DefectiveCategoryId != 0)
            {
                sqlParameter.AddParameterInteger("defectivecategoryid", inVo.DefectiveCategoryId);
            }
            if (inVo.ProcessId > 0)
            {
                sqlParameter.AddParameterInteger("processid ", inVo.ProcessId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                DefectiveReasonVo currOutVo = new DefectiveReasonVo
                {
                    DefectiveReasonId = Convert.ToInt32(dataReader["defective_reason_id"]),
                    DefectiveReasonCode = dataReader["defective_reason_cd"].ToString(),
                    DefectiveReasonName = dataReader["defective_reason_name"].ToString(),
                    DefectiveCategoryId = ConvertDBNull<Int32>(dataReader, "defective_category_id"),
                    DefectiveCategoryName = ConvertDBNull<string>(dataReader, "defective_category_name"),
                    DisplayOrder = Convert.ToInt32(dataReader["display_order"].ToString())
                };

                outVo.DefectiveReasonListVo.Add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
