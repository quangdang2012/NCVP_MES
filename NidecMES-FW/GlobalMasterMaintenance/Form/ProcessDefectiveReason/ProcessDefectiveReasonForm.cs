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
    public partial class ProcessDefectiveReasonForm 
    {
        #region PrivateVariables

        /// <summary>
        /// initialize vo
        /// </summary>
        private readonly DefectiveReasonVo defInVo = new DefectiveReasonVo();

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
        private static readonly CommonLogger Logger = CommonLogger.GetInstance(typeof(ProcessDefectiveReasonForm));

        #endregion

        #region Constructor
        public ProcessDefectiveReasonForm()
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
        private void LoadProcessWork()
        {
            ProcessWorkVo outVo = new ProcessWorkVo();

            try
            {
                outVo = (ProcessWorkVo)base.InvokeCbm(new GetProcessWorkMasterMntCbm(), new ProcessWorkVo(), false);

                outVo.ProcessWorkListVo.ForEach(p => p.ProcessWorkName = p.ProcessWorkCode + " " + p.ProcessWorkName);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
                return;
            }

            ComboBind(ProcessWork_cmb, outVo.ProcessWorkListVo, "ProcessWorkName", "ProcessWorkId");
        }

        /// <summary>
        /// Binds tree view 
        /// </summary>
        /// <param name="prcWrkList"></param>
        private void PopulateTreeView(List<ProcessWorkVo> prcWrkList)
        {

            DefectiveReasonVo defOutVo = new DefectiveReasonVo();

            try
            {
                defOutVo = (DefectiveReasonVo)base.InvokeCbm(new GetDefectiveReasonMasterMntCbm(), defInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
                return;
            }

            ProcessDefectiveReasonDetails_tv.Nodes.Clear();

            TreeNode[] headerNode = new TreeNode[prcWrkList.Count];

            int i = 0;

            foreach (ProcessWorkVo prcW in prcWrkList)
            {
                TreeNode child = new TreeNode
                {
                    Text = prcW.ProcessWorkCode + " " + prcW.ProcessWorkName,
                    Tag = prcW.ProcessWorkId
                };

                headerNode[i] = child;

                int childNodes = defOutVo.DefectiveReasonListVo.Count;

                TreeNode[] rootNodes = new TreeNode[childNodes];

                int node = 0;
                

                ProcessDefectiveReasonVo prcDefRsnOutVo = new ProcessDefectiveReasonVo();

                try
                {
                    prcDefRsnOutVo = (ProcessDefectiveReasonVo)base.InvokeCbm(new GetProcessDefectiveReasonMasterMntCbm(), new ProcessDefectiveReasonVo(), false);
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    Logger.Error(exception.GetMessageData());
                    return;
                }

                foreach (DefectiveReasonVo dfrVo in defOutVo.DefectiveReasonListVo)
                {
                    TreeNode rootChild = new TreeNode
                    {
                        Text = dfrVo.DefectiveReasonCode + " " + dfrVo.DefectiveReasonName,
                        Tag = dfrVo.DefectiveReasonId
                    };

                    List<ProcessDefectiveReasonVo> prcDefRsnList = prcDefRsnOutVo.ProcessDefectiveReasonListVo.Where(t => t.ProcessWorkId == Convert.ToInt32(child.Tag)).ToList();

                    foreach (ProcessDefectiveReasonVo prDfRsnVo in prcDefRsnList)
                    {
                        if (prDfRsnVo.DefectiveReasonId == Convert.ToInt32(rootChild.Tag))
                        {
                            rootChild.Checked = true;
                        }
                    }

                    rootNodes[node] = rootChild;

                    headerNode[i].Nodes.Add(rootNodes[node]);

                    node += 1;
                }

                ProcessDefectiveReasonDetails_tv.Nodes.Add(headerNode[i]);

                i += 1;
            }
        }

        /// <summary>
        /// Adds new proess defect
        /// </summary>
        /// <param name="processId"></param>
        /// <param name="defectRsnId"></param>
        private void AddProcessDefectReason(int processId, int defectRsnId)
        {
            ProcessDefectiveReasonVo prWDefInVo = new ProcessDefectiveReasonVo
            {
                ProcessWorkId = processId,
                DefectiveReasonId = defectRsnId,
                //RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                RegistrationUserCode = UserData.GetUserData().UserCode,
                FactoryCode = UserData.GetUserData().FactoryCode
            };
            
            try
            {
                ProcessDefectiveReasonVo outVo = (ProcessDefectiveReasonVo)base.InvokeCbm(new AddProcessDefectiveReasonMasterMntCbm(), prWDefInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
                return;
            }
        }

        /// <summary>
        /// Deletes process defect
        /// </summary>
        /// <param name="prWId"></param>
        /// <param name="defRsnId"></param>
        private void DeleteProcessDefect(int prWId, int defRsnId)
        {
            ProcessDefectiveReasonVo delInVo = new ProcessDefectiveReasonVo
            {
                ProcessWorkId = prWId,
                DefectiveReasonId = defRsnId
            };

            ProcessDefectiveReasonVo delOutVo = new ProcessDefectiveReasonVo();

            try
            {
                delOutVo = (ProcessDefectiveReasonVo)base.InvokeCbm(new DeleteProcessDefectiveReasonMasterMntCbm(), delInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
                return;
            }
        }

        /// <summary>
        /// binds treeview with process def reason details
        /// </summary>
        private void BindTreeView()
        {
            ProcessWorkVo prWInVo = new ProcessWorkVo();

            if (ProcessWork_cmb.SelectedIndex > -1)
            {
                prWInVo.ProcessWorkId = Convert.ToInt32(ProcessWork_cmb.SelectedValue);
            }

            ProcessWorkVo prWOutVo = new ProcessWorkVo();

            try
            {
                prWOutVo = (ProcessWorkVo)base.InvokeCbm(new GetProcessWorkMasterMntCbm(), prWInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
                return;
            }

            PopulateTreeView(prWOutVo.ProcessWorkListVo);
        }


        #endregion

        #region FormEvents
        /// <summary>
        /// for load, loads process work and binds treeview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessDefectiveReasonForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadProcessWork();

            //BindTreeView();
            Cursor.Current = Cursors.Default;
            ProcessWork_cmb.Select();
        }
        #endregion

        #region ButtonClick
        /// <summary>
        /// search button click, binds treeview with process
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
        /// updates process defective reason
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            int prcDefCount;

            int prcWrkId;

            int defRsnId;
            Cursor.Current = Cursors.WaitCursor;
            TreeNodeCollection nodes = ProcessDefectiveReasonDetails_tv.Nodes;

            ProcessDefectiveReasonVo prcDefCheckVo = new ProcessDefectiveReasonVo();

            try
            {
                prcDefCheckVo = (ProcessDefectiveReasonVo)base.InvokeCbm(new GetProcessDefectiveReasonMasterMntCbm(), new ProcessDefectiveReasonVo(), false);
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
                    //Check process work defective reason is already added.
                    prcWrkId =  Convert.ToInt32(tn.Tag.ToString());

                    defRsnId = Convert.ToInt32(child.Tag.ToString());

                    prcDefCount = prcDefCheckVo.ProcessDefectiveReasonListVo.Where(t => t.ProcessWorkId == prcWrkId && t.DefectiveReasonId == defRsnId).Count();

                    if (child.Checked)
                    {
                        if (prcDefCount == 0)
                        {
                            AddProcessDefectReason(prcWrkId, defRsnId);
                        }
                    }
                    else
                    {
                        if (prcDefCount == 1)
                        {
                            DeleteProcessDefect(prcWrkId, defRsnId);
                        }
                    }
                }
            }
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
            ProcessDefectiveReasonDetails_tv.Nodes.Clear();

            ProcessWork_cmb.SelectedIndex = -1;
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
        private void ProcessDefectiveReasonDetails_tv_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                int d = (int)(0.2 * e.Bounds.Height);
                Rectangle rect = new Rectangle(d + ProcessDefectiveReasonDetails_tv.Margin.Left, d + e.Bounds.Top, e.Bounds.Height - d * 2, e.Bounds.Height - d * 2);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromKnownColor(KnownColor.Control)), rect);
                e.Graphics.DrawRectangle(Pens.Silver, rect);
                StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
                e.Graphics.DrawString(e.Node.IsExpanded ? "-" : "+", ProcessDefectiveReasonDetails_tv.Font, new SolidBrush(Color.Blue), rect, sf);
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
                    SizeF textSize = e.Graphics.MeasureString(e.Node.Text, ProcessDefectiveReasonDetails_tv.Font);
                    e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight), new RectangleF(textRect.Left, textRect.Top, textSize.Width, textRect.Height));
                }
                e.Graphics.DrawString(e.Node.Text, ProcessDefectiveReasonDetails_tv.Font, new SolidBrush(ProcessDefectiveReasonDetails_tv.ForeColor), textRect, sf);
            }
            else e.DrawDefault = true;
        }

        /// <summary>
        /// handles treeview node click and set parent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessDefectiveReasonDetails_tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                ProcessDefectiveReasonDetails_tv.SelectedNode = e.Node;
            }
        }

        #endregion

    }
}
