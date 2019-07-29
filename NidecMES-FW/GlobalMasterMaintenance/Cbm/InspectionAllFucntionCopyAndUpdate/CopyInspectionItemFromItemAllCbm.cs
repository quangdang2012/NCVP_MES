using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CopyInspectionItemFromItemAllCbm : CbmController
    {
        private readonly CbmController getInspectionItemChildCbm = new GetInspectionItemChildCbm();

        private readonly CbmController getInspectionItemSeqCbm = new GetInspectionItemSeqCbm();

        private CbmController copyInspectionFormatMasterMntCbm = null;

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            InspectionReturnVo outVo = new InspectionReturnVo();
            InspectionReturnVo copyChildVo = null;

            ValueObjectList<ValueObject> inListVo = (ValueObjectList<ValueObject>)vo;
            if (inListVo == null || inListVo.GetList() == null || inListVo.GetList().Count == 0)
            {
                return outVo;
            }

            InspectionItemVo updateitemVo = (InspectionItemVo)inListVo.GetList()[2];
            InspectionItemSelectionDatatypeValueVo updateSelectionDataTypeValueVo = (InspectionItemSelectionDatatypeValueVo)inListVo.GetList()[3];
            copyInspectionFormatMasterMntCbm = new CopyInspectionFormatMasterMntCbm();

            outVo = (InspectionReturnVo)copyInspectionFormatMasterMntCbm.Execute(trxContext, vo);

            updateitemVo.InspectionItemId = outVo.InspectionItemId;
            //copyChildItemsExist(trxContext, updateitemVo);

            InspectionItemVo childInVo = new InspectionItemVo();
            childInVo.ParentInspectionItemId = updateitemVo.InspectionItemIdCopy;

            ValueObjectList<InspectionItemVo> childOutVo = (ValueObjectList<InspectionItemVo>)getInspectionItemChildCbm.Execute(trxContext, childInVo);
            
            if (childOutVo != null && childOutVo.GetList() != null && childOutVo.GetList().Count > 0)
            {
                int RunningNumber = 1;
                InspectionItemVo inVo = new InspectionItemVo();
                //inVo.ParentInspectionItemId = updateitemVo.InspectionItemId;
                inVo.InspectionProcessId = updateitemVo.InspectionProcessId;

                InspectionItemVo getRunningNoVo = (InspectionItemVo)getInspectionItemSeqCbm.Execute(trxContext, inVo);
                if (getRunningNoVo != null && getRunningNoVo.InspectionItemCode != null)
                {
                    string strTemp;
                    strTemp = getRunningNoVo.InspectionItemCode;
                    if (strTemp.LastIndexOf(GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue()) > 0)
                    {
                        strTemp = strTemp.Substring(strTemp.LastIndexOf(GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue()) + 1);
                        if (strTemp.All(Char.IsDigit))
                        {
                            RunningNumber = Convert.ToInt32(strTemp) + 1;
                        }
                    }
                }

                int displyOrd = 0;
                foreach (InspectionItemVo itmVo in childOutVo.GetList())
                {
                    displyOrd += 1;
                    itmVo.ParentInspectionItemId = updateitemVo.InspectionItemId;
                    itmVo.InspectionItemIdCopy = itmVo.InspectionItemId;
                    itmVo.InspectionProcessCode = updateitemVo.InspectionProcessCode;
                    itmVo.DisplayOrder = displyOrd;

                    itmVo.InspectionItemCode = updateitemVo.InspectionProcessCode + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() +
                                                    GlobalMasterDataTypeEnum.ITEM_CODE.GetValue() + GlobalMasterDataTypeEnum.CODE_SEPARATOR.GetValue() + RunningNumber;

                    inListVo.GetList()[2] = itmVo;

                    copyInspectionFormatMasterMntCbm = new CopyInspectionFormatMasterMntCbm();
                    copyChildVo = (InspectionReturnVo)copyInspectionFormatMasterMntCbm.Execute(trxContext, inListVo);
                    RunningNumber += 1;
                }
            }

            if(copyChildVo != null)
            {
                return copyChildVo;
            }
            return outVo;
        }       

    }
}

