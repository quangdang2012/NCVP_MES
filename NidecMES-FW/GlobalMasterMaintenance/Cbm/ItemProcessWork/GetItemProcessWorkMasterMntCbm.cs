using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetItemProcessWorkMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getItemProcessWorkDao = new GetItemProcessWorkMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getItemProcessWorkDao.Execute(trxContext, vo);

        }
    }
}
