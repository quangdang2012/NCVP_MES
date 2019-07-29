using System.Collections.Generic;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Linq;
namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddUpdateLineItemCycleTimeMasterMntCbm : CbmController
    {
        //private readonly CbmController getLineItemCycleTimeMasterMntCbm = new GetLineItemCycleTimeMasterMntCbm(); 
        private readonly CbmController getLineItemCycleTimeMasterCbm = new GetLineItemCycleTimeMasterCbm(); 

        private readonly CbmController addLineItemCycleTimeMasterMntCbm = new AddLineItemCycleTimeMasterMntCbm();

        //private readonly CbmController updateLineItemCycleTimeMasterMntCbm = new UpdateLineItemCycleTimeMasterMntCbm();
        private readonly CbmController deleteLineItemCycleTimeMasterMntCbm = new DeleteLineItemCycleTimeMasterMntCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            List<ValueObject> inList = ((ValueObjectList<ValueObject>)vo).GetList();

            LineItemCycleTimeVo deleteInVo = (LineItemCycleTimeVo)inList.FirstOrDefault();
            ValueObjectList<LineItemCycleTimeVo> addInVo = (ValueObjectList<LineItemCycleTimeVo>)inList.Skip(1).FirstOrDefault(); ;
            //ValueObjectList<LineItemCycleTimeVo> inVo = new ValueObjectList<LineItemCycleTimeVo>();
            UpdateResultVo outVo = new UpdateResultVo();

            UpdateResultVo resultVo = (UpdateResultVo)deleteLineItemCycleTimeMasterMntCbm.Execute(trxContext, deleteInVo);

            if(addInVo !=null && addInVo.GetList() !=null && addInVo.GetList().Count>0)
            {
                foreach (LineItemCycleTimeVo currentVo in addInVo.GetList())
                {
                    resultVo = (UpdateResultVo)addLineItemCycleTimeMasterMntCbm.Execute(trxContext, currentVo);

                    outVo.AffectedCount = resultVo.AffectedCount;
                }
                return outVo;
            }


            return outVo;

        }
    }
}
