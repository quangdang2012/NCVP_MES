using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddInspectionTestInstructionCopyCbm : CbmController
    {

        private readonly DataAccessObject addInspectionTestInstructionCopyDao = new AddInspectionTestInstructionCopyDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addInspectionTestInstructionCopyDao.Execute(trxContext, vo);
        }
    }
}
