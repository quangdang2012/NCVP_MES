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
    public partial class LineAndWorkContentForm
    {
        #region PrivateVariables

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
        private static readonly CommonLogger Logger = CommonLogger.GetInstance(typeof(LineAndWorkContentForm));

        /// <summary>
        /// initialize vo
        /// </summary>
        private readonly WorkContentVo workContentInVo = new WorkContentVo();

        #endregion

        #region Constructor

        public LineAndWorkContentForm()
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
        /// Loads line
        /// </summary>
        private void LoadWorkContentType()
        {
            ValueObjectList<ProdutionWorkContentTypeVo> outVo = new ValueObjectList<ProdutionWorkContentTypeVo>();

            try
            {
                outVo = (ValueObjectList<ProdutionWorkContentTypeVo>)base.InvokeCbm(new GetProdutionWorkContentTypeCbm(), new ProdutionWorkContentTypeVo(), false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
                return;
            }
            if (outVo == null || outVo.GetList() == null || outVo.GetList().Count == 0)
            {
                return;
            }
            outVo.GetList().ForEach(p => p.ProdutionWorkContentTypeName = p.ProdutionWorkContentTypeCode + " " + p.ProdutionWorkContentTypeName);

            ComboBind(WorkContentType_Cmb, outVo.GetList(), "ProdutionWorkContentTypeName", "ProdutionWorkContentTypeId");
        }

        /// <summary>
        /// binds treeview with line WorkContent details
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

        /// <summary>
        /// Binds tree view 
        /// </summary>
        /// <param name="Linelist"></param>
        private void PopulateTreeView(List<LineVo> Linelist)
        {

            WorkContentVo workContentOutVo = new WorkContentVo();

            if (WorkContentType_Cmb.SelectedIndex > -1)
            {
                workContentInVo.WorkContentTypeId = Convert.ToInt32(WorkContentType_Cmb.SelectedValue);
            }

            try
            {
                workContentOutVo = (WorkContentVo)base.InvokeCbm(new GetWorkContentMasterMntCbm(), workContentInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
                return;
            }

            LineAndWorkContent_tv.Nodes.Clear();

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

                int childNodes = workContentOutVo.WorkContentListVo.Count;

                TreeNode[] rootNodes = new TreeNode[childNodes];

                int node = 0;


                ValueObjectList<LineWorkContentVo> lineWrkContentOutVo = new ValueObjectList<LineWorkContentVo>();

                try
                {
                    lineWrkContentOutVo = (ValueObjectList<LineWorkContentVo>)base.InvokeCbm(new GetLineWorkContentMasterMntCbm(), new LineWorkContentVo(), false);
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    Logger.Error(exception.GetMessageData());
                    return;
                }

                foreach (WorkContentVo wctVo in workContentOutVo.WorkContentListVo)
                {
                    TreeNode rootChild = new TreeNode
                    {
                        Text = wctVo.WorkContentCode + " " + wctVo.WorkContentName,
                        Tag = wctVo.WorkContentId
                    };

                    if (lineWrkContentOutVo != null && lineWrkContentOutVo.GetList() != null && lineWrkContentOutVo.GetList().Count > 0)
                    {
                        List<LineWorkContentVo> linWrkCntList = lineWrkContentOutVo.GetList().Where(t => t.LineId == Convert.ToInt32(child.Tag)).ToList();

                        foreach (LineWorkContentVo lnWrkCntVo in linWrkCntList)
                        {
                            if (lnWrkCntVo.WorkContentId == Convert.ToInt32(rootChild.Tag))
                            {
                                rootChild.Checked = true;
                            }
                        }
                    }

                    rootNodes[node] = rootChild;

                    headerNode[i].Nodes.Add(rootNodes[node]);

                    node += 1;
                }

                LineAndWorkContent_tv.Nodes.Add(headerNode[i]);

                i += 1;
            }
            if (LineAndWorkContent_tv.Nodes.Count > 0) Update_btn.Enabled = true;

        }

        /// <summary>
        /// Adds new Line Work Content
        /// </summary>
        /// <param name="LineId"></param>
        /// <param name="workContId"></param>
        private int AddLineWorkContent(int LineId, int workContId)
        {
            LineWorkContentVo lineWorkContentInVo = new LineWorkContentVo
            {
                LineId = LineId,
                WorkContentId = workContId,
                RegistrationUserCode = UserData.GetUserData().UserCode,
                FactoryCode = UserData.GetUserData().FactoryCode
            };
            UpdateResultVo outVo = new UpdateResultVo();
            try
            {
                outVo = (UpdateResultVo)base.InvokeCbm(new AddLineWorkContentMasterMntCbm(), lineWorkContentInVo, false);
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
        /// Delete Line work content
        /// </summary>
        /// <param name="lId"></param>
        /// <param name="workContId"></param>
        private int DeleteLineWorkContent(int lId, int workContId)
        {
            LineWorkContentVo delInVo = new LineWorkContentVo
            {
                LineId = lId,
                WorkContentId = workContId
            };
            UpdateResultVo delOutVo = new UpdateResultVo();
            try
            {
                delOutVo = (UpdateResultVo)base.InvokeCbm(new DeleteLineWorkContentMasterMntCbm(), delInVo, false);
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

        #endregion

        #region FormEvents
        /// <summary>
        /// for load, loads Line in Combo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineAndWorkContentForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadLine();
            LoadWorkContentType();
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
        /// updates Line Work Content
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (LineAndWorkContent_tv.Nodes.Count == 0) return;
            int lineWorkContentCount = 0;
            int linId;
            int workContentId;
            int ResultCnt = 0;
            Cursor.Current = Cursors.WaitCursor;
            TreeNodeCollection nodes = LineAndWorkContent_tv.Nodes;

            ValueObjectList<LineWorkContentVo> lineWorkContentCheckVo = new ValueObjectList<LineWorkContentVo>();

            try
            {
                lineWorkContentCheckVo = (ValueObjectList<LineWorkContentVo>)base.InvokeCbm(new GetLineWorkContentMasterMntCbm(), new LineWorkContentVo(), false);
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
                    //Check Line work content is already added.
                    linId = Convert.ToInt32(tn.Tag.ToString());

                    workContentId = Convert.ToInt32(child.Tag.ToString());
                    if (lineWorkContentCheckVo != null && lineWorkContentCheckVo.GetList() != null && lineWorkContentCheckVo.GetList().Count > 0)
                    {
                        lineWorkContentCount = lineWorkContentCheckVo.GetList().Where(t => t.LineId == linId && t.WorkContentId == workContentId).Count();
                    }
                    if (child.Checked)
                    {
                        if (lineWorkContentCount == 0)
                        {
                            ResultCnt += AddLineWorkContent(linId, workContentId);
                        }
                    }
                    else
                    {
                        if (lineWorkContentCount == 1)
                        {
                            ResultCnt += DeleteLineWorkContent(linId, workContentId);
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
            LineAndWorkContent_tv.Nodes.Clear();
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
        private void LineAndWorkContent_tv_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                int d = (int)(0.2 * e.Bounds.Height);
                Rectangle rect = new Rectangle(d + LineAndWorkContent_tv.Margin.Left, d + e.Bounds.Top, e.Bounds.Height - d * 2, e.Bounds.Height - d * 2);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromKnownColor(KnownColor.Control)), rect);
                e.Graphics.DrawRectangle(Pens.Silver, rect);
                StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
                e.Graphics.DrawString(e.Node.IsExpanded ? "-" : "+", LineAndWorkContent_tv.Font, new SolidBrush(Color.Blue), rect, sf);
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
                    SizeF textSize = e.Graphics.MeasureString(e.Node.Text, LineAndWorkContent_tv.Font);
                    e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight), new RectangleF(textRect.Left, textRect.Top, textSize.Width, textRect.Height));
                }
                e.Graphics.DrawString(e.Node.Text, LineAndWorkContent_tv.Font, new SolidBrush(LineAndWorkContent_tv.ForeColor), textRect, sf);
            }
            else e.DrawDefault = true;

        }


        /// <summary>
        /// handles treeview node click and set parent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineAndWorkContent_tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                LineAndWorkContent_tv.SelectedNode = e.Node;
            }
        }

        #endregion
    }
}
