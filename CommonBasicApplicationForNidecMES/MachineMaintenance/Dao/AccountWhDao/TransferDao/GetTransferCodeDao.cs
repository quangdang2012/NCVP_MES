using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetTransferCodeDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            TransferVo inVo = (TransferVo)vo;
            StringBuilder sql = new StringBuilder();
            TransferVo voNoList = new TransferVo();
           
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"SELECT case when MAX(transfer_device_id) is null then 0 else MAX(transfer_device_id) end transfer_device_id from t_transfer_device");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            string transfer_device_id = sqlCommandAdapter.ExecuteScalar(sqlParameter).ToString();
            inVo.TransferDeviceID = int.Parse(transfer_device_id);

            return inVo;
        }
    }
}