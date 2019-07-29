using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckItemRelationCbm : CbmController
    {

        private readonly DataAccessObject checkItemRelationDao = new CheckItemRelationDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkItemRelationDao.Execute(trxContext, vo);

        }
    }
}
