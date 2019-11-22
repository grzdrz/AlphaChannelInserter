using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlphaChannelInsertion
{
    public class Insertion
    {
        public Bitmap bitmap1;
        public Bitmap bitmap2;
        public Bitmap bitmap3;
        public Color[,] pixelsArray1;
        public Color[,] pixelsArray2;
        public Color[,] pixelsArray3;

        public Insertion(Bitmap bitmap1, Bitmap bitmap2)
        {
            this.bitmap1 = bitmap1;
            this.bitmap2 = bitmap2;
            this.bitmap3 = new Bitmap(bitmap1.Width, bitmap1.Height);
        }

        public Bitmap Insert()
        {
            pixelsArray1 = new Color[bitmap1.Width, bitmap1.Height];
            pixelsArray2 = new Color[bitmap2.Width, bitmap2.Height];
            pixelsArray3 = new Color[bitmap1.Width, bitmap1.Height];

            int alpha;
            for (int i = 0; i < pixelsArray1.GetLength(0); i++)
                for (int j = 0; j < pixelsArray1.GetLength(1); j++)
                {
                    pixelsArray1[i, j] = bitmap1.GetPixel(i, j);
                    pixelsArray2[i, j] = bitmap2.GetPixel(i, j);

                    alpha = (int)((pixelsArray2[i, j].B + pixelsArray2[i, j].R + pixelsArray2[i, j].G) / 3);
                    pixelsArray3[i, j] = Color.FromArgb(alpha, pixelsArray1[i, j]);
                    bitmap3.SetPixel(i, j, pixelsArray3[i, j]);
                }
            return bitmap3;
        }
    }
}
//0   0   0   - черный
//255 255 255 - белый
//n   n   n   - серые, при 0 < n < 255 

//Черный цвет -> альфа-канал пикселя -> прозрачный пиксель
//Белый цвет -> альфа-канал пикселя -> непрозрачный пиксель