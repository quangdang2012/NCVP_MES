using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddEmployeeMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addEmpDao = new AddEmployeeMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return addEmpDao.Execute(trxContext, vo);

        }
    }
}
