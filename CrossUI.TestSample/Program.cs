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
             window.AddChild(new Button("a3", new Vector2f(100,200)));
             window.AddChild(new Button("aaa", new Vector2f(450,350)));
             window.AddChild(new Button("a1", new Vector2f(250,350)));
             window.AddChild(new Button("a2", new Vector2f(100,100)));
             
             window.ForceUpdate();
         }

         public static void Run(ref CrossWindow window)
         {
             window.Run();
         }
     }
 }