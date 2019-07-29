using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddInspectionItemMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addInspectionItemMasterMntDao = new AddInspectionItemMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addInspectionItemMasterMntDao.Execute(trxContext, vo);

        }
    }
}
