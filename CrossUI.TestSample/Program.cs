﻿using CrossUI.Objects;
using CrossUI.Objects.UI;
using CrossUI.SFML.System;

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
             /*var amount = 100;
             var width = window.RenderWindow.Size.X / amount;
             var height = window.RenderWindow.Size.Y / amount;
             for (var x = 0; x < amount; x++)
             {
                 for (var y = 0; y < amount; y++)
                 {
                     window.AddChild(new Button($"{x},{y}", new Vector2F(width * x, height * y)));
                 }
             }*/
             
             window.AddChild(new Button("a3", new Vector2F(100,200)));
             window.AddChild(new Button("aaa", new Vector2F(450,350)));
             window.AddChild(new Button("a1", new Vector2F(250,350)));
             window.AddChild(new Button("a2", new Vector2F(100,100)));
             
             window.ForceUpdate();
         }

         public static void Run(ref CrossWindow window)
         {
             window.Run();
         }
     }
 }