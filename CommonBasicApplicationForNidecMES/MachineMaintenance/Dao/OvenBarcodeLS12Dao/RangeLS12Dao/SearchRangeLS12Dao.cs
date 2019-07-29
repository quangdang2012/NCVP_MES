using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchRangeLS12Dao : AbstractDataAccessObject
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
            sql.Append(@"select * from m_ovenmachinels12_range where 1=1 ");
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
            sql.Append(" order by range_model,range_process ");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                RangeVo outVo = new RangeVo
                {
                    RangeId = int.Parse(dataReader["ovenmachine_rangels12_id"].ToString()),
                    Model = dataReader["range_model"].ToString(),
                    Process = dataReader["range_process"].ToString(),
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
