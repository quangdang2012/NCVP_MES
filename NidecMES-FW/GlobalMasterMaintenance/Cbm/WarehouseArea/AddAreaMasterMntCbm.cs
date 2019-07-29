using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddAreaMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addAreaDao = new AddAreaMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addAreaDao.Execute(trxContext, vo);
        }
    }
}
