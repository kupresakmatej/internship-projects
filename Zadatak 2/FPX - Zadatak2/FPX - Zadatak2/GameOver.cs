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
    class GameOver
    {
        private static List<IRenderable> Drawables;
        private static List<IRenderable> renderables;

        private Color color = new Color();

        private static MouseControls MouseControls;
        private static GameWindow GameWindow;
        private static Circle CircleFollow;

        public List<Quad[]> winList = new List<Quad[]>();
        public List<QuadTexture[]> buttonList = new List<QuadTexture[]>();

        float xClick;
        float yClick;

        QuadTexture restartButton;
        QuadTexture exitButton;

        private static BoardLogic BoardLogic;

        public GameOver(List<IRenderable> drawables, MouseControls mouseControls, GameWindow gameWindow, Circle circleFollow, BoardLogic boardLogic)
        {
            Drawables = drawables;
            renderables = drawables;

            MouseControls = mouseControls;
            CircleFollow = circleFollow;
            CircleFollow.Layer = 3;

            GameWindow = gameWindow;
            BoardLogic = boardLogic;
        }

        public void EndScreen(Color color)
        {
            BoardLogic.ClearBoard();

            Drawables.Clear();
            GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();

            GameWindow.MouseDown -= MouseControls.DropOnMouse;
            GameWindow.MouseDown -= MouseControls.CallLogic;
            GameWindow.MouseDown += MouseControls.gameOver.ButtonLogic;

            DrawButtons(GameWindow.Width, GameWindow.Height);

            DrawEndScreen(GameWindow.Width, GameWindow.Height, color);
        }

        public void DrawButtons(float width, float height)
        {
            QuadTexture[] buttonsArray = new QuadTexture[2];

            Texture restartTexture = new Texture(@"C:\Users\Reroot\Desktop\FPX\restartButton.bmp");
            Texture exitTexture = new Texture(@"C:\Users\Reroot\Desktop\FPX\exitButton.bmp");

            restartButton = new QuadTexture(new Vector((width / 2) - 200f, (height / 2) - 200f), 100f, 100f, restartTexture);
            restartButton.Layer = 2;
            exitButton = new QuadTexture(new Vector((width / 2) + 175f, (height / 2) - 200f), 100f, 100f, exitTexture);
            exitButton.Layer = 2;

            buttonsArray[0] = restartButton;
            buttonsArray[1] = exitButton;
            buttonList.Add(buttonsArray);

            Drawables.Add(restartButton);
            Drawables.Add(exitButton);
        }

        public void ButtonLogic(object o, EventArgs e)
        {
            var mouse = OpenTK.Input.Mouse.GetCursorState();

            xClick = mouse.X - GameWindow.Bounds.X;
            yClick = GameWindow.Height - (mouse.Y - GameWindow.Bounds.Y);

            if (CheckIfInsideExitButton(GameWindow.Width, GameWindow.Height, xClick, yClick))
            {
                GameWindow.Exit();
            }
            else if (CheckIfInsideRestartButton(GameWindow.Width, GameWindow.Height, xClick, yClick))
            {
                GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
                GL.LoadIdentity();

                GameWindow.Exit();

                GameWindow window = new GameWindow(GameWindow.Width, GameWindow.Height);

                BoardLogic boardLogic = new BoardLogic();
                boardLogic.FillBoard();

                Game game = new Game(window, boardLogic);
            }
            else
            {
                Console.WriteLine("No buttons were clicked.");
            }
        }

        public bool CheckIfInsideExitButton(float width, float height, float x, float y)
        {
            if ((x >= exitButton.Position.X - 50f && x <= exitButton.Position.X + 50f) && (y >= exitButton.Position.Y - 50f && y <= exitButton.Position.Y + 50f))
            {
                return true;
            }
            return false;
        }

        public bool CheckIfInsideRestartButton(float width, float height, float x, float y)
        {
            if ((x >= restartButton.Position.X - 50f && x <= restartButton.Position.X + 50f) && (y >= restartButton.Position.Y - 50f && y <= restartButton.Position.Y + 50f))
            {
                return true;
            }
            return false;
        }

        public void DrawEndScreen(float width, float height, Color color)
        {
            //Quad[] winArray = new Quad[19];

            ////W
            //Quad quad1 = new Quad(new Vector((width / 2 - 160f), height / 2 + 100f), 25f, 150f, color);
            //Quad quad2 = new Quad(new Vector((width / 2 - 160f) + 50f, height / 2 + 80f), 25f, 90f, color);
            //Quad quad3 = new Quad(new Vector((width / 2 - 160f) + 100f, height / 2 + 100f), 25f, 150f, color);
            //Quad quad4 = new Quad(new Vector((width / 2 - 160f) + 50f, height / 2 + 25f), 125f, 25f, color);

            ////I
            //Quad quad5 = new Quad(new Vector((width / 2 - 160f) + 150f, height / 2 + 93f), 25f, 162.5f, color);

            ////N
            //Quad quad6 = new Quad(new Vector((width / 2 - 160f) + 200f, height / 2 + 93f), 25f, 162.5f, color);
            //Quad quad7 = new Quad(new Vector((width / 2 - 160f) + 235f, height / 2 + 161.5f), 50f, 25f, color);
            //Quad quad8 = new Quad(new Vector((width / 2 - 160f) + 250f, height / 2 + 93f), 25f, 162.5f, color);
            //Quad quad9 = new Quad(new Vector((width / 2 - 160f) + 262f, height / 2 + 24.5f), 50f, 25f, color);
            //Quad quad10 = new Quad(new Vector((width / 2 - 160f) + 292f, height / 2 + 93f), 25f, 162.5f, color);

            ////R
            //Quad quadR1 = new Quad(new Vector((width / 2) - 210f, (height / 2) - 115f), 6f, 55f, color.Gray);
            //Quad quadR2 = new Quad(new Vector((width / 2) - 195f, (height / 2) - 90f), 25f, 5f, color.Gray);
            //Quad quadR3 = new Quad(new Vector((width / 2) - 185f, (height / 2) - 100f), 5f, 25f, color.Gray);
            //Quad quadR4 = new Quad(new Vector((width / 2) - 195f, (height / 2) - 115f), 25f, 5f, color.Gray);
            //Quad quadR5 = new Quad(new Vector((width / 2) - 190f, (height / 2) - 130f), 5f, 25f, color.Gray);

            ////E
            //Quad quadE1 = new Quad(new Vector((width / 2) + 165f, (height / 2) - 110f), 6f, 55f, color.Gray);
            //Quad quadE2 = new Quad(new Vector((width / 2) + 175f, (height / 2) - 85f), 25f, 5f, color.Gray);
            //Quad quadE3 = new Quad(new Vector((width / 2) + 175f, (height / 2) - 112.5f), 25f, 5f, color.Gray);
            //Quad quadE4 = new Quad(new Vector((width / 2) + 175f, (height / 2) - 140f), 25f, 5f, color.Gray);

            //Drawables.Add(quad1);
            //Drawables.Add(quad2);
            //Drawables.Add(quad3);
            //Drawables.Add(quad4);
            //Drawables.Add(quad5);
            //Drawables.Add(quad6);
            //Drawables.Add(quad7);
            //Drawables.Add(quad8);
            //Drawables.Add(quad9);
            //Drawables.Add(quad10);

            //Drawables.Add(quadR1);
            //Drawables.Add(quadR2);
            //Drawables.Add(quadR3);
            //Drawables.Add(quadR4);
            //Drawables.Add(quadR5);

            //Drawables.Add(quadE1);
            //Drawables.Add(quadE2);
            //Drawables.Add(quadE3);
            //Drawables.Add(quadE4);

            //winArray[0] = quad1;
            //winArray[1] = quad2;
            //winArray[2] = quad3;
            //winArray[3] = quad4;
            //winArray[4] = quad5;
            //winArray[5] = quad6;
            //winArray[6] = quad7;
            //winArray[7] = quad8;
            //winArray[8] = quad9;
            //winArray[9] = quad10;
            //winArray[10] = quadR1;
            //winArray[11] = quadR2;
            //winArray[12] = quadR3;
            //winArray[13] = quadR4;
            //winArray[14] = quadR5;
            //winArray[15] = quadE1;
            //winArray[16] = quadE2;
            //winArray[17] = quadE3;
            //winArray[18] = quadE4;
            //winList.Add(winArray);
        }
    }
}