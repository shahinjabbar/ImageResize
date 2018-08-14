using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Picture_Resize
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }
        OpenFileDialog ofd = new OpenFileDialog();
        SaveFileDialog sfd = new SaveFileDialog();
        public string Filename;
        public string FileAdress;
        public double _width;
        public double _height;
        public double dividedsize;
        public void Button1_Click(object sender, EventArgs e)
        {
            ofd.Filter = "JPG|*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filename = ofd.FileName;
                FileAdress = filename;
                var filePath = ofd;
                Image image = new Bitmap(filename, true);
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                PictureBox1.Image = image;
                label1.Text = filename;
                textBox3.Text = Convert.ToString(image.Width + "px");
                textBox4.Text = Convert.ToString(image.Height + "px");
                _width = (float)image.Width;
                _height = (float)image.Height;
                dividedsize = _width / _height;
                textBox5.Text = "";
                textBox6.Text = "";
                Filename = ofd.SafeFileName;
                Bitmap imgImage = new Bitmap(PictureBox1.Image);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                _width = Convert.ToInt32(textBox1.Text);
                _height = Convert.ToInt32(textBox2.Text);
                PictureBox1.Width = (int)_width;
                PictureBox1.Height = (int)_height;
                textBox3.Text = Convert.ToString(PictureBox1.Width + "px");
                textBox4.Text = Convert.ToString(PictureBox1.Height + "px");
                var image = Image.FromFile(ofd.FileName);
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter in the right format (Enter numbers)");
            }

         

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string manw = textBox6.Text;
            double bb = Convert.ToDouble(manw);
            string manh = textBox5.Text;
            double cc = Convert.ToDouble(manh);
            double manualw = (double)bb;
            double manualh = (double)cc;
            _width = manualw;
            _height =manualh;
            PictureBox1.Width = (int)_width;
            PictureBox1.Height = (int)_height;
            textBox5.Text = Convert.ToString(PictureBox1.Width + "px");
            textBox6.Text = Convert.ToString(PictureBox1.Height + "px");
            //try
            //{
               
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Please enter in the right format (Enter numbers)");
            //}
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                var d = Convert.ToInt32(textBox6.Text);
                double x = (double)d;
                textBox5.Text = Convert.ToString((x / dividedsize));
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter in the right format (Enter numbers)");
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                var g = Convert.ToInt32(textBox5.Text);
                double y = (double)g;
                textBox6.Text = Convert.ToString((dividedsize * y));
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter in the right format (Enter numbers)");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Size size = new Size((int)_width, (int)_height);
            Image resultImage = new Bitmap(PictureBox1.Image, size);
            resultImage.Save(Filename);
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.InitialDirectory = @"C:\Users\acer\Desktop\SubDir";
            saveFile.Filter = "JPG | *.jpg";
            saveFile.Title = "Save an image";
            saveFile.AddExtension = true;
            saveFile.DefaultExt = "bmp";
            saveFile.FilterIndex = 2;
            saveFile.RestoreDirectory = true;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string fName = saveFile.FileName;
                resultImage.Save(fName, ImageFormat.Bmp);
            };
        }
    }
}




