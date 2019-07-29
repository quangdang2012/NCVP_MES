using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionItemInsertedListCbm : CbmController
    {
        private readonly DataAccessObject getInspectionItemInsertedListDao = new GetInspectionItemInsertedListDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionItemInsertedListDao.Execute(trxContext, vo);

        }
    }
}
