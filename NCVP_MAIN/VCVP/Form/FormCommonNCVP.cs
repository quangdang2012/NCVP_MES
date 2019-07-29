using Com.Nidec.Mes.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Form
{
    public partial class FormCommonNCVP : Com.Nidec.Mes.Framework.FormCommon
    {
        public FormCommonNCVP()
        {
            InitializeComponent();
        }


        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        protected static PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        public CommonLogger logger;

        /// <summary>
        /// initialize message data
        /// </summary>
        protected static MessageData messageData;
        private void FormCommonNCVP_Load(object sender, EventArgs e)
        {
            logger = CommonLogger.GetInstance(this.GetType());
            this.UserName_lbl.Text += "(" + UserData.GetUserData().UserCode + ")" + UserData.GetUserData().UserName;
            this.FactoryCode_lbl.Text += UserData.GetUserData().FactoryCode;
            this.Title_lbl.Text = Text;
        }
    }
}
