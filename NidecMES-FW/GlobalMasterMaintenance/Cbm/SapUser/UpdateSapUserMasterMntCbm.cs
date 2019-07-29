using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class UpdateSapUserMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateSapUserDao = new UpdateSapUserMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateSapUserDao.Execute(trxContext, vo);

        }
    }
}
