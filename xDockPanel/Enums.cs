using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace xDockPanel
{
    [Flags]
    [Serializable]
    [Editor(typeof(DockAreasEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public enum DockAreas
    {
        Float = 1,
        Left = 2,
        Right = 4,
        Top = 8,
        Bottom = 16,
        Document = 32
    }

    public enum DockState
    {
        Unknown = 0,
        Float = 1,
        AutoHideTop = 2,
        AutoHideLeft = 3,
        AutoHideBottom = 4,
        AutoHideRight = 5,
        Document = 6,
        Top = 7,
        Left = 8,
        Bottom = 9,
        Right = 10,
        Hidden = 11
    }

    public enum DockAlignment
    {
        Left,
        Right,
        Top,
        Bottom
    }

    public enum DocumentStyle
    {
        DockingMdi
    }

    /// <summary>
    /// The location to draw the DockPaneStrip for Document style windows.
    /// </summary>
    public enum DocumentTabStripLocation
    {
        Top,
        Bottom
    }
}
