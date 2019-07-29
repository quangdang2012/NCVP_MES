using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckLocalSupplierRelationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LocalSupplierVo inVo = (LocalSupplierVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append(" select Count(lsr.local_supplier_cd) as SupplierCount from m_local_supplier as lsr");            
            sqlQuery.Append(" inner join m_process_work_local_supplier as prsup on lsr.local_supplier_id = prsup.local_supplier_id ");
            sqlQuery.Append(" where 1 = 1 ");
            if (inVo.LocalSupplierCode != null)
            {
                sqlQuery.Append(" and UPPER(local_supplier_cd) = UPPER(:localsuppliercd)");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();


            if (inVo.LocalSupplierCode != null)
            {
                sqlParameter.AddParameterString("localsuppliercd", inVo.LocalSupplierCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            LocalSupplierVo outVo = new LocalSupplierVo();

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["SupplierCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
