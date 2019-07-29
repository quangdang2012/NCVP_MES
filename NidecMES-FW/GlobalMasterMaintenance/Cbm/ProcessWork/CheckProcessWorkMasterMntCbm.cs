using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckProcessWorkMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkProcessWorkDao = new CheckProcessWorkMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkProcessWorkDao.Execute(trxContext, vo);

        }
    }
}
