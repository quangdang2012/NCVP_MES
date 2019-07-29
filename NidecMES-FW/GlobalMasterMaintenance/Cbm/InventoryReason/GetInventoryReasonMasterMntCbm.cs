using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInventoryReasonMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getInventoryReasonMasterMntDao = new GetInventoryReasonMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getInventoryReasonMasterMntDao.Execute(trxContext, vo);

        }
    }
}
