using System;
using System.IO;
using System.Threading.Tasks;

namespace CrossUI.Viewer
{
    public static class FileWatch
    {
        public static FileSystemWatcher Watcher;

        public static bool Started;

        private static int lastTime;

        public static void Start(string path)
        {
            Watcher = new FileSystemWatcher
            {
                Path = path,
                NotifyFilter = NotifyFilters.LastWrite,
                Filter = "*.cs",
                EnableRaisingEvents = true
            };

            Watcher.Changed += WatcherOnChanged;

            Started = true;
        }

        private static void WatcherOnChanged(object sender, FileSystemEventArgs e)
        {
            try
            {
                Watcher.EnableRaisingEvents = false;

                Console.Clear();
                Compiler.DisableDraw();
                Console.WriteLine("File changed!");
                Compiler.Build();
            }

            finally
            {
                Watcher.EnableRaisingEvents = true;
            }

        }
    }
}