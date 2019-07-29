using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetCastingMachineFurnaceMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getCastingMachineFurnaceDao = new GetCastingMachineFurnaceMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getCastingMachineFurnaceDao.Execute(trxContext, vo);

        }
    }
}
