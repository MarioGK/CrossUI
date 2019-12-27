using System;
using CrossUI.Objects;
using SFML.Graphics;
using SFML.Window;

namespace CrossUI.Viewer
{
    public class Program
    {
        public static CrossWindow Window = new CrossWindow("Viewer");
        public static void Main(string[] args)
        {
            var projectPath = @"F:\Projects\CrossUI\CrossUI.TestSample\";
            FileWatch.Start(projectPath);
            Compiler.ProjectPath = projectPath;
            Compiler.Build();
            
            Window.Run();
            Console.Read();
            return;
        }
    }
}