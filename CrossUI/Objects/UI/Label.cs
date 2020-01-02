using CrossUI.SFML.Graphics;
using CrossUI.SFML.System;

namespace CrossUI.Objects.UI
{
    public class Label : BaseUIObject
    {
        public Label(string id, Vector2F position) : base(id, position)
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