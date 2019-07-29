using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetCauseAndDefectiveDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            DefectiveReasonVo inVo = (DefectiveReasonVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<DefectiveReasonVo> voList = new ValueObjectList<DefectiveReasonVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("SELECT a.defective_reason_id, a.defective_reason_name FROM m_defective_reason a LEFT JOIN m_cause b ON b.defective_reason_id = a.defective_reason_id LEFT JOIN m_machine c ON c.machine_id = b.machine_id WHERE machine_name = :machine_name ORDER BY defective_reason_id");

            sqlParameter.AddParameterString("machine_name", inVo.DefectiveReasonCode);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());



            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                DefectiveReasonVo outVo = new DefectiveReasonVo
                {
                     DefectiveReasonId = int.Parse(dataReader["defective_reason_id"].ToString()),
                     DefectiveReasonName = dataReader["defective_reason_name"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }

    }

}
