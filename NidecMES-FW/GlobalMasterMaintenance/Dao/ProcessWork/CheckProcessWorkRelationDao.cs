using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckProcessWorkRelationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessWorkVo inVo = (ProcessWorkVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select psw.process_work_cd as ProcessWorkCd, pwdr.process_work_id as DefectiveId, ");
            sqlQuery.Append(" ipw.process_work_id as ItemProcessWorkId,pwls.process_work_id as ProcessSupplierId from m_process_work psw ");
            sqlQuery.Append(" left outer join m_process_work_defective_reason pwdr on psw.process_work_id = pwdr.process_work_id ");
            sqlQuery.Append(" left outer join m_item_process_work ipw on psw.process_work_id = ipw.process_work_id ");
            sqlQuery.Append(" left outer join m_process_work_local_supplier pwls on psw.process_work_id = pwls.process_work_id ");
            sqlQuery.Append(" where psw.factory_cd = :factcd ");

            if (inVo.ProcessWorkCode != null)
            {
                sqlQuery.Append(" and UPPER(process_work_cd) = UPPER(:processworkcd)");
            }
           
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("factcd", UserData.GetUserData().FactoryCode);

            if (inVo.ProcessWorkCode != null)
            {
                sqlParameter.AddParameterString("processworkcd", inVo.ProcessWorkCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ProcessWorkVo outVo = new ProcessWorkVo();

            while (dataReader.Read())
            {
                //outVo.AffectedCount = Convert.ToInt32(dataReader["WorkCount"]);               
                outVo.DefectiveIdCount = Convert.ToInt32("0" + dataReader["DefectiveId"]);
                outVo.ItemProcessWorkIdCount = Convert.ToInt32("0" + dataReader["ItemProcessWorkId"]);
                outVo.ProcessSupplierIdCount = Convert.ToInt32("0" + dataReader["ProcessSupplierId"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
