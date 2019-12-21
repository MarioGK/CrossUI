using CrossUI.Objects;
using CrossUI.SDL2;
using CrossUI.SDL2.Enumerations;
using CrossUI.SDL2.Events;
using CrossUI.SDL2.Structs;

namespace CrossUI.TestSample
 {
     internal static unsafe class Program
     {
         private static Window window;
         private static void Main(string[] args)
         {
             window = new Window();
             
             window.sdlWindow.KeyDown += SdlWindowOnKeyDown;
             
             window.Run();
         }

         private static void SdlWindowOnKeyDown(KeyEvent obj)
         {
         }
     }
 }