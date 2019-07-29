using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteCastingMachineFurnaceMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteCastingMachineFurnaceDao = new DeleteCastingMachineFurnaceMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteCastingMachineFurnaceDao.Execute(trxContext, vo);

        }
    }
}
