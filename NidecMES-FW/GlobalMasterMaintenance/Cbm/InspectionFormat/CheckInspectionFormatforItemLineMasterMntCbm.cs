using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckInspectionFormatforItemLineMasterMntCbm : CbmController
    {

        //private readonly CbmController checkInspectionFormatCbm = new CheckInspectionFormatMasterMntCbm();
        private readonly CbmController checkItemLineInspectionFormatMasterMntCbm = new CheckItemLineInspectionFormatMasterMntCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            InspectionFormatVo inVo = (InspectionFormatVo)vo;
            InspectionFormatVo OutVo = null;

            //InspectionFormatVo formatVo = (InspectionFormatVo)checkInspectionFormatCbm.Execute(trxContext, vo);
            //if(formatVo != null && formatVo.AffectedCount > 0)
            //{
            //    OutVo = new InspectionFormatVo();
            //    OutVo.AffectedCount = formatVo.AffectedCount;
            //    return OutVo;
            //}

            ItemLineInspectionFormatVo ItemlineinVo = new ItemLineInspectionFormatVo();

            ItemlineinVo.LineId = inVo.LineId;
            ItemlineinVo.SapItemCode = inVo.SapItemCode;
            
            ItemLineInspectionFormatVo itemlineVo = (ItemLineInspectionFormatVo)checkItemLineInspectionFormatMasterMntCbm.Execute(trxContext, ItemlineinVo);
            if (itemlineVo != null && itemlineVo.AffectedCount > 0)
            {
                OutVo = new InspectionFormatVo();
                OutVo.AffectedCount = itemlineVo.AffectedCount;
                return OutVo;
            }
            return OutVo;

        }
    }
}
