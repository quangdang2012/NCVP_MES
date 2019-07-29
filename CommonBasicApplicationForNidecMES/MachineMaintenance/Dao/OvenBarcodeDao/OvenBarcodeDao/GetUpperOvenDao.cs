using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class GetUpperOvenDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            OvenBarcodeVo inVo = (OvenBarcodeVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<OvenBarcodeVo> voList = new ValueObjectList<OvenBarcodeVo>();
            OvenBarcodeVo von = new OvenBarcodeVo();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"select case when count(*) = 0 then '110' else max(range_upper) end ca from  m_ovenmachine_range where 1=1 ");
            if (!String.IsNullOrEmpty(inVo.Model))
            {
                sql.Append(@" and range_model = :range_model ");
                sqlParameter.AddParameterString("range_model", inVo.Model);
            }
            if (!String.IsNullOrEmpty(inVo.Line))
            {
                sql.Append(@" and range_line = :range_line ");
                sqlParameter.AddParameterString("range_line", inVo.Line);
            }
            if (!String.IsNullOrEmpty(inVo.Barcode))
            {
                sql.Append(@" and range_barcode = :range_barcode ");
                sqlParameter.AddParameterString("range_barcode", inVo.Barcode);
            }
            sql.Append(" limit 1");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            string dataReader = "";
            //execute SQL
                dataReader = sqlCommandAdapter.ExecuteScalar(sqlParameter).ToString();
            
            von.Upper = dataReader;
            return von;
        }
    }
}
