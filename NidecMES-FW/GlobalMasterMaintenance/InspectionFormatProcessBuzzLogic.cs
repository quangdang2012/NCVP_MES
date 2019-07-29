using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public class InspectionFormatProcessBuzzLogic
    {

        #region Variables

        /// <summary>
        /// get the instance of CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(InspectionFormatProcessBuzzLogic));

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();


        #endregion

        #region PrivateMethods
        /// <summary>
        /// To get the Format Id based on Process id
        /// </summary>
        /// <param name="inspectionprocessid"></param>
        /// <returns></returns>
        public InspectionFormatVo getFormatDetails(CopyInspectionFormatVo inVo)
        {
            InspectionFormatVo outVo = null;
            try
            {
                outVo = (InspectionFormatVo)DefaultCbmInvoker.Invoke(new GetInspectionFormatDetailForCopyFunctionMasterMntCbm(), inVo);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), null);
                logger.Error(exception.GetMessageData());
            }
            if (outVo != null && outVo.InspectionFormatId > 0)
            {
                outVo.InspectionFormatCode = outVo.InspectionFormatCode.Substring(0, outVo.InspectionFormatCode.Length - 6);
                outVo.InspectionFormatIdCopy = outVo.InspectionFormatId;
            }
            return outVo;
        }

        /// <summary>
        /// 
        /// </summary>
        public void closeallforms()
        {
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (f.Name.Contains("Inspection") && f.Name != "InspectionFormatMasterForm")
                    f.Close();
            }
        }

        /// <summary>
        /// To get the Format Id based on Process id
        /// </summary>
        /// <param name="inspectionprocessid"></param>
        /// <returns></returns>
        public InspectionReturnVo RefreshAllFormGrid(InspectionReturnVo inVo)
        {
            InspectionReturnVo outVo = null;
            try
            {
                outVo = (InspectionReturnVo)DefaultCbmInvoker.Invoke(new GetAllInspectionIDMasterMntCbm(), inVo);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), null);
                logger.Error(exception.GetMessageData());
            }           
            return outVo;
        }

        #endregion

    }
}
