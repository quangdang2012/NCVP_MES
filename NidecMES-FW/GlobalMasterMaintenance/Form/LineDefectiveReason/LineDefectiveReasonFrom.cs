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
    public partial class LineDefectiveReasonForm
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
        private static readonly CommonLogger Logger = CommonLogger.GetInstance(typeof(LineDefectiveReasonForm));

        #endregion

        #region Constructor
        public LineDefectiveReasonForm()
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
        /// Loads line
        /// </summary>
        private void LoadLine()
        {
            LineVo outVo = new LineVo();

            try
            {
                outVo = (LineVo)base.InvokeCbm(new GetLineMasterMntCbm(), new LineVo(), false);

                outVo.LineListVo.ForEach(p => p.LineName = p.LineCode + " " + p.LineName);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
                return;
            }

            ComboBind(Line_cmb, outVo.LineListVo, "LineName", "LineId");
        }

        /// <summary>
        /// Binds tree view 
        /// </summary>
        /// <param name="Linelist"></param>
        private void PopulateTreeView(List<LineVo> Linelist)
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

            LineDefectiveReasonDetails_tv.Nodes.Clear();

            TreeNode[] headerNode = new TreeNode[Linelist.Count];

            int i = 0;

            foreach (LineVo lin in Linelist)
            {
                TreeNode child = new TreeNode
                {
                    Text = lin.LineCode + " " + lin.LineName,
                    Tag = lin.LineId
                };

                headerNode[i] = child;

                int childNodes = defOutVo.DefectiveReasonListVo.Count;

                TreeNode[] rootNodes = new TreeNode[childNodes];

                int node = 0;


                ValueObjectList<LineDefectiveReasonVo> linDefRsnOutVo = new ValueObjectList<LineDefectiveReasonVo>();

                try
                {
                    linDefRsnOutVo = (ValueObjectList<LineDefectiveReasonVo>)base.InvokeCbm(new GetLineDefectiveReasonMasterMntCbm(), new LineDefectiveReasonVo(), false);
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

                    if (linDefRsnOutVo != null && linDefRsnOutVo.GetList() != null && linDefRsnOutVo.GetList().Count > 0)
                    {
                        List<LineDefectiveReasonVo> linDefRsnList = linDefRsnOutVo.GetList().Where(t => t.LineId == Convert.ToInt32(child.Tag)).ToList();

                        foreach (LineDefectiveReasonVo lnDfRsnVo in linDefRsnList)
                        {
                            if (lnDfRsnVo.DefectiveReasonId == Convert.ToInt32(rootChild.Tag))
                            {
                                rootChild.Checked = true;
                            }
                        }
                    }

                    rootNodes[node] = rootChild;

                    headerNode[i].Nodes.Add(rootNodes[node]);

                    node += 1;
                }

                LineDefectiveReasonDetails_tv.Nodes.Add(headerNode[i]);

                i += 1;
            }
            if (LineDefectiveReasonDetails_tv.Nodes.Count > 0) Update_btn.Enabled = true;

        }

        /// <summary>
        /// Adds new proess defect
        /// </summary>
        /// <param name="LineId"></param>
        /// <param name="defectRsnId"></param>
        private int AddLineDefectReason(int LineId, int defectRsnId)
        {
            LineDefectiveReasonVo LinDefInVo = new LineDefectiveReasonVo
            {
                LineId = LineId,
                DefectiveReasonId = defectRsnId,
                //RegistrationDateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),
                RegistrationUserCode = UserData.GetUserData().UserCode,
                FactoryCode = UserData.GetUserData().FactoryCode
            };
            UpdateResultVo outVo = new UpdateResultVo();
            try
            {
                outVo = (UpdateResultVo)base.InvokeCbm(new AddLineDefectiveReasonMasterMntCbm(), LinDefInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
            }
            if (outVo != null && outVo.AffectedCount > 0)
            {
                return outVo.AffectedCount;
            }
            return 0;
        }

        /// <summary>
        /// Deletes Line defect
        /// </summary>
        /// <param name="lId"></param>
        /// <param name="defRsnId"></param>
        private int DeleteLineDefect(int lId, int defRsnId)
        {
            LineDefectiveReasonVo delInVo = new LineDefectiveReasonVo
            {
                LineId = lId,
                DefectiveReasonId = defRsnId
            };
            UpdateResultVo delOutVo = new UpdateResultVo();
            try
            {
                delOutVo = (UpdateResultVo)base.InvokeCbm(new DeleteLineDefectiveReasonMasterMntCbm(), delInVo, false);
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
        /// binds treeview with line def reason details
        /// </summary>
        private void BindTreeView()
        {
            LineVo lineInVo = new LineVo();

            if (Line_cmb.SelectedIndex > -1)
            {
                lineInVo.LineId = Convert.ToInt32(Line_cmb.SelectedValue);
            }

            LineVo lineOutVo = new LineVo();

            try
            {
                lineOutVo = (LineVo)base.InvokeCbm(new GetLineMasterMntCbm(), lineInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
                return;
            }
            string message = string.Format(Properties.Resources.mmci00009);
            StartProgress(message);
            PopulateTreeView(lineOutVo.LineListVo);
            CompleteProgress();
        }


        #endregion

        #region FormEvents
        /// <summary>
        /// for load, loads Line and binds treeview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineDefectiveReasonForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadLine();

            //BindTreeView();
            Cursor.Current = Cursors.Default;
            Line_cmb.Select();
        }
        #endregion

        #region ButtonClick
        /// <summary>
        /// search button click, binds treeview with Line
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            BindTreeView();
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// updates Line defective reason
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (LineDefectiveReasonDetails_tv.Nodes.Count == 0) return;
            int linDefCount = 0;
            int linId;
            int defRsnId;
            int ResultCnt = 0;
            Cursor.Current = Cursors.WaitCursor;
            TreeNodeCollection nodes = LineDefectiveReasonDetails_tv.Nodes;

            ValueObjectList<LineDefectiveReasonVo> linDefCheckVo = new ValueObjectList<LineDefectiveReasonVo>();

            try
            {
                linDefCheckVo = (ValueObjectList<LineDefectiveReasonVo>)base.InvokeCbm(new GetLineDefectiveReasonMasterMntCbm(), new LineDefectiveReasonVo(), false);
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
                    //Check Line defective reason is already added.
                    linId = Convert.ToInt32(tn.Tag.ToString());

                    defRsnId = Convert.ToInt32(child.Tag.ToString());
                    if (linDefCheckVo != null && linDefCheckVo.GetList() != null && linDefCheckVo.GetList().Count > 0)
                    {
                        linDefCount = linDefCheckVo.GetList().Where(t => t.LineId == linId && t.DefectiveReasonId == defRsnId).Count();
                    }
                    if (child.Checked)
                    {
                        if (linDefCount == 0)
                        {
                            ResultCnt += AddLineDefectReason(linId, defRsnId);
                        }
                    }
                    else
                    {
                        if (linDefCount == 1)
                        {
                            ResultCnt += DeleteLineDefect(linId, defRsnId);
                        }
                    }
                }
            }
            if (ResultCnt == 0) return;
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
            LineDefectiveReasonDetails_tv.Nodes.Clear();
            Line_cmb.SelectedIndex = -1;
            Line_cmb.Text = string.Empty;
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
        private void LineDefectiveReasonDetails_tv_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                int d = (int)(0.2 * e.Bounds.Height);
                Rectangle rect = new Rectangle(d + LineDefectiveReasonDetails_tv.Margin.Left, d + e.Bounds.Top, e.Bounds.Height - d * 2, e.Bounds.Height - d * 2);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromKnownColor(KnownColor.Control)), rect);
                e.Graphics.DrawRectangle(Pens.Silver, rect);
                StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
                e.Graphics.DrawString(e.Node.IsExpanded ? "-" : "+", LineDefectiveReasonDetails_tv.Font, new SolidBrush(Color.Blue), rect, sf);
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
                    SizeF textSize = e.Graphics.MeasureString(e.Node.Text, LineDefectiveReasonDetails_tv.Font);
                    e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight), new RectangleF(textRect.Left, textRect.Top, textSize.Width, textRect.Height));
                }
                e.Graphics.DrawString(e.Node.Text, LineDefectiveReasonDetails_tv.Font, new SolidBrush(LineDefectiveReasonDetails_tv.ForeColor), textRect, sf);
            }
            else e.DrawDefault = true;
        }

        /// <summary>
        /// handles treeview node click and set parent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineDefectiveReasonDetails_tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                LineDefectiveReasonDetails_tv.SelectedNode = e.Node;
            }
        }

        #endregion


    }
}
