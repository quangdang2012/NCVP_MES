using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddGetMoldIdMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addMoldDao = new AddGetMoldIdMasterMntDao();
        
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return addMoldDao.Execute(trxContext, vo);

        }
    }
}
