using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdateCavityMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updateCavityDao = new UpdateCavityMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateCavityDao.Execute(trxContext, vo);

        }
    }
}
