using System.Collections.Generic;
using CrossUI.SFML.Graphics;
using CrossUI.SFML.System;
using SFML.Graphics;

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