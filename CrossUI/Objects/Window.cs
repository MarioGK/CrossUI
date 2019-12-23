using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace CrossUI.Objects
{
    public class Window
    {
        private RenderWindow window;

        public delegate void DrawDelegate(Window renderer);

        public delegate void QuitDelegate(Window window);

        public event DrawDelegate OnDraw;
        public event QuitDelegate OnQuit;

        public Color BackgroundColor { get; set; } = new Color(255,255,255);

        public Window()
        {
            window = new RenderWindow(new VideoMode(800, 600), "SFML running in .NET Core");
            window.SetFramerateLimit(60);
            window.Closed += (_, __) => window.Close();
        }

        public void Draw()
        {
            var shape = new RectangleShape(new Vector2f(100, 100))
            {
                FillColor = Color.Black
            };
            
            window.Clear(Color.White);
            window.Draw(shape);
            window.Display();
        }

        private void Update()
        {

        }
        
        public void Run()
        {
            while (window.IsOpen)
            {
                window.DispatchEvents();
                Draw();
            }
        }
    }
}