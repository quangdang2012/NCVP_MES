using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao.DefectiveReason
{
    public class CheckWorkCenterReasonDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            CheckWorkCenterReasonVo inVo = (CheckWorkCenterReasonVo)vo;
            CheckWorkCenterReasonVo outVo = new CheckWorkCenterReasonVo();

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL query
            sqlQuery.Append(" select count(defective_reason) as defective_reason from t_prod_report_defective_info a  ");
            sqlQuery.Append(" left join m_defective_reason b on b.defective_reason_id = a.defective_reason  ");
            sqlQuery.Append(" left join t_prod_report_dtl x on x.production_report_dtl_id = a.production_report_dtl_id  ");
            sqlQuery.Append(" left join t_prod_report c on c.production_report_id = x.production_report_id   ");
            sqlQuery.Append(" left join sap_mo d on d.sap_manufacturing_order_number = c.mo_number  ");
            sqlQuery.Append(" left join m_process_work e on e.process_work_cd = d.sap_work_center  ");
            sqlQuery.Append(" where 1 = 1  ");

            if (inVo != null)
            {
                sqlQuery.Append(" and b.defective_reason_cd = :defective_reason_cd ");
                sqlQuery.Append(" and e.process_work_id = :sap_work_center ");
            }
            else
            {
                return outVo;
            }
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo != null)
            {
                sqlParameter.AddParameterString("defective_reason_cd", inVo.Defective_Reason_ID);
                sqlParameter.AddParameterInteger("sap_work_center", inVo.Work_Center);
            }
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);


            while (dataReader.Read())
            {
                outVo.Flag = Convert.ToInt32(dataReader["defective_reason"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
