using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class GetUserFactoryMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getUserFactoryDao = new GetUserFactoryMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getUserFactoryDao.Execute(trxContext, vo);

        }
    }
}
