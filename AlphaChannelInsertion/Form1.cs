using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlphaChannelInsertion
{
    public partial class Form1 : Form
    {
        public Bitmap bitmap1;
        public Bitmap bitmap2;
        public Bitmap bitmap3;

        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.AddExtension = true;
            openFileDialog.Filter = "PNG files (*.png)|*.png";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bitmap1 = (Bitmap)Bitmap.FromFile(openFileDialog.FileName);
                pictureBox1.Image = bitmap1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.AddExtension = true;
            openFileDialog.Filter = "PNG files (*.png)|*.png";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bitmap2 = (Bitmap)Bitmap.FromFile(openFileDialog.FileName);
                pictureBox2.Image = bitmap2;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Insertion insertion = new Insertion(bitmap1, bitmap2);
            bitmap3 = insertion.Insert();
            pictureBox3.Image = bitmap3;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckFileExists = false;
            saveFileDialog.AddExtension = true;
            saveFileDialog.Filter = "PNG files (*.png)|*.png";

            DialogResult showDialogResult = saveFileDialog.ShowDialog(); 
            if (showDialogResult == DialogResult.Cancel)
                return;
            if (showDialogResult == System.Windows.Forms.DialogResult.OK)
                using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    bitmap3.Save(stream, ImageFormat.Png);
                }
            MessageBox.Show("Файл сохранен");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

//Bitmap.FromFile статический метод из базового абстрактного класса Image, создающий экземпляр наследника Bitmap и апкастящий его до Image.
//Поэтому чтобы получить Bitmap экземпляр с помощью этого метода нужно после его вызова даункастнуть объект до Bitmap.
