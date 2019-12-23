using System;
using CrossUI.SDL2.Wrapper;
using SDL2;
using static SDL2.SDL;

namespace CrossUI.Objects
{
    public class Window
    {
        private readonly IntPtr windowPtr;
        private readonly IntPtr rendererPtr;
        public readonly Renderer Renderer;

        public delegate void DrawDelegate(Renderer renderer);

        public delegate void QuitDelegate(Window window);

        public event DrawDelegate OnDraw;
        public event QuitDelegate OnQuit;

        public Color BackgroundColor { get; set; } = new Color(255,255,255);

        public bool Running { get; private set; }

        public Window()
        {
            Running = true;
            SDL_Init(SDL.SDL_INIT_VIDEO);

            windowPtr = SDL_CreateWindow("Test", SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, 1280, 768,
                SDL_WindowFlags.SDL_WINDOW_RESIZABLE);
            rendererPtr = SDL_CreateRenderer(windowPtr, -1, SDL_RendererFlags.SDL_RENDERER_ACCELERATED);
            
            SDL_Setg
            
            Renderer = new Renderer(rendererPtr);
        }

        public void Draw()
        {
            Renderer.Clear();
            
            OnDraw?.Invoke(Renderer);

            var rect = new SDL_Rect {x = 100, y = 100, h = 250, w = 100};
            var rect1 = new SDL_Rect {x = 250, y = 200, h = 250, w = 100};
            SDL_SetRenderDrawColor(rendererPtr, 255, 0, 0, 255);
            
            SDL_RenderDrawRect(rendererPtr, ref rect);
            SDL_RenderFillRect(rendererPtr, ref rect1);
            
            Renderer.SetRenderDrawColor(BackgroundColor);
            Renderer.Render();
        }

        private void Update()
        {

        }

        private void HandleEvents()
        {
            while (SDL_PollEvent(out var e) != 0)
            {
                switch (e.type)
                {
                    case SDL_EventType.SDL_QUIT:
                        OnQuit?.Invoke(this);
                        Running = false;
                        break;
                }
            }
        }

        public void Run()
        {
            while (Running)
            {
                HandleEvents();
                Update();
                Draw();
            }
        }
    }
}