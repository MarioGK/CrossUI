using System;
using System.Collections.Generic;
using System.Linq;
using CrossUI.Managers;
using CrossUI.Objects.Animations;
using CrossUI.Objects.UI;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace CrossUI.Objects
{
    public class CrossWindow : BaseObject
    {
        public RenderWindow RenderWindow;

        public delegate void DrawDelegate(ref RenderWindow renderer);

        public delegate void QuitDelegate(CrossWindow crossWindow);

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

        public Clock Clock { get; set; }

        //public CrossWindow(string id) : base(id)
        public CrossWindow(string id, bool createWindow = true) : base(id)
        {
            _Manager.InitializeAllManagers();
            
            var settings = new ContextSettings{ AntialiasingLevel = 4};
            
            Clock = new Clock();

            if (createWindow)
            {
                RenderWindow = new RenderWindow(new VideoMode(800, 600), id, Styles.Default, settings);
                RenderWindow.SetFramerateLimit(60);
            
                RenderWindow.Closed += RenderWindowOnClosed;
                RenderWindow.Resized += (sender, args) =>
                {
                    RenderWindow.SetView(new View(new FloatRect(0, 0, args.Width, args.Height)));
                    ForceUpdate();
                };
                RenderWindow.MouseMoved += RenderWindowOnMouseMoved;
                RenderWindow.MouseButtonPressed += RenderWindowOnMouseButtonPressed;
            }

            FPSText = new Text("00", FontManager.CurrentFont)
            {
                FillColor = new Color(255,0,0), CharacterSize = 24,DisplayedString = "00"
            };
        }

        private void RenderWindowOnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            foreach (var child in Children)
            {
                if (child.IsInside(e.X, e.Y))
                {
                    child.TriggerOnClick();
                }
            }
        }

        private void RenderWindowOnClosed(object sender, EventArgs e)
        {
            OnQuit?.Invoke(this);
            RenderWindow.Close();
        }

        private void RenderWindowOnMouseMoved(object sender, MouseMoveEventArgs e)
        {
            foreach (var obj in Children)
            {
                obj.TriggerOnHover(obj.IsInside(e.X,e.Y));
            }
        }

        private readonly Clock clock = new Clock();
        public float DeltaTime { get; private set; }

        public void Render(ref RenderWindow renderWindow)
        {
            DeltaTime = clock.Restart().AsSeconds();
            
            renderWindow.Clear(Color.White);
            //FPS
            FPSText.DisplayedString = (1f / DeltaTime).ToString("00");
            renderWindow.Draw(FPSText);
            
            AnimationManager.UpdateAll();

            foreach (var obj in Children)
            {
                obj.Draw(ref renderWindow);
            }
            
            OnDraw?.Invoke(ref renderWindow);
            
            renderWindow.Display();
        }

        public void Run()
        {
            while (RenderWindow.IsOpen)
            {
                RenderWindow.DispatchEvents();
                Render(ref RenderWindow);
            }
        }

        public void DeleteAllChildren()
        {
            ChildrenDictionary = new Dictionary<string, BaseUIObject>();
        }

        public void ForceUpdate()
        {
            foreach (var child in Children)
            {
                child.Update();
            }
        }
    }
}