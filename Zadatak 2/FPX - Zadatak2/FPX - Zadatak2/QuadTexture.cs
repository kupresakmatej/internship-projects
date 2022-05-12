using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;


namespace FPX___Zadatak2
{
    class QuadTexture : IRenderable
    {
        public Vector Position { get; set; }
        private float A { get; set; }
        private float B { get; set; }

        private int layer;
        public int Layer { get { return this.layer; } set { this.layer = value; } }
        private Texture TextureInstance { get; set; }

        public QuadTexture(Vector position, float a, float b, Texture texture)
        {
            Position = position;
            A = a;
            B = b;
            TextureInstance = texture;
        }

        public void Draw()
        {
            GL.BindTexture(TextureTarget.Texture2D, TextureInstance.TextureInt);

            GL.Begin(BeginMode.Quads);

            GL.TexCoord2(0, 0);
            GL.Vertex2(Position.X - A / 2, Position.Y - B / 2);
            GL.TexCoord2(1, 0);
            GL.Vertex2(Position.X + A / 2, Position.Y - B / 2);
            GL.TexCoord2(1, 1);
            GL.Vertex2(Position.X + A / 2, Position.Y + B / 2);
            GL.TexCoord2(0, 1);
            GL.Vertex2(Position.X - A / 2, Position.Y + B / 2);

            GL.End();

            GL.BindTexture(TextureTarget.Texture2D, 0);
        }
    }
}
