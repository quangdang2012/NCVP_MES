using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class ProcessWorkLocalSupplierForm : Com.Nidec.Mes.GlobalMasterMaintenance.FormCommonMaster
    {

        #region Variables

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(ProcessWorkLocalSupplierForm));

        #endregion

        #region Constructor

        /// <summary>
        /// constructor of the form
        /// </summary>
        public ProcessWorkLocalSupplierForm()
        {
            InitializeComponent();
        }
        #endregion

        #region PrivateMethods

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

        /// <summary>
        /// Loads Process Work
        /// </summary>
        private void LoadLocalSupplier()
        {
            LocalSupplierVo outVo = new LocalSupplierVo();

            try
            {
                outVo = (LocalSupplierVo)base.InvokeCbm(new GetLocalSupplierMasterMntCbm(), new LocalSupplierVo(), false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }

            ComboBind(Supplier_cmb, outVo.LocalSupplierListVo, "LocalSupplierName", "LocalSupplierId");
        }

        /// <summary>
        /// Get with processwork
        /// </summary>
        private void LoadProcessWork()
        {

            ProcessWorkLocalSupplierVo prWLSInVo = new ProcessWorkLocalSupplierVo();

            prWLSInVo.LocalSupplierId = Convert.ToInt32(Supplier_cmb.SelectedValue);

            ProcessWorkLocalSupplierVo prWLSOutVo = new ProcessWorkLocalSupplierVo();

            try
            {
                prWLSOutVo = (ProcessWorkLocalSupplierVo)base.InvokeCbm(new GetProcessWorkLocalSupplierMasterMntCbm(), prWLSInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }

        }

        /// <summary>
        /// Creates seacrh condition as per user inputs 
        /// </summary>
        /// <returns>search condition</returns>
        private ProcessWorkLocalSupplierVo FormConditionVo()
        {
            ProcessWorkLocalSupplierVo inVo = new ProcessWorkLocalSupplierVo();

            if (Supplier_cmb.SelectedIndex > -1)
            {
                inVo.LocalSupplierId = Convert.ToInt32(Supplier_cmb.SelectedValue);
            }

            return inVo;
        }

        /// <summary>
        /// Fills all user records to gridview control
        /// </summary>
        private void GridBind(ProcessWorkLocalSupplierVo conditionInVo)
        {
            ProcessWork_dgv.DataSource = null;

            try
            {
                ProcessWorkLocalSupplierVo outVo = (ProcessWorkLocalSupplierVo)base.InvokeCbm(new GetProcessWorkLocalSupplierMasterMntCbm(), conditionInVo, false);

                ProcessWork_dgv.AutoGenerateColumns = false;

                outVo.ProcessWorkLocalSupplierListVo.ForEach(t => t.IsExists = t.LocalSupplierId > 0 ? "True" : "False");

                BindingSource bindingSource1 = new BindingSource(outVo.ProcessWorkLocalSupplierListVo, null);

                if (bindingSource1.Count > 0)
                {
                    ProcessWork_dgv.DataSource = bindingSource1;
                }
                else
                {
                    messageData = new MessageData("mmci00006", Properties.Resources.mmci00006, null); //item process work
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                }

                ProcessWork_dgv.ClearSelection();

            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// Checks mandatory fields
        /// </summary>
        /// <returns></returns>
        private bool CheckMandatory()
        {

            if (Supplier_cmb.Text == string.Empty || Supplier_cmb.SelectedIndex < 0)
            {
                messageData = new MessageData("mmce00002", Properties.Resources.mmce00002, Supplier_lbl.Text);
                popUpMessage.Warning(messageData, Text);

                Supplier_cmb.Focus();

                return false;
            }

            return true;
        }
        #endregion

        #region FormEvents
        /// <summary>
        /// form loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessWorkLocalSupplierForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadLocalSupplier();
            Cursor.Current = Cursors.Default;
            Supplier_cmb.Select();
        }
        #endregion

        #region ButtonClick

        /// <summary>
        /// event to get the record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (CheckMandatory())
            { GridBind(FormConditionVo()); }
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// event to clear the controls of search criteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            Supplier_cmb.SelectedIndex = -1;
            ProcessWork_dgv.DataSource = null;
        }
        /// <summary>
        /// updates process work local supplier
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessWorkLocalSupplierVo outVo;
                Cursor.Current = Cursors.WaitCursor;
                if (CheckMandatory() && ProcessWork_dgv.RowCount > 0)
                {

                    foreach (DataGridViewRow row in ProcessWork_dgv.Rows)
                    {
                        outVo = new ProcessWorkLocalSupplierVo();

                        ProcessWorkLocalSupplierVo checkInVo = new ProcessWorkLocalSupplierVo
                        {
                            LocalSupplierId = Convert.ToInt32(Supplier_cmb.SelectedValue.ToString())
                        };

                        ProcessWorkLocalSupplierVo checkOutVo = (ProcessWorkLocalSupplierVo)base.InvokeCbm(new GetProcessWorkLocalSupplierMasterMntCbm(), checkInVo, false);

                        bool isExists = checkOutVo.ProcessWorkLocalSupplierListVo.Any(t => t.LocalSupplierId > 0 && t.ProcessWorkId == Convert.ToInt32(row.Cells["colProcessWorkId"].Value.ToString()));

                        ProcessWorkLocalSupplierVo processWorkSupInVo = new ProcessWorkLocalSupplierVo
                        {
                            LocalSupplierId = Convert.ToInt32(Supplier_cmb.SelectedValue.ToString()),
                            ProcessWorkId = Convert.ToInt32(row.Cells["colProcessWorkId"].Value.ToString()),
                            RegistrationUserCode = UserData.GetUserData().UserCode,
                            FactoryCode = UserData.GetUserData().FactoryCode
                        };

                        if (row.Cells["colSelect"].Value.ToString() == "True" && !isExists)
                        {
                            outVo = (ProcessWorkLocalSupplierVo)base.InvokeCbm(new AddProcessWorkLocalSupplierMasterMntCbm(), processWorkSupInVo, false);
                        }
                        else if (row.Cells["colSelect"].Value.ToString() == "False" && isExists)
                        {
                            outVo = (ProcessWorkLocalSupplierVo)base.InvokeCbm(new DeleteProcessWorkLocalSupplierMasterMntCbm(), processWorkSupInVo, false);
                        }
                    }

                    Cursor.Current = Cursors.Default;
                    messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
                    logger.Info(messageData);
                    popUpMessage.Information(messageData, Text);
                    Cursor.Current = Cursors.WaitCursor;
                    GridBind(FormConditionVo());
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// close form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
