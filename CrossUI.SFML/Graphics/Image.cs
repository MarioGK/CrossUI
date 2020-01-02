using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using CrossUI.SFML.System;
using LoadingFailedException = CrossUI.SFML.Exceptions.LoadingFailedException;

namespace CrossUI.SFML.Graphics
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Image is the low-level class for loading and
    /// manipulating images
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class Image : ObjectBase
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the image with black color
        /// </summary>
        /// <param name="width">Image width</param>
        /// <param name="height">Image height</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public Image(uint width, uint height) : this(width, height, Color.Black) { }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the image from a single color
        /// </summary>
        /// <param name="width">Image width</param>
        /// <param name="height">Image height</param>
        /// <param name="color">Color to fill the image with</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public Image(uint width, uint height, Color color) : base(sfImage_createFromColor(width, height, color))
        {
            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("image");
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the image from a file
        /// </summary>
        /// <param name="filename">Path of the image file to load</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public Image(string filename) : base(sfImage_createFromFile(filename))
        {
            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("image", filename);
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the image from a file in a stream
        /// </summary>
        /// <param name="stream">Stream containing the file contents</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public Image(Stream stream) :
            base(IntPtr.Zero)
        {
            using (var adaptor = new SFML.System.StreamAdaptor(stream))
            {
                CPointer = sfImage_createFromStream(adaptor.InputStreamPtr);
            }

            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("image");
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the image from a file in memory
        /// </summary>
        /// <param name="bytes">Byte array containing the file contents</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public Image(byte[] bytes) :
            base(IntPtr.Zero)
        {
            var pin = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                CPointer = sfImage_createFromMemory(pin.AddrOfPinnedObject(), Convert.ToUInt64(bytes.Length));
            }
            finally
            {
                pin.Free();
            }
            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("image");
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the image directly from an array of pixels
        /// </summary>
        /// <param name="pixels">2 dimensions array containing the pixels</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public Image(Color[,] pixels) :
            base(IntPtr.Zero)
        {
            var width = (uint)pixels.GetLength(0);
            var height = (uint)pixels.GetLength(1);

            // Transpose the array (.Net gives dimensions in reverse order of what SFML expects)
            var transposed = new Color[height, width];
            for (var x = 0; x < width; ++x)
            {
                for (var y = 0; y < height; ++y)
                {
                    transposed[y, x] = pixels[x, y];
                }
            }

            unsafe
            {
                fixed (Color* pixelsPtr = transposed)
                {
                    CPointer = sfImage_createFromPixels(width, height, (byte*)pixelsPtr);
                }
            }

            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("image");
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the image directly from an array of pixels
        /// </summary>
        /// <param name="width">Image width</param>
        /// <param name="height">Image height</param>
        /// <param name="pixels">array containing the pixels</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public Image(uint width, uint height, byte[] pixels) :
            base(IntPtr.Zero)
        {
            unsafe
            {
                fixed (byte* pixelsPtr = pixels)
                {
                    CPointer = sfImage_createFromPixels(width, height, pixelsPtr);
                }
            }

            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("image");
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the image from another image
        /// </summary>
        /// <param name="copy">Image to copy</param>
        ////////////////////////////////////////////////////////////
        public Image(Image copy) :
            base(sfImage_copy(copy.CPointer))
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Save the contents of the image to a file
        /// </summary>
        /// <param name="filename">Path of the file to save (overwritten if already exist)</param>
        /// <returns>True if saving was successful</returns>
        ////////////////////////////////////////////////////////////
        public bool SaveToFile(string filename) => sfImage_saveToFile(CPointer, filename);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Create a transparency mask from a specified colorkey
        /// </summary>
        /// <param name="color">Color to become transparent</param>
        ////////////////////////////////////////////////////////////
        public void CreateMaskFromColor(Color color)
        {
            CreateMaskFromColor(color, 0);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Create a transparency mask from a specified colorkey
        /// </summary>
        /// <param name="color">Color to become transparent</param>
        /// <param name="alpha">Alpha value to use for transparent pixels</param>
        ////////////////////////////////////////////////////////////
        public void CreateMaskFromColor(Color color, byte alpha)
        {
            sfImage_createMaskFromColor(CPointer, color, alpha);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Copy pixels from another image onto this one.
        /// This function does a slow pixel copy and should only
        /// be used at initialization time
        /// </summary>
        /// <param name="source">Source image to copy</param>
        /// <param name="destX">X coordinate of the destination position</param>
        /// <param name="destY">Y coordinate of the destination position</param>
        ////////////////////////////////////////////////////////////
        public void Copy(Image source, uint destX, uint destY)
        {
            Copy(source, destX, destY, new IntRect(0, 0, 0, 0));
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Copy pixels from another image onto this one.
        /// This function does a slow pixel copy and should only
        /// be used at initialization time
        /// </summary>
        /// <param name="source">Source image to copy</param>
        /// <param name="destX">X coordinate of the destination position</param>
        /// <param name="destY">Y coordinate of the destination position</param>
        /// <param name="sourceRect">Sub-rectangle of the source image to copy</param>
        ////////////////////////////////////////////////////////////
        public void Copy(Image source, uint destX, uint destY, IntRect sourceRect)
        {
            Copy(source, destX, destY, sourceRect, false);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Copy pixels from another image onto this one.
        /// This function does a slow pixel copy and should only
        /// be used at initialization time
        /// </summary>
        /// <param name="source">Source image to copy</param>
        /// <param name="destX">X coordinate of the destination position</param>
        /// <param name="destY">Y coordinate of the destination position</param>
        /// <param name="sourceRect">Sub-rectangle of the source image to copy</param>
        /// <param name="applyAlpha">Should the copy take in account the source transparency?</param>
        ////////////////////////////////////////////////////////////
        public void Copy(Image source, uint destX, uint destY, IntRect sourceRect, bool applyAlpha)
        {
            sfImage_copyImage(CPointer, source.CPointer, destX, destY, sourceRect, applyAlpha);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Get a pixel from the image
        /// </summary>
        /// <param name="x">X coordinate of pixel in the image</param>
        /// <param name="y">Y coordinate of pixel in the image</param>
        /// <returns>Color of pixel (x, y)</returns>
        ////////////////////////////////////////////////////////////
        public Color GetPixel(uint x, uint y) => sfImage_getPixel(CPointer, x, y);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Change the color of a pixel
        /// </summary>
        /// <param name="x">X coordinate of pixel in the image</param>
        /// <param name="y">Y coordinate of pixel in the image</param>
        /// <param name="color">New color for pixel (x, y)</param>
        ////////////////////////////////////////////////////////////
        public void SetPixel(uint x, uint y, Color color)
        {
            sfImage_setPixel(CPointer, x, y, color);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Get a copy of the array of pixels (RGBA 8 bits integers components)
        /// Array size is Width x Height x 4
        /// </summary>
        /// <returns>Array of pixels</returns>
        ////////////////////////////////////////////////////////////
        public byte[] Pixels
        {
            get
            {
                var size = Size;
                var pixelsPtr = new byte[size.X * size.Y * 4];
                Marshal.Copy(sfImage_getPixelsPtr(CPointer), pixelsPtr, 0, pixelsPtr.Length);
                return pixelsPtr;
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Size of the image, in pixels
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Vector2U Size => sfImage_getSize(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Flip the image horizontally
        /// </summary>
        ////////////////////////////////////////////////////////////
        public void FlipHorizontally()
        {
            sfImage_flipHorizontally(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Flip the image vertically
        /// </summary>
        ////////////////////////////////////////////////////////////
        public void FlipVertically()
        {
            sfImage_flipVertically(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => $"[Image] Size({Size})";

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Internal constructor
        /// </summary>
        /// <param name="cPointer">Pointer to the object in C library</param>
        ////////////////////////////////////////////////////////////
        internal Image(IntPtr cPointer) : base(cPointer) { }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        ////////////////////////////////////////////////////////////
        protected override void Destroy(bool disposing)
        {
            sfImage_destroy(CPointer);
        }

        #region Imports
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfImage_createFromColor(uint width, uint height, Color col);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private unsafe static extern IntPtr sfImage_createFromPixels(uint width, uint height, byte* pixels);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfImage_createFromFile(string filename);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private unsafe static extern IntPtr sfImage_createFromStream(IntPtr stream);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private unsafe static extern IntPtr sfImage_createFromMemory(IntPtr data, ulong size);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfImage_copy(IntPtr image);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfImage_destroy(IntPtr cPointer);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfImage_saveToFile(IntPtr cPointer, string filename);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfImage_createMaskFromColor(IntPtr cPointer, Color col, byte alpha);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfImage_copyImage(IntPtr cPointer, IntPtr source, uint destX, uint destY, IntRect sourceRect, bool applyAlpha);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfImage_setPixel(IntPtr cPointer, uint x, uint y, Color col);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Color sfImage_getPixel(IntPtr cPointer, uint x, uint y);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfImage_getPixelsPtr(IntPtr cPointer);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector2U sfImage_getSize(IntPtr cPointer);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern uint sfImage_flipHorizontally(IntPtr cPointer);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern uint sfImage_flipVertically(IntPtr cPointer);
        #endregion
    }
}
