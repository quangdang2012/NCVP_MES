using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class UpdateUserMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateUserDao = new UpdateUserMasterMntDao();

        private readonly DataAccessObject addUserFactoryDao = new AddUserFactoryMasterMntDao();

        private readonly DataAccessObject deleteUserFactoryDao = new DeleteUserFactoryMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            UserVo inVo = (UserVo)vo;
            UserFactoryVo inVo2 = new UserFactoryVo
            {
                UserCode = inVo.UserCode,
                FactoryCd = inVo.RegistrationFactoryCode,
                RegistrationUserCode = inVo.RegistrationUserCode
            };

            inVo2.UserFactoryListVo.Add(inVo2);
            deleteUserFactoryDao.Execute(trxContext, inVo2);
            addUserFactoryDao.Execute(trxContext, inVo2);
            return updateUserDao.Execute(trxContext, vo);

        }
    }
}
