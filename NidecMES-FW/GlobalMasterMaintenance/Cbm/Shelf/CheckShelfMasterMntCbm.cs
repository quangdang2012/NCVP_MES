using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckShelfMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkShelfDao = new CheckShelfMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkShelfDao.Execute(trxContext, vo);

        }
    }
}
