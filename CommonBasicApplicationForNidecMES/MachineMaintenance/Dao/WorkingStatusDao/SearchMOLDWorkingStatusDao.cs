using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchMOLDWorkingStatusDao : AbstractDataAccessObject
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
            sql.Append(@"select mold_machine, mold_inspect_data, mold_inspect_date + mold_inspect_time as a, mold_remark  from t_mold_status_machine  where (mold_machine,mold_status_id) in(select mold_machine, max(mold_status_id) from t_mold_status_machine group by mold_machine) order by mold_inspect_data desc ");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                SeachMachineWorkingStatusVo outVo = new SeachMachineWorkingStatusVo
                {

                    MOLDData = double.Parse(dataReader["mold_inspect_data"].ToString()),
                    MOLDMachine = dataReader["mold_machine"].ToString(),
                    MOLDDateTimeLoad = DateTime.Parse(dataReader["a"].ToString()),
                    MOLDRemark = dataReader["mold_remark"].ToString(),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
