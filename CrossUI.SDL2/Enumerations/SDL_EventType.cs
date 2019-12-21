using System.ComponentModel;

namespace CrossUI.SDL2.Enumerations
{
    /// <summary>
    /// The types of events that can be delivered.
    /// </summary>
    public enum SDL_EventType
    {
        FirstEvent = 0,

        /* Application events */

        /// <summary>
        /// User-requested quit.
        /// </summary>
        Quit = 0x100,

        /// <summary>
        /// The application is being terminated by the OS.
        /// Called on iOS in applicationWillTerminate()
        /// Called on Android in onDestroy()
        /// </summary>
        Terminating,

        /// <summary>
        /// The application is low on memory, free memory if possible.
        /// Called on iOS in applicationDidReceiveMemoryWarning()
        /// Called on Android in onLowMemory()
        /// </summary>
        LowMemory,

        /// <summary>
        /// The application is about to enter the background.
        /// Called on iOS in applicationWillResignActive().
        /// Called on Android in onPause()
        /// </summary>
        WillEnterBackground,
        /// <summary>
        /// The application did enter the background and may not get CPU for some time.
        /// Called on iOS in applicationDidEnterBackground().
        /// Called on Android in onPause()
        /// </summary>
        DidEnterBackground,
        /// <summary>
        /// The application is about to enter the foreground
        /// Called on iOS in applicationWillEnterForeground()
        /// Called on Android in onResume()
        /// </summary>
        WillEnterForeground,
        /// <summary>
        /// The application is now interactive
        /// Called on iOS in applicationDidBecomeActive()
        /// Called on Android in onResume()
        /// </summary>
        DidEnterForeground,

        /* Sdl2Window events */
        /// <summary>
        /// Sdl2Window state change
        /// </summary>
        WindowEvent = 0x200,
        /// <summary>
        /// System specific event
        /// </summary>
        SysWMEvent,

        /* Keyboard events */
        /// <summary>
        /// Key pressed
        /// </summary>
        KeyDown = 0x300,
        /// <summary>
        /// Key released
        /// </summary>
        KeyUp,
        /// <summary>
        /// Keyboard text editing (composition)
        /// </summary>
        TextEditing,
        /// <summary>
        /// Keyboard text input
        /// </summary>
        TextInput,
        /// <summary>
        /// Keymap changed due to a system event such as an input language or keyboard layout change.
        /// </summary>
        KeyMapChanged,

        /* Mouse events */
        /// <summary>
        /// Mouse moved
        /// </summary>
        MouseMotion = 0x400,
        MouseButtonDown,
        /// <summary>
        /// Mouse button released
        /// </summary>
        MouseButtonUp,
        /// <summary>
        /// Mouse wheel motion
        /// </summary>
        MouseWheel,

        /* Joystick events */
        /// <summary>
        /// Joystick axis motion
        /// </summary>
        JoyAxisMotion = 0x600,
        /// <summary>
        /// Joystick trackball motion
        /// </summary>
        JoyBallMotion,
        /// <summary>
        /// Joystick hat position change
        /// </summary>
        JoyHatMotion,
        /// <summary>
        /// Joystick button pressed
        /// </summary>
        JoyButtonDown,
        /// <summary>
        /// Joystick button released
        /// </summary>
        JoyButtonUp,
        /// <summary>
        /// A new joystick has been inserted into the system
        /// </summary>
        JoyDeviceAdded,
        /// <summary>
        /// An opened joystick has been removed
        /// </summary>
        JoyDeviceRemoved,

        /* Game controller events */
        /// <summary>
        /// Game controller axis motion
        /// </summary>
        ControllerAxisMotion = 0x650,
        /// <summary>
        /// Game controller button pressed
        /// </summary>
        ControllerButtonDown,
        /// <summary>
        /// Game controller button released
        /// </summary>
        ControllerButtonUp,
        /// <summary>
        /// A new Game controller has been inserted into the system
        /// </summary>
        ControllerDeviceAdded,
        /// <summary>
        /// An opened Game controller has been removed
        /// </summary>
        ControllerDeviceRemoved,
        /// <summary>
        /// The controller mapping was updated
        /// </summary>
        ControllerDeviceRemapped,

        /* Touch events */
        FingerDown = 0x700,
        FingerUp,
        FingerMotion,

        /* Gesture events */
        DollarGesture = 0x800,
        DollarRecord,
        MultiGesture,

        /* Clipboard events */
        /// <summary>
        /// The clipboard changed
        /// </summary>
        ClipboardUpdate = 0x900,

        /* Drag and drop events */
        /// <summary>
        /// The system requests a file open
        /// </summary>
        DropFile = 0x1000,
        /// <summary>
        /// text/plain drag-and-drop event
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        DropTest,
        /// <summary>
        /// text/plain drag-and-drop event
        /// </summary>
        DropText = DropTest,
        /// <summary>
        /// A new set of drops is beginning (NULL filename) 
        /// </summary>
        DropBegin,
        /// <summary>
        /// Current set of drops is now complete (NULL filename)
        /// </summary>
        DropComplete,

        /* Audio hotplug events */
        /// <summary>
        /// A new audio device is available
        /// </summary>
        AudioDeviceAdded = 0x1100,
        /// <summary>
        /// An audio device has been removed.
        /// </summary>
        AudioDeviceRemoved,

        /* Render events */
        /// <summary>
        /// The render targets have been reset and their contents need to be updated
        /// </summary>
        RenderTargetsReset = 0x2000,
        /// <summary>
        /// The device has been reset and all textures need to be recreated
        /// </summary>
        RenderDeviceReset,

        /// <summary>
        /// Events ::SDL_USEREVENT through ::SDL_LASTEVENT are for your use,
        /// *  and should be allocated with SDL_RegisterEvents()
        /// </summary>
        UserEvent = 0x8000,

        LastEvent = 0xFFFF
    }
}