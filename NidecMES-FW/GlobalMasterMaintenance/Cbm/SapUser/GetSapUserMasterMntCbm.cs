using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class GetSapUserMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getUserDao = new GetSapUserMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getUserDao.Execute(trxContext, vo);

        }
    }
}
