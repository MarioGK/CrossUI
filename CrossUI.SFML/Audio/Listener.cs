using System.Runtime.InteropServices;
using System.Security;
using CrossUI.SFML.System;

namespace CrossUI.SFML.Audio
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    /// The audio listener is the point in the scene
    /// from where all the sounds are heard
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class Listener
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        /// The volume is a number between 0 and 100; it is combined with
        /// the individual volume of each sound / music.
        /// The default value for the volume is 100 (maximum).
        /// </summary>
        ////////////////////////////////////////////////////////////
        public static float GlobalVolume
        {
            get => sfListener_getGlobalVolume();
            set => sfListener_setGlobalVolume(value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// 3D position of the listener (default is (0, 0, 0))
        /// </summary>
        ////////////////////////////////////////////////////////////
        public static Vector3F Position
        {
            get => sfListener_getPosition();
            set => sfListener_setPosition(value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// The direction (also called "at vector") is the vector
        /// pointing forward from the listener's perspective. Together
        /// with the up vector, it defines the 3D orientation of the
        /// listener in the scene. The direction vector doesn't
        /// have to be normalized.
        /// The default listener's direction is (0, 0, -1).
        /// </summary>
        ////////////////////////////////////////////////////////////
        public static Vector3F Direction
        {
            get => sfListener_getDirection();
            set => sfListener_setDirection(value);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// The up vector is the vector that points upward from the
        /// listener's perspective. Together with the direction, it
        /// defines the 3D orientation of the listener in the scene.
        /// The up vector doesn't have to be normalized.
        /// The default listener's up vector is (0, 1, 0). It is usually
        /// not necessary to change it, especially in 2D scenarios.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public static Vector3F UpVector
        {
            get => sfListener_getUpVector();
            set => sfListener_setUpVector(value);
        }

        #region Imports
        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfListener_setGlobalVolume(float volume);

        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern float sfListener_getGlobalVolume();

        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfListener_setPosition(Vector3F position);

        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector3F sfListener_getPosition();

        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfListener_setDirection(Vector3F direction);

        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector3F sfListener_getDirection();

        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfListener_setUpVector(Vector3F upVector);

        [DllImport(Csfml.Audio, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector3F sfListener_getUpVector();
        #endregion
    }
}
