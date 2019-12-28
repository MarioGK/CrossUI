using System;
using SFML.Graphics;
using SFML.System;

namespace CrossUI.Objects.Shapes
{
    public class RoundedRectangle : Shape
    {
        private Vector2f size;

        public RoundedRectangle(Vector2f size, float radius, uint cornerPointCount = 10)
        {
            Size = size;
            CornerPointCount = cornerPointCount;
            Radius = radius;
            Update();
        }
        
        public override uint GetPointCount()
        {
            return CornerPointCount*4;
        }
        
        public float Radius { get; set; }

        public uint CornerPointCount { get; set; }

        public Vector2f Size
        {
            get => size;
            set
            {
                size = value;
                Update();
            }
        }

        public override Vector2f GetPoint(uint index)
        {
            if (index >= CornerPointCount * 4)
            {
                return new Vector2f(0,0);
            }

            var deltaAngle = 90.0f/(CornerPointCount-1);
            var center = new Vector2f(0,0);
            var centerIndex = index/CornerPointCount;
            
            switch(centerIndex)
            {
                case 0: 
                    center.X = Size.X - Radius;
                    center.Y = Radius;
                    break;
                case 1: 
                    center.X = Radius;
                    center.Y = Radius;
                    break;
                case 2: 
                    center.X = Radius;
                    center.Y = Size.Y - Radius;
                    break;
                case 3: 
                    center.X = Size.X - Radius;
                    center.Y = Size.Y - Radius;
                    break;
            }

            var x = Radius*MathF.Cos(deltaAngle*(index-centerIndex)*MathF.PI/180)+center.X;
            var y = -Radius*MathF.Sin(deltaAngle*(index-centerIndex)*MathF.PI/180)+center.Y;
            
            var returnPoint = new Vector2f(x, y);

            return returnPoint;
        }
    }
}