using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class AddListRequestDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            TransferVo inVo = (TransferVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into t_transfer_device(transfer_device_cd, transfer_content, transfer_dept, destination_dept, registration_user_cd, registration_date_time, factory_cd) ");
            sql.Append("values(:transfer_device_cd, :transfer_content, :transfer_dept, :destination_dept, :registration_user_cd, now(), :factory_cd)");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("transfer_device_cd", inVo.TransferDeviceCode);
            sqlParameter.AddParameterString("transfer_content", inVo.TransferContent);
            sqlParameter.AddParameterString("transfer_dept", inVo.TransferDept);
            sqlParameter.AddParameterString("destination_dept", inVo.DestinationDept);
            sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            sqlParameter.AddParameterString("registration_user_cd", inVo.RegistrationUserCode);
            //execute SQL

            TransferVo outVo = new TransferVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
