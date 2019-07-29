using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class UpdateStatusTransferListDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            TransferVo inVo = (TransferVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("update t_transfer_device");

            if (!String.IsNullOrEmpty(inVo.TransferStatus))
            {
                sql.Append(" set trans_status = :trans_status, transfer_dept_approver = :transfer_dept_approver");
            }

            if (!String.IsNullOrEmpty(inVo.DestinationStatus))
            {
                sql.Append(" set destination_status = :destination_status, destination_dept_approver = :destination_dept_approver");
            }

            if (!String.IsNullOrEmpty(inVo.ApproveStatus))
            {
                sql.Append(" set approve_status = :approve_status, account_approver = :account_approver");
            }
            sql.Append(" where transfer_device_id = :transfer_device_id");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("transfer_device_id", inVo.TransferDeviceId);
            if (!String.IsNullOrEmpty(inVo.TransferStatus))
            {
                sqlParameter.AddParameterString("trans_status", inVo.TransferStatus);
                sqlParameter.AddParameterString("transfer_dept_approver", inVo.TransferApprover);
            }

            if (!String.IsNullOrEmpty(inVo.DestinationStatus))
            {
                sqlParameter.AddParameterString("destination_status", inVo.DestinationStatus);
                sqlParameter.AddParameterString("destination_dept_approver", inVo.DestinationApprover);
            }

            if (!String.IsNullOrEmpty(inVo.ApproveStatus))
            {
                sqlParameter.AddParameterString("approve_status", inVo.ApproveStatus);
                sqlParameter.AddParameterString("account_approver", inVo.Accounter);
            }
            //execute SQL
            //int a = sqlCommandAdapter.ExecuteNonQuery(sqlParameter);
            TransferVo outVo = new TransferVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
