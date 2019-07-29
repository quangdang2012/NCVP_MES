using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionProcessForCopyMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getInspectionProcessForCopyMasterMntDao = new GetInspectionProcessForCopyMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionProcessForCopyMasterMntDao.Execute(trxContext, vo);

        }
    }
}
