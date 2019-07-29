using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetItemMasterCbm : CbmController
    {
        private readonly DataAccessObject getItemDao = new GetItemMasterDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getItemDao.Execute(trxContext, vo);

        }
    }
}
