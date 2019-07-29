using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionItemChildCbm : CbmController
    {
        private readonly DataAccessObject getInspectionItemChildDao = new GetInspectionItemChildDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionItemChildDao.Execute(trxContext, vo);

        }
    }
}
