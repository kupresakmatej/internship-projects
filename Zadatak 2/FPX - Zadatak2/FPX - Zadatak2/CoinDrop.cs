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
    class CoinDrop
    {
        private static GameWindow gameWindow;

        private List<Circle> circles;

        private int[] columnDrop;

        private static Game Game;

        private int miliseconds;

        public CoinDrop(List<Circle> Circles, int[] ColumnDrop, GameWindow GameWindow, Game game)
        {
            circles = Circles;
            columnDrop = ColumnDrop;
            gameWindow = GameWindow;
            Game = game;
        }

        public void DropCoin(object o, EventArgs e)
        {
            foreach (Circle circle in circles)
            {
                if (circle.Position.X == gameWindow.Width / 2 - 299.5f) //1. column
                {
                    miliseconds = 2400 - (columnDrop[0] * 350);
                    if (circle.Position.Y > (columnDrop[0] * 100) + (gameWindow.Height / 2 - 250f))
                    {
                        circle.Position = new Vector(circle.Position.X, circle.Position.Y - 5f);
                        Game.canDrop = false;
                    }
                }

                else if (circle.Position.X == gameWindow.Width / 2 - 199.5f) //2. column
                {
                    miliseconds = 2400 - (columnDrop[1] * 350);
                    if (circle.Position.Y > (columnDrop[1] * 100) + (gameWindow.Height / 2 - 250f))
                    {
                        circle.Position = new Vector(circle.Position.X, circle.Position.Y - 5f);
                        Game.canDrop = false;
                    }
                }

                else if (circle.Position.X == gameWindow.Width / 2 - 99.5f) //3. column
                {
                    miliseconds = 2400 - (columnDrop[2] * 350);
                    if (circle.Position.Y > (columnDrop[2] * 100) + (gameWindow.Height / 2 - 250f))
                    {
                        circle.Position = new Vector(circle.Position.X, circle.Position.Y - 5f);
                        Game.canDrop = false;
                    }
                }

                else if (circle.Position.X == gameWindow.Width / 2 + 0.5f) //4. column
                {
                    miliseconds = 2400 - (columnDrop[3] * 350);
                    if (circle.Position.Y > (columnDrop[3] * 100) + (gameWindow.Height / 2 - 250f))
                    {
                        circle.Position = new Vector(circle.Position.X, circle.Position.Y - 5f);
                        Game.canDrop = false;
                    }
                }

                else if (circle.Position.X == gameWindow.Width / 2 + 100.5f) //5. column
                {
                    miliseconds = 2400 - (columnDrop[4] * 350);
                    if (circle.Position.Y > (columnDrop[4] * 100) + (gameWindow.Height / 2 - 250f))
                    {
                        circle.Position = new Vector(circle.Position.X, circle.Position.Y - 5f);
                        Game.canDrop = false;
                    }
                }

                else if (circle.Position.X == gameWindow.Width / 2 + 200.5f) //6. column
                {
                    miliseconds = 2400 - (columnDrop[5] * 350);
                    if (circle.Position.Y > (columnDrop[5] * 100) + (gameWindow.Height / 2 - 250f))
                    {
                        circle.Position = new Vector(circle.Position.X, circle.Position.Y - 5f);
                        Game.canDrop = false;
                    }
                }

                else if (circle.Position.X == gameWindow.Width / 2 + 300.5f) //7. column
                {
                    miliseconds = 2400 - (columnDrop[6] * 350);
                    if (circle.Position.Y > (columnDrop[6] * 100) + (gameWindow.Height / 2 - 250f))
                    {
                        circle.Position = new Vector(circle.Position.X, circle.Position.Y - 5f);
                        Game.canDrop = false;
                    }
                }
            }

            GL.Clear(ClearBufferMask.ColorBufferBit);
        }

        public async void WaitForDrop(object o, EventArgs e)
        {
            await Task.Delay(miliseconds);

            Game.canDrop = true;
        }
    }
}
