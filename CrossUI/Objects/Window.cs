using System;
using System.Collections.Generic;
using System.Linq;
using CrossUI.Managers;
using CrossUI.Objects.UI;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace CrossUI.Objects
{
    public class Window : BaseObject
    {
        private RenderWindow window;

        public delegate void DrawDelegate(Window renderer);

        public delegate void QuitDelegate(Window window);

        public event DrawDelegate OnDraw;
        public event QuitDelegate OnQuit;

        public Color BackgroundColor { get; set; } = new Color(255,255,255);

        public Text FPSText { get; set; }

        public Dictionary<string, BaseUIObject> Children { get; set; } = new Dictionary<string, BaseUIObject>();

        public void AddChild(BaseUIObject obj)
        {
            obj.Parent = this;
        }

        public Window(string id) : base(id)
        {
            FontManager.Initialize();
            
            window = new RenderWindow(new VideoMode(800, 600), id);
            window.SetFramerateLimit(60);
            window.Closed += (_, __) => window.Close();
            
            window.MouseMoved += WindowOnMouseMoved;
            
            FPSText = new Text("00", FontManager.Font)
            {
                FillColor = new Color(255,0,0), CharacterSize = 24,DisplayedString = "00"
            };
            
            Children.Add(button.ID, button);
        }

        private void WindowOnMouseMoved(object sender, MouseMoveEventArgs e)
        {
            foreach (var obj in Children.Values)
            {
                obj.TriggerOnHover(obj.IsInside(e.X,e.Y));
            }
        }

        private static readonly Button button = new Button("button", new Vector2f(100,100));
        
        private readonly Clock clock = new Clock();
        public float DeltaTime { get; private set; }

        public void Draw()
        {
            DeltaTime = clock.Restart().AsSeconds();
            
            window.Clear(Color.White);
            //FPS
            FPSText.DisplayedString = (1f / DeltaTime).ToString("00");
            window.Draw(FPSText);

            foreach (var obj in Children.Values)
            {
                obj.Draw(window);
            }
            
            window.Display();
        }

        private void Update()
        {
            foreach (var obj in Children.Values.Where(x => x.NeedsUpdate))
            {
                obj.Update();
            }
        }
        
        public void Run()
        {
            while (window.IsOpen)
            {
                window.DispatchEvents();
                Update();
                Draw();
            }
        }
    }
}