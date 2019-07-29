using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckProcessWorkLineMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkProcessWorklineDao = new CheckProcessWorkLineMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkProcessWorklineDao.Execute(trxContext, vo);

        }
    }
}
