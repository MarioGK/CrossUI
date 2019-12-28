using System;
using SFML.Graphics;
using SFML.System;

namespace CrossUI.Objects.Shapes
{
    public class RoundedLine : Shape
    {
        public RoundedLine(Vector2f startPoint, Vector2f endPosition, float width)
        {
            Position = startPoint;
            EndPosition = endPosition;
            Width = width;
            Update();
        }
        
        public Vector2f EndPosition { get; set; }
        public float Width { get; set; }
        
        public override uint GetPointCount()
        {
            return 30;
        }

        public override Vector2f GetPoint(uint index)
        {
            var p1 = new Vector2f(1.0f, 0.0f);
            var p2 = EndPosition + new Vector2f(1.0f, 0.0f) - Position;

            Vector2f offset;
            int iFlipDirection;

            if(index < 15)
            {
                offset = p2;
                iFlipDirection = 1;
            }
            else
            {
                offset = p1;
                iFlipDirection = -1;
                index -= 15;
            }

            var start = -MathF.Atan2(p1.Y * p2.Y, p2.X - p1.X);

            var angle = index * MathF.PI / 14 - MathF.PI / 2 + start;
            var x = MathF.Cos(angle) * Width / 2;
            var y = MathF.Sin(angle) * Width / 2;

            return new Vector2f(offset.X + x * iFlipDirection, offset.Y + y * iFlipDirection);
        }
    }
}