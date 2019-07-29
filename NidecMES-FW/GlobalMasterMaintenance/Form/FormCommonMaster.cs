using System;
using System.Reflection;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Resources;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class FormCommonMaster
    {
        /// <summary>
        /// initialize MasterMntCommonCbm
        /// </summary>
        private static readonly MasterMntCommonCbm commonCbm=new MasterMntCommonCbm();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(FormCommonMaster));
       
        /// <summary>
        /// invokes respective cbm
        /// </summary>
        /// <param name="userCbm"></param>
        /// <param name="userVo"></param>
        /// <param name="isLogging"></param>
        /// <returns></returns>
        public ValueObject InvokeCbm(CbmController userCbm, ValueObject userVo, bool isLogging)
        {
 
            MasterMntCommonInVo commonInVo = new MasterMntCommonInVo();
            commonInVo.TargetCbm = userCbm;
            commonInVo.TargetInVo = userVo;
            commonInVo.IsLogging = isLogging;

            return DefaultCbmInvoker.Invoke(commonCbm, commonInVo);
        }


        /// <summary>
        /// constructor
        /// </summary>
        public FormCommonMaster()
        {
            InitializeComponent();

        }

        /// <summary>
        /// form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCommonMaster_Load(object sender, EventArgs e)
        {
            
            MessageData messageData = new MessageData("mmci00004", Properties.Resources.mmci00004, 
                                                    new string[] { MethodBase.GetCurrentMethod().ToString() , this.Text , UserData.GetUserData().UserName } );
            logger.Info(messageData);

        }
       
        /// <summary>
        /// form close event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCommonMaster_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageData messageData = new MessageData("mmci00005", Properties.Resources.mmci00005,
                                                    new string[] { MethodBase.GetCurrentMethod().ToString(), this.Text, UserData.GetUserData().UserName });
            logger.Info(messageData);
        }

    }
}
