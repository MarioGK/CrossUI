using System;
using CrossUI.SDL2;

namespace CrossUI
 {
     internal static class Program
     {
         private static void Main(string[] args)
         {
             SDL.SDL_Init(SDLInitFlags.Video);
             //SDL.SDL_Init(SDLInitFlags.Timer);

             SDL.SDL_CreateWindow("test", SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, 1280, 720,
             SDL_WindowFlags.Resizable);

             Console.Read();
         }
     }
 }