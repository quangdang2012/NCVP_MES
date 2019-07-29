using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddMoldMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addMoldDao = new AddMoldMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return addMoldDao.Execute(trxContext, vo);

        }
    }
}
