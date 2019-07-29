using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckRoleRelationCbm : CbmController
    {

        private readonly DataAccessObject checkRoleRelDao = new CheckRoleRelationDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkRoleRelDao.Execute(trxContext, vo);

        }
    }
}
