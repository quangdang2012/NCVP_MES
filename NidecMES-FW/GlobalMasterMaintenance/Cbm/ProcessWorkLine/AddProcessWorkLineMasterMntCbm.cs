using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddProcessWorkLineMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addLineDao = new AddProcessWorkLineMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addLineDao.Execute(trxContext, vo);

        }
    }
}
