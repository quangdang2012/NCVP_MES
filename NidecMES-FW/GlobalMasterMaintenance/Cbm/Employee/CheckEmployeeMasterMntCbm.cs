using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckEmployeeMasterMntCbm : CbmController
    {

        private readonly DataAccessObject checkEmpDao = new CheckEmployeeMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return checkEmpDao.Execute(trxContext, vo);
        }
    }
}
