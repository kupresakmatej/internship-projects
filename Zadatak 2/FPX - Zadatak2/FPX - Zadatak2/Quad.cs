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
    class Quad : IDrawable
    {
        public Vector Position { get; set; }
        private float A { get; set; }
        private float B { get; set; }
        private Color Color { get; set; }

        private int layer;
        public int Layer { get { return this.layer; } set { this.layer = value; } }

        public Quad(Vector position, float a, float b, Color color)
        {
            Position = position;
            A = a;
            B = b;
            Color = color;
            Layer = 1;
        }

        public void Draw()
        {
            GL.Begin(BeginMode.Quads);

            GL.Color3(Color.R, Color.G, Color.B);

            GL.Vertex2(Position.X - A/2, Position.Y - B/2);
            GL.Vertex2(Position.X + A / 2, Position.Y - B/2);
            GL.Vertex2(Position.X + A/2, Position.Y + B/2);
            GL.Vertex2(Position.X - A / 2, Position.Y + B/2);

            GL.End();
        }
    }
}
