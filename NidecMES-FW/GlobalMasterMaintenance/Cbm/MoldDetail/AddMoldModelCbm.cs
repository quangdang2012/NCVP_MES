using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    class AddMoldModelCbm : CbmController
    {
        private readonly DataAccessObject addMoldModelDao = new AddMoldModelDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return addMoldModelDao.Execute(trxContext, vo);
        }
    }
}
