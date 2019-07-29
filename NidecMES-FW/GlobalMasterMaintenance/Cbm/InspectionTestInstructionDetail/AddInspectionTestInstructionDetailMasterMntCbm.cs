using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddInspectionTestInstructionDetailMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addInspectionTestInstructionDetailDao = new AddInspectionTestInstructionDetailMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addInspectionTestInstructionDetailDao.Execute(trxContext, vo);
        }
    }
}
