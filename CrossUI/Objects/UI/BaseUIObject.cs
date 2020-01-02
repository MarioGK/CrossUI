

using System;
using System.Collections.Generic;
using CrossUI.Enumerations;
using CrossUI.SFML.Graphics;
using CrossUI.SFML.System;

namespace CrossUI.Objects.UI
{
    public abstract class BaseUIObject : BaseObject
    {
        public BaseUIObject(string id, Vector2F position) : base(id)
        {
            ID = id;
            Position = position;
        }

        public CrossWindow ParentWindow { get; set; }

        public Vector2F Position { get; set; }

        public bool Hovering { get; set; }

        public delegate void ClickDelegate();
        public delegate void HoverDelegate(bool inside);

        public event ClickDelegate OnClick;
        public event HoverDelegate OnHover;

        public Anchor Anchors { get; set; }
        public Margin Margin { get; set; }
        
        public FloatRect Rect { get; protected set; }

        internal void TriggerOnClick()
        {
            OnClick?.Invoke();
        }
        
        internal void TriggerOnHover(bool value)
        {
            if (value == Hovering)
            {
                return;
            }

            Hovering = value;
            OnHover?.Invoke(Hovering);
        }

        internal abstract void Draw(ref RenderWindow window);
        internal abstract void Update();

        public bool IsInside(float x, float y)
        {
            return Rect.Contains(x, y);
        }

        public void NotifyUIChange()
        {
            ParentWindow.RequiresRenderUpdate = true;
        }
    }
}