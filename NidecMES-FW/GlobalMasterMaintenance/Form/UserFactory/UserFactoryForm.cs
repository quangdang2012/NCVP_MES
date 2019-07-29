using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public partial class UserFactoryForm
    {
        #region Variables

        /// <summary>
        /// initialize message data
        /// </summary>
        private MessageData messageData;

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(UserFactoryForm));

        /// <summary>
        /// initialize popupmessagecontroller
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();
        #endregion

        #region Constructor

        /// <summary>
        /// constructor
        /// </summary>
        public UserFactoryForm()
        {
            InitializeComponent();
        }
        #endregion

        #region PrivateMethods

        /// <summary>
        /// Updates user role
        /// </summary>
        private void UpdateUserFactory()
        {
            TreeNodeCollection nodes = UserFactoryDetails_tv.Nodes;

            UserFactoryVo userFactoryInVo = new UserFactoryVo();

            try
            {
                UserFactoryVo userFactoryCheckVo = (UserFactoryVo)base.InvokeCbm(new GetUserFactoryMasterMntCbm(), userFactoryInVo, false);
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
                return;
            }

            int displayOrder = 0;

            foreach (TreeNode tn in nodes)
            {
                if (tn.ToolTipText == "Changed")
                {
                    string userCd = tn.Tag.ToString();
                    userFactoryInVo.UserCode = userCd;
                    userFactoryInVo.RegistrationUserCode = UserData.GetUserData().UserCode;

                    foreach (TreeNode child in tn.Nodes)
                    {
                        if (child.Checked)
                        {
                            displayOrder = displayOrder + 1;

                            UserFactoryVo userFactoryListVo = new UserFactoryVo
                            {
                                UserCode = userCd,
                                FactoryCd = child.Tag.ToString(),
                                DisplayOrder = displayOrder
                            };

                            userFactoryInVo.UserFactoryListVo.Add(userFactoryListVo);
                        }
                    }

                    try
                    {
                        UserFactoryVo userFactoryOutVo = (UserFactoryVo)base.InvokeCbm(new UpdateUserFactoryMasterMntCbm(), userFactoryInVo, false);
                        userFactoryInVo.UserFactoryListVo.Clear();
                    }
                    catch (Framework.ApplicationException exception)
                    {
                        popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                        logger.Error(exception.GetMessageData());
                        return;
                    }
                }
            }

            messageData = new MessageData("mmci00002", Properties.Resources.mmci00002, null);
            logger.Info(messageData);
            popUpMessage.Information(messageData, Text);
        }

        /// <summary>
        /// Binds tree view with user 
        /// </summary>
        private void BindTreeView()
        {
            UserVo userInVo = new UserVo();

            if (User_cmb.Text != string.Empty || User_cmb.SelectedIndex > 0)
            {
                userInVo.UserName = User_cmb.SelectedValue.ToString();
                string strUserCode = User_cmb.Text.ToString();
                string[] tokens = strUserCode.Split(':');
                userInVo.UserCode = tokens[0].ToString();
            }
            try
            {
                UserVo userOutVo = (UserVo)base.InvokeCbm(new GetUserMasterMntCbm(), userInVo, false);                
                PopulateTreeView(userOutVo.UserListVo);
                    
              
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
            }
        }

        /// <summary>
        /// Binds tree view with role 
        /// </summary>
        /// <param name="userList"></param>
        private void PopulateTreeView(List<UserVo> userList)
        {
            UserFactoryDetails_tv.Nodes.Clear();

            TreeNode[] headerNode = new TreeNode[userList.Count];

            int i = 0;

            foreach (UserVo user in userList)
            {
                TreeNode child = new TreeNode
                {
                    Text = user.UserCode + ": " + user.UserName,
                    Tag = user.UserCode
                };

                headerNode[i] = child;

                int node = 0;

                UserFactoryVo userFactoryInVo = new UserFactoryVo
                {
                    UserCode = user.UserCode
                };


                UserFactoryVo userFactoryOutVo;

                try
                {
                    userFactoryOutVo = (UserFactoryVo)base.InvokeCbm(new GetUserFactoryMasterMntCbm(), userFactoryInVo, false);
                }
                catch (Framework.ApplicationException exception)
                {
                    popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                    logger.Error(exception.GetMessageData());
                    return;
                }

                int childNodes = userFactoryOutVo.UserFactoryListVo.Count;

                TreeNode[] rootNodes = new TreeNode[childNodes];

                List<UserFactoryVo> userFactoryList = userFactoryOutVo.UserFactoryListVo;

                foreach (UserFactoryVo userFactory in userFactoryList)
                {
                    TreeNode rootChild = new TreeNode
                    {
                        Text = userFactory.FactoryName,
                        Tag = userFactory.FactoryCd
                    };

                    if (userFactory.DisplayOrder < 99)
                    {
                        rootChild.Checked = true;
                    }

                    rootNodes[node] = rootChild;

                    headerNode[i].Nodes.Add(rootNodes[node]);

                    node += 1;
                }

                UserFactoryDetails_tv.Nodes.Add(headerNode[i]);

                i += 1;
            }
        }

        /// <summary>
        /// Checks tree node is movable
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private bool IsTreeNodeMovable(TreeNode source, TreeNode target)
        {
            if (target == null || source == null) return false;
            if (target == source) return false;
            if (target.Parent == source) return false;

            // Target cannot be a source's child
            if (IsAncestor(target, source)) return false;
            if (source.Parent == null) return false;
            if (target.Parent != null && source.Parent.Name != target.Parent.Name) return false;

            return true;
        }

        /// <summary>
        /// Checks ancestor node 
        /// </summary>
        /// <param name="descendant"></param>
        /// <param name="ancestor"></param>
        /// <returns></returns>
        private bool IsAncestor(TreeNode descendant, TreeNode ancestor)
        {
            TreeNode investigatedNode = descendant;
            while (investigatedNode != null)
            {
                if (investigatedNode == ancestor) return true;
                investigatedNode = investigatedNode.Parent;
            }
            return false;
        }

        /// <summary>
        /// Loads User Code and User name
        /// </summary>
        /// <summary>
        /// Loads User Detail
        /// </summary>
        private void LoadUserCode()
        {
            UserVo userInVo = new UserVo();
            try
            {
                UserVo userOutVo = (UserVo)base.InvokeCbm(new GetUserMasterMntCbm(), userInVo, false);

                ComboBind(User_cmb, userOutVo.UserListVo, "UserDetail", "UserName");
            }
            catch (Framework.ApplicationException exception)
            {
                popUpMessage.ApplicationError(exception.GetMessageData(), Text);
                logger.Error(exception.GetMessageData());
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

        #endregion

        #region FormEvents
        /// <summary>
        /// form load, binds tree view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserFactoryForm_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;           
            LoadUserCode();
            Update_btn.Enabled = false;
            Cursor.Current = Cursors.Default;
            User_cmb.Select();
        }


        #endregion

        #region ButtonClick

        /// <summary>
        /// update user factory data to db
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update_btn_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            UpdateUserFactory();
            BindTreeView();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// binds treeview on search user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_btn_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            BindTreeView();
            Update_btn.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// clears controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_btn_Click(object sender, EventArgs e)
        {
            User_cmb.SelectedIndex = -1;
            UserFactoryDetails_tv.Nodes.Clear();
            //Update_btn.Enabled = false;
            //UserFactoryDetails_tv.
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

        #region ControlEvents
        /// <summary>
        /// sets selected node as parent on node click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserFactoryDetails_tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                UserFactoryDetails_tv.SelectedNode = e.Node;
            }
        }

        /// <summary>
        /// draws node check box to '+'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserFactoryDetails_tv_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Node.Parent == null)
            {
                int d = (int)(0.2 * e.Bounds.Height);
                Rectangle rect = new Rectangle(d + UserFactoryDetails_tv.Margin.Left, d + e.Bounds.Top, e.Bounds.Height - d * 2, e.Bounds.Height - d * 2);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromKnownColor(KnownColor.Control)), rect);
                e.Graphics.DrawRectangle(Pens.Silver, rect);
                StringFormat sf = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };
                e.Graphics.DrawString(e.Node.IsExpanded ? "-" : "+", UserFactoryDetails_tv.Font, new SolidBrush(Color.Blue), rect, sf);
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
                    SizeF textSize = e.Graphics.MeasureString(e.Node.Text, UserFactoryDetails_tv.Font);
                    e.Graphics.FillRectangle(new SolidBrush(SystemColors.Highlight), new RectangleF(textRect.Left, textRect.Top, textSize.Width, textRect.Height));
                }
                e.Graphics.DrawString(e.Node.Text, UserFactoryDetails_tv.Font, new SolidBrush(UserFactoryDetails_tv.ForeColor), textRect, sf);
            }
            else e.DrawDefault = true;

            if (e.Node.Level == 2)
            {
                e.Node.HideCheckBox();
            }
        }

        /// <summary>
        /// Enables node dragable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserFactoryDetails_tv_DragOver(object sender, DragEventArgs e)
        {
            TreeNode targetNode = null;
            TreeNode sourceNode = null;

            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                Point point = UserFactoryDetails_tv.PointToClient(new Point(e.X, e.Y));
                targetNode = UserFactoryDetails_tv.GetNodeAt(point.X, point.Y);
                sourceNode = e.Data.GetData(typeof(TreeNode)) as TreeNode;
                int delta = UserFactoryDetails_tv.Height - point.Y;
                if ((delta < UserFactoryDetails_tv.Height / 2) && (delta > 0))
                {
                    TreeNode tn = UserFactoryDetails_tv.GetNodeAt(point.X, point.Y);
                    tn.NextVisibleNode?.EnsureVisible();
                }
                if ((delta > UserFactoryDetails_tv.Height / 2) && (delta < UserFactoryDetails_tv.Height))
                {
                    TreeNode tn = UserFactoryDetails_tv.GetNodeAt(point.X, point.Y);
                    tn.PrevVisibleNode?.EnsureVisible();
                }
            }

            if (targetNode != null)
            {
                targetNode.Expand();

                if (IsTreeNodeMovable(sourceNode, targetNode))
                {
                    e.Effect = DragDropEffects.Move;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// Drag and drop node
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserFactoryDetails_tv_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                TreeNode sourceNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
                Point point = UserFactoryDetails_tv.PointToClient(new Point(e.X, e.Y));
                TreeNode targetNode = UserFactoryDetails_tv.GetNodeAt(point.X, point.Y);

                if (IsTreeNodeMovable(sourceNode, targetNode))
                {
                    sourceNode.Parent.ToolTipText = "Changed";

                    TreeNode dragNode = sourceNode;
                    UserFactoryDetails_tv.Nodes.Remove(sourceNode);
                    if (targetNode.Parent == null)
                    {
                        targetNode.Nodes.Insert(0, dragNode);
                    }
                    else
                    {
                        targetNode.Parent.Nodes.Insert(targetNode.Index + 1, dragNode);
                    }
                }
            }
        }

        /// <summary>
        /// drags factory nodes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserFactoryDetails_tv_ItemDrag(object sender, ItemDragEventArgs e)
        {
            UserFactoryDetails_tv.DoDragDrop((TreeNode)e.Item, DragDropEffects.All);
        }

        /// <summary>
        /// moves factory nodes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserFactoryDetails_tv_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)) && sender.Equals(UserFactoryDetails_tv))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// changes tooltip text to changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserFactoryDetails_tv_AfterCheck(object sender, TreeViewEventArgs e)
        {
            e.Node.Parent.ToolTipText = "Changed";
        }
        #endregion
    }
}
