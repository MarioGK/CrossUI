using System;
using CrossUI.SDL2;
using CrossUI.SDL2.Enumerations;
using CrossUI.SDL2.Structs;

namespace CrossUI
 {
     internal static unsafe class Program
     {
         private static void Main(string[] args)
         {
             SDL.SDL_Init(SDLInitFlags.Video);
             //SDL.SDL_Init(SDLInitFlags.Timer);

             var window = SDL.SDL_CreateWindow("test", SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, 1280, 720,
             SDL_WindowFlags.Resizable);

             var quit = false;
             

             while (!quit)
             {
                 SDL_Event sdlEvent;
                 while (SDL.SDL_PollEvent(&sdlEvent) != 0)
                 {
                     switch (sdlEvent.type)
                     {
                         case SDL_EventType.FirstEvent:
                             break;
                         case SDL_EventType.Quit:
                             break;
                         case SDL_EventType.Terminating:
                             break;
                         case SDL_EventType.LowMemory:
                             break;
                         case SDL_EventType.WillEnterBackground:
                             break;
                         case SDL_EventType.DidEnterBackground:
                             break;
                         case SDL_EventType.WillEnterForeground:
                             break;
                         case SDL_EventType.DidEnterForeground:
                             break;
                         case SDL_EventType.WindowEvent:
                             break;
                         case SDL_EventType.SysWMEvent:
                             break;
                         case SDL_EventType.KeyDown:
                             break;
                         case SDL_EventType.KeyUp:
                             break;
                         case SDL_EventType.TextEditing:
                             break;
                         case SDL_EventType.TextInput:
                             break;
                         case SDL_EventType.KeyMapChanged:
                             break;
                         case SDL_EventType.MouseMotion:
                             break;
                         case SDL_EventType.MouseButtonDown:
                             break;
                         case SDL_EventType.MouseButtonUp:
                             break;
                         case SDL_EventType.MouseWheel:
                             break;
                         case SDL_EventType.JoyAxisMotion:
                             break;
                         case SDL_EventType.JoyBallMotion:
                             break;
                         case SDL_EventType.JoyHatMotion:
                             break;
                         case SDL_EventType.JoyButtonDown:
                             break;
                         case SDL_EventType.JoyButtonUp:
                             break;
                         case SDL_EventType.JoyDeviceAdded:
                             break;
                         case SDL_EventType.JoyDeviceRemoved:
                             break;
                         case SDL_EventType.ControllerAxisMotion:
                             break;
                         case SDL_EventType.ControllerButtonDown:
                             break;
                         case SDL_EventType.ControllerButtonUp:
                             break;
                         case SDL_EventType.ControllerDeviceAdded:
                             break;
                         case SDL_EventType.ControllerDeviceRemoved:
                             break;
                         case SDL_EventType.ControllerDeviceRemapped:
                             break;
                         case SDL_EventType.FingerDown:
                             break;
                         case SDL_EventType.FingerUp:
                             break;
                         case SDL_EventType.FingerMotion:
                             break;
                         case SDL_EventType.DollarGesture:
                             break;
                         case SDL_EventType.DollarRecord:
                             break;
                         case SDL_EventType.MultiGesture:
                             break;
                         case SDL_EventType.ClipboardUpdate:
                             break;
                         case SDL_EventType.DropFile:
                             break;
                         case SDL_EventType.DropTest:
                             break;
                         case SDL_EventType.DropBegin:
                             break;
                         case SDL_EventType.DropComplete:
                             break;
                         case SDL_EventType.AudioDeviceAdded:
                             break;
                         case SDL_EventType.AudioDeviceRemoved:
                             break;
                         case SDL_EventType.RenderTargetsReset:
                             break;
                         case SDL_EventType.RenderDeviceReset:
                             break;
                         case SDL_EventType.UserEvent:
                             break;
                         case SDL_EventType.LastEvent:
                             break;
                         default:
                             throw new ArgumentOutOfRangeException();
                     }
                 }
             }

             Console.Read();
         }
     }
 }