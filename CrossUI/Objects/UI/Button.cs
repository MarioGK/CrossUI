using CrossUI.Managers;
using CrossUI.SFML.Graphics;
using CrossUI.SFML.Graphics.Shapes;
using CrossUI.SFML.System;

namespace CrossUI.Objects.UI
{
    public class Button : BaseUIObject
    {
        private Color backgroundColor = ThemeManager.CurrentThemeConfiguration.ButtonColor;

        public Text DisplayText
        {
            get => displayText;
            private set
            {
                displayText = value;
                Update();
            }
        }

        private Color foreground = ThemeManager.CurrentThemeConfiguration.ButtonForeground;
        private Color hoverColor = ThemeManager.CurrentThemeConfiguration.ButtonHoverColor;
        private string text;
        private RoundedRectangle backgroundRectangle;
        private Text displayText;

        public Button(string id, Vector2F pos) : base(id, pos)
        {
            text = id;

            displayText = new Text(Text, FontManager.CurrentFont) {FillColor = Foreground, Position = Position};
            backgroundRectangle = new RoundedRectangle(new Vector2F(40, 40), 4f)
                {FillColor = BackgroundColor, Position = Position};

            OnHover += OnOnHover;
            OnClick += OnOnClick;
        }

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

        public Color HoverColor
        {
            get => hoverColor;
            set
            {
                hoverColor = value;
                Update();
            }
        }

        public RoundedRectangle BackgroundRectangle
        {
            get => backgroundRectangle;
            set
            {
                backgroundRectangle = value;
                Update();
            }
        }

        private void OnOnClick()
        {
            //BackgroundRectangle.AnimateColorChange(Color.Yellow, 2f);
        }

        private void OnOnHover(bool inside)
        {
            BackgroundRectangle.FillColor = inside ? HoverColor : BackgroundColor;
            Update();
        }

        internal override void Draw(ref RenderWindow window)
        {
            window.Draw(BackgroundRectangle);
            window.Draw(DisplayText);
        }

        internal sealed override void Update()
        {
            BackgroundRectangle.Position = Position;
            var textSize = DisplayText.GetLocalBounds();
            DisplayText.Position = new Vector2F(Position.X + 10f, Position.Y + 10f);
            BackgroundRectangle.Size = new Vector2F(textSize.Width + 25f, textSize.Height * 2f + 10f);
            DisplayText.FillColor = foreground;
            Rect = BackgroundRectangle.GetGlobalBounds();
            NotifyUIChange();
        }
    }
}