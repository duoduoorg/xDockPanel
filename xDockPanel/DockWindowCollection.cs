using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace xDockPanel
{
    public class DockWindowCollection : ReadOnlyCollection<DockWindow>
    {
        internal DockWindowCollection(DockPanel panel)
            : base(new List<DockWindow>())
        {
            Items.Add(new DockWindow(panel, DockState.Document));
            Items.Add(new DockWindow(panel, DockState.Left));
            Items.Add(new DockWindow(panel, DockState.Right));
            Items.Add(new DockWindow(panel, DockState.Top));
            Items.Add(new DockWindow(panel, DockState.Bottom));
        }

        public DockWindow this [DockState state]
        {
            get
            {
                if (state == DockState.Document)
                    return Items[0];
                else if (state == DockState.Left || state == DockState.AutoHideLeft)
                    return Items[1];
                else if (state == DockState.Right || state == DockState.AutoHideRight)
                    return Items[2];
                else if (state == DockState.Top || state == DockState.AutoHideTop)
                    return Items[3];
                else if (state == DockState.Bottom || state == DockState.AutoHideBottom)
                    return Items[4];
                throw (new ArgumentOutOfRangeException());
            }
        }
    }
}
