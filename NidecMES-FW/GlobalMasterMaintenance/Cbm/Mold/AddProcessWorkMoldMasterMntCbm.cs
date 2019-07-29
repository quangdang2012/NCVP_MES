using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddProcessWorkMoldMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addProcessWorkMoldDao = new AddProcessWorkMoldMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return addProcessWorkMoldDao.Execute(trxContext, vo);

        }
    }
}
