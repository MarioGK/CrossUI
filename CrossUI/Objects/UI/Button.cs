
using CrossUI.Managers;
using SFML.Graphics;
using SFML.System;

namespace CrossUI.Objects.UI
{
    public class Button : BaseUIObject
    {
        public string Text
        {
            get => text;
            set
            {
                text = value;
                Update();
            }
        }

        public Color BackgroundColor
        {
            get => backgroundColor;
            set
            {
                backgroundColor = value;
                Update();
            }
        }

        public Color Foreground
        {
            get => foreground;
            set
            {
                foreground = value;
                Update();
            }
        }

        public Button(string id, Vector2f pos) : base(id, pos)
        {
            text = "I am a button";
            backgroundColor = new Color(255, 0, 0);
            foreground = new Color(0, 0, 0);

            DisplayText = new Text(Text, FontManager.Font) {FillColor = Foreground, Position = Position};
            BackgroundRectangle = new RectangleShape(new Vector2f(200,200)) {FillColor = BackgroundColor, Position = Position};

            OnHover += OnOnHover;
            
            Update();
        }

        private void OnOnHover(bool inside)
        {
            BackgroundRectangle.FillColor = inside ? Color.Blue : BackgroundColor;
            //BackgroundColor = Color.Blue;
        }

        public Text DisplayText;
        public RectangleShape BackgroundRectangle;
        private Color foreground;
        private string text;
        private Color backgroundColor;

        internal override void Draw(RenderWindow window)
        {
            window.Draw(BackgroundRectangle);
            window.Draw(DisplayText);
        }

        protected sealed override void Update()
        {
            var textSize = DisplayText.GetLocalBounds();
            BackgroundRectangle.Size = new Vector2f(textSize.Width + 5f, textSize.Height *2f);
            Rect = BackgroundRectangle.GetGlobalBounds();
        }
    }
}