using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class UpdatePaletteMasterMntCbm : CbmController
    {

        private readonly DataAccessObject updatePaletteDao = new UpdatePaletteMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updatePaletteDao.Execute(trxContext, vo);

        }
    }
}
