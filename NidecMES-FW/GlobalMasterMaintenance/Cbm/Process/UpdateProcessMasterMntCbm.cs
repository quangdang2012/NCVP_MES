using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateProcessMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateProcessDao = new UpdateProcessMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateProcessDao.Execute(trxContext, vo);

        }
    }
}
