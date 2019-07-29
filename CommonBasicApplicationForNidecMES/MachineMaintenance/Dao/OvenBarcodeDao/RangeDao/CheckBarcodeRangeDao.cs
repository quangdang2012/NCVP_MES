using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class CheckBarcodeRangeDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            RangeVo inVo = (RangeVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<RangeVo> voList = new ValueObjectList<RangeVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"select count(*) count_barcode from m_ovenmachine_range where 1=1 ");
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

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            
            RangeVo outVo = new RangeVo();
            outVo.Count = int.Parse(sqlCommandAdapter.ExecuteScalar(sqlParameter).ToString());
            
            return outVo;
        }
    }
}
