namespace CrossUI.SDL2.Structs
{
    public unsafe struct WindowInfo
    {
        public const int WindowInfoSizeInBytes = 100;
        private fixed byte bytes[WindowInfoSizeInBytes];
    }
}