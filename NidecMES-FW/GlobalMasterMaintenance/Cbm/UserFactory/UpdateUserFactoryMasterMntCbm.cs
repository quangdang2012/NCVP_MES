using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class UpdateUserFactoryMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteUserFactoryDao = new DeleteUserFactoryMasterMntDao();

        private readonly DataAccessObject addUserFactoryDao = new AddUserFactoryMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            deleteUserFactoryDao.Execute(trxContext, vo);
            return addUserFactoryDao.Execute(trxContext, vo);

        }
    }
}
