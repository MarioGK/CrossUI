using System;
using System.Runtime.InteropServices;

namespace CrossUI.SFML.System
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Vector2f is an utility class for manipulating 2 dimensional
    /// vectors with float components
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2F : IEquatable<Vector2F>
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the vector from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        ////////////////////////////////////////////////////////////
        public Vector2F(float x, float y)
        {
            X = x;
            Y = y;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator - overload ; returns the opposite of a vector
        /// </summary>
        /// <param name="v">Vector to negate</param>
        /// <returns>-v</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2F operator -(Vector2F v) => new Vector2F(-v.X, -v.Y);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator - overload ; subtracts two vectors
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 - v2</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2F operator -(Vector2F v1, Vector2F v2) => new Vector2F(v1.X - v2.X, v1.Y - v2.Y);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator + overload ; add two vectors
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 + v2</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2F operator +(Vector2F v1, Vector2F v2) => new Vector2F(v1.X + v2.X, v1.Y + v2.Y);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator * overload ; multiply a vector by a scalar value
        /// </summary>
        /// <param name="v">Vector</param>
        /// <param name="x">Scalar value</param>
        /// <returns>v * x</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2F operator *(Vector2F v, float x) => new Vector2F(v.X * x, v.Y * x);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator * overload ; multiply a scalar value by a vector
        /// </summary>
        /// <param name="x">Scalar value</param>
        /// <param name="v">Vector</param>
        /// <returns>x * v</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2F operator *(float x, Vector2F v) => new Vector2F(v.X * x, v.Y * x);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator / overload ; divide a vector by a scalar value
        /// </summary>
        /// <param name="v">Vector</param>
        /// <param name="x">Scalar value</param>
        /// <returns>v / x</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2F operator /(Vector2F v, float x) => new Vector2F(v.X / x, v.Y / x);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator == overload ; check vector equality
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 == v2</returns>
        ////////////////////////////////////////////////////////////
        public static bool operator ==(Vector2F v1, Vector2F v2) => v1.Equals(v2);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator != overload ; check vector inequality
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 != v2</returns>
        ////////////////////////////////////////////////////////////
        public static bool operator !=(Vector2F v1, Vector2F v2) => !v1.Equals(v2);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => $"[Vector2f] X({X}) Y({Y})";

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Compare vector and object and checks if they are equal
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>Object and vector are equal</returns>
        ////////////////////////////////////////////////////////////
        public override bool Equals(object obj) => ( obj is Vector2F ) && Equals((Vector2F)obj);

        ///////////////////////////////////////////////////////////
        /// <summary>
        /// Compare two vectors and checks if they are equal
        /// </summary>
        /// <param name="other">Vector to check</param>
        /// <returns>Vectors are equal</returns>
        ////////////////////////////////////////////////////////////
        public bool Equals(Vector2F other) => ( X == other.X ) && ( Y == other.Y );

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Provide a integer describing the object
        /// </summary>
        /// <returns>Integer description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode();

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Explicit casting to another vector type
        /// </summary>
        /// <param name="v">Vector being casted</param>
        /// <returns>Casting result</returns>
        ////////////////////////////////////////////////////////////
        public static explicit operator Vector2I(Vector2F v) => new Vector2I((int)v.X, (int)v.Y);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Explicit casting to another vector type
        /// </summary>
        /// <param name="v">Vector being casted</param>
        /// <returns>Casting result</returns>
        ////////////////////////////////////////////////////////////
        public static explicit operator Vector2U(Vector2F v) => new Vector2U((uint)v.X, (uint)v.Y);

        /// <summary>X (horizontal) component of the vector</summary>
        public float X;

        /// <summary>Y (vertical) component of the vector</summary>
        public float Y;
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Vector2i is an utility class for manipulating 2 dimensional
    /// vectors with integer components
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2I : IEquatable<Vector2I>
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the vector from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        ////////////////////////////////////////////////////////////
        public Vector2I(int x, int y)
        {
            X = x;
            Y = y;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator - overload ; returns the opposite of a vector
        /// </summary>
        /// <param name="v">Vector to negate</param>
        /// <returns>-v</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2I operator -(Vector2I v) => new Vector2I(-v.X, -v.Y);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator - overload ; subtracts two vectors
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 - v2</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2I operator -(Vector2I v1, Vector2I v2) => new Vector2I(v1.X - v2.X, v1.Y - v2.Y);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator + overload ; add two vectors
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 + v2</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2I operator +(Vector2I v1, Vector2I v2) => new Vector2I(v1.X + v2.X, v1.Y + v2.Y);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator * overload ; multiply a vector by a scalar value
        /// </summary>
        /// <param name="v">Vector</param>
        /// <param name="x">Scalar value</param>
        /// <returns>v * x</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2I operator *(Vector2I v, int x) => new Vector2I(v.X * x, v.Y * x);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator * overload ; multiply a scalar value by a vector
        /// </summary>
        /// <param name="x">Scalar value</param>
        /// <param name="v">Vector</param>
        /// <returns>x * v</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2I operator *(int x, Vector2I v) => new Vector2I(v.X * x, v.Y * x);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator / overload ; divide a vector by a scalar value
        /// </summary>
        /// <param name="v">Vector</param>
        /// <param name="x">Scalar value</param>
        /// <returns>v / x</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2I operator /(Vector2I v, int x) => new Vector2I(v.X / x, v.Y / x);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator == overload ; check vector equality
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 == v2</returns>
        ////////////////////////////////////////////////////////////
        public static bool operator ==(Vector2I v1, Vector2I v2) => v1.Equals(v2);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator != overload ; check vector inequality
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 != v2</returns>
        ////////////////////////////////////////////////////////////
        public static bool operator !=(Vector2I v1, Vector2I v2) => !v1.Equals(v2);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => $"[Vector2i] X({X}) Y({Y})";

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Compare vector and object and checks if they are equal
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>Object and vector are equal</returns>
        ////////////////////////////////////////////////////////////
        public override bool Equals(object obj) => ( obj is Vector2I ) && Equals((Vector2I)obj);

        ///////////////////////////////////////////////////////////
        /// <summary>
        /// Compare two vectors and checks if they are equal
        /// </summary>
        /// <param name="other">Vector to check</param>
        /// <returns>Vectors are equal</returns>
        ////////////////////////////////////////////////////////////
        public bool Equals(Vector2I other) => ( X == other.X ) && ( Y == other.Y );

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Provide a integer describing the object
        /// </summary>
        /// <returns>Integer description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode();

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Explicit casting to another vector type
        /// </summary>
        /// <param name="v">Vector being casted</param>
        /// <returns>Casting result</returns>
        ////////////////////////////////////////////////////////////
        public static explicit operator Vector2F(Vector2I v) => new Vector2F(v.X, v.Y);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Explicit casting to another vector type
        /// </summary>
        /// <param name="v">Vector being casted</param>
        /// <returns>Casting result</returns>
        ////////////////////////////////////////////////////////////
        public static explicit operator Vector2U(Vector2I v) => new Vector2U((uint)v.X, (uint)v.Y);

        /// <summary>X (horizontal) component of the vector</summary>
        public int X;

        /// <summary>Y (vertical) component of the vector</summary>
        public int Y;
    }

    ////////////////////////////////////////////////////////////
    /// <summary>
    /// Vector2u is an utility class for manipulating 2 dimensional
    /// vectors with unsigned integer components
    /// </summary>
    ////////////////////////////////////////////////////////////
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2U : IEquatable<Vector2U>
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Construct the vector from its coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        ////////////////////////////////////////////////////////////
        public Vector2U(uint x, uint y)
        {
            X = x;
            Y = y;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator - overload ; subtracts two vectors
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 - v2</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2U operator -(Vector2U v1, Vector2U v2) => new Vector2U(v1.X - v2.X, v1.Y - v2.Y);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator + overload ; add two vectors
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 + v2</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2U operator +(Vector2U v1, Vector2U v2) => new Vector2U(v1.X + v2.X, v1.Y + v2.Y);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator * overload ; multiply a vector by a scalar value
        /// </summary>
        /// <param name="v">Vector</param>
        /// <param name="x">Scalar value</param>
        /// <returns>v * x</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2U operator *(Vector2U v, uint x) => new Vector2U(v.X * x, v.Y * x);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator * overload ; multiply a scalar value by a vector
        /// </summary>
        /// <param name="x">Scalar value</param>
        /// <param name="v">Vector</param>
        /// <returns>x * v</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2U operator *(uint x, Vector2U v) => new Vector2U(v.X * x, v.Y * x);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator / overload ; divide a vector by a scalar value
        /// </summary>
        /// <param name="v">Vector</param>
        /// <param name="x">Scalar value</param>
        /// <returns>v / x</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2U operator /(Vector2U v, uint x) => new Vector2U(v.X / x, v.Y / x);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator == overload ; check vector equality
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 == v2</returns>
        ////////////////////////////////////////////////////////////
        public static bool operator ==(Vector2U v1, Vector2U v2) => v1.Equals(v2);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Operator != overload ; check vector inequality
        /// </summary>
        /// <param name="v1">First vector</param>
        /// <param name="v2">Second vector</param>
        /// <returns>v1 != v2</returns>
        ////////////////////////////////////////////////////////////
        public static bool operator !=(Vector2U v1, Vector2U v2) => !v1.Equals(v2);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => $"[Vector2u] X({X}) Y({Y})";

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Compare vector and object and checks if they are equal
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>Object and vector are equal</returns>
        ////////////////////////////////////////////////////////////
        public override bool Equals(object obj) => ( obj is Vector2U ) && Equals((Vector2U)obj);

        ///////////////////////////////////////////////////////////
        /// <summary>
        /// Compare two vectors and checks if they are equal
        /// </summary>
        /// <param name="other">Vector to check</param>
        /// <returns>Vectors are equal</returns>
        ////////////////////////////////////////////////////////////
        public bool Equals(Vector2U other) => ( X == other.X ) && ( Y == other.Y );

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Provide a integer describing the object
        /// </summary>
        /// <returns>Integer description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode();

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Explicit casting to another vector type
        /// </summary>
        /// <param name="v">Vector being casted</param>
        /// <returns>Casting result</returns>
        ////////////////////////////////////////////////////////////
        public static explicit operator Vector2I(Vector2U v) => new Vector2I((int)v.X, (int)v.Y);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Explicit casting to another vector type
        /// </summary>
        /// <param name="v">Vector being casted</param>
        /// <returns>Casting result</returns>
        ////////////////////////////////////////////////////////////
        public static explicit operator Vector2F(Vector2U v) => new Vector2F(v.X, v.Y);

        /// <summary>X (horizontal) component of the vector</summary>
        public uint X;

        /// <summary>Y (vertical) component of the vector</summary>
        public uint Y;
    }
}
