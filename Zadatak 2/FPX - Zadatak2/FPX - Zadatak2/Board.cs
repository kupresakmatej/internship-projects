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
        private List<Quad> quads = new List<Quad>();
        private List<CircleHole> circleHoles = new List<CircleHole>();
        private List<Circle> circles = new List<Circle>();

        Color color = new Color();

        private static GameWindow GameWindow;

        Game game = new Game();

        private Circle circle = new Circle(new Vector(0f, 0f), 50f, new Color(0, 255, 0), 250);
        private Circle circle1 = new Circle(new Vector(10f, 10f), 50f, new Color(0, 255, 0), 250);

        public Board(GameWindow gameWindow)
        {
            GameWindow = gameWindow;
        }

        public List<Drawable> GenerateBoard()
        {
            for(int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 6; j++)
                {
                    DrawFrame(i * 100f, j* 100f);
                    DrawHole(i * 200f, j * 200f);
                }
            }

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    FillHole(i * 100f, j * 100f);
                }
            }

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    FillHoleDown(i * 100f, j * 100f);
                }
            }

            for(int i = 0; i < 7; i++)
            {
                FillHoleUp(i * 100f, 0);
            }

            //drawables.Add(circle);
            //drawables.Add(circle1);
            return drawables;
        }

        public void DrawFrame(float x, float y)
        {
            Quad quad = new Quad(new Vector((GameWindow.Width/2 - 375f) + x, (GameWindow.Height/ 2 - 300f) + y), 200f, 40f, color.Blue);
            Quad quad2 = new Quad(new Vector((GameWindow.Width / 2 - 375f) + x, (GameWindow.Height / 2 - 300f) + y), 42f, 200f, color.Blue);
            Quad quad3 = new Quad(new Vector((GameWindow.Width / 2 - 275f) + x, (GameWindow.Height / 2 - 300f) + y), 42f, 200f, color.Blue);
            Quad quad4 = new Quad(new Vector((GameWindow.Width / 2 - 375f) + x, (GameWindow.Height / 2 - 200f) + y), 242f, 40f, color.Blue);

            drawables.Add(quad);
            drawables.Add(quad2);
            drawables.Add(quad3);
            drawables.Add(quad4);

            //Circle circle = new Circle(new Vector(162.5f, 37f), 35f, new Color(255, 255, 0), 250);
        }

        public void DrawHole(float x, float y)
        {
            CircleHole hole = new CircleHole(new Vector((GameWindow.Width / 2 - 100f) + x, (GameWindow.Height / 2 - 235f) + y), 115f, 70f, color.Blue, 250);

            drawables.Add(hole);

            circleHoles.Add(hole);
        }

        public void FillHole(float x, float y)
        {
            Circle circle = new Circle(new Vector((GameWindow.Width / 2 - 275f) + x, (GameWindow.Height / 2 - 195f) + y), 40f, color.Blue, 250);

            drawables.Add(circle);

            circles.Add(circle);
        }

        public void FillHoleDown(float x, float y)
        {
            Circle circle = new Circle(new Vector((GameWindow.Width / 2 - 275f) + x, (GameWindow.Height / 2 - 275f) + y), 25f, color.Blue, 250);

            drawables.Add(circle);

            circles.Add(circle);
        }

        public void FillHoleUp(float x, float y)
        {
            Circle circle = new Circle(new Vector((GameWindow.Width / 2 - 275f) + x, (GameWindow.Height / 2 + 300f) + y), 25f, color.Blue, 250);

            drawables.Add(circle);

            circles.Add(circle);
        }

        public void WindowReshape(int width, int height)
        {
            //foreach (Quad quad in quads)
            //{
            //    quad.Position = new Vector(quad.Position.X, quad.Position.Y);
            //}
            //foreach (CircleHole hole in circleHoles)
            //{
            //    hole.Position = new Vector(hole.Position.X, hole.Position.Y);
            //}
            //foreach (Circle circle in circles)
            //{
            //    circle.Position = new Vector(circle.Position.X, circle.Position.Y);
            //}

            //circle.Position = new Vector(width / 2, height / 2);
            //circle1.Position = new Vector((width / 2) + 50f, height / 2);
            //Console.WriteLine(string.Format("{0} {1}", circle.Position.X, circle.Position.Y));
        }
    }
}