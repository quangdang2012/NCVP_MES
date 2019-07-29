using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteInspectionFormatAndItemLineMasterMntCbm : CbmController
    {

        private readonly CbmController deleteInspectionFormatcbm = new DeleteInspectionFormatMasterMntCbm();
        private readonly CbmController deleteItemLineInspectionFormatMasterMntCbm = new DeleteItemLineInspectionFormatMasterMntCbm();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            InspectionFormatVo inVo = (InspectionFormatVo)vo;

            UpdateResultVo OutVo = new UpdateResultVo();

            OutVo  = (UpdateResultVo)deleteInspectionFormatcbm.Execute(trxContext, inVo);
            if(OutVo != null && OutVo.AffectedCount > 0)
            {
                ItemLineInspectionFormatVo itemlineInVo = new ItemLineInspectionFormatVo();
                itemlineInVo.InspectionFormatId = inVo.InspectionFormatId; 
                return deleteItemLineInspectionFormatMasterMntCbm.Execute(trxContext, itemlineInVo);
            }
            return OutVo;
        }
    }
}
