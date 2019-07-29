using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddCavityMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addCavityDao = new AddCavityMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addCavityDao.Execute(trxContext, vo);
        }
    }
}
