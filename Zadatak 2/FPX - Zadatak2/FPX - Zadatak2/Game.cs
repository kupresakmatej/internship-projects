﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Imaging;
using System.Drawing;

namespace FPX___Zadatak2
{
    public class Game
    {
        private static string AFFIRMATIVE = "x";
        private static string NEGATIVE = "y";

        GameWindow gameWindow;
        List<Drawable> drawables;

        public Game(GameWindow window)
        {
            this.gameWindow = window;
            drawables = new List<Drawable>();
            Input();
            Start();
        }

        private List<Drawable> Input()
        {
            Board board = new Board();
            List<Drawable> drawBoard;
            drawBoard = board.DrawBoard();

            foreach(Drawable drawable in drawBoard)
            {
                drawables.Add(drawable);
            }

            drawables.Sort((x, y) => x.Layer.CompareTo(y.Layer));
            return drawables;
        }

        public void Start()
        {
            Renderer renderer = new Renderer(drawables, gameWindow);

            //GL.Viewport(0, 0, gameWindow.Width, gameWindow.Height);

            gameWindow.Load += Loaded;
            gameWindow.Resize += Resize;
            gameWindow.RenderFrame += renderer.RenderF;
            gameWindow.Run(1.0 / 60.0);
        }

        public void Resize(object o, EventArgs e)
        {
            //OnResize.Invoke();

            GL.Viewport(0, 0, gameWindow.Width, gameWindow.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0.0, gameWindow.Width, 0.0, gameWindow.Height, -1.0, 1.0);

            GL.MatrixMode(MatrixMode.Modelview);
        }

        //public event Action OnResize;

        public void Loaded(object o, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}
