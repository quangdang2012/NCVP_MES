using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class CheckLocalSupplierRelationCbm : CbmController
    {

        private readonly DataAccessObject checkLocalSupplierRelationDao = new CheckLocalSupplierRelationDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkLocalSupplierRelationDao.Execute(trxContext, vo);

        }
    }
}
