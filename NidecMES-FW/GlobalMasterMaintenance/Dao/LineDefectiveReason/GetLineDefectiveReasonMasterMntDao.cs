using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetLineDefectiveReasonMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LineDefectiveReasonVo inVo = (LineDefectiveReasonVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select");
            sqlQuery.Append(" ldr.line_defective_reason_id,");
            sqlQuery.Append(" ldr.defective_reason_id,");
            sqlQuery.Append(" ldr.line_id,");
            sqlQuery.Append(" df.defective_reason_name,");
            sqlQuery.Append(" l.line_name");
            sqlQuery.Append(" from m_line_defective_reason ldr");
            sqlQuery.Append(" inner join m_line l on ldr.line_id = l.line_id");
            sqlQuery.Append(" inner join m_defective_reason df on ldr.defective_reason_id = df.defective_reason_id");
            sqlQuery.Append(" where ldr.factory_cd = :faccd ");

            if (inVo.DefectiveReasonId > 0)
            {
                sqlQuery.Append(" and ldr.defective_reason_id = :dfrid");
            }

            if (inVo.LineId > 0)
            {
                sqlQuery.Append(" and ldr.line_id = :lid");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterInteger("dfrid", inVo.DefectiveReasonId);
            sqlParameter.AddParameterInteger("pwid", inVo.LineId);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<LineDefectiveReasonVo> outVo = null;

            while (dataReader.Read())
            {
                LineDefectiveReasonVo currOutVo = new LineDefectiveReasonVo
                {
                    LineDefectiveReasonId = Convert.ToInt32(dataReader["line_defective_reason_id"]),
                    DefectiveReasonId = Convert.ToInt32(dataReader["defective_reason_id"]),
                    LineId = Convert.ToInt32(dataReader["line_id"]),
                    LineName = dataReader["line_name"].ToString(),
                    DefectiveReasonName = dataReader["defective_reason_name"].ToString()
                };
                if (outVo == null)
                {
                    outVo = new ValueObjectList<LineDefectiveReasonVo>();
                }
                outVo.add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
