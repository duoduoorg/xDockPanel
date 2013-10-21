using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;

namespace xDockPanel
{
    public class DockContent : Form, IDockContent
    {
        public DockContent()
        {
            m_dockHandler = new DockContentHandler(this);
            m_dockHandler.DockStateChanged += new EventHandler(DockHandler_DockStateChanged);
            //Suggested as a fix by bensty regarding form resize
            this.ParentChanged += new EventHandler(DockContent_ParentChanged);
        }

        //Suggested as a fix by bensty regarding form resize
        private void DockContent_ParentChanged(object Sender, EventArgs e)
        {
            if (this.Parent != null)
                this.Font = this.Parent.Font;
        }

        private DockContentHandler m_dockHandler = null;
        [Browsable(false)]
        public DockContentHandler DockHandler
        {
            get    {    return m_dockHandler;    }
        }

        [Category("Dock")]
        [DefaultValue(DockAreas.Left | DockAreas.Right | DockAreas.Top | DockAreas.Bottom | DockAreas.Document | DockAreas.Float)]
        public DockAreas DockAreas
        {
            get    {    return DockHandler.DockAreas;    }
            set    {    DockHandler.DockAreas = value;    }
        }

        [Category("Dock")]
        [DefaultValue(0.25)]
        public double AutoHidePortion
        {
            get    {    return DockHandler.AutoHidePortion;    }
            set    {    DockHandler.AutoHidePortion = value;    }
        }

        private string m_tabText = null;
        [Category("Dock")]
        [DefaultValue(null)]
        public string TabText
        {
            get { return m_tabText; }
            set { DockHandler.TabText = m_tabText = value; }
        }

        private bool ShouldSerializeTabText()
        {
            return (m_tabText != null);
        }

        [Category("Dock")]
        [DefaultValue(true)]
        public bool CloseButton
        {
            get    {    return DockHandler.CloseButton;    }
            set    {    DockHandler.CloseButton = value;    }
        }

        [Category("Dock")]
        [DefaultValue(true)]
        public bool CloseButtonVisible
        {
            get { return DockHandler.CloseButtonVisible; }
            set { DockHandler.CloseButtonVisible = value; }
        }
        
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DockPanel DockPanel
        {
            get {    return DockHandler.DockPanel; }
            set    {    DockHandler.DockPanel = value;    }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DockState DockState
        {
            get    {    return DockHandler.DockState;    }
            set    {    DockHandler.DockState = value;    }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DockPane Pane
        {
            get {    return DockHandler.Pane; }
            set    {    DockHandler.Pane = value;        }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsHidden
        {
            get    {    return DockHandler.IsHidden;    }
            set    {    DockHandler.IsHidden = value;    }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DockState VisibleState
        {
            get    {    return DockHandler.VisibleState;    }
            set    {    DockHandler.VisibleState = value;    }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsFloat
        {
            get    {    return DockHandler.IsFloat;    }
            set    {    DockHandler.IsFloat = value;    }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DockPane PanelPane
        {
            get    {    return DockHandler.PanelPane;    }
            set    {    DockHandler.PanelPane = value;    }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DockPane FloatPane
        {
            get    {    return DockHandler.FloatPane;    }
            set    {    DockHandler.FloatPane = value;    }
        }

        [Category("Dock")]
        [DefaultValue(false)]
        public bool HideOnClose
        {
            get    {    return DockHandler.HideOnClose;    }
            set    {    DockHandler.HideOnClose = value;    }
        }

        [Category("Dock")]
        [DefaultValue(DockState.Unknown)]
        public DockState ShowHint
        {
            get    {    return DockHandler.ShowHint;    }
            set    {    DockHandler.ShowHint = value;    }
        }

        [Browsable(false)]
        public bool IsActivated
        {
            get    {    return DockHandler.IsActivated;    }
        }

        public bool IsDockStateValid(DockState dockState)
        {
            return DockHandler.IsDockStateValid(dockState);
        }

        [Category("Dock")]
        [DefaultValue(null)]
        public ContextMenu TabPageContextMenu
        {
            get    {    return DockHandler.TabPageContextMenu;    }
            set    {    DockHandler.TabPageContextMenu = value;    }
        }

        [Category("Dock")]
        [DefaultValue(null)]
        public ContextMenuStrip TabPageContextMenuStrip
        {
            get { return DockHandler.TabPageContextMenuStrip; }
            set { DockHandler.TabPageContextMenuStrip = value; }
        }

        [Category("Appearance")]
        [DefaultValue(null)]
        public string ToolTipText
        {
            get    {    return DockHandler.ToolTipText;    }
            set {    DockHandler.ToolTipText = value;    }
        }

        public new void Activate()
        {
            DockHandler.Activate();
        }

        public new void Hide()
        {
            DockHandler.Hide();
        }

        public new void Show()
        {
            DockHandler.Show();
        }

        public void Show(DockPanel dockPanel)
        {
            DockHandler.Show(dockPanel);
        }

        public void Show(DockPanel dockPanel, DockState dockState)
        {
            DockHandler.Show(dockPanel, dockState);
        }

        public void Show(DockPanel dockPanel, Rectangle floatWindowBounds)
        {
            DockHandler.Show(dockPanel, floatWindowBounds);
        }

        public void Show(DockPane pane, IDockContent beforeContent)
        {
            DockHandler.Show(pane, beforeContent);
        }

        public void Show(DockPane previousPane, DockAlignment alignment, double proportion)
        {
            DockHandler.Show(previousPane, alignment, proportion);
        }

        public void FloatAt(Rectangle floatWindowBounds)
        {
            DockHandler.FloatAt(floatWindowBounds);
        }

        public void DockTo(DockPane paneTo, DockStyle dockStyle, int contentIndex)
        {
            DockHandler.DockTo(paneTo, dockStyle, contentIndex);
        }

        public void DockTo(DockPanel panel, DockStyle dockStyle)
        {
            DockHandler.DockTo(panel, dockStyle);
        }

        #region IDockContent Members
        void IDockContent.OnActivated(EventArgs e)
        {
            this.OnActivated(e);
        }

        void IDockContent.OnDeactivate(EventArgs e)
        {
            this.OnDeactivate(e);
        }
        #endregion

        #region Events
        private void DockHandler_DockStateChanged(object sender, EventArgs e)
        {
            OnDockStateChanged(e);
        }

        private static readonly object DockStateChangedEvent = new object();
        [Category("PropertyChanged")]
        public event EventHandler DockStateChanged
        {
            add    {    Events.AddHandler(DockStateChangedEvent, value);    }
            remove    {    Events.RemoveHandler(DockStateChangedEvent, value);    }
        }
        protected virtual void OnDockStateChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[DockStateChangedEvent];
            if (handler != null)
                handler(this, e);
        }
        #endregion

        /// <summary>
        /// Overridden to avoid resize issues with nested controls
        /// </summary>
        /// <remarks>
        /// http://blogs.msdn.com/b/alejacma/archive/2008/11/20/controls-won-t-get-resized-once-the-nesting-hierarchy-of-windows-exceeds-a-certain-depth-x64.aspx
        /// http://support.microsoft.com/kb/953934
        /// </remarks>
        protected override void OnSizeChanged(EventArgs e)
        {
            if (DockPanel != null && IsHandleCreated)
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    base.OnSizeChanged(e);
                });
            }
            else
            {
                base.OnSizeChanged(e);
            }
        }
    }
}
