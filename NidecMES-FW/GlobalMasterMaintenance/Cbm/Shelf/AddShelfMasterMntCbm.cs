using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddShelfMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addShelfDao = new AddShelfMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addShelfDao.Execute(trxContext, vo);
        }
    }
}
