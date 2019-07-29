using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteInspectionTestInstructionMasterMntCbm : CbmController
    {
        private readonly DataAccessObject deleteInspectionTestInstructionDao = new DeleteInspectionTestInstructionMasterMntDao();
            

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            // Deleting header table related records in detail table.
            return deleteInspectionTestInstructionDao.Execute(trxContext, vo);

        }
    }
}
