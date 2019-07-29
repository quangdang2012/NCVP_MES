using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class DeleteSapUserMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteSapUserDao = new DeleteSapUserMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteSapUserDao.Execute(trxContext, vo);

        }
    }
}
