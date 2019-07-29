using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateInspectionProcessMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateInspectionProcessDao = new UpdateInspectionProcessMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateInspectionProcessDao.Execute(trxContext, vo);

        }
    }
}
