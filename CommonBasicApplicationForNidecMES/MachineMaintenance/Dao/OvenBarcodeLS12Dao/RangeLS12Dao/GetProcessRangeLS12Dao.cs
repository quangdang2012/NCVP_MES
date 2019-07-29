using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class GetProcessRangeLS12Dao : AbstractDataAccessObject
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
            sql.Append(@"select distinct range_process from m_ovenmachinels12_range where 1=1 ");
            if (!String.IsNullOrEmpty(inVo.Model))
            {
                sql.Append(@" and range_model = :range_model ");
                sqlParameter.AddParameterString("range_model", inVo.Model);
            }
            sql.Append(" order by range_process");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                RangeVo outVo = new RangeVo
                {

             
                    Process = dataReader["range_process"].ToString(),
                    
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
