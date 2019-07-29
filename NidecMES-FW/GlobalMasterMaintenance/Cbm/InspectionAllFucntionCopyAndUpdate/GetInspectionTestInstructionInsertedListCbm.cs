using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionTestInstructionInsertedListCbm : CbmController
    {
        private readonly DataAccessObject getInspectionTestInstructionInsertedListDao = new GetInspectionTestInstructionInsertedListDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionTestInstructionInsertedListDao.Execute(trxContext, vo);

        }
    }
}
