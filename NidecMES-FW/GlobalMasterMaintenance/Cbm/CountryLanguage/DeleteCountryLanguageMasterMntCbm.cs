using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteCountryLanguageMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteCountryLangDao = new DeleteCountryLanguageMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteCountryLangDao.Execute(trxContext, vo);

        }
    }
}
