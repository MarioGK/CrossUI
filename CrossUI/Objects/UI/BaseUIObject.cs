

using SFML.Graphics;

namespace CrossUI.Objects.UI
{
    public abstract class BaseUIObject
    {
        public BaseUIObject(string id)
        {
            ID = id;
            DrawableObject = new 
        }
        public string ID { get; set; }

        public delegate void ClickDelegate();
        public delegate void HoverDelegate();

        public event ClickDelegate OnClick;
        public event ClickDelegate OnHover;

        internal Drawable DrawableObject { get; set; }

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