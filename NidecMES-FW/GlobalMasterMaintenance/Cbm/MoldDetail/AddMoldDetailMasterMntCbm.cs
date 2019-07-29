using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddMoldDetailMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addMolDetDao = new AddMoldDetailMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return addMolDetDao.Execute(trxContext, vo);
        }
    }
}
