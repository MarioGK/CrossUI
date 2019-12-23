namespace CrossUI.Objects
 {
     public class Color
     {
         public Color()
         {
             
         }
         
         public Color(byte r, byte g, byte b)
         {
             R = r;
             G = g;
             B = b;
             A = 255;
         }
         
         public Color(byte r, byte g, byte b, byte a)
         {
             R = r;
             G = g;
             B = b;
             A = a;
         }
         
         public byte R { get; set; }
         public byte G { get; set; }
         public byte B { get; set; }
         public byte A { get; set; }
     }
 }