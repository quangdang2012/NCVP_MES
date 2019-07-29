using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchRangeDao : AbstractDataAccessObject
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
            sql.Append(@"select * from m_ovenmachine_range where 1=1 ");
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
            sql.Append(" order by range_model,range_line,range_barcode ");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                RangeVo outVo = new RangeVo
                {
                    RangeId = int.Parse(dataReader["ovenmachine_range_id"].ToString()),
                    Model = dataReader["range_model"].ToString(),
                    Line = dataReader["range_line"].ToString(),
                    Barcode = dataReader["range_barcode"].ToString(),
                    Lower = dataReader["range_lower"].ToString(),
                    Upper = dataReader["range_upper"].ToString(),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
