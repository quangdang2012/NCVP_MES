using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class AddUserMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addUserDao = new AddUserMasterMntDao();

        private readonly DataAccessObject addUserFactoryDao = new AddUserFactoryMasterMntDao();

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
            addUserFactoryDao.Execute(trxContext, inVo2);
            return addUserDao.Execute(trxContext, vo);

        }
    }
}
