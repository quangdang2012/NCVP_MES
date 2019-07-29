using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class DeleteUserFactoryMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteUserFactoryDao = new DeleteUserFactoryMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteUserFactoryDao.Execute(trxContext, vo);

        }
    }
}
