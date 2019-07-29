using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckCavityMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkCavityDao = new CheckCavityMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkCavityDao.Execute(trxContext, vo);

        }
    }
}
