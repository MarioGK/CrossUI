﻿using System;
using CrossUI.Managers;
using CrossUI.Objects.Shapes;
using SFML.Graphics;
using SFML.System;

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

        public Button(string id, Vector2f pos) : base(id, pos)
        {
            text = "I am a button";

            displayText = new Text(Text, FontManager.CurrentFont) {FillColor = Foreground, Position = Position};
            backgroundRectangle = new RoundedRectangle(new Vector2f(40, 40), 4f)
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
            this.AnimateElasticMove(new Vector2f(50, 50), 10f);
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
            DisplayText.Position = new Vector2f(Position.X + 10f, Position.Y + 10f);
            BackgroundRectangle.Size = new Vector2f(textSize.Width + 25f, textSize.Height * 2f + 10f);
            DisplayText.FillColor = foreground;
            Rect = BackgroundRectangle.GetGlobalBounds();
            NotifyUIChange();
        }
    }
}