using System;
using System.Runtime.InteropServices;
using System.Security;
using CrossUI.SFML.System;

namespace CrossUI.SFML.Graphics
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Define a set of one or more 2D primitives
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class VertexArray : ObjectBase, IDrawable
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Default constructor
        /// </summary>
        ////////////////////////////////////////////////////////////
        public VertexArray() :
            base(sfVertexArray_create())
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the vertex array with a type
        /// </summary>
        /// <param name="type">Type of primitives</param>
        ////////////////////////////////////////////////////////////
        public VertexArray(PrimitiveType type) :
            base(sfVertexArray_create())
        {
            PrimitiveType = type;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the vertex array with a type and an initial number of vertices
        /// </summary>
        /// <param name="type">Type of primitives</param>
        /// <param name="vertexCount">Initial number of vertices in the array</param>
        ////////////////////////////////////////////////////////////
        public VertexArray(PrimitiveType type, uint vertexCount) :
            base(sfVertexArray_create())
        {
            PrimitiveType = type;
            Resize(vertexCount);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the vertex array from another vertex array
        /// </summary>
        /// <param name="copy">Transformable to copy</param>
        ////////////////////////////////////////////////////////////
        public VertexArray(VertexArray copy) :
            base(sfVertexArray_copy(copy.CPointer))
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Total vertex count
        /// </summary>
        ////////////////////////////////////////////////////////////
        public uint VertexCount => sfVertexArray_getVertexCount(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Read-write access to vertices by their index.
        ///
        /// This function doesn't check index, it must be in range
        /// [0, VertexCount - 1]. The behaviour is undefined
        /// otherwise.
        /// </summary>
        /// <param name="index">Index of the vertex to get</param>
        /// <returns>Reference to the index-th vertex</returns>
        ////////////////////////////////////////////////////////////
        public Vertex this[uint index]
        {
            get
            {
                unsafe
                {
                    return *sfVertexArray_getVertex(CPointer, index);
                }
            }
            set
            {
                unsafe
                {
                    *sfVertexArray_getVertex(CPointer, index) = value;
                }
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Clear the vertex array
        /// </summary>
        ////////////////////////////////////////////////////////////
        public void Clear()
        {
            sfVertexArray_clear(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Resize the vertex array
        /// 
        /// If \a vertexCount is greater than the current size, the previous
        /// vertices are kept and new (default-constructed) vertices are
        /// added.
        /// If \a vertexCount is less than the current size, existing vertices
        /// are removed from the array.
        /// </summary>
        /// <param name="vertexCount">New size of the array (number of vertices)</param>
        ////////////////////////////////////////////////////////////
        public void Resize(uint vertexCount)
        {
            sfVertexArray_resize(CPointer, vertexCount);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Add a vertex to the array
        /// </summary>
        /// <param name="vertex">Vertex to add</param>
        ////////////////////////////////////////////////////////////
        public void Append(Vertex vertex)
        {
            sfVertexArray_append(CPointer, vertex);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Type of primitives to draw
        /// </summary>
        ////////////////////////////////////////////////////////////
        public PrimitiveType PrimitiveType
        {
            get => sfVertexArray_getPrimitiveType(CPointer);
            set => sfVertexArray_setPrimitiveType(CPointer, value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Compute the bounding rectangle of the vertex array.
        ///
        /// This function returns the axis-aligned rectangle that
        /// contains all the vertices of the array.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public FloatRect Bounds => sfVertexArray_getBounds(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Draw the vertex array to a render target
        /// </summary>
        /// <param name="target">Render target to draw to</param>
        /// <param name="states">Current render states</param>
        ////////////////////////////////////////////////////////////
        public void Draw(IRenderTarget target, RenderStates states)
        {
            var marshaledStates = states.Marshal();

            if (target is RenderWindow)
            {
                sfRenderWindow_drawVertexArray(( (RenderWindow)target ).CPointer, CPointer, ref marshaledStates);
            }
            else if (target is RenderTexture)
            {
                sfRenderTexture_drawVertexArray(( (RenderTexture)target ).CPointer, CPointer, ref marshaledStates);
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        ////////////////////////////////////////////////////////////
        protected override void Destroy(bool disposing)
        {
            sfVertexArray_destroy(CPointer);
        }

        #region Imports
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfVertexArray_create();

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfVertexArray_copy(IntPtr cPointer);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfVertexArray_destroy(IntPtr cPointer);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern uint sfVertexArray_getVertexCount(IntPtr cPointer);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern unsafe Vertex* sfVertexArray_getVertex(IntPtr cPointer, uint index);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfVertexArray_clear(IntPtr cPointer);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfVertexArray_resize(IntPtr cPointer, uint vertexCount);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfVertexArray_append(IntPtr cPointer, Vertex vertex);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfVertexArray_setPrimitiveType(IntPtr cPointer, PrimitiveType type);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern PrimitiveType sfVertexArray_getPrimitiveType(IntPtr cPointer);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern FloatRect sfVertexArray_getBounds(IntPtr cPointer);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderWindow_drawVertexArray(IntPtr cPointer, IntPtr vertexArray, ref RenderStates.MarshalData states);

        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfRenderTexture_drawVertexArray(IntPtr cPointer, IntPtr vertexArray, ref RenderStates.MarshalData states);
        #endregion
    }
}
