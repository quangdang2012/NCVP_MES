using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckMoldDetailMasterMntCbm : CbmController
    {
        private readonly DataAccessObject checkMolDetDao = new CheckMoldDetailMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkMolDetDao.Execute(trxContext, vo);

        }
    }
}
