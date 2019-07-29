using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchSTWorkingStatusDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            SeachMachineWorkingStatusVo inVo = (SeachMachineWorkingStatusVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<SeachMachineWorkingStatusVo> voList = new ValueObjectList<SeachMachineWorkingStatusVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"select st_machine, st_inspect_data, st_inspect_date + st_inspect_time as a, st_remark from t_st_status_machine  where (st_machine, st_status_id) in (select st_machine, max(st_status_id) from t_st_status_machine group by st_machine) order by st_inspect_data desc ");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                SeachMachineWorkingStatusVo outVo = new SeachMachineWorkingStatusVo
                {

                    STData = double.Parse(dataReader["st_inspect_data"].ToString()),
                    STMachine = dataReader["st_machine"].ToString(),
                    STDateTimeLoad = DateTime.Parse(dataReader["a"].ToString()),
                    STRemark = dataReader["st_remark"].ToString(),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
