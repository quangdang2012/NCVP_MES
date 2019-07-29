using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddItemProcessWorkMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addItemProcessWorkDao = new AddItemProcessWorkMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addItemProcessWorkDao.Execute(trxContext, vo);

        }
    }
}
