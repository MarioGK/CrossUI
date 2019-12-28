
using System;
using CrossUI.Managers;
using CrossUI.Objects.Animations;
using CrossUI.Objects.Shapes;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

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

        public Color HoverColor
        {
            get => hoverColor;
            set
            {
                hoverColor = value;
                Update();
            }
        }

        public Button(string id, Vector2f pos) : base(id, pos)
        {
            text = "I am a button";

            DisplayText = new Text(Text, FontManager.CurrentFont) {FillColor = Foreground, Position = Position};
            BackgroundRectangle = new RoundedRectangle(new Vector2f(40,40), 4f) {FillColor = BackgroundColor, Position = Position};

            OnHover += OnOnHover;
            OnClick += OnOnClick;
            
            Update();
        }

        private void OnOnClick()
        {
            //BackgroundRectangle.AnimateColorChange(Color.Yellow, 2f);
            BackgroundRectangle.AnimateElasticMove(new Vector2f(10,10), 1.5f);
            DisplayText.AnimateElasticMove(new Vector2f(10,10), 1.5f);
            Update();
        }

        private void OnOnHover(bool inside)
        {
            BackgroundRectangle.FillColor = inside ? HoverColor : BackgroundColor;
        }

        public Text DisplayText;
        public RoundedRectangle BackgroundRectangle { get; set; }
        private Color foreground = ThemeManager.CurrentTheme.ButtonForeground;
        private string text;
        private Color backgroundColor = ThemeManager.CurrentTheme.ButtonColor;
        private Color hoverColor = ThemeManager.CurrentTheme.ButtonHoverColor;

        internal override void Draw(ref RenderWindow window)
        {
            window.Draw(BackgroundRectangle);
            window.Draw(DisplayText);
        }

        internal sealed override void Update()
        {
            var textSize = DisplayText.GetLocalBounds();
            DisplayText.Position = new Vector2f(Position.X + 10f, Position.Y + 10f);
            BackgroundRectangle.Size = new Vector2f(textSize.Width + 25f, textSize.Height *2f + 10f);
            DisplayText.FillColor = foreground;
            Rect = BackgroundRectangle.GetGlobalBounds();
        }
    }
}