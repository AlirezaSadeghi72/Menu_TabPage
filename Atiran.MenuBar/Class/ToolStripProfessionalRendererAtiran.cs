﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atiran.MenuBar.Class
{
    public class ToolStripProfessionalRendererAtiran : ToolStripProfessionalRenderer
    {
        public ToolStripProfessionalRendererAtiran() : base(new MyColors()) { }
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowRectangle = Rectangle.Empty;
            if (e.Item.Selected)
            {
                e.Graphics.DrawImage(new Bitmap(Properties.Resources.expandleft, new Size(16, 16)), new Point(5, 5));
            }
            else
            {
                e.Graphics.DrawImage(new Bitmap(Properties.Resources.expandDown, new Size(16, 16)), new Point(5, 5));
            }
            //base.OnRenderArrow(e);
        }
        protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            base.OnRenderItemImage(e);
            if (e.Item.Tag is MyTag && ((MyTag)e.Item.Tag).FormId > 0)
            {
                if (!e.Item.Selected)
                {
                    e.Graphics.DrawImage(new Bitmap(Properties.Resources.LemonChiffon, new Size(16, 16)),
                        new Point(e.Item.ContentRectangle.Right - 19, e.Item.ContentRectangle.Top + 6));
                }
                else
                {
                    e.Graphics.DrawImage(new Bitmap(Properties.Resources.Yellow, new Size(16, 16)),
                        new Point(e.Item.ContentRectangle.Right - 19, e.Item.ContentRectangle.Top + 6));
                }
            }
        }
    }
    partial class MyColors : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(80, 104, 125); }
        }
        public override Color MenuItemPressedGradientBegin
        {
            get { return Color.FromArgb(80, 104, 125); }
        }
        public override Color MenuItemPressedGradientEnd
        {
            get { return Color.FromArgb(80, 104, 125); }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.FromArgb(80, 104, 125); }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.FromArgb(20, 130, 150); }
        }
        public override Color ImageMarginGradientBegin
        {
            get { return Color.FromArgb(20, 130, 150); }
        }
        public override Color ImageMarginGradientMiddle
        {
            get { return Color.FromArgb(20, 130, 150); }
        }
        public override Color ImageMarginGradientEnd
        {
            get
            {
                return Color.FromArgb(20, 130, 150);
            }
        }
        public override Color MenuItemBorder
        {
            get { return Color.Transparent; }
        }
        public override Color ButtonSelectedHighlight => Color.Teal;//زماني كه موس روي زير منوها ميرود
        public override Color ButtonCheckedGradientBegin => Color.FromArgb(20, 130, 150);
        public override Color ButtonCheckedGradientEnd => Color.FromArgb(20, 130, 150);
        public override Color ButtonCheckedGradientMiddle => Color.FromArgb(20, 130, 150);
        public override Color ButtonCheckedHighlight => Color.FromArgb(20, 130, 150);
        public override Color ButtonCheckedHighlightBorder => Color.FromArgb(20, 130, 150);
        public override Color ButtonPressedBorder => Color.Red;
        public override Color ButtonPressedGradientBegin => Color.Red;
        public override Color ButtonPressedGradientEnd => Color.Red;
        public override Color ButtonPressedGradientMiddle => Color.Red;
        public override Color ButtonPressedHighlight => Color.Red;
        public override Color ButtonPressedHighlightBorder => Color.Red;
        public override Color ButtonSelectedBorder => Color.Red;
        public override Color ToolStripPanelGradientEnd => Color.Red;
        public override Color ToolStripPanelGradientBegin => Color.Red;
        public override Color ToolStripDropDownBackground => Color.FromArgb(20, 130, 150); // رنگ دور زير منوها
    }
}
