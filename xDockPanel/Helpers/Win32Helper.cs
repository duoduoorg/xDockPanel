using System.Drawing;
using System.Windows.Forms;

namespace xDockPanel
{
    public static class Win32Helper
    {
        internal static Control ControlAtPoint(Point pt)
        {
            return Control.FromChildHandle(NativeMethods.WindowFromPoint(pt));
        }

        internal static uint MakeLong(int low, int high)
        {
            return (uint)((high << 16) + low);
        }
    }
}
