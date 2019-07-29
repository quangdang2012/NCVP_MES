using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    class AddMoldDrawingCbm : CbmController
    {
        private readonly DataAccessObject addMoldDrawingDao = new AddMoldDrawingDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return addMoldDrawingDao.Execute(trxContext, vo);
        }
    }
}
