using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionFormatDetailForCopyFunctionMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getInspectionItemListDao = new GetInspectionFormatDetailForCopyFunctionMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionItemListDao.Execute(trxContext, vo);

        }
    }
}
