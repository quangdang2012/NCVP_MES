using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddInspectionTestInstructionDetailCopyCbm : CbmController
    {

        private readonly DataAccessObject addInspectionTestInstructionDetailCopyDao = new AddInspectionTestInstructionDetailCopyDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addInspectionTestInstructionDetailCopyDao.Execute(trxContext, vo);
        }
    }
}
