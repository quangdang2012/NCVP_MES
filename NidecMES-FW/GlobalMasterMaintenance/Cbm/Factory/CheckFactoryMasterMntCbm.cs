using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckFactoryMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkFactoryDao = new CheckFactoryMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkFactoryDao.Execute(trxContext, vo);

        }
    }
}
