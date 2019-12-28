using SFML.Graphics;
using SFML.System;

namespace CrossUI.Objects.UI
{
    public class TextBox : BaseUIObject
    {
        public TextBox(string id, Vector2f position) : base(id, position)
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