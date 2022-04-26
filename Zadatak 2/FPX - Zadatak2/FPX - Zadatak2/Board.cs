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
    class Board
    {
        private List<Drawable> drawables = new List<Drawable>();

        private float Width { get; set; }
        private float Height { get; set; }

        Game game = new Game();

        public Board(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public List<Drawable> DrawBoard()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    DrawFrame(i * 50f, j * 50f);
                    DrawHole(i * 100f, j * 100f);
                }
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    FillHole(i * 50f, j * 50f);
                }
            }

            return drawables;
        }

        public void DrawFrame(float x, float y)
        {
            Quad quad = new Quad(new Vector(x + 150f, y + 25f), 120f, 20f, new Color(0, 0, 255));
            Quad quad2 = new Quad(new Vector(x + 150f, y + 25f), 20f, 110f, new Color(0, 0, 255));
            Quad quad3 = new Quad(new Vector(x + 200f, y + 25f), 20f, 110f, new Color(0, 0, 255));
            Quad quad4 = new Quad(new Vector(x + 150f, y + 75f), 120f, 20f, new Color(0, 0, 255));

            //Circle circle = new Circle(new Vector(162.5f, 37f), 35f, new Color(255, 255, 0), 250);

            drawables.Add(quad);
            drawables.Add(quad2);
            drawables.Add(quad3);
            drawables.Add(quad4);
            //drawables.Add(circle);
        }

        public void DrawHole(float x, float y)
        {
            CircleHole hole = new CircleHole(new Vector(x + 300f, y + 50f), 60f, 40f, new Color(0, 0, 255), 250);

            drawables.Add(hole);
        }

        public void FillHole(float x, float y)
        {
            Circle circle = new Circle(new Vector(x + 191.5f, y + 66.5f), 26f, new Color(0, 0, 255), 250);

            drawables.Add(circle);
        }       

        public void WindowReshape(int width, int height)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0.0, Width, Height, 0.0, 1.0, -1.0);
            var ratioX = width / (float)Width;
            var ratioY = height / (float)Height;
            var ratio = ratioX < ratioY ? ratioX : ratioY;
            var viewWidth = Convert.ToInt32(Width * ratio);
            var viewHeight = Convert.ToInt32(Height * ratio);
            var viewX = Convert.ToInt32((width - Width * ratio) / 2);
            var viewY = Convert.ToInt32((height - Height * ratio) / 2);
            GL.Viewport(viewX, viewY, viewWidth, viewHeight);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
        }
    }
}