namespace CrossUI.Objects
{
    public class Margin
    {
        public Margin()
        {
            
        }
        
        public Margin(float top, float bottom, float left, float right)
        {
            Top = top;
            Bottom = bottom;
            Left = left;
            Right = right;
        }
        
        public float Top { get; set; }
        public float Bottom { get; set; }
        public float Left { get; set; }
        public float Right { get; set; }

        public static Margin operator +(Margin a, Margin b)
        {
            var result = new Margin(a.Top + b.Top, a.Bottom + b.Bottom, a.Left + b.Left, a.Right + b.Right);
            return result;
        }
    }
}