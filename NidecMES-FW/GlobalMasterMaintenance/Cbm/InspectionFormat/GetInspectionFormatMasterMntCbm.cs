using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionFormatMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getInspectionFormatDao = new GetInspectionFormatMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionFormatDao.Execute(trxContext, vo);

        }
    }
}
