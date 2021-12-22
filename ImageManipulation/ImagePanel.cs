using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ImageManipulation
{
    public class ImagePanel : Panel
    {
        private Image primary;
        private Image secondary;
        private int width;

        public ImagePanel(int imWidth)
        {
            WidthIm = imWidth;
        }

        public Image Primary { get => primary; set => primary = value; }
        public Image Secondary { get => secondary; set => secondary = value; }
        public int WidthIm { get => width; set => width = value; }

        protected override void OnPaint(PaintEventArgs e)
        {
            Font f = new Font("Arial", 14);
            SolidBrush b = new SolidBrush(Color.Black);
            int x = WidthIm / 2;
            if (primary != null)
            {
                this.Width = primary.Width + 90;
                this.Height = primary.Height + 30;
            }
            e.Graphics.DrawString("Primary", f, b, new Point(x-4, 5));
            e.Graphics.DrawImage(primary, new Point(0, 30));
            if (secondary != null) {
                e.Graphics.DrawString("Secondary", f, b, new Point(WidthIm + x - 5, 5));
                e.Graphics.DrawImage(secondary, new Point(WidthIm, 15));
            }
            base.OnPaint(e);
        }

    }
}
