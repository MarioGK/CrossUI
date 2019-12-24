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

        public delegate void DrawDelegate(RenderWindow renderer);

        public delegate void QuitDelegate(Window window);

        public event DrawDelegate OnDraw;
        public event QuitDelegate OnQuit;

        public Color BackgroundColor { get; set; } = new Color(255,255,255);

        public Text FPSText { get; set; }

        internal Dictionary<string, BaseUIObject> ChildrenDictionary { get; set; } = new Dictionary<string, BaseUIObject>();

        public IEnumerable<BaseUIObject> Children => ChildrenDictionary.Values;

        public void AddChild(BaseUIObject obj)
        {
            obj.Parent = this;
            ChildrenDictionary.Add(obj.ID, obj);
        }

        public void RemoveChild(string id)
        {
            ChildrenDictionary.Remove(id);
        }

        public Window(string id) : base(id)
        {
            FontManager.Initialize();
            
            var settings = new ContextSettings{ AntialiasingLevel = 4};
            
            window = new RenderWindow(new VideoMode(800, 600), id, Styles.Default, settings);
            window.SetFramerateLimit(60);
            window.Closed += WindowOnClosed;
            
            window.MouseMoved += WindowOnMouseMoved;
            
            FPSText = new Text("00", FontManager.Font)
            {
                FillColor = new Color(255,0,0), CharacterSize = 24,DisplayedString = "00"
            };
            
            AddChild(button);
        }

        private void WindowOnClosed(object sender, EventArgs e)
        {
            OnQuit?.Invoke(this);
            window.Close();
        }

        private void WindowOnMouseMoved(object sender, MouseMoveEventArgs e)
        {
            foreach (var obj in Children)
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

            foreach (var obj in Children)
            {
                obj.Draw(window);
            }
            
            OnDraw?.Invoke(window);
            
            window.Display();
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