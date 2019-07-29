using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class GetLowerOvenLS12Dao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            OvenBarcodeVo inVo = (OvenBarcodeVo)vo;
            StringBuilder sql = new StringBuilder();
            OvenBarcodeVo von = new OvenBarcodeVo();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"select case when count(*) = 0 then '90' else max(range_lower) end ca from  m_ovenmachinels12_range where 1=1 ");
            if (!String.IsNullOrEmpty(inVo.Model))
            {
                sql.Append(@" and range_model = :range_model ");
                sqlParameter.AddParameterString("range_model", inVo.Model);
            }
            if (!String.IsNullOrEmpty(inVo.Process))
            {
                sql.Append(@" and range_process = :range_process ");
                sqlParameter.AddParameterString("range_process", inVo.Process);
            }
            sql.Append(" limit 1");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            
            string dataReader = "";
            dataReader = sqlCommandAdapter.ExecuteScalar(sqlParameter).ToString();

            von.Lower = dataReader;
            return von;
        }
    }
}
