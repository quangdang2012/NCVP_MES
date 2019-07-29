using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchMACWorkingStatusDao : AbstractDataAccessObject
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
            sql.Append(@"select mac_machine, mac_inspect_data, mac_inspect_date + mac_inspect_time as a, mac_remark  from t_mac_status_machine where (mac_machine, mac_status_id) in(select mac_machine, max(mac_status_id) from t_mac_status_machine group by mac_machine) order by mac_inspect_data desc ");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                SeachMachineWorkingStatusVo outVo = new SeachMachineWorkingStatusVo
                {

                    MACData = double.Parse(dataReader["mac_inspect_data"].ToString()),
                    MACMachine = dataReader["mac_machine"].ToString(),
                    MACDateTimeLoad = DateTime.Parse(dataReader["a"].ToString()),
                    MACRemark = dataReader["mac_remark"].ToString(),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
