using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddInventoryReasonMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addInventoryReasonMasterMntDao = new AddInventoryReasonMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addInventoryReasonMasterMntDao.Execute(trxContext, vo);

        }
    }
}
