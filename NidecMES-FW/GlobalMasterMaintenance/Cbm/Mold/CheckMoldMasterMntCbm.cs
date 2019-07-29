using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckMoldMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkMoldDao = new CheckMoldMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return checkMoldDao.Execute(trxContext, vo);

        }
    }
}
