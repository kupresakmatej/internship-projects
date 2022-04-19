using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPX___Zadatak2
{
    class Texture
    {
        public int TextureInt { get; set; }

        public Texture()
        {
            TextureInt = 0;
        }

        public int GenerateTexture()
        {
            int texture;

            GL.Enable(EnableCap.Texture2D);
            GL.GenTextures(1, out texture);

            BitmapData texData = LoadImage(@"C:\Users\Reroot\Desktop\FPX\crate_texture.bmp");

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, texData.Width, texData.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, texData.Scan0);

            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            return texture;
        }

        public BitmapData LoadImage(string texturePath)
        {
            Bitmap bmp = new Bitmap(texturePath);

            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);

            BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            bmp.UnlockBits(bmpData);

            return bmpData;
        }
    }
}
