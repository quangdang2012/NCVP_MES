using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetGlobalItemByItemCbm : CbmController
    {
        private readonly DataAccessObject getGlobalItemByItemDao = new GetGlobalItemByItemDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getGlobalItemByItemDao.Execute(trxContext, vo);

        }
    }
}
