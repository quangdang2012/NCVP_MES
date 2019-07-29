using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class GetLocalUsersMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getUsersDao = new GetLocalUsersMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getUsersDao.Execute(trxContext, vo);

        }
    }
}
