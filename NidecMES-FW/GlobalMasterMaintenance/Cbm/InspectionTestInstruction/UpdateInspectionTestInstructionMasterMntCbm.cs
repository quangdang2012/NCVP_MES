using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateInspectionTestInstructionMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateInspectionTestInstructionDao = new UpdateInspectionTestInstructionMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateInspectionTestInstructionDao.Execute(trxContext, vo);

        }
    }
}
