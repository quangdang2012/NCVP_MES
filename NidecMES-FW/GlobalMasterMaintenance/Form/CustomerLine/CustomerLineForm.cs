using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class CustomerLineForm
    {

        #region Variables

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(CustomerLineForm));

        /// <summary>
        ///  get message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// initialize SortOrder
        /// </summary>
        private SortOrder sortDirection;

        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public CustomerLineForm()
        {
            InitializeComponent();
        }

        #endregion

        #region PrivateMethods

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind()
        {
            Customer_dgv.DataSource = null;
            CustomerLineVo outVo = null;
            CustomerLineVo inVo = new CustomerLineVo();
            inVo.CustomerId = Convert.ToInt32(CustomerLine_cmb.SelectedValue);
            inVo.LineId = Convert.ToInt32(Line_cmb.SelectedValue);
            try
            {
                outVo = (CustomerLineVo)DefaultCbmInvoker.Invoke(new GetCustomerLineCbm(),inVo);
                Customer_dgv.AutoGenerateColumns = false;
                Customer_dgv.DataSource = outVo.customerLineListVo;
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            
            BindingSource CustomerLineBindingSource = new BindingSource(outVo.customerLineListVo, null);
            if (CustomerLineBindingSource.Count == 0)
            {
                messageData = new MessageData("mmci00006", Properties.Resources.mmci00006);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
                return;
            }
            Customer_dgv.ClearSelection();
        }
    
        private DataGridViewRow GetCustomerData()
        {
            int selectedrowindex = Customer_dgv.SelectedCells[0].RowIndex;

            return Customer_dgv.Rows[selectedrowindex];
        }
        /// <summary>
        /// binds datasource
        /// </summary>
        /// <param name="outVo"></param>
        private void BindDataSource(List<CustomerLineVo> outVo)
        {
            Customer_dgv.AutoGenerateColumns = false;
            BindingSource bindingSource1 = new BindingSource(outVo, null);

            if (bindingSource1 != null && bindingSource1.Count > 0)
            {
                Customer_dgv.DataSource = bindingSource1;
            }
            else
            {
                messageData = new MessageData("tpci00006", Properties.Resources.mmci00006, null);
                logger.Info(messageData);
                popUpMessage.Information(messageData, Text);
            }
            Customer_dgv.ClearSelection();
        }
        #endregion


        #region FormEvents
        /// <summary>
        /// form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private readonly GetCustomerLineCbm getGetCustomerLineCbm = new GetCustomerLineCbm();

        private void CustomerLineForm_Load(object sender, EventArgs e)
        {
            GetCustomerInfomation();
            GetLineInfomation();
        }
        #endregion
        private void GetCustomerInfomation()
        {
            CustomerVo customerinVo = new CustomerVo();
            CustomerVo customeroutVo = new CustomerVo();
            customerinVo.FactoryCode = UserData.GetUserData().FactoryCode;
            try
            {
                customeroutVo = (CustomerVo)DefaultCbmInvoker.Invoke(new GetCustomerMasterMntCbm(), customerinVo);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            if (customeroutVo != null && customeroutVo.CustomerListVo.Count > 0)
            {
                ComboBind(CustomerLine_cmb, customeroutVo.CustomerListVo, "CustomerName", "CustomerId");
            }
        }
        private void GetLineInfomation()
        {
            LineVo lineinVo = new LineVo();
            LineVo lineoutVo = new LineVo();
            lineinVo.FactoryCode = UserData.GetUserData().FactoryCode;
            try
            {
                lineoutVo = (LineVo)DefaultCbmInvoker.Invoke(new GetLineMasterMntCbm(), lineinVo);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
            if (lineoutVo != null && lineoutVo.LineListVo.Count > 0)
            {
                ComboBind(Line_cmb, lineoutVo.LineListVo, "LineName", "LineId");
            }
        }

        /// <summary>
        /// For binding combo box
        /// </summary>
        /// <param name="pCombo"></param>
        /// <param name="pDatasource"></param>
        /// <param name="pDisplay"></param>
        /// <param name="pValue"></param>
        private void ComboBind<T>(ComboBox pCombo, List<T> pDatasource, string pDisplay, string pValue)
        {
            pCombo.DataSource = pDatasource;
            pCombo.DisplayMember = pDisplay;
            pCombo.ValueMember = pValue;
            pCombo.SelectedIndex = -1;
            pCombo.Text = string.Empty;
        }
        private void Search_btn_Click(object sender, EventArgs e)
        {
            GridBind();
        }
        private void CustomerLine_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            CustomerLine_cmb.SelectedIndex = -1;
            Line_cmb.SelectedIndex = -1;
            CustomerLine_cmb.Text = string.Empty;
            Line_cmb.Text = string.Empty;
            Customer_dgv.DataSource = null;
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}