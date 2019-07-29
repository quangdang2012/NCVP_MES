using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionFormatLastRecordforSerailNoMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getInspectionFormatLastRecordforSerailNoMasterDao = new GetInspectionFormatLastRecordforSerailNoMasterDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionFormatLastRecordforSerailNoMasterDao.Execute(trxContext, vo);

        }
    }
}
