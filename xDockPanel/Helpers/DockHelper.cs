using System.Drawing;
using System.Windows.Forms;

namespace xDockPanel
{
    internal static class DockHelper
    {
        public static bool IsDockAutoHide(DockState state)
        {
            if (state == DockState.AutoHideLeft ||
                state == DockState.AutoHideRight ||
                state == DockState.AutoHideTop ||
                state == DockState.AutoHideBottom)
                return true;
            else
                return false;
        }

        public static bool IsDockValid(DockState state, DockAreas areas)
        {
            if (((areas & DockAreas.Float) == 0) &&
                (state == DockState.Float))
                return false;
            else if (((areas & DockAreas.Document) == 0) &&
                (state == DockState.Document))
                return false;
            else if (((areas & DockAreas.Left) == 0) &&
                (state == DockState.Left || state == DockState.AutoHideLeft))
                return false;
            else if (((areas & DockAreas.Right) == 0) &&
                (state == DockState.Right || state == DockState.AutoHideRight))
                return false;
            else if (((areas & DockAreas.Top) == 0) &&
                (state == DockState.Top || state == DockState.AutoHideTop))
                return false;
            else if (((areas & DockAreas.Bottom) == 0) &&
                (state == DockState.Bottom || state == DockState.AutoHideBottom))
                return false;
            else
                return true;
        }

        public static bool IsDockWindowState(DockState state)
        {
            if (state == DockState.Top || state == DockState.Bottom || state == DockState.Left ||
                state == DockState.Right || state == DockState.Document)
                return true;
            else
                return false;
        }

        public static DockState ToggleAutoHideState(DockState state)
        {
            if (state == DockState.Left)
                return DockState.AutoHideLeft;
            else if (state == DockState.Right)
                return DockState.AutoHideRight;
            else if (state == DockState.Top)
                return DockState.AutoHideTop;
            else if (state == DockState.Bottom)
                return DockState.AutoHideBottom;
            else if (state == DockState.AutoHideLeft)
                return DockState.Left;
            else if (state == DockState.AutoHideRight)
                return DockState.Right;
            else if (state == DockState.AutoHideTop)
                return DockState.Top;
            else if (state == DockState.AutoHideBottom)
                return DockState.Bottom;
            else
                return state;
        }

        public static DockPane PaneAtPoint(Point pt, DockPanel dockPanel)
        {
            for (Control control = Win32Helper.ControlAtPoint(pt); control != null; control = control.Parent)
            {
                IDockContent content = control as IDockContent;
                if (content != null && content.DockHandler.DockPanel == dockPanel)
                    return content.DockHandler.Pane;

                DockPane pane = control as DockPane;
                if (pane != null && pane.DockPanel == dockPanel)
                    return pane;
            }
            return null;
        }

        public static FloatWindow FloatWindowAtPoint(Point pt, DockPanel dockPanel)
        {
            for (Control control = Win32Helper.ControlAtPoint(pt); control != null; control = control.Parent)
            {
                FloatWindow floatWindow = control as FloatWindow;
                if (floatWindow != null && floatWindow.DockPanel == dockPanel)
                    return floatWindow;
            }
            return null;
        }
    }
}
