using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddAuthorityControlMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addAuthorityControlDao = new AddAuthorityControlMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addAuthorityControlDao.Execute(trxContext, vo);

        }
    }
}
