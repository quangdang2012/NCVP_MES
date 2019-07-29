using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchTDWorkingStatusDao : AbstractDataAccessObject
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
            sql.Append(@"select td_machine, td_inspect_data, td_inspect_date + td_inspect_time as a, td_remark  from t_td_status_machine  where (td_machine,td_status_id) in(select td_machine, max(td_status_id) from t_td_status_machine group by td_machine) order by td_inspect_data desc ");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                SeachMachineWorkingStatusVo outVo = new SeachMachineWorkingStatusVo
                {

                    TDData = double.Parse(dataReader["td_inspect_data"].ToString()),
                    TDMachine = dataReader["td_machine"].ToString(),
                    TDDateTimeLoad = DateTime.Parse(dataReader["a"].ToString()),
                    TDRemark = dataReader["td_remark"].ToString(),

                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
