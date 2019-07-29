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
    public partial class CustomerLineMasterForm
    {
        #region PrivateVariables

        /// <summary>
        /// initialize vo
        /// </summary>      
        private readonly LineVo linInVo = new LineVo();

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
        private static readonly CommonLogger Logger = CommonLogger.GetInstance(typeof(CustomerLineMasterForm));

        #endregion

        #region Constructor
        public CustomerLineMasterForm()
        {
            InitializeComponent();
        }
        #endregion

        #region PrivateMethods

        /// <summary>
        /// Loads Customer
        /// </summary>
        private void LoadCustomer()
        {

            CustomerVo outVo = new CustomerVo();
            try
            {
                outVo = (CustomerVo)base.InvokeCbm(new GetCustomerMasterMntCbm(), new CustomerVo(), false);
                outVo.CustomerListVo.ForEach(p => p.CustomerName = p.CustomerCode + " " + p.CustomerName);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
                return;
            }

            ComboBind(Customer_cmb, outVo.CustomerListVo, "CustomerName", "CustomerId");

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

        /// <summary>
        /// Binds tree view 
        /// </summary>
        /// <param name="prcWrkList"></param>
        private void PopulateTreeView(List<CustomerVo> prcWrkList)
        {

            LineVo linOutVo = new LineVo();

            try
            {
                linOutVo = (LineVo)base.InvokeCbm(new GetLineMasterMntCbm(), linInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
                return;
            }

            CustomerLineDetails_tv.Nodes.Clear();

            TreeNode[] headerNode = new TreeNode[prcWrkList.Count];

            int i = 0;

            foreach (CustomerVo prcW in prcWrkList)
            {
                TreeNode child = new TreeNode
                {
                    Text = prcW.CustomerCode + " " + prcW.CustomerName,
                    Tag = prcW.CustomerId
                };

                headerNode[i] = child;

                int childNodes = linOutVo.LineListVo.Count;

                TreeNode[] rootNodes = new TreeNode[childNodes];

                int node = 0;

                CustomerLineVo inVo = new CustomerLineVo();
                inVo.CustomerId = Convert.ToInt32(Customer_cmb.SelectedValue);
                CustomerLineVo prcDefRsnOutVo = new CustomerLineVo();

                try
                {
                    prcDefRsnOutVo = (CustomerLineVo)base.InvokeCbm(new GetCustomerLineMasterMntCbm(), inVo, false);
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    Logger.Error(exception.GetMessageData());
                    return;
                }

                foreach (LineVo dfrVo in linOutVo.LineListVo)
                {
                    TreeNode rootChild = new TreeNode
                    {
                        Text = dfrVo.LineCode + " " + dfrVo.LineName,
                        Tag = dfrVo.LineId
                    };

                    List<CustomerLineVo> prcDefRsnList = prcDefRsnOutVo.customerLineListVo.Where(t => t.CustomerId == Convert.ToInt32(child.Tag)).ToList();

                    foreach (CustomerLineVo prDfRsnVo in prcDefRsnList)
                    {
                        if (prDfRsnVo.LineId == Convert.ToInt32(rootChild.Tag))
                        {
                            rootChild.Checked = true;
                        }
                    }

                    rootNodes[node] = rootChild;

                    headerNode[i].Nodes.Add(rootNodes[node]);

                    node += 1;
                }

                CustomerLineDetails_tv.Nodes.Add(headerNode[i]);

                i += 1;
            }
            if (CustomerLineDetails_tv.Nodes.Count > 0) Update_btn.Enabled = true;
        }

        /// <summary>
        /// Add new customer line
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="lineId"></param>
        private int AddCustomerLine(int customerId, int lineId)
        {
            CustomerLineVo prWDefInVo = new CustomerLineVo
            {
                CustomerId = customerId,
                LineId = lineId,
                //RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                RegistrationUserCode = UserData.GetUserData().UserCode,
                FactoryCode = UserData.GetUserData().FactoryCode
            };
            CustomerLineVo outVo = null;
            try
            {
                outVo = (CustomerLineVo)base.InvokeCbm(new AddCustomerLineMasterMntCbm(), prWDefInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
            }
            if (outVo != null & outVo.AffectedCount > 0)
            {
                return outVo.AffectedCount;
            }
            return 0;
        }

        /// <summary>
        /// Delete customer line
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="lineId"></param>
        private int DeleteCustomerLine(int customerId, int lineId)
        {
            CustomerLineVo delInVo = new CustomerLineVo
            {
                CustomerId = customerId,
                LineId = lineId
            };
            CustomerLineVo delOutVo = null;
            try
            {
                delOutVo = (CustomerLineVo)base.InvokeCbm(new DeleteCustomerLineMasterMntCbm(), delInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
            }
            if (delOutVo != null && delOutVo.AffectedCount > 0)
            {
                return delOutVo.AffectedCount;
            }
            return 0;
        }

        /// <summary>
        /// binds treeview with customer line details
        /// </summary>
        private void BindTreeView()
        {
            CustomerVo prWInVo = new CustomerVo();

            if (Customer_cmb.SelectedIndex > -1)
            {
                //prWInVo.CustomerName = Convert.ToString(Customer_cmb.SelectedText);
                prWInVo.CustomerId = Convert.ToInt32(Customer_cmb.SelectedValue);
            }

            CustomerVo prWOutVo = new CustomerVo();

            try
            {
                prWOutVo = (CustomerVo)base.InvokeCbm(new GetCustomerMasterMntCbm(), prWInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
                return;
            }

            PopulateTreeView(prWOutVo.CustomerListVo);
        }


        #endregion

        #region FormEvents
        /// <summary>
        /// for loads customer and binds treeview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerLineMasterForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadCustomer();

            //BindTreeView();
            Cursor.Current = Cursors.Default;
            Customer_cmb.Select();
        }
        #endregion

        #region ButtonClick
        /// <summary>
        /// search button click, binds treeview with customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            BindTreeView();
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// updates customer line
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (CustomerLineDetails_tv.Nodes.Count == 0) return;
            int prcDefCount;
            int prcWrkId;
            int defRsnId;
            int resultcnt = 0;
            Cursor.Current = Cursors.WaitCursor;
            TreeNodeCollection nodes = CustomerLineDetails_tv.Nodes;

            CustomerLineVo prcDefCheckVo = new CustomerLineVo();

            try
            {
                prcDefCheckVo = (CustomerLineVo)base.InvokeCbm(new GetCustomerLineMasterMntCbm(), new CustomerLineVo(), false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
                return;
            }

            foreach (TreeNode tn in nodes)
            {
                foreach (TreeNode child in tn.Nodes)
                {
                    //Check customer line is already added.
                    prcWrkId = Convert.ToInt32(tn.Tag.ToString());

                    defRsnId = Convert.ToInt32(child.Tag.ToString());

                    prcDefCount = prcDefCheckVo.customerLineListVo.Where(t => t.CustomerId == prcWrkId && t.LineId == defRsnId).Count();

                    if (child.Checked)
                    {
                        if (prcDefCount == 0)
                        {
                            resultcnt += AddCustomerLine(prcWrkId, defRsnId);
                        }
                    }
                    else
                    {
                        if (prcDefCount == 1)
                        {
                            resultcnt += DeleteCustomerLine(prcWrkId, defRsnId);
                        }
                    }
                }
            }
            if (resultcnt == 0) return;
            Cursor.Current = Cursors.Default;
            messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
            Logger.Info(messageData);
            popUpMessage.Information(messageData, Text);
        }

        /// <summary>
        /// clears input controls and grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            CustomerLineDetails_tv.Nodes.Clear();

            Customer_cmb.SelectedIndex = -1;
            Customer_cmb.Text = string.Empty;
            Update_btn.Enabled = false;
        }

        /// <summary>
        /// closes form on exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region ControlEvents
        /// <summary>
        /// draws tree view button to '+' 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerLineDetails_tv_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                int d = (int)(0.2 * e.Bounds.Height);
                Rectangle rect = new Rectangle(d + CustomerLineDetails_tv.Margin.Left, d + e.Bounds.Top, e.Bounds.Height - d * 2, e.Bounds.Height - d * 2);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromKnownColor(KnownColor.Control)), rect);
                e.Graphics.DrawRectangle(Pens.Silver, rect);
                StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
                e.Graphics.DrawString(e.Node.IsExpanded ? "-" : "+", CustomerLineDetails_tv.Font, new SolidBrush(Color.Blue), rect, sf);
                //Draw the dotted line connecting the expanding/collapsing button and the node Text
                using (Pen dotted = new Pen(Color.Black) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dot })
                {
                    e.Graphics.DrawLine(dotted, new Point(rect.Right + 1, rect.Top + rect.Height / 2), new Point(rect.Right + 4, rect.Top + rect.Height / 2));
                }
                //Draw text
                sf.Alignment = StringAlignment.Near;
                Rectangle textRect = new Rectangle(e.Bounds.Left + rect.Right + 4, e.Bounds.Top, e.Bounds.Width - rect.Right - 4, e.Bounds.Height);
                if (e.Node.IsSelected)
                {
                    SizeF textSize = e.Graphics.MeasureString(e.Node.Text, CustomerLineDetails_tv.Font);
                    e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight), new RectangleF(textRect.Left, textRect.Top, textSize.Width, textRect.Height));
                }
                e.Graphics.DrawString(e.Node.Text, CustomerLineDetails_tv.Font, new SolidBrush(CustomerLineDetails_tv.ForeColor), textRect, sf);
            }
            else e.DrawDefault = true;
        }

        /// <summary>
        /// handles treeview node click and set parent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerLineDetails_tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                CustomerLineDetails_tv.SelectedNode = e.Node;
            }
        }

        #endregion

    }
}
