using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteEmployeeMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteEmpDao = new DeleteEmployeeMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return deleteEmpDao.Execute(trxContext, vo);
        }
    }
}
