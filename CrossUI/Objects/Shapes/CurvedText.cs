using System;
using SFML.Graphics;
using SFML.System;

namespace CrossUI.Objects.Shapes
{
    public class CurvedText : Transformable, Drawable
    {
        public CurvedText(
            string str,
            float radius,
            float spacing,
            Font font,
            uint charSize) : this(str, radius, font, charSize)
        {
            Spacing = spacing;
        }

        public CurvedText(
            string str,
            float radius,
            Font font = null,
            uint charSize = 30)
        {
            vertices = new VertexArray(PrimitiveType.Quads);
            DisplayedString = str;
            CharacterSize = charSize;
            Radius = radius;
            Spacing = 0;
            Color = Color.Black;
            Font = font;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            if (Font == null)
                return;
            states.Transform *= Transform;
            if (Centered)
                states.Transform *= centerTransform;
            states.Texture = Font.GetTexture(CharacterSize);
            target.Draw(vertices, states);
        }

        private void UpdateGeometry()
        {
            if (font == null)
                return;
            vertices.Clear();
            var hspace = Font.GetGlyph(' ', CharacterSize, true, 0f).Advance;
            var vspace = Font.GetLineSpacing(CharacterSize);
            float previousX = 0;
            float x = 0;
            float y = CharacterSize;
            var previousChar = '\0';
            float angleCovered = 0;

            var transform = Transform.Identity;

            foreach (var c in DisplayedString)
            {
                x += Font.GetKerning(previousChar, c, CharacterSize) + Spacing;
                previousChar = c;

                switch (c)
                {
                    case ' ':
                        x += hspace;
                        continue;
                    case '\t':
                        x += 4 * hspace;
                        continue;
                    case '\n':
                        y += vspace;
                        previousX = 0;
                        angleCovered = 0;
                        transform = Transform.Identity;
                        x = 0;
                        continue;
                    case '\v':
                        y += vspace * 4;
                        continue;
                }

                var g = Font.GetGlyph(c, CharacterSize, false, 0f);
                var x0 = x + g.Bounds.Left;
                var y0 = y + g.Bounds.Top;
                var x1 = x0 + g.Bounds.Width;
                var y1 = y0 + g.Bounds.Height;
                float u0 = g.TextureRect.Left;
                float v0 = g.TextureRect.Top;
                var u1 = u0 + g.TextureRect.Width;
                var v1 = v0 + g.TextureRect.Height;

                var angle = 2f * (float) Math.Atan((x - previousX) / 2f / Radius)
                               * 180f / (float) Math.PI;
                angleCovered += angle;

                transform.Rotate(angle, x0 - g.Bounds.Width / 2f, Radius / 2f);

                var topLeft = new Vector2f(x0, y0);
                var bottomLeft = new Vector2f(x0, y1);
                var topRight = new Vector2f(x1, y0);
                var bottomRight = new Vector2f(x1, y1);

                topLeft = transform.TransformPoint(topLeft);
                topRight = transform.TransformPoint(topRight);
                bottomLeft = transform.TransformPoint(bottomLeft);
                bottomRight = transform.TransformPoint(bottomRight);

                vertices.Append(new Vertex(topLeft, Color, new Vector2f(u0, v0)));
                vertices.Append(new Vertex(topRight, Color, new Vector2f(u1, v0)));
                vertices.Append(new Vertex(bottomRight, Color, new Vector2f(u1, v1)));
                vertices.Append(new Vertex(bottomLeft, Color, new Vector2f(u0, v1)));

                previousX = x;
                x += g.Advance;
            }

            centerTransform = Transform.Identity;
            centerTransform.Rotate(-angleCovered / 2f, 0, Radius);
            centerTransform.Translate(0, -Radius / 2f);
            Color = color;
        }

        public float Radius
        {
            get => radius;
            set
            {
                radius = value;
                UpdateGeometry();
            }
        }

        public string DisplayedString
        {
            get => displayedString;
            set
            {
                displayedString = value;
                UpdateGeometry();
            }
        }

        public Font Font
        {
            get => font;
            set
            {
                font = value;
                UpdateGeometry();
            }
        }

        public uint CharacterSize
        {
            get => characterSize;
            set
            {
                characterSize = value;
                UpdateGeometry();
            }
        }

        public Color Color
        {
            get => color;
            set
            {
                color = value;
                for (uint i = 0; i < vertices.VertexCount; i++)
                {
                    Vertex v = vertices[i];
                    v.Color = color;
                    vertices[i] = v;
                }
            }
        }

        public float Spacing
        {
            get => spacing;
            set
            {
                spacing = value;
                UpdateGeometry();
            }
        }

        public bool Centered
        {
            get => centered;
            set => centered = value;
        }

        private VertexArray vertices;
        private float radius;
        private string displayedString;
        private Font font;
        private uint characterSize;
        private Color color;
        private float spacing;
        private bool centered;
        private Transform centerTransform;
    }
}