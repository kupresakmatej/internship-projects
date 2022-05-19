using System;
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
    class MainMenu
    {
        public static List<IRenderable> Drawables;

        private static GameWindow GameWindow;
        private static BoardGFX Board;
        Color color = new Color();
        public List<Quad[]> reshapeTitle = new List<Quad[]>();
        public List<Quad[]> reshapeButtons = new List<Quad[]>();

        float xClick;
        float yClick;

        float w;
        float h;

        Quad onePlayerButton;
        Quad twoPlayerButton;

        private static Game Game;

        public MainMenu(GameWindow gameWindow, BoardGFX board, List<IRenderable> drawables, Game game)
        {
            GameWindow = gameWindow;
            Board = board;
            Drawables = drawables;
            Game = game;

            onePlayerButton = new Quad();
            twoPlayerButton = new Quad();

            DrawButtons(GameWindow.Width, GameWindow.Height);
            DrawTitle(GameWindow.Width, GameWindow.Height);
        }

        public void DrawButtons(float width, float height)
        {
            Quad[] quads = new Quad[2];

            w = width / 2;
            h = height / 2;

            onePlayerButton = new Quad(new Vector(width / 2 - 250f, height / 2 - 285f), 200f, 50f, color.Gray);
            twoPlayerButton = new Quad(new Vector(width / 2 + 250f, height / 2 - 285f), 200f, 50f, color.Gray);

            Drawables.Add(onePlayerButton);
            Drawables.Add(twoPlayerButton);

            quads[0] = onePlayerButton;
            quads[1] = twoPlayerButton;

            reshapeButtons.Add(quads);
        }
        
        public void DrawTitle(float width, float height)
        {
            Quad[] quads = new Quad[6];

            Quad letterC1 = new Quad(new Vector(width/2 - 220f, height/2 + 200f), 25f, 200f, color.Red);
            Quad letterC2 = new Quad(new Vector(width / 2 - 133f, height / 2 + 287f), 150f, 25f, color.Red);
            Quad letterC3 = new Quad(new Vector(width / 2 - 133f, height / 2 + 112f), 150f, 25f, color.Red);

            Quad number4_1 = new Quad(new Vector(width/2 + 200f, height/2 + 200f), 25f, 200f, color.Yellow);
            Quad number4_2 = new Quad(new Vector(width / 2 + 130f, height / 2 + 200f), 150f, 25f, color.Yellow);
            Quad number4_3 = new Quad(new Vector(width / 2 + 67f, height / 2 + 245f), 25f, 110f, color.Yellow);

            Drawables.Add(letterC1);
            Drawables.Add(letterC2);
            Drawables.Add(letterC3);

            Drawables.Add(number4_1);
            Drawables.Add(number4_2);
            Drawables.Add(number4_3);

            quads[0] = letterC1;
            quads[1] = letterC2;
            quads[2] = letterC3;
            quads[3] = number4_1;
            quads[4] = number4_2;
            quads[5] = number4_3;

            reshapeTitle.Add(quads);
        }

        public async void ButtonLogic(object o, EventArgs e)
        {
            var mouse = OpenTK.Input.Mouse.GetCursorState();

            xClick = mouse.X - GameWindow.Bounds.X;
            yClick = GameWindow.Height - (mouse.Y - GameWindow.Bounds.Y);

            if (StartOnePlayerGame(GameWindow.Width, GameWindow.Height, xClick, yClick))
            {
                GameWindow.Exit();
            }
            else if (StartTwoPlayerGame(GameWindow.Width, GameWindow.Height, xClick, yClick))
            {
                System.Threading.Thread.Sleep(100);

                GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);

                Drawables.Clear();

                GL.LoadIdentity();

                GameWindow.SwapBuffers();

                Game.Input();
                Game.Start();
            }
            else
            {
                Console.WriteLine("No buttons were clicked.");
            }
        } 

        public bool StartOnePlayerGame(float width, float height, float x, float y)
        {
            if ((x >= onePlayerButton.Position.X - 110f && x <= onePlayerButton.Position.X + 110f) && (y >= onePlayerButton.Position.Y - 35f && y <= onePlayerButton.Position.Y + 35f))
            {
                return true;
            }
            return false;
        }

        public bool StartTwoPlayerGame(float width, float height, float x, float y)
        {
            if ((x >= twoPlayerButton.Position.X - 110f && x <= twoPlayerButton.Position.X + 110f) && (y >= twoPlayerButton.Position.Y - 35f && y <= twoPlayerButton.Position.Y + 35f))
            {
                return true;
            }
            return false;
        }

        public void WindowReshape(float width, float height)
        {
            foreach(Quad[] quads in reshapeTitle)
            {
                if (width < w)
                {
                    for (int i = 0; i < quads.Length; i++)
                    {
                        quads[i].Position = new Vector(quads[i].Position.X + (width / 2 - w), quads[i].Position.Y);
                    }
                }
                if (width > w)
                {
                    for (int i = 0; i < quads.Length; i++)
                    {
                        quads[i].Position = new Vector(quads[i].Position.X + (width / 2 - w), quads[i].Position.Y);
                    }
                }
                if (height < h)
                {
                    for (int i = 0; i < quads.Length; i++)
                    {
                        quads[i].Position = new Vector(quads[i].Position.X, quads[i].Position.Y + (height / 2 - h));
                    }
                }
                if (height > h)
                {
                    for (int i = 0; i < quads.Length; i++)
                    {
                        quads[i].Position = new Vector(quads[i].Position.X, quads[i].Position.Y + (height / 2 - h));
                    }
                }
            }

            foreach (Quad[] quads in reshapeButtons)
            {
                if (width < w)
                {
                    for (int i = 0; i < quads.Length; i++)
                    {
                        quads[i].Position = new Vector(quads[i].Position.X + (width / 2 - w), quads[i].Position.Y);
                    }
                }
                if (width > w)
                {
                    for (int i = 0; i < quads.Length; i++)
                    {
                        quads[i].Position = new Vector(quads[i].Position.X + (width / 2 - w), quads[i].Position.Y);
                    }
                }
                if (height < h)
                {
                    for (int i = 0; i < quads.Length; i++)
                    {
                        quads[i].Position = new Vector(quads[i].Position.X, quads[i].Position.Y + (height / 2 - h));
                    }
                }
                if (height > h)
                {
                    for (int i = 0; i < quads.Length; i++)
                    {
                        quads[i].Position = new Vector(quads[i].Position.X, quads[i].Position.Y + (height / 2 - h));
                    }
                }
            }

            w = width / 2;
            h = height / 2;
        }
    }
}