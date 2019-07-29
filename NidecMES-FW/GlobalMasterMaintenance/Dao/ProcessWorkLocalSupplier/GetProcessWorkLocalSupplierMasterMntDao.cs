using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetProcessWorkLocalSupplierMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessWorkLocalSupplierVo inVo = (ProcessWorkLocalSupplierVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select");
            sqlQuery.Append(" pw.process_work_id,");
            sqlQuery.Append(" pw.process_work_name,");
            sqlQuery.Append(" t.local_supplier_id");
            sqlQuery.Append(" from m_process_work pw ");
            sqlQuery.Append(" left join ");
            sqlQuery.Append(" (select pws.process_work_id, pws.local_supplier_id  from m_process_work_local_supplier pws ");
            sqlQuery.Append(" inner join m_local_supplier ls on ls.local_supplier_id = pws.local_supplier_id ");
            sqlQuery.Append(" where pws.local_supplier_id = :localsupplierid ) t ");
            sqlQuery.Append(" on t.process_work_id = pw.process_work_id ");
            //if (inVo.LocalSupplierId > 0)
            //{
            //    sqlQuery.Append(" and pws.local_supplier_id = :localsupplierid");
            //}


            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.LocalSupplierId > 0)
            {
                sqlParameter.AddParameterInteger("localsupplierid", inVo.LocalSupplierId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ProcessWorkLocalSupplierVo outVo = new ProcessWorkLocalSupplierVo();

            while (dataReader.Read())
            {
                ProcessWorkLocalSupplierVo currOutVo = new ProcessWorkLocalSupplierVo
                {
                    LocalSupplierId = Convert.ToInt32(DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["local_supplier_id"])),
                    ProcessWorkId = Convert.ToInt32(dataReader["process_work_id"]),
                    ProcessWorkName = dataReader["process_work_name"].ToString(),
                };

                outVo.ProcessWorkLocalSupplierListVo.Add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
