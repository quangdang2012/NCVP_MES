using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class DeleteUserMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteUserDao = new DeleteUserMasterMntDao();

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

                deleteUserFactoryDao.Execute(trxContext, inVo2);
                return deleteUserDao.Execute(trxContext, vo);

        }
    }
}
