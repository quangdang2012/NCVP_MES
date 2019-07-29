using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateEmployeeMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateEmpDao = new UpdateEmployeeMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return updateEmpDao.Execute(trxContext, vo);
        }
    }
}
