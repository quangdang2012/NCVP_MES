using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class CheckBarcodeRangeLS12Dao : AbstractDataAccessObject
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
            sql.Append(@"select count(*) count_process from m_ovenmachinels12_range where 1=1 ");
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

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            
            RangeVo outVo = new RangeVo();
            outVo.Count = int.Parse(sqlCommandAdapter.ExecuteScalar(sqlParameter).ToString());
            
            return outVo;
        }
    }
}
