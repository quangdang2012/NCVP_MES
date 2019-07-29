using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddInspectionFormatAndItemLineFormatCbm : CbmController
    {

        private readonly CbmController addInspectionFormatCbm = new AddInspectionFormatMasterMntCbm();
        private readonly CbmController getInspectionFormatLastRecordforSerailNoMasterMnt = new GetInspectionFormatLastRecordforSerailNoMasterMntCbm();
        private readonly CbmController addItemLineInspectionFormatMasterMntCbm = new AddItemLineInspectionFormatMasterMntCbm();
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            InspectionFormatVo inVo = (InspectionFormatVo)vo;
            InspectionFormatVo OutVo = null;
            int SerialNumber = 1;
            InspectionFormatVo getseqVo = (InspectionFormatVo)getInspectionFormatLastRecordforSerailNoMasterMnt.Execute(trxContext, vo);
            if (getseqVo != null && getseqVo.InspectionFormatCode != null)
            {
                string[] splitval = getseqVo.InspectionFormatCode.Split(Convert.ToChar(GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue()));
                if (splitval.Length > 3)
                {
                    if (splitval[splitval.Length - 1].All(Char.IsDigit))
                    {
                        SerialNumber = Convert.ToInt32(splitval[splitval.Length - 1]) + 1;
                    }                   
                }
            }
            inVo.InspectionFormatCode = inVo.InspectionFormatCode + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() + SerialNumber.ToString().PadLeft(5, '0');
            inVo.InspectionFormatSeq = getseqVo.InspectionFormatSeq;
            InspectionFormatVo returnformatidVo = (InspectionFormatVo)addInspectionFormatCbm.Execute(trxContext, inVo);
            if (returnformatidVo != null && returnformatidVo.InspectionFormatId > 0)
            {
                ItemLineInspectionFormatVo itemlineInVo = new ItemLineInspectionFormatVo();
                itemlineInVo.InspectionFormatId = returnformatidVo.InspectionFormatId;
                itemlineInVo.SapItemCode = inVo.SapItemCode;
                itemlineInVo.LineId = inVo.LineId;
                ItemLineInspectionFormatVo ItemlineOutVo = (ItemLineInspectionFormatVo)addItemLineInspectionFormatMasterMntCbm.Execute(trxContext, itemlineInVo);
                if (ItemlineOutVo != null)
                {
                    OutVo = new InspectionFormatVo();
                    OutVo.AffectedCount = ItemlineOutVo.AffectedCount;
                    OutVo.InspectionFormatId = returnformatidVo.InspectionFormatId;
                    OutVo.InspectionFormatCode = inVo.InspectionFormatCode;
                }
            }
            return OutVo;
        }
    }
}
