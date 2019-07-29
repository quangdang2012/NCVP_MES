using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetEmployeeWithoutLikeSearchMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getEmpDao = new GetEmployeeWithoutLikeSearchMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getEmpDao.Execute(trxContext, vo);
        }
    }
}
