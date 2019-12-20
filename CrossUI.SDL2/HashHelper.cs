namespace CrossUI.SDL2
{
    internal static class HashHelper
    {
        public static int Combine(int value1, int value2)
        {
            var rol5 = ((uint)value1 << 5) | ((uint)value1 >> 27);
            return ((int)rol5 + value1) ^ value2;
        }
    }
}
