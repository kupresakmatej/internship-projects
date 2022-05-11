﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace FPX___Zadatak2
{
    class CircleHole : IRenderable
    {
        public Vector Position { get; set; }
        private float RadiusOut { get; set; }
        private float RadiusIn { get; set; }
        private Color Color { get; set; }
        private int AmountOfTriangles { get; set; }

        private int layer;
        public int Layer { get { return this.layer; } set { this.layer = value; } }

        public CircleHole(Vector position, float radiusOut, float radiusIn, Color color, int amountOfTriangles)
        {
            Position = position;
            RadiusOut = radiusOut;
            RadiusIn = radiusIn;
            Color = color;
            AmountOfTriangles = amountOfTriangles;
            Layer = 1;
        }

        public void Draw()
        {
            //GL.Translate(Position.X, Position.Y, 0.0);

            GL.Color3(Color.R, Color.G, Color.B);
            //GL.Vertex2(Position.X, Position.Y);

            GL.Begin(BeginMode.TriangleStrip);
            
            for (int i = 0; i <= AmountOfTriangles; i++)
            {
                float angle = i * ((3.14159f/(float)AmountOfTriangles) * 2f);

                GL.Vertex2(Position.X + RadiusIn * Math.Cos(angle), Position.Y + RadiusIn * Math.Sin(angle));
                GL.Vertex2(Position.X + RadiusOut * Math.Cos(angle), Position.Y + RadiusOut * Math.Sin(angle));

                //GL.Vertex2(RadiusIn * Math.Cos(angle), RadiusIn * Math.Sin(angle));
                //GL.Vertex2(RadiusOut * Math.Cos(angle), RadiusOut * Math.Sin(angle));
            }
            GL.End();
        }
    }
}
