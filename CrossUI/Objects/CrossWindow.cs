﻿using System;
using System.Collections.Generic;
using System.Threading;
using CrossUI.Managers;
using CrossUI.Objects.Theme;
using CrossUI.Objects.UI;
using CrossUI.SFML.Graphics;
using CrossUI.SFML.Window;

namespace CrossUI.Objects
{
    public class CrossWindow : BaseObject
    {
        public RenderWindow RenderWindow;

        public delegate void DrawDelegate(ref RenderWindow renderer);

        public delegate void QuitDelegate(CrossWindow crossWindow);

        public event DrawDelegate OnDraw;
        public event QuitDelegate OnQuit;

        internal Dictionary<string, BaseUIObject> ChildrenDictionary { get; set; } = new Dictionary<string, BaseUIObject>();

        public IEnumerable<BaseUIObject> Children => ChildrenDictionary.Values;

        public void AddChild(BaseUIObject obj)
        {
            obj.Parent = this;
            obj.ParentWindow = this;
            ChildrenDictionary.Add(obj.ID, obj);
        }

        public void RemoveChild(string id)
        {
            ChildrenDictionary.Remove(id);
        }

        public CrossWindow(string id, bool createWindow = true) : base(id)
        {
            var settings = new ContextSettings{ AntialiasingLevel = 4};
            
            RequiresRenderUpdate = true;

            if (!createWindow) return;
            RenderWindow = new RenderWindow(new VideoMode(800, 600), id, Window.Styles.Default, settings);
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

        public static WindowTheme Theme => ThemeManager.CurrentThemeConfiguration.WindowTheme;

        public uint RenderedFrames { get; set; }

        public void Render(ref RenderWindow renderWindow)
        {
            if (!RequiresRenderUpdate)
            {
                Thread.Sleep(15);
                return;
            }

            RequiresRenderUpdate = false;
            
            Console.WriteLine($"Rendering frame {RenderedFrames++}...");
            
            renderWindow.Clear(Theme.Background);

            foreach (var obj in Children)
            {
                obj.Draw(ref renderWindow);
            }
            
            OnDraw?.Invoke(ref renderWindow);
            
            renderWindow.Display();
        }

        public bool RequiresRenderUpdate { get; set; }

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