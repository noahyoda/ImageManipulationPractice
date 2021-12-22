using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageManipulation
{
    public partial class Form1 : Form
    {
        ImagePanel content;
        Manipulator m;
        public Form1()
        {
            InitializeComponent();
            m = new Manipulator();
            Image mainimg = Image.FromFile("../../car.jpg");
            content = new ImagePanel(mainimg.Width);
            content.Primary = mainimg;
            this.Controls.Add(content);
            this.ClientSize = new Size(mainimg.Width + 90, mainimg.Height + 20);
            orderLabel.Location = new Point(mainimg.Width + 5, 50);
            rgbOrder.Location = new Point(mainimg.Width + 5, 70);
            blurButton.Location = new Point(mainimg.Width + 10, 200);
            blurStatus.Location = new Point(mainimg.Width + 10, 230);
        }

        private void UpdateFrame()
        {
            MethodInvoker invalidator = new MethodInvoker(() => Invalidate(true));
            Invoke(invalidator);
        }

        private void rgbOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // get rgb order
                string order = rgbOrder.Text;
                // update image
                content.Primary = m.RGBSwap(content.Primary, order);
                // invalidate form
                UpdateFrame();
                //reset box value
                rgbOrder.Text = "";
            }
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
            if (e.KeyCode == Keys.R)
                rgbOrder.Text += 'r';
            if (e.KeyCode == Keys.G)
                rgbOrder.Text += 'g';
            if (e.KeyCode == Keys.B)
                rgbOrder.Text += 'b';
            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        private void blurButton_Click(object sender, EventArgs e)
        {
            blurStatus.Text = "starting blur...";
            blurStatus.Update();
            content.Primary = m.GaussianFilter(content.Primary, 5);
            blurStatus.Text = "blur complete!";
            UpdateFrame();
        }
    }
}
