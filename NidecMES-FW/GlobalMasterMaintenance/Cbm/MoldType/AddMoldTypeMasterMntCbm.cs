using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddMoldTypeMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addMoldTypeDao = new AddMoldTypeMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addMoldTypeDao.Execute(trxContext, vo);

        }
    }
}
