using CrossUI.SDL2;
using CrossUI.SDL2.Enumerations;
using CrossUI.SDL2.Structs;

namespace CrossUI.Objects
{
    public class Window
    {
        public readonly SDLWindow sdlWindow;
        private readonly SDL_Window nativeWindow;
        private readonly SDL_Renderer renderer;
        
        public Window()
        {
            SDL.Init(SDLInitFlags.Video);
            
            sdlWindow = new SDLWindow("Test", SDL.WINDOWPOS_CENTERED, SDL.WINDOWPOS_CENTERED, 1280,768, SDLWindowFlags.Resizable);
            nativeWindow = new SDL_Window(sdlWindow.SdlWindowHandle);
            
            renderer = SDL.CreateRenderer(nativeWindow, -1, SDLRendererFlags.SDLRendererSoftware);
        }

        public void Run()
        {
            while (sdlWindow.Exists)
            {
                sdlWindow.PumpEvents();
                SDL.SDL_SetRenderDrawColor(renderer, 0, 0, 0, 255);
                SDL.RenderClear(renderer);

                SDL.SDL_SetRenderDrawColor(renderer, 255, 0, 0, 255);
                SDL.RenderDrawLine(renderer,320, 200, 300, 240);
                SDL.RenderDrawLine(renderer,300, 240, 340, 240);
                SDL.RenderDrawLine(renderer,340, 240, 320, 200);
            
                SDL.RenderPresent(renderer);
            }
        }
    }
}