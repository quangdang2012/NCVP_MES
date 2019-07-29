using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeletePaletteMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deletePaletteDao = new DeletePaletteMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deletePaletteDao.Execute(trxContext, vo);

        }
    }
}
