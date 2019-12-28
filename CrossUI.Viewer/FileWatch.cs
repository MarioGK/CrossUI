using System;
using System.IO;

namespace CrossUI.Viewer
{
    public class FileWatch
    {
        public readonly FileSystemWatcher Watcher;

        public bool Started;

        private int lastTime;

        public FileWatch(string path)
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

        public delegate void OnChangedDelegate();

        public event OnChangedDelegate OnChanged;

        private void WatcherOnChanged(object sender, FileSystemEventArgs e)
        {
            try
            {
                Watcher.EnableRaisingEvents = false;
                OnChanged?.Invoke();
            }

            finally
            {
                Watcher.EnableRaisingEvents = true;
            }

        }
    }
}