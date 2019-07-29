using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddInspectionProcessMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addInspectionProcessDao = new AddInspectionProcessMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addInspectionProcessDao.Execute(trxContext, vo);
        }
    }
}
