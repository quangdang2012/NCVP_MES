using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchSPWorkingStatusDao : AbstractDataAccessObject
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
            sql.Append(@"select press_machine, press_inspect_data, press_inspect_date + press_inspect_time as a, press_remark  from t_press_status_machine where (press_machine,press_status_id) in(select press_machine, max(press_status_id) from t_press_status_machine group by press_machine) order by press_inspect_data desc ");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                SeachMachineWorkingStatusVo outVo = new SeachMachineWorkingStatusVo
                {

                    SPData = double.Parse(dataReader["press_inspect_data"].ToString()),
                    SPMachine = dataReader["press_machine"].ToString(),
                    SPDateTimeLoad = DateTime.Parse(dataReader["a"].ToString()),
                    SPRemark = dataReader["press_remark"].ToString(),

                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
