using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CrossUI.SDL2.Enumerations;
using CrossUI.SDL2.Structs;

namespace CrossUI.SDL2
{
    internal static class Sdl2WindowRegistry
    {
        public static readonly object Lock = new object();
        private static readonly Dictionary<uint, SDLWindow> _eventsByWindowID
            = new Dictionary<uint, SDLWindow>();
        private static bool _firstInit;

        public static void RegisterWindow(SDLWindow window)
        {
            lock (Lock)
            {
                _eventsByWindowID.Add(window.WindowId, window);
                if (!_firstInit)
                {
                    _firstInit = true;
                    Sdl2Events.Subscribe(ProcessWindowEvent);
                }
            }
        }

        public static void RemoveWindow(SDLWindow window)
        {
            lock (Lock)
            {
                _eventsByWindowID.Remove(window.WindowId);
            }
        }

        private static unsafe void ProcessWindowEvent(ref SDL_Event ev)
        {
            var handled = false;
            uint windowID = 0;
            switch (ev.type)
            {
                case SDL_EventType.Quit:
                case SDL_EventType.Terminating:
                case SDL_EventType.WindowEvent:
                case SDL_EventType.KeyDown:
                case SDL_EventType.KeyUp:
                case SDL_EventType.TextEditing:
                case SDL_EventType.TextInput:
                case SDL_EventType.KeyMapChanged:
                case SDL_EventType.MouseMotion:
                case SDL_EventType.MouseButtonDown:
                case SDL_EventType.MouseButtonUp:
                case SDL_EventType.MouseWheel:
                    windowID = ev.windowID;
                    handled = true;
                    break;
                case SDL_EventType.DropBegin:
                case SDL_EventType.DropComplete:
                case SDL_EventType.DropFile:
                case SDL_EventType.DropText:
                    var dropEvent = Unsafe.As<SDL_Event, SDL_DropEvent>(ref ev);
                    windowID = dropEvent.windowID;
                    handled = true;
                    break;
                default:
                    handled = false;
                    break;
            }


            if (handled && _eventsByWindowID.TryGetValue(windowID, out var window))
            {
                window.AddEvent(ev);
            }
        }
    }
}
