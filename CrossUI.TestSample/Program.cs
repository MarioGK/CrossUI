using CrossUI.Objects;
using CrossUI.Objects.UI;
using SFML.Graphics;
using SFML.System;

namespace CrossUI.TestSample
 {
     public static class Program
     {
         public static CrossWindow CrossWindow;
         
         public static void Main(string[] args)
         {
             CrossWindow = new CrossWindow("Test");
             Configure(ref CrossWindow);
             Run(ref CrossWindow);
         }

         public static void Configure(ref CrossWindow window)
         {
             //window.AddChild(new Button("a1", new Vector2f(100,50)));
             window.AddChild(new Button("aaa", new Vector2f(450,350)));
         }

         public static void Run(ref CrossWindow window)
         {
             window.Run();
         }
     }
 }