﻿using Atiran.Utility.Docking2;

namespace Atiran.Utility.Docking2.Theme.ThemeVS2012
{
    internal class VS2012DockPaneSplitterControlFactory : DockPanelExtender.IDockPaneSplitterControlFactory
    {
        public DockPane.SplitterControlBase CreateSplitterControl(DockPane pane)
        {
            return new VS2012SplitterControl(pane);
        }
    }
}
