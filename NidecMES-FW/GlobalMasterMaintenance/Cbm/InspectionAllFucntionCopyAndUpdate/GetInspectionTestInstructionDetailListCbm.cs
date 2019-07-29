using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionTestInstructionDetailListCbm : CbmController
    {
        private readonly DataAccessObject getInspectionTestInstructionDetailListDao = new GetInspectionTestInstructionDetailListDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionTestInstructionDetailListDao.Execute(trxContext, vo);

        }
    }
}
