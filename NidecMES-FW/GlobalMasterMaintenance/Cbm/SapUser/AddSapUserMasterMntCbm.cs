using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class AddSapUserMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addSapUserDao = new AddSapUserMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addSapUserDao.Execute(trxContext, vo);

        }
    }
}
