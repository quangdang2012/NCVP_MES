using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class GetCurrentServerDateTimeCbm : CbmController
    {


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            DateTimeVo outVo = new DateTimeVo();
            outVo.CurrentDateTime = trxContext.ProcessingDBDateTime;

            return outVo;

        }
    }
}
