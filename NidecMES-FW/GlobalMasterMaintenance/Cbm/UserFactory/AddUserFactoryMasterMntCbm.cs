using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class AddUserFactoryMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addUserFactoryDao = new AddUserFactoryMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addUserFactoryDao.Execute(trxContext, vo);

        }
    }
}
