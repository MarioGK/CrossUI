
using SFML.Graphics;
using SFML.System;

namespace CrossUI.Objects.UI
{
    public class Button : BaseUIObject
    {
        private static readonly Font font = new Font("segoeui.ttf");
        public string Text { get; set; }

        public Color BackgroundColor { get; set; }
        public Color Foreground { get; set; }

        public Button(string id, Vector2f pos) : base(id, pos)
        {
            Text = "I am a button";
            BackgroundColor = new Color(255, 0, 0);
            Foreground = new Color(0, 0, 0);

            DisplayText = new Text(Text, font) {FillColor = Foreground, Position = Position};
            BackgroundRectangle = new RectangleShape(new Vector2f(200,200)) {FillColor = BackgroundColor, Position = Position};

            OnHover += OnOnHover;
        }

        private void OnOnHover(bool inside)
        {
            if (inside)
            {
                BackgroundRectangle.FillColor = Color.Blue;
            }
            else
            {
                BackgroundRectangle.FillColor = BackgroundColor;
            }
            //BackgroundColor = Color.Blue;
        }

        public Text DisplayText;
        public RectangleShape BackgroundRectangle;

        internal override void Draw(RenderWindow window)
        {
            window.Draw(BackgroundRectangle);
            window.Draw(DisplayText);
        }

        internal override void Update()
        {
            var textSize = DisplayText.GetLocalBounds();
            BackgroundRectangle.Size = new Vector2f(textSize.Width + 5f, textSize.Height *2f);
            Rect = BackgroundRectangle.GetGlobalBounds();
            NeedsUpdate = false;
        }
    }
}