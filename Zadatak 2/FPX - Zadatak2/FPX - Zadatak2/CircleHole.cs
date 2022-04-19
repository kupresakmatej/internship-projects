﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace FPX___Zadatak2
{
    class CircleHole : Drawable
    {
        private Vector Position { get; set; }
        private float RadiusOut { get; set; }
        private float RadiusIn { get; set; }
        private Color Color { get; set; }
        private int AmountOfTriangles { get; set; }

        public CircleHole(Vector position, float radiusOut, float radiusIn, Color color, int amountOfTriangles)
        {
            Position = position;
            RadiusOut = radiusOut;
            RadiusIn = radiusIn;
            Color = color;
            AmountOfTriangles = amountOfTriangles;
        }

        public override void Draw()
        {
            GL.Translate(Position.X + RadiusOut, Position.Y + RadiusOut, 0.0);

            GL.Begin(BeginMode.TriangleFan);

            GL.Color3(Color.R, Color.G, Color.B);
            GL.Vertex2(Position.X, Position.Y);

            for (int i = 0; i <= AmountOfTriangles; i++)
            {
                GL.Vertex2(Position.X + (RadiusOut * Math.Cos(i * (2 * Math.PI) / AmountOfTriangles)), Position.Y + (RadiusOut * Math.Sin(i * (2 * Math.PI) / AmountOfTriangles)));
            }

            GL.End();

            GL.Begin(BeginMode.TriangleFan);

            GL.Color3(0, 0, 0);

            for (int i = 0; i <= AmountOfTriangles; i++)
            {
                GL.Vertex2(Position.X + (RadiusIn * Math.Cos(i * (2 * Math.PI) / AmountOfTriangles)), Position.Y + (RadiusIn * Math.Sin(i * (2 * Math.PI) / AmountOfTriangles)));
            }

            GL.End();

        }
    }
}
