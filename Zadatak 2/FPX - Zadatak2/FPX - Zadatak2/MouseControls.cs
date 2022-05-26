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
        private List<IRenderable> drawables;
        private List<Circle> circles;

        private GameWindow gameWindow;

        private Color color = new Color();

        public Circle circleFollow = new Circle();

        private static int[] columnDrop;

        public static Game Game;

        float xClick;
        float yClick;

        public int playerCounter;

        private static BoardGFX Board;
        private static BoardLogic BoardLogic;
        public GameOver gameOver;

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

            circleFollow = new Circle(new Vector(gameWindow.Width / 2, gameWindow.Height / 2), 10f, color.Green, 250);
            circleFollow.Layer = 3;
            drawables.Add(circleFollow);


            gameOver = new GameOver(Drawables, this, GameWindow, circleFollow, BoardLogic, Game);
            Board.winList = gameOver.winList;
            Board.buttonList = gameOver.buttonList;
        }

        public async void CallLogic(object o, EventArgs e)
        {
            if (logic.GameOver())
            { 
                await Task.Delay(2500);
                System.Threading.Thread.Sleep(100);

                drawables.Clear();

                BoardLogic.ClearBoard();
                logic.coin = Coin.Empty;

                Game.canDrop = false;

                if (playerCounter % 2 != 0)
                {
                    GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);

                    GL.LoadIdentity();

                    gameOver.EndScreen(color.Red);
                }
                else
                {
                    GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit);

                    GL.LoadIdentity();

                    gameOver.EndScreen(color.Yellow);
                }
            }
        }

        public void FollowMouse(object o, EventArgs e)
        {
            var mouse = OpenTK.Input.Mouse.GetCursorState();

            float x = mouse.X - gameWindow.Bounds.X;
            float y = gameWindow.Height - (mouse.Y - gameWindow.Bounds.Y);

            circleFollow.Position = new Vector(x - 5f, y + 25f);

            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        public async void DropOnMouse(object o, EventArgs e)
        {
            var mouse = OpenTK.Input.Mouse.GetCursorState();

            xClick = mouse.X - gameWindow.Bounds.X;
            yClick = gameWindow.Height - (mouse.Y - gameWindow.Bounds.Y);

            ColumnIdx = 0;

            if(Game.canDrop && Game.isSinglePlayer)
            {
                if(playerCounter % 2 != 0)
                {
                    DrawOnClick(xClick, yClick, color.Yellow);
                }
                else
                {
                    DrawAI(color.Red);
                }
            }
            else if (Game.canDrop && !Game.isSinglePlayer)
            {
                if (playerCounter % 2 == 0)
                {
                    DrawOnClick(xClick, yClick, color.Red);
                }
                else
                {
                    DrawOnClick(xClick, yClick, color.Yellow);
                }
            }
        }

        public void ChangePlayerColor(object o, EventArgs e)
        {
            if(playerCounter % 2 != 0 && (xClick >= (gameWindow.Bounds.Width/2 - 350f) || xClick <= (gameWindow.Bounds.Width/2 + 350f)))
            {
                foreach (Quad[] quad in Board.p1List)
                {
                    quad[0].Color = color.Yellow;
                    quad[1].Color = color.Yellow;
                    quad[2].Color = color.Yellow;
                    quad[3].Color = color.Yellow;
                    quad[4].Color = color.Yellow;
                }
                foreach (Quad[] quad in Board.p2List)
                {
                    quad[0].Color = color.White;
                    quad[1].Color = color.White;
                    quad[2].Color = color.White;
                    quad[3].Color = color.White;
                    quad[4].Color = color.White;
                    quad[5].Color = color.White;
                    quad[6].Color = color.White;
                    quad[7].Color = color.White;
                    quad[8].Color = color.White;
                }
            }
            else if(playerCounter % 2 == 0 && (xClick >= (gameWindow.Bounds.Width / 2 - 350f) || xClick <= (gameWindow.Bounds.Width / 2 + 350f)))
            {
                foreach (Quad[] quad in Board.p1List)
                {
                    quad[0].Color = color.White;
                    quad[1].Color = color.White;
                    quad[2].Color = color.White;
                    quad[3].Color = color.White;
                    quad[4].Color = color.White;
                }
                foreach (Quad[] quad in Board.p2List)
                {
                    quad[0].Color = color.Red;
                    quad[1].Color = color.Red;
                    quad[2].Color = color.Red;
                    quad[3].Color = color.Red;
                    quad[4].Color = color.Red;
                    quad[5].Color = color.Red;
                    quad[6].Color = color.Red;
                    quad[7].Color = color.Red;
                    quad[8].Color = color.Red;
                }
            }
        }

        public void DrawOnClick(float x, float y, Color color)
        {
            if(Game.isSinglePlayer)
            {
                if (x > (gameWindow.Bounds.Width / 2 - 50f) && x < (gameWindow.Bounds.Width / 2 + 50f) && Game.canDrop) //4. column
                {
                    Circle circle = new Circle(new Vector(gameWindow.Width / 2 + 0.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                    columnDrop[3] += 1;

                    ColumnIdx = 3;

                    playerCounter++;

                    logic.FallIntoPlaceSP(ColumnIdx);

                    drawables.Add(circle);
                    circles.Add(circle);
                }
                else if (x < (gameWindow.Bounds.Width / 2 - 50f) && x > (gameWindow.Bounds.Width / 2 - 150f) && Game.canDrop) //3. column
                {
                    Circle circle = new Circle(new Vector(gameWindow.Width / 2 - 99.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                    columnDrop[2] += 1;

                    ColumnIdx = 2;

                    playerCounter++;

                    logic.FallIntoPlaceSP(ColumnIdx);

                    drawables.Add(circle);
                    circles.Add(circle);
                }
                else if (x < (gameWindow.Bounds.Width / 2 - 150f) && x > (gameWindow.Bounds.Width / 2 - 250f) && Game.canDrop) //2. column
                {
                    Circle circle = new Circle(new Vector(gameWindow.Width / 2 - 199.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                    columnDrop[1] += 1;

                    ColumnIdx = 1;

                    playerCounter++;

                    logic.FallIntoPlaceSP(ColumnIdx);

                    drawables.Add(circle);
                    circles.Add(circle);
                }
                else if (x < (gameWindow.Bounds.Width / 2 - 250f) && x > (gameWindow.Bounds.Width / 2 - 350f) && Game.canDrop) //1. column
                {
                    Circle circle = new Circle(new Vector(gameWindow.Width / 2 - 299.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                    columnDrop[0] += 1;

                    ColumnIdx = 0;

                    playerCounter++;

                    logic.FallIntoPlaceSP(ColumnIdx);

                    drawables.Add(circle);
                    circles.Add(circle);
                }
                else if (x > (gameWindow.Bounds.Width / 2 + 50f) && x < (gameWindow.Bounds.Width / 2 + 150f) && Game.canDrop) //5. column
                {
                    Circle circle = new Circle(new Vector(gameWindow.Width / 2 + 100.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                    columnDrop[4] += 1;

                    ColumnIdx = 4;

                    playerCounter++;

                    logic.FallIntoPlaceSP(ColumnIdx);

                    drawables.Add(circle);
                    circles.Add(circle);
                }
                else if (x > (gameWindow.Bounds.Width / 2 + 150f) && x < (gameWindow.Bounds.Width / 2 + 250f) && Game.canDrop) //6. column
                {
                    Circle circle = new Circle(new Vector(gameWindow.Width / 2 + 200.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                    columnDrop[5] += 1;

                    ColumnIdx = 5;

                    playerCounter++;

                    logic.FallIntoPlaceSP(ColumnIdx);

                    drawables.Add(circle);
                    circles.Add(circle);
                }
                else if (x > (gameWindow.Bounds.Width / 2 + 250f) && x < (gameWindow.Bounds.Width / 2 + 350f) && Game.canDrop) //7. column
                {
                    Circle circle = new Circle(new Vector(gameWindow.Width / 2 + 300.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                    columnDrop[6] += 1;

                    ColumnIdx = 6;

                    playerCounter++;

                    logic.FallIntoPlaceSP(ColumnIdx);

                    drawables.Add(circle);
                    circles.Add(circle);
                }
            }
            else
            {
                if (x > (gameWindow.Bounds.Width / 2 - 50f) && x < (gameWindow.Bounds.Width / 2 + 50f) && Game.canDrop) //4. column
                {
                    Circle circle = new Circle(new Vector(gameWindow.Width / 2 + 0.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                    columnDrop[3] += 1;

                    ColumnIdx = 3;

                    playerCounter++;

                    logic.DropIntoBoard(ColumnIdx, playerCounter);

                    drawables.Add(circle);
                    circles.Add(circle);
                }
                else if (x < (gameWindow.Bounds.Width / 2 - 50f) && x > (gameWindow.Bounds.Width / 2 - 150f) && Game.canDrop) //3. column
                {
                    Circle circle = new Circle(new Vector(gameWindow.Width / 2 - 99.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                    columnDrop[2] += 1;

                    ColumnIdx = 2;

                    playerCounter++;

                    logic.DropIntoBoard(ColumnIdx, playerCounter);

                    drawables.Add(circle);
                    circles.Add(circle);
                }
                else if (x < (gameWindow.Bounds.Width / 2 - 150f) && x > (gameWindow.Bounds.Width / 2 - 250f) && Game.canDrop) //2. column
                {
                    Circle circle = new Circle(new Vector(gameWindow.Width / 2 - 199.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                    columnDrop[1] += 1;

                    ColumnIdx = 1;

                    playerCounter++;

                    logic.DropIntoBoard(ColumnIdx, playerCounter);

                    drawables.Add(circle);
                    circles.Add(circle);
                }
                else if (x < (gameWindow.Bounds.Width / 2 - 250f) && x > (gameWindow.Bounds.Width / 2 - 350f) && Game.canDrop) //1. column
                {
                    Circle circle = new Circle(new Vector(gameWindow.Width / 2 - 299.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                    columnDrop[0] += 1;

                    ColumnIdx = 0;

                    playerCounter++;

                    logic.DropIntoBoard(ColumnIdx, playerCounter);

                    drawables.Add(circle);
                    circles.Add(circle);
                }
                else if (x > (gameWindow.Bounds.Width / 2 + 50f) && x < (gameWindow.Bounds.Width / 2 + 150f) && Game.canDrop) //5. column
                {
                    Circle circle = new Circle(new Vector(gameWindow.Width / 2 + 100.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                    columnDrop[4] += 1;

                    ColumnIdx = 4;

                    playerCounter++;

                    logic.DropIntoBoard(ColumnIdx, playerCounter);

                    drawables.Add(circle);
                    circles.Add(circle);
                }
                else if (x > (gameWindow.Bounds.Width / 2 + 150f) && x < (gameWindow.Bounds.Width / 2 + 250f) && Game.canDrop) //6. column
                {
                    Circle circle = new Circle(new Vector(gameWindow.Width / 2 + 200.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                    columnDrop[5] += 1;

                    ColumnIdx = 5;

                    playerCounter++;

                    logic.DropIntoBoard(ColumnIdx, playerCounter);

                    drawables.Add(circle);
                    circles.Add(circle);
                }
                else if (x > (gameWindow.Bounds.Width / 2 + 250f) && x < (gameWindow.Bounds.Width / 2 + 350f) && Game.canDrop) //7. column
                {
                    Circle circle = new Circle(new Vector(gameWindow.Width / 2 + 300.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                    columnDrop[6] += 1;

                    ColumnIdx = 6;

                    playerCounter++;

                    logic.DropIntoBoard(ColumnIdx, playerCounter);

                    drawables.Add(circle);
                    circles.Add(circle);
                }
            }        

            drawables.Sort((j, k) => j.Layer.CompareTo(k.Layer));

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.ColorBufferBit);
        }

        public void DrawAI(Color color)
        {
            logic.columnAI = logic.DetermineColumnAI();

            if(logic.columnAI == 1)
            {
                Circle circle = new Circle(new Vector(gameWindow.Width / 2 - 299.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                columnDrop[0] += 1;

                ColumnIdx = 0;

                playerCounter++;

                logic.DropIntoBoard(ColumnIdx, playerCounter);

                drawables.Add(circle);
                circles.Add(circle);
            }
            else if(logic.columnAI == 2)
            {
                Circle circle = new Circle(new Vector(gameWindow.Width / 2 - 199.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                columnDrop[1] += 1;

                ColumnIdx = 1;

                playerCounter++;

                logic.DropIntoBoard(ColumnIdx, playerCounter);

                drawables.Add(circle);
                circles.Add(circle);
            }
            else if(logic.columnAI == 3)
            {
                Circle circle = new Circle(new Vector(gameWindow.Width / 2 - 99.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                columnDrop[2] += 1;

                ColumnIdx = 2;

                playerCounter++;

                logic.DropIntoBoard(ColumnIdx, playerCounter);

                drawables.Add(circle);
                circles.Add(circle);
            }
            else if (logic.columnAI == 4)
            {
                Circle circle = new Circle(new Vector(gameWindow.Width / 2 + 0.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                columnDrop[3] += 1;

                ColumnIdx = 3;

                playerCounter++;

                logic.DropIntoBoard(ColumnIdx, playerCounter);

                drawables.Add(circle);
                circles.Add(circle);
            }
            else if (logic.columnAI == 5)
            {
                Circle circle = new Circle(new Vector(gameWindow.Width / 2 + 100.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                columnDrop[4] += 1;

                ColumnIdx = 4;

                playerCounter++;

                logic.DropIntoBoard(ColumnIdx, playerCounter);

                drawables.Add(circle);
                circles.Add(circle);
            }
            else if (logic.columnAI == 6)
            {
                Circle circle = new Circle(new Vector(gameWindow.Width / 2 + 200.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                columnDrop[5] += 1;

                ColumnIdx = 5;

                playerCounter++;

                logic.DropIntoBoard(ColumnIdx, playerCounter);

                drawables.Add(circle);
                circles.Add(circle);
            }

            drawables.Sort((j, k) => j.Layer.CompareTo(k.Layer));

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.ColorBufferBit);
        }
    }
}
