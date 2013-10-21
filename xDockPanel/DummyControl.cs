using System;
using System.Windows.Forms;

namespace xDockPanel
{
    internal class DummyControl : Control
    {
        public DummyControl()
        {
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
