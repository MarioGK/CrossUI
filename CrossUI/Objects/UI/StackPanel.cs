using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;

namespace CrossUI.Objects.UI
{
    public class StackPanel : BaseUIObject
    {
        public List<BaseUIObject> Children { get; set; }
        public StackPanel() : base("stack", new Vector2f())
        {
        }

        internal override void Draw(ref RenderWindow window)
        {
            throw new System.NotImplementedException();
        }

        internal override void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}