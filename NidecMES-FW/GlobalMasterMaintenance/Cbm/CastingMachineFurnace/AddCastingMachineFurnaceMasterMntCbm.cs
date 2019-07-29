using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddCastingMachineFurnaceMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addCastingMachineFurnaceDao = new AddCastingMachineFurnaceMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addCastingMachineFurnaceDao.Execute(trxContext, vo);

        }
    }
}
