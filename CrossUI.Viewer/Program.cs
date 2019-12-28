using System;
using CrossUI.Objects;

namespace CrossUI.Viewer
{
    public class Program
    {
        public static CrossWindow Window = new CrossWindow("Viewer");
        public static void Main(string[] args)
        {
            var projectPath = @"F:\Projects\CrossUI\CrossUI.TestSample\";
            var compiler = new Compiler(projectPath);
            compiler.Build();

            var fileWatch = new FileWatch(projectPath);
            fileWatch.OnChanged += () =>
            {
                compiler.DisableDraw();
                compiler.Build();
            };

            Window.Run();
            Console.Read();
            return;
        }
    }
}