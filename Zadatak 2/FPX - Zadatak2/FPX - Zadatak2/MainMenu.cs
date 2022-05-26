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
        public List<QuadTexture[]> reshapeTitle = new List<QuadTexture[]>();
        public List<QuadTexture[]> reshapeButtons = new List<QuadTexture[]>();

        float xClick;
        float yClick;

        float w;
        float h;

        QuadTexture onePlayerButton;
        QuadTexture twoPlayerButton;

        private static Game Game;

        public MainMenu(GameWindow gameWindow, BoardGFX board, List<IRenderable> drawables, Game game)
        {
            GameWindow = gameWindow;
            Board = board;
            Drawables = drawables;
            Game = game;

            Drawables.Clear();

            onePlayerButton = new QuadTexture();
            twoPlayerButton = new QuadTexture();

            DrawButtons(GameWindow.Width, GameWindow.Height);
            DrawTitle(GameWindow.Width, GameWindow.Height);
        }

        public void DrawButtons(float width, float height)
        {
            QuadTexture[] quads = new QuadTexture[2];

            w = width / 2;
            h = height / 2;

            Texture textureOne = new Texture(@"C:\Users\Reroot\Desktop\FPX\onePlayer.bmp");
            Texture textureTwo = new Texture(@"C:\Users\Reroot\Desktop\FPX\twoPlayer.bmp");

            onePlayerButton = new QuadTexture(new Vector(width / 2 - 250f, height / 2 - 100f), 200f, 50f, textureOne);
            twoPlayerButton = new QuadTexture(new Vector(width / 2 + 250f, height / 2 - 100f), 200f, 50f, textureTwo);
            onePlayerButton.Layer = 3;
            twoPlayerButton.Layer = 3;

            Drawables.Add(onePlayerButton);
            Drawables.Add(twoPlayerButton);

            quads[0] = onePlayerButton;
            quads[1] = twoPlayerButton;

            reshapeButtons.Add(quads);

            Drawables.Sort((x, y) => x.Layer.CompareTo(y.Layer));
        }
        
        public void DrawTitle(float width, float height)
        {
            QuadTexture[] quadTextures = new QuadTexture[1];

            Texture texture = new Texture(@"C:\Users\Reroot\Desktop\FPX\mainMenu_Title750.bmp");

            QuadTexture mainMenuTitle = new QuadTexture(new Vector(width/2, height/2 + 200f), 750f, 750f, texture);
            mainMenuTitle.Layer = 2;

            quadTextures[0] = mainMenuTitle;

            Drawables.Add(mainMenuTitle);

            reshapeTitle.Add(quadTextures);

            Drawables.Sort((x, y) => x.Layer.CompareTo(y.Layer));
        }

        public void ButtonLogic(object o, EventArgs e)
        {
            var mouse = OpenTK.Input.Mouse.GetCursorState();

            xClick = mouse.X - GameWindow.Bounds.X;
            yClick = GameWindow.Height - (mouse.Y - GameWindow.Bounds.Y);

            if (StartOnePlayerGame(GameWindow.Width, GameWindow.Height, xClick, yClick))
            {
                System.Threading.Thread.Sleep(100);

                GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);

                Drawables.Clear();

                GameWindow.SwapBuffers();

                Game.isSinglePlayer = true;

                Game.Input();
                Game.Start(Game.isSinglePlayer);

                GL.LoadIdentity();
            }
            else if (StartTwoPlayerGame(GameWindow.Width, GameWindow.Height, xClick, yClick))
            {
                System.Threading.Thread.Sleep(100);

                GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);

                Drawables.Clear();

                GameWindow.SwapBuffers();

                Game.isSinglePlayer = false;

                Game.Input();
                Game.Start(Game.isSinglePlayer);

                GL.LoadIdentity();
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
            foreach(QuadTexture[] quads in reshapeTitle)
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

            foreach (QuadTexture[] quads in reshapeButtons)
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