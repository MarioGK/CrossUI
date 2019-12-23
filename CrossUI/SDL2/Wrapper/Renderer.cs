using System;
using CrossUI.Objects;
using static SDL2.SDL;

namespace CrossUI.SDL2.Wrapper
{
    public class Renderer
    {
        private readonly IntPtr renderer;
        
        public Renderer(IntPtr rendererPointer)
        {
            renderer = rendererPointer;
        }
        #region ColorRelated

        public void SetRenderDrawColor(Color color)
        {
            SDL_SetRenderDrawColor(renderer, color.R,color.G,color.B, color.A);
        }

        public void Render()
        {
            SDL_RenderPresent(renderer);
        }

        public void Clear()
        {
            SDL_RenderClear(renderer);
        }

        #endregion
    }
}