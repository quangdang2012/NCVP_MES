using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckProcessWorkDisplayMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkProcessWorkDisplayMasterMntDao = new CheckProcessWorkDisplayMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkProcessWorkDisplayMasterMntDao.Execute(trxContext, vo);

        }
    }
}
