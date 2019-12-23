

using SFML.Graphics;
using SFML.System;

namespace CrossUI.Objects.UI
{
    public abstract class BaseUIObject
    {
        public BaseUIObject(string id, Vector2i position)
        {
            ID = id;
            Position = position;
            //DrawableObject = new RenderTexture(100,100);
        }
        public string ID { get; set; }
        public Vector2i Position { get; set; }

        public delegate void ClickDelegate();
        public delegate void HoverDelegate();

        public event ClickDelegate OnClick;
        public event ClickDelegate OnHover;

        //internal Drawable DrawableObject { get; set; }

        protected void TriggerOnClick()
        {
            OnClick?.Invoke();
        }
        
        protected void TriggerOnHover()
        {
            OnHover?.Invoke();
        }

        internal abstract void Draw();
    }
}