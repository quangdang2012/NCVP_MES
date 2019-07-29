using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckLocationMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkLocationDao = new CheckLocationMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkLocationDao.Execute(trxContext, vo);

        }
    }
}
