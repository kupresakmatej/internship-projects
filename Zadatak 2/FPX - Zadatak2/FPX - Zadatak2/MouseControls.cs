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
    class MouseControls
    {
        GameOver gameOver;

        private List<IRenderable> drawables;
        private List<Circle> circles;

        private GameWindow gameWindow;

        private Color color = new Color();

        private Circle circleFollow;
        private Quad quad;

        private static int[] columnDrop;

        public static Game Game;

        float xClick;
        float yClick;

        private int playerCounter;

        private static BoardGFX Board;
        private static BoardLogic BoardLogic;

        Logic logic;

        public int ColumnIdx { get; set; }

        public MouseControls(List<IRenderable> Drawables, List<Circle> Circles, GameWindow GameWindow, int[] ColumnDrop, Game CanDrop, int PlayerCounter, BoardGFX board, BoardLogic boardLogic)
        {
            drawables = Drawables;
            circles = Circles;
            gameWindow = GameWindow;
            columnDrop = ColumnDrop;
            Game = CanDrop;
            playerCounter = PlayerCounter;
            Board = board;
            BoardLogic = boardLogic;

            logic = new Logic(BoardLogic);

            ColumnIdx = 0;

            circleFollow = new Circle(new Vector(gameWindow.Width / 2, gameWindow.Height / 2), 10f, color.Yellow, 250);
            circleFollow.Layer = 2;
            drawables.Add(circleFollow);

            quad = new Quad(new Vector(-10000, -10000), 100000, 100000, color.Black);
        }

        public void CallLogic(object o, EventArgs e)
        {
            if (Game.canDrop && !logic.GameOver())
            {
                logic.DropIntoBoard(ColumnIdx, playerCounter);
                Console.WriteLine(ColumnIdx);
                BoardLogic.PrintBoard();
            }
            if (logic.GameOver())
            {
                Console.WriteLine("over");

                GameOver();
            }
        }

        public async void GameOver()
        {
            await Task.Delay(2500);

            quad.Position = new Vector(gameWindow.Width / 2, gameWindow.Height / 2);
            drawables.Add(quad);
        }

        public void FollowMouse(object o, EventArgs e)
        {
            var mouse = OpenTK.Input.Mouse.GetCursorState();

            float x = mouse.X - gameWindow.Bounds.X;
            float y = gameWindow.Height - (mouse.Y - gameWindow.Bounds.Y);

            circleFollow.Position = new Vector(x - 5f, y + 25f);

            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        public void DropOnMouse(object o, EventArgs e)
        {
            var mouse = OpenTK.Input.Mouse.GetCursorState();

            xClick = mouse.X - gameWindow.Bounds.X;
            yClick = gameWindow.Height - (mouse.Y - gameWindow.Bounds.Y);

            ColumnIdx = 0;

            if(Game.canDrop)
            {
                if(playerCounter % 2 == 0)
                {
                    DrawOnClick(xClick, yClick, color.Red);
                    playerCounter++;
                    ChangePlayerColor(color.Yellow, color.White);
                }
                else
                {
                    DrawOnClick(xClick, yClick, color.Yellow);
                    playerCounter++;
                    ChangePlayerColor(color.White, color.Red);
                }
            }
            else
            {
                Console.WriteLine("wait");      
            }
        }

        public void ChangePlayerColor(Color p1Color, Color p2Color)
        {
            foreach(Quad[] quad in Board.p1List)
            {
                quad[0].Color = p1Color;
                quad[1].Color = p1Color;
                quad[2].Color = p1Color;
                quad[3].Color = p1Color;
                quad[4].Color = p1Color;
            }
            foreach (Quad[] quad in Board.p2List)
            {
                quad[0].Color = p2Color;
                quad[1].Color = p2Color;
                quad[2].Color = p2Color;
                quad[3].Color = p2Color;
                quad[4].Color = p2Color;
                quad[5].Color = p2Color;
                quad[6].Color = p2Color;
                quad[7].Color = p2Color;
                quad[8].Color = p2Color;
            }
        }

        public void DrawOnClick(float x, float y, Color color)
        {
            if (x > (gameWindow.Bounds.Width / 2 - 50f) && x < (gameWindow.Bounds.Width / 2 + 50f) && Game.canDrop) //4. column
            {
                Console.WriteLine(string.Format("x: {0} y: {1}", x, y));

                Circle circle = new Circle(new Vector(gameWindow.Width / 2 + 0.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                columnDrop[3] += 1;

                ColumnIdx = 3;

                drawables.Add(circle);
                circles.Add(circle);
            }
            else if ((x < (gameWindow.Bounds.Width / 2 - 50f) && x > (gameWindow.Bounds.Width / 2 - 150f))) //3. column
            {
                Console.WriteLine(string.Format("x: {0} y: {1}", x, y));

                Circle circle = new Circle(new Vector(gameWindow.Width / 2 - 99.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                columnDrop[2] += 1;

                ColumnIdx = 2;

                drawables.Add(circle);
                circles.Add(circle);
            }
            else if ((x < (gameWindow.Bounds.Width / 2 - 150f) && x > (gameWindow.Bounds.Width / 2 - 250f))) //2. column
            {
                Console.WriteLine(string.Format("x: {0} y: {1}", x, y));

                Circle circle = new Circle(new Vector(gameWindow.Width / 2 - 199.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                columnDrop[1] += 1;

                ColumnIdx = 1;

                drawables.Add(circle);
                circles.Add(circle);
            }
            else if ((x < (gameWindow.Bounds.Width / 2 - 250f) && x > (gameWindow.Bounds.Width / 2 - 350f))) //1. column
            {
                Console.WriteLine(string.Format("x: {0} y: {1}", x, y));

                Circle circle = new Circle(new Vector(gameWindow.Width / 2 - 299.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                columnDrop[0] += 1;

                ColumnIdx = 0;

                drawables.Add(circle);
                circles.Add(circle);
            }
            else if ((x > (gameWindow.Bounds.Width / 2 + 50f) && x < (gameWindow.Bounds.Width / 2 + 150f))) //5. column
            {
                Console.WriteLine(string.Format("x: {0} y: {1}", x, y));

                Circle circle = new Circle(new Vector(gameWindow.Width / 2 + 100.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                columnDrop[4] += 1;

                ColumnIdx = 4;

                drawables.Add(circle);
                circles.Add(circle);
            }
            else if ((x > (gameWindow.Bounds.Width / 2 + 150f) && x < (gameWindow.Bounds.Width / 2 + 250f))) //6. column
            {
                Console.WriteLine(string.Format("x: {0} y: {1}", x, y));

                Circle circle = new Circle(new Vector(gameWindow.Width / 2 + 200.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                columnDrop[5] += 1;

                ColumnIdx = 5;

                drawables.Add(circle);
                circles.Add(circle);
            }
            else if ((x > (gameWindow.Bounds.Width / 2 + 250f) && x < (gameWindow.Bounds.Width / 2 + 350f))) //7. column
            {
                Console.WriteLine(string.Format("x: {0} y: {1}", x, y));

                Circle circle = new Circle(new Vector(gameWindow.Width / 2 + 300.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                columnDrop[6] += 1;

                ColumnIdx = 6;

                drawables.Add(circle);
                circles.Add(circle);
            }

            drawables.Sort((j, k) => j.Layer.CompareTo(k.Layer));

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.ColorBufferBit);
        }
    }
}
