using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using CrossUI.SFML.System;

namespace CrossUI.SFML.Window
{
    //////////////////////////////////////////////////////////////////
    /// <summary>
    /// This class defines a .NET interface to an SFML OpenGL Context
    /// </summary>
    //////////////////////////////////////////////////////////////////
    public class Context : CriticalFinalizerObject
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Default constructor
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Context()
        {
            myThis = sfContext_create();
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Finalizer
        /// </summary>
        ////////////////////////////////////////////////////////////
        ~Context()
        {
            sfContext_destroy(myThis);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Activate or deactivate the context
        /// </summary>
        /// <param name="active">True to activate, false to deactivate</param>
        /// <returns>true on success, false on failure</returns>
        ////////////////////////////////////////////////////////////
        public bool SetActive(bool active)
        {
            return sfContext_setActive(myThis, active);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Get the settings of the context.
        /// </summary>
        ////////////////////////////////////////////////////////////
        public ContextSettings Settings => sfContext_getSettings(myThis);

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Global helper context
        /// </summary>
        ////////////////////////////////////////////////////////////
        public static Context Global
        {
            get
            {
                if (_ourGlobalContext == null)
                {
                    _ourGlobalContext = new Context();
                }

                return _ourGlobalContext;
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        /// Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString()
        {
            return "[Context]";
        }

        private static Context _ourGlobalContext = null;

        private readonly IntPtr myThis = IntPtr.Zero;

        #region Imports
        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfContext_create();

        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfContext_destroy(IntPtr view);

        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfContext_setActive(IntPtr view, bool active);

        [DllImport(Csfml.Window, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern ContextSettings sfContext_getSettings(IntPtr view);
        #endregion
    }
}
