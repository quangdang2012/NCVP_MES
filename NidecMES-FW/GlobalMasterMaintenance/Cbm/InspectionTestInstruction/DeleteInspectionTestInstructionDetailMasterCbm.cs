using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteInspectionTestInstructionDetailMasterCbm : CbmController
    {
        private readonly DataAccessObject deleteInspectionTestInstructionDetailDao = new DeleteInspectionTestInstructionDetailMasterDao();
            

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            // Deleting header table related records in detail table.
            return deleteInspectionTestInstructionDetailDao.Execute(trxContext, vo);

        }
    }
}
