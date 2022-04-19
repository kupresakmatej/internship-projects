﻿using System;
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
    class Quad : Drawable
    {
        private Vector Position { get; set; }
        private float A { get; set; }
        public override int Layer { get => base.Layer; set => base.Layer = value; }
        private int Texture { get; set; }

        public Quad(Vector position, float a, int texture)
        {
            Position = position;
            A = a;
            Texture = texture;
        }

        public override void Draw()
        {
            GL.BindTexture(TextureTarget.Texture2D, Texture);

            GL.Translate(Position.X, Position.Y, 0.0);

            GL.Begin(BeginMode.Quads);

            GL.TexCoord2(0, 0);
            GL.Vertex2(Position.X, Position.Y);
            GL.TexCoord2(1, 0);
            GL.Vertex2(Position.X + A, Position.Y);
            GL.TexCoord2(1, 1);
            GL.Vertex2(Position.X + A, Position.Y + A);
            GL.TexCoord2(0, 1);
            GL.Vertex2(Position.X, Position.Y + A);

            GL.End();
        }
    }
}
