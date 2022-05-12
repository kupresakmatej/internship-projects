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
    class GameLoop
    {
        public GameLoop(int width, int height)
        {
            GameWindow window = new GameWindow(1280, 720);

            BoardLogic boardLogic = new BoardLogic();
            boardLogic.FillBoard();

            Game game = new Game(window, boardLogic);
        }
    }
}
