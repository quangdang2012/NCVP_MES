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
    public partial class LineBuildingForm
    {
        #region PrivateVariables

        /// <summary>
        /// initialize vo
        /// </summary>
        private readonly LineVo lineInVo = new LineVo();

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
        public LineBuildingForm()
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
        /// Load Building
        /// </summary>
        private void LoadBuilding()
        {
            BuildingVo outVo = new BuildingVo();

            try
            {
                outVo = (BuildingVo)base.InvokeCbm(new GetBuildingMasterMntCbm(), new BuildingVo(), false);

                outVo.BuildingListVo.ForEach(p => p.BuildingName = p.BuildingCode + " " + p.BuildingName);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
                return;
            }

            ComboBind(Building_cmb, outVo.BuildingListVo, "BuildingName", "BuildingId");
        }

        /// <summary>
        /// Binds tree view 
        /// </summary>
        /// <param name="Buildinglist"></param>
        private void PopulateTreeView(List<BuildingVo> Buildinglist)
        {

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

            LineBuildingDetails_tv.Nodes.Clear();

            TreeNode[] headerNode = new TreeNode[Buildinglist.Count];

            int i = 0;

            foreach (BuildingVo building in Buildinglist)
            {
                TreeNode child = new TreeNode
                {
                    Text = building.BuildingCode + " " + building.BuildingName,
                    Tag = building.BuildingId
                };

                headerNode[i] = child;

                int childNodes = lineOutVo.LineListVo.Count;

                TreeNode[] rootNodes = new TreeNode[childNodes];

                int node = 0;


                ValueObjectList<LineBuildingVo> linBuildingOutVo = new ValueObjectList<LineBuildingVo>();

                try
                {
                    linBuildingOutVo = (ValueObjectList<LineBuildingVo>)base.InvokeCbm(new GetLineBuildingMasterMntCbm(), new LineBuildingVo(), false);
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    Logger.Error(exception.GetMessageData());
                    return;
                }

                foreach (LineVo lineVo in lineOutVo.LineListVo)
                {
                    TreeNode rootChild = new TreeNode
                    {
                        Text = lineVo.LineCode + " " + lineVo.LineName,
                        Tag = lineVo.LineId
                    };

                    if (linBuildingOutVo != null && linBuildingOutVo.GetList() != null && linBuildingOutVo.GetList().Count > 0)
                    {
                        List<LineBuildingVo> linBuildingList = linBuildingOutVo.GetList().Where(t => t.BuildingId == Convert.ToInt32(child.Tag)).ToList();

                        foreach (LineBuildingVo linBuildVo in linBuildingList)
                        {
                            if (linBuildVo.LineId == Convert.ToInt32(rootChild.Tag))
                            {
                                rootChild.Checked = true;
                            }
                        }
                    }

                    rootNodes[node] = rootChild;

                    headerNode[i].Nodes.Add(rootNodes[node]);

                    node += 1;
                }

                LineBuildingDetails_tv.Nodes.Add(headerNode[i]);

                i += 1;
            }
            if (LineBuildingDetails_tv.Nodes.Count > 0) Update_btn.Enabled = true;            
        }

        /// <summary>
        /// Adds new line Building
        /// </summary>
        /// <param name="LineId"></param>
        /// <param name="buildingId"></param>
        private int AddLineBuilding(int LineId, int buildingId)
        {
            LineBuildingVo LineBuildInVo = new LineBuildingVo
            {
                LineId = LineId,
                BuildingId = buildingId,
                RegistrationUserCode = UserData.GetUserData().UserCode,
                FactoryCode = UserData.GetUserData().FactoryCode
            };
            UpdateResultVo outVo = new UpdateResultVo();
            try
            {
                outVo = (UpdateResultVo)base.InvokeCbm(new AddLineBuildingMasterMntCbm(), LineBuildInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
            }
            return outVo.AffectedCount;
        }

        /// <summary>
        /// Deletes Line building
        /// </summary>
        /// <param name="lineId"></param>
        /// <param name="buildingId"></param>
        private int DeleteLineBuilding(int lineId, int buildingId)
        {
            LineBuildingVo delInVo = new LineBuildingVo
            {
                LineId = lineId,
                BuildingId = buildingId
            };
            UpdateResultVo delOutVo = new UpdateResultVo();
            try
            {
                delOutVo = (UpdateResultVo)base.InvokeCbm(new DeleteLineBuildingMasterMntCbm(), delInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
            }
            return delOutVo.AffectedCount;
        }

        /// <summary>
        /// binds treeview with line building details
        /// </summary>
        private void BindTreeView()
        {
            BuildingVo buildingInVo = new BuildingVo();

            if (Building_cmb.SelectedIndex > -1)
            {
                buildingInVo.BuildingId = Convert.ToInt32(Building_cmb.SelectedValue);
            }

            BuildingVo buildingOutVo = new BuildingVo();

            try
            {
                buildingOutVo = (BuildingVo)base.InvokeCbm(new GetBuildingMasterMntCbm(), buildingInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                Logger.Error(exception.GetMessageData());
                return;
            }
            string message = string.Format(Properties.Resources.mmci00009);
            StartProgress(message);
            PopulateTreeView(buildingOutVo.BuildingListVo);
            CompleteProgress();
        }


        #endregion

        #region FormEvents
        /// <summary>
        /// for load, loads Line and binds treeview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineBuildingForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadBuilding();
            Cursor.Current = Cursors.Default;
            Building_cmb.Select();
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
        /// updates Line building
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            if (LineBuildingDetails_tv.Nodes.Count == 0) return;
            int linBuildCount = 0;
            int linId;
            int buildId;
            int resultCnt = 0;

            Cursor.Current = Cursors.WaitCursor;
            TreeNodeCollection nodes = LineBuildingDetails_tv.Nodes;

            ValueObjectList<LineBuildingVo> linBuildCheckVo = new ValueObjectList<LineBuildingVo>();

            try
            {
                linBuildCheckVo = (ValueObjectList<LineBuildingVo>)base.InvokeCbm(new GetLineBuildingMasterMntCbm(), new LineBuildingVo(), false);
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
                    //Check Line building is already added.
                    buildId = Convert.ToInt32(tn.Tag.ToString());
                    linId = Convert.ToInt32(child.Tag.ToString());

                    if (linBuildCheckVo != null && linBuildCheckVo.GetList() != null && linBuildCheckVo.GetList().Count > 0)
                    {
                        linBuildCount = linBuildCheckVo.GetList().Where(t => t.LineId == linId && t.BuildingId == buildId).Count();
                    }
                    if (child.Checked)
                    {
                        if (linBuildCount == 0)
                        {
                            resultCnt += AddLineBuilding(linId, buildId);
                        }
                    }
                    else
                    {
                        if (linBuildCount == 1)
                        {
                            resultCnt += DeleteLineBuilding(linId, buildId);
                        }
                    }
                }
            }
            if (resultCnt == 0) return;
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
            LineBuildingDetails_tv.Nodes.Clear();

            Building_cmb.SelectedIndex = -1;
            Building_cmb.Text = string.Empty;
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
        private void LineBuildingDetails_tv_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                int d = (int)(0.2 * e.Bounds.Height);
                Rectangle rect = new Rectangle(d + LineBuildingDetails_tv.Margin.Left, d + e.Bounds.Top, e.Bounds.Height - d * 2, e.Bounds.Height - d * 2);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromKnownColor(KnownColor.Control)), rect);
                e.Graphics.DrawRectangle(Pens.Silver, rect);
                StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
                e.Graphics.DrawString(e.Node.IsExpanded ? "-" : "+", LineBuildingDetails_tv.Font, new SolidBrush(Color.Blue), rect, sf);
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
                    SizeF textSize = e.Graphics.MeasureString(e.Node.Text, LineBuildingDetails_tv.Font);
                    e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight), new RectangleF(textRect.Left, textRect.Top, textSize.Width, textRect.Height));
                }
                e.Graphics.DrawString(e.Node.Text, LineBuildingDetails_tv.Font, new SolidBrush(LineBuildingDetails_tv.ForeColor), textRect, sf);
            }
            else e.DrawDefault = true;
        }

        /// <summary>
        /// handles treeview node click and set parent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineBuildingDetails_tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                LineBuildingDetails_tv.SelectedNode = e.Node;
            }
        }


        #endregion

    }
}
