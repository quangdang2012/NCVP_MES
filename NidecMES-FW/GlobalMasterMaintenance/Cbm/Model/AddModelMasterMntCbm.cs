using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddModelMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addModelDao = new AddModelMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addModelDao.Execute(trxContext, vo);
        }
    }
}
