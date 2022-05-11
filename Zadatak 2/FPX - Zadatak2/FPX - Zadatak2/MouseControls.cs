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

        private Circle circleFollow = new Circle();

        private static int[] columnDrop;

        public static Game Game;

        float xClick;
        float yClick;

        private int playerCounter;

        public MouseControls(List<IRenderable> Drawables, List<Circle> Circles, GameWindow GameWindow, int[] ColumnDrop, Game CanDrop, int PlayerCounter)
        {
            drawables = Drawables;
            circles = Circles;
            gameWindow = GameWindow;
            columnDrop = ColumnDrop;
            Game = CanDrop;
            playerCounter = PlayerCounter;

            circleFollow = new Circle(new Vector(gameWindow.Width / 2, gameWindow.Height / 2), 10f, color.Yellow, 250);
            circleFollow.Layer = 2;
            drawables.Add(circleFollow);
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

            if(Game.canDrop)
            {
                if(playerCounter % 2 == 0)
                {
                    DrawOnClick(xClick, yClick, color.Red);
                    playerCounter++;
                }
                else
                {
                    DrawOnClick(xClick, yClick, color.Yellow);
                    playerCounter++;
                }
            }
            else
            {
                Console.WriteLine("wait");
            }
        }

        public void DrawOnClick(float x, float y, Color color)
        {
            if (x > (gameWindow.Bounds.Width / 2 - 50f) && x < (gameWindow.Bounds.Width / 2 + 50f) && Game.canDrop) //4. column
            {
                Console.WriteLine(string.Format("x: {0} y: {1}", x, y));

                Circle circle = new Circle(new Vector(gameWindow.Width / 2 + 10.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                columnDrop[3] += 1;

                drawables.Add(circle);
                circles.Add(circle);
            }
            else if ((x < (gameWindow.Bounds.Width / 2 - 50f) && x > (gameWindow.Bounds.Width / 2 - 150f))) //3. column
            {
                Console.WriteLine(string.Format("x: {0} y: {1}", x, y));

                Circle circle = new Circle(new Vector(gameWindow.Width / 2 - 89.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                columnDrop[2] += 1;

                drawables.Add(circle);
                circles.Add(circle);
            }
            else if ((x < (gameWindow.Bounds.Width / 2 - 150f) && x > (gameWindow.Bounds.Width / 2 - 250f))) //2. column
            {
                Console.WriteLine(string.Format("x: {0} y: {1}", x, y));

                Circle circle = new Circle(new Vector(gameWindow.Width / 2 - 189.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                columnDrop[1] += 1;

                drawables.Add(circle);
                circles.Add(circle);
            }
            else if ((x < (gameWindow.Bounds.Width / 2 - 250f) && x > (gameWindow.Bounds.Width / 2 - 350f))) //1. column
            {
                Console.WriteLine(string.Format("x: {0} y: {1}", x, y));

                Circle circle = new Circle(new Vector(gameWindow.Width / 2 - 289.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                columnDrop[0] += 1;

                drawables.Add(circle);
                circles.Add(circle);
            }
            else if ((x > (gameWindow.Bounds.Width / 2 + 50f) && x < (gameWindow.Bounds.Width / 2 + 150f))) //5. column
            {
                Console.WriteLine(string.Format("x: {0} y: {1}", x, y));

                Circle circle = new Circle(new Vector(gameWindow.Width / 2 + 110.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                columnDrop[4] += 1;

                drawables.Add(circle);
                circles.Add(circle);
            }
            else if ((x > (gameWindow.Bounds.Width / 2 + 150f) && x < (gameWindow.Bounds.Width / 2 + 250f))) //6. column
            {
                Console.WriteLine(string.Format("x: {0} y: {1}", x, y));

                Circle circle = new Circle(new Vector(gameWindow.Width / 2 + 210.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                columnDrop[5] += 1;

                drawables.Add(circle);
                circles.Add(circle);
            }
            else if ((x > (gameWindow.Bounds.Width / 2 + 250f) && x < (gameWindow.Bounds.Width / 2 + 350f))) //7. column
            {
                Console.WriteLine(string.Format("x: {0} y: {1}", x, y));

                Circle circle = new Circle(new Vector(gameWindow.Width / 2 + 310.5f, gameWindow.Height / 2 + 350f), 30f, color, 250);

                columnDrop[6] += 1;

                drawables.Add(circle);
                circles.Add(circle);
            }

            drawables.Sort((j, k) => j.Layer.CompareTo(k.Layer));

            GL.Clear(ClearBufferMask.ColorBufferBit);
        }
    }
}
