using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetMoldIdForExcelUploadCbm : CbmController
    {
        private readonly DataAccessObject getMoldIdForExcelUploadDao = new GetMoldIdForExcelUploadDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getMoldIdForExcelUploadDao.Execute(trxContext, vo);

        }
    }
}
