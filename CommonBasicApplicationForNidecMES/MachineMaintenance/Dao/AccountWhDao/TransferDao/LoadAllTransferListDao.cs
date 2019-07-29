using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class LoadAllTransferListDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            TransferVo inVo = (TransferVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<TransferVo> voList = new ValueObjectList<TransferVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sql.Append(@"select a.transfer_device_id, a.transfer_device_cd, a.transfer_content, a.transfer_dept, a.trans_status, a.transfer_dept_approver, a.destination_dept, a.destination_status, a.destination_dept_approver, a.account_approver, a.approve_status, b.user_name from t_transfer_device a
                            left join m_mes_user b on b.user_cd = b.registration_user_cd
                         where 1 = 1");
            
            if (!String.IsNullOrEmpty(inVo.DestinationDept))
            {
                sql.Append(@" and a.destination_dept = :destination_dept");
                sqlParameter.AddParameterString("destination_dept", inVo.DestinationDept);
            }

            sql.Append(" order by a.transfer_device_cd");
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                TransferVo outVo = new TransferVo
                {
                    TransferDeviceId = int.Parse(dataReader["transfer_device_id"].ToString()),
                    TransferDeviceCode = dataReader["transfer_device_cd"].ToString(),
                    TransferContent = dataReader["transfer_content"].ToString(),
                    TransferDept = dataReader["transfer_dept"].ToString(),
                    TransferStatus = dataReader["trans_status"].ToString(),
                    TransferApprover = dataReader["transfer_dept_approver"].ToString(),
                    DestinationDept = dataReader["destination_dept"].ToString(),
                    DestinationStatus = dataReader["destination_status"].ToString(),
                    DestinationApprover = dataReader["destination_dept_approver"].ToString(),
                    Accounter = dataReader["account_approver"].ToString(),
                    ApproveStatus = dataReader["approve_status"].ToString(),
                    UserName = dataReader["user_name"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }

    }
}
