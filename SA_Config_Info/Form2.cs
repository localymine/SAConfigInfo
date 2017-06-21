using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SA_Config_Info
{
    public partial class Form2 : Form
    {
        private int _xPos;
        private int _yPos;
        private bool _dragging;

        public Form2()
        {
            InitializeComponent();

            this.MouseWheel += new MouseEventHandler(pictureHelp_MouseWheel);
        }

        private void pictureHelp_MouseWheel(object sender, MouseEventArgs e)
        {
            // mouse scroll up
            if (e.Delta > 0)
            {
                Console.WriteLine("up");
                ZoomInOut(true);
            }

            // mouse scroll down
            if (e.Delta < 0)
            {
                Console.WriteLine("down");
                ZoomInOut(false);
            }

            // throw new NotImplementedException();
        }

        private void pictureHelp_MouseUp(object sender, MouseEventArgs e)
        {
            var c = sender as PictureBox;
            if (null == c) return;
            _dragging = false;
        }

        private void pictureHelp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            _dragging = true;
            _xPos = e.X;
            _yPos = e.Y;
        }

        private void pictureHelp_MouseMove(object sender, MouseEventArgs e)
        {
            var c = sender as PictureBox;
            if (!_dragging || null == c) return;
            c.Top = e.Y + c.Top - _yPos;
            c.Left = e.X + c.Left - _xPos;
        }

        private void ZoomInOut(bool zoom)
        {
            //Zoom ratio by which the images will be zoomed by default
            int zoomRatio = 10;
            //Set the zoomed width and height
            int widthZoom = pictureHelp.Width * zoomRatio / 100;
            int heightZoom = pictureHelp.Height * zoomRatio / 100;
            //zoom = true --> zoom in
            //zoom = false --> zoom out
            if (!zoom)
            {
                widthZoom *= -1;
                heightZoom *= -1;
            }
            //Add the width and height to the picture box dimensions
            pictureHelp.Width += widthZoom;
            pictureHelp.Height += heightZoom;

        }
    }
}
