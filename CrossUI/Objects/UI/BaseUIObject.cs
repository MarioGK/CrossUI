using SDL2;

namespace CrossUI.Objects.UI
{
    public abstract class BaseUIObject
    {
        public BaseUIObject(string id)
        {
            ID = id;
        }
        public string ID { get; set; }

        public SDL.SDL_Rect Rectangle { get; set; }

        public delegate void ClickDelegate();
        public delegate void HoverDelegate();

        public event ClickDelegate OnClick;
        public event ClickDelegate OnHover;

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