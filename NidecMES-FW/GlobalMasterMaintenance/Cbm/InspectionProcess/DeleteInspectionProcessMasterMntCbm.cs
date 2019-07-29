using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteInspectionProcessMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteInspectionProcessDao = new DeleteInspectionProcessMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteInspectionProcessDao.Execute(trxContext, vo);

        }
    }
}
