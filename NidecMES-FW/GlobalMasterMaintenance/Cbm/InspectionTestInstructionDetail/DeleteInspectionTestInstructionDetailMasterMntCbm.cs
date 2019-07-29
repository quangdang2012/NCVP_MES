using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteInspectionTestInstructionDetailMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteInspectionTestInstructionDetailDao = new DeleteInspectionTestInstructionDetailMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteInspectionTestInstructionDetailDao.Execute(trxContext, vo);

        }
    }
}
