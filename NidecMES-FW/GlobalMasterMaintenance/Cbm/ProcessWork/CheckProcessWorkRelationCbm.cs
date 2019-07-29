using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckProcessWorkRelationCbm : CbmController
    {

        private readonly DataAccessObject checkProcessWorkRelationDao = new CheckProcessWorkRelationDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkProcessWorkRelationDao.Execute(trxContext, vo);

        }
    }
}
