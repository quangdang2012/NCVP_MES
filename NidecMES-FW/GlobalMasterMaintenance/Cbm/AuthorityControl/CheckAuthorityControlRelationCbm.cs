using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckAuthorityControlRelationCbm : CbmController
    {

        private readonly DataAccessObject checkAuthorityControlRelDao = new CheckAuthorityControlRelationDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkAuthorityControlRelDao.Execute(trxContext, vo);

        }
    }
}
