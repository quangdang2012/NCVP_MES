using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteInventoryReasonMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteInventoryReasonMasterMntDao = new DeleteInventoryReasonMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteInventoryReasonMasterMntDao.Execute(trxContext, vo);

        }
    }
}
