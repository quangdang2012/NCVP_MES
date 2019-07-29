using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddLineWorkContentMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addLineWorkContentMasterMntDao = new AddLineWorkContentMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addLineWorkContentMasterMntDao.Execute(trxContext, vo);

        }
    }
}
