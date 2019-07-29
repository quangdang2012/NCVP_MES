using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckProcessMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkProcessDao = new CheckProcessMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkProcessDao.Execute(trxContext, vo);

        }
    }
}
