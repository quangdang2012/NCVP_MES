using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckAuthorityControlMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkAuthorityControlDao = new CheckAuthorityControlMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkAuthorityControlDao.Execute(trxContext, vo);

        }
    }
}
