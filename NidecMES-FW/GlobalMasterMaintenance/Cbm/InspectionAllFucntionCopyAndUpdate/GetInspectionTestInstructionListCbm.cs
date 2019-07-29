using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetInspectionTestInstructionListCbm : CbmController
    {
        private readonly DataAccessObject getInspectionTestInstructionListDao = new GetInspectionTestInstructionListDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getInspectionTestInstructionListDao.Execute(trxContext, vo);

        }
    }
}
