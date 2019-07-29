using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddInspectionTestInstructionMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addInspectionTestInstructionDao = new AddInspectionTestInstructionMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addInspectionTestInstructionDao.Execute(trxContext, vo);
        }
    }
}
