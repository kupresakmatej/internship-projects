using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Imaging;
using System.Drawing;
using System.Diagnostics;

namespace FPX___Zadatak2
{ 
    public class Game
    {
        GameWindow gameWindow;
        List<IRenderable> drawables;
        BoardGFX board;

        private List<Circle> circles = new List<Circle>();

        Color color = new Color();

        private int[] columnDrop = new int[7] { -1, -1, -1, -1, -1, -1, -1 };

        public bool canDrop { get; set; }

        private int playerCounter;

        public int ColumnIdx { get; set; }

        BoardLogic BoardLogic;

        public Game(GameWindow window, BoardLogic boardLogic)
        {
            this.gameWindow = window;
            drawables = new List<IRenderable>();
            board = new BoardGFX(gameWindow);
            canDrop = true;
            board.DrawPlayers(gameWindow.Width, gameWindow.Height, color.Yellow, color.White);

            BoardLogic = boardLogic;

            Input();
            Start();
        }

        private List<IRenderable> Input()
        {
            List<IRenderable> drawBoard;
            drawBoard = board.GenerateBoard(gameWindow.Width, gameWindow.Height);

            foreach(IRenderable drawable in drawBoard)
            {
                drawables.Add(drawable);
            }

            drawables.Sort((x, y) => x.Layer.CompareTo(y.Layer));
            return drawables;
        }

        public void Start()
        {
            playerCounter = 1;

            Renderer renderer = new Renderer(drawables, gameWindow);
            MouseControls mouseControls = new MouseControls(drawables, circles, gameWindow, columnDrop, this, playerCounter, board, BoardLogic);
            CoinDrop coinDrop = new CoinDrop(circles, columnDrop, gameWindow, this);

            gameWindow.Load += Loaded;
            gameWindow.MouseMove += mouseControls.FollowMouse;
            gameWindow.MouseDown += mouseControls.DropOnMouse;
            gameWindow.MouseDown += mouseControls.CallLogic;
            gameWindow.RenderFrame += renderer.RenderF;
            gameWindow.RenderFrame += coinDrop.DropCoin;
            gameWindow.RenderFrame += coinDrop.WaitForDrop;
            gameWindow.Resize += Resize;
            gameWindow.Run(1.0 / 60.0);

            //GL.Viewport(0, 0, gameWindow.Width, gameWindow.Height);        
        }

        public void Resize(object o, EventArgs e)
        {
            OnResize?.Invoke();

            OnResize += () => board.WindowReshape(gameWindow.Width, gameWindow.Height, circles);

            GL.Viewport(0, 0, gameWindow.Width, gameWindow.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, gameWindow.Width, 0, gameWindow.Height, -1, 1);

            GL.MatrixMode(MatrixMode.Modelview);
        }

        public event Action OnResize;      

        public void Loaded(object o, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }
}
