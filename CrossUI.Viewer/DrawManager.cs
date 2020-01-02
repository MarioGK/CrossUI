using System;
using CrossUI.SFML.Graphics;
using SFML.Graphics;

namespace CrossUI.Viewer
{
    public static class DrawManager
    {
        //public delegate void DrawDelegate();

        public static Action<RenderWindow> DrawFunction;
    }
}