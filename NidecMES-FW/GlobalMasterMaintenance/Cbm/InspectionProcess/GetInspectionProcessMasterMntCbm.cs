using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionProcessMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getInspectionProcessDao = new GetInspectionProcessMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionProcessDao.Execute(trxContext, vo);

        }
    }
}
