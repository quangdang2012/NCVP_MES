using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckAreaMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkAreaDao = new CheckAreaMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkAreaDao.Execute(trxContext, vo);

        }
    }
}
