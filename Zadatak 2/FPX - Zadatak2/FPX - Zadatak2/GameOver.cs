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

        private Color color = new Color();

        private static MouseControls MouseControls;
        private static GameWindow GameWindow;
        private static Circle CircleFollow;

        public List<Quad[]> winList = new List<Quad[]>();
        public List<Quad[]> buttonList = new List<Quad[]>();

        float xClick;
        float yClick;

        Quad restartButton;
        Quad exitButton;

        private static Game Game;
        private static BoardLogic BoardLogic;

        public GameOver(List<IRenderable> drawables, MouseControls mouseControls, GameWindow gameWindow, Circle circleFollow, Game game, BoardLogic boardLogic)
        {
            Drawables = drawables;

            MouseControls = mouseControls;
            CircleFollow = circleFollow;
            CircleFollow.Layer = 2;

            restartButton = new Quad();
            exitButton = new Quad();

            GameWindow = gameWindow;
            Game = game;
            BoardLogic = boardLogic;
        }

        public void EndScreen()
        {
            GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
            Drawables.Clear();

            GameWindow.MouseDown -= MouseControls.DropOnMouse;
            GameWindow.MouseDown -= MouseControls.CallLogic;
            GameWindow.MouseDown += MouseControls.gameOver.ButtonLogic;

            DrawEndScreen(GameWindow.Width, GameWindow.Height);
            DrawButtons(GameWindow.Width, GameWindow.Height);

            GL.LoadIdentity();

            //gameWindow.Exit();
        }

        public async void DrawButtons(float width, float height)
        {
            Quad[] buttonsArray = new Quad[2];

            await Task.Delay(1500);

            restartButton = new Quad(new Vector((width / 2) - 200f, (height / 2) - 200f), 100f, 100f, color.Gray);
            exitButton = new Quad(new Vector((width / 2) + 175f, (height / 2) - 200f), 100f, 100f, color.Gray);

            Drawables.Add(restartButton);
            Drawables.Add(exitButton);

            buttonsArray[0] = restartButton;
            buttonsArray[1] = exitButton;
            buttonList.Add(buttonsArray);

            Drawables.Add(CircleFollow);
        }

        public async void ButtonLogic(object o, EventArgs e)
        {
            var mouse = OpenTK.Input.Mouse.GetCursorState();

            xClick = mouse.X - GameWindow.Bounds.X;
            yClick = GameWindow.Height - (mouse.Y - GameWindow.Bounds.Y);

            foreach(Quad[] button in buttonList)
            {
                Console.WriteLine(string.Format("Button {0} {1}", button[0].Position.X, button[0].Position.Y));
                Console.WriteLine(string.Format("Button {0} {1}", button[1].Position.X, button[1].Position.Y));
            }

            Console.WriteLine(string.Format("Click {0} {1}", xClick, yClick));
            Console.WriteLine(string.Format("Click {0} {1}", exitButton.Position.X/2, exitButton.Position.Y/2));

            if(CheckIfInsideExitButton(GameWindow.Width, GameWindow.Height, xClick, yClick))
            {
                GameWindow.Exit();
            }
            //else if(CheckIfInsideRestartButton(GameWindow.Width, GameWindow.Height, xClick, yClick))
            //{
            //    await Task.Delay(500);

            //    GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);
            //    Drawables.Clear();

            //    await Task.Delay(1000);

            //    GameWindow.MouseDown += MouseControls.DropOnMouse;
            //    GameWindow.MouseDown += MouseControls.CallLogic;
            //    GameWindow.MouseDown -= MouseControls.gameOver.ButtonLogic;

            //    GL.LoadIdentity();
            //}
            else
            {
                Console.WriteLine("No buttons were clicked.");
            }
        }

        public bool CheckIfInsideExitButton(float width, float height, float x, float y)
        {
            if((x >= exitButton.Position.X - 50f && x <= exitButton.Position.X + 50f) && (y >= exitButton.Position.Y - 50f && y <= exitButton.Position.Y + 50f))
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

        public async void DrawEndScreen(float width, float height)
        {
            Quad[] winArray = new Quad[10];

            await Task.Delay(1000);

            //W
            Quad quad1 = new Quad(new Vector((width/2 - 160f), height/2 + 100f), 25f, 150f, color.Blue);
            Quad quad2 = new Quad(new Vector((width / 2 - 160f) + 50f, height / 2 + 80f), 25f, 90f, color.Blue);
            Quad quad3 = new Quad(new Vector((width / 2 - 160f) + 100f, height / 2 + 100f), 25f, 150f, color.Blue);
            Quad quad4 = new Quad(new Vector((width / 2 - 160f) + 50f, height / 2 + 25f), 125f, 25f, color.Blue);

            //I
            Quad quad5 = new Quad(new Vector((width / 2 - 160f) + 150f, height / 2 + 93f), 25f, 162.5f, color.Blue);

            //N
            Quad quad6 = new Quad(new Vector((width / 2 - 160f) + 200f, height / 2 + 93f), 25f, 162.5f, color.Blue);
            Quad quad7 = new Quad(new Vector((width / 2 - 160f) + 235f, height / 2 + 161.5f), 50f, 25f, color.Blue);
            Quad quad8 = new Quad(new Vector((width / 2 - 160f) + 250f, height / 2 + 93f), 25f, 162.5f, color.Blue);
            Quad quad9 = new Quad(new Vector((width / 2 - 160f) + 262f, height / 2 + 24.5f), 50f, 25f, color.Blue);
            Quad quad10 = new Quad(new Vector((width / 2 - 160f) + 292f, height / 2 + 93f), 25f, 162.5f, color.Blue);

            Drawables.Add(quad1);
            Drawables.Add(quad2);
            Drawables.Add(quad3);
            Drawables.Add(quad4);
            Drawables.Add(quad5);
            Drawables.Add(quad6);
            Drawables.Add(quad7);
            Drawables.Add(quad8);
            Drawables.Add(quad9);
            Drawables.Add(quad10);

            winArray[0] = quad1;
            winArray[1] = (quad2);
            winArray[2] = (quad3);
            winArray[3] = (quad4);
            winArray[4] = (quad5);
            winArray[5] = (quad6);
            winArray[6] = (quad7);
            winArray[7] = (quad8);
            winArray[8] = (quad9);
            winArray[9] = (quad10);
            winList.Add(winArray);

            Drawables.Add(CircleFollow);
        }
    }
}
