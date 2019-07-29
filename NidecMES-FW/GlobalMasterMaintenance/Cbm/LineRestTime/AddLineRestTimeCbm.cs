using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Linq;
namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddLineRestTimeCbm : CbmController
    {
        private readonly CbmController deleteLineRestTimeMasterMntCbm = new DeleteLineRestTimeMasterMntCbm();

        private readonly CbmController addLineRestTimeMasterMntCbm = new AddLineRestTimeMasterMntCbm();
        
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ValueObjectList<LineRestTimeVo> inVo = (ValueObjectList<LineRestTimeVo>)vo;

            UpdateResultVo outVo = new UpdateResultVo();

            UpdateResultVo deleteVo = (UpdateResultVo)deleteLineRestTimeMasterMntCbm.Execute(trxContext, inVo.GetList()[0]);

            foreach (LineRestTimeVo currentVo in inVo.GetList())
            {
                if (currentVo.PlanRestMinutes != null && currentVo.PlanRestMinutes != 0)
                {
                    UpdateResultVo resultVo = (UpdateResultVo)addLineRestTimeMasterMntCbm.Execute(trxContext, currentVo);
                    outVo.AffectedCount = resultVo.AffectedCount;
                }
            }

            return outVo;

        }
    }
}
