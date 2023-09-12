using System;
using System.Runtime.InteropServices;

namespace GLFWNet
{
    public delegate void GLFWglproc();
    public delegate void GLFWvkproc();
    public delegate void GLFWerrorfun(int error_code, IntPtr description);
    public delegate void GLFWwindowposfun(IntPtr window, int x, int y);
    public delegate void GLFWwindowsizefun(IntPtr window, int width, int height);
    public delegate void GLFWwindowclosefun(IntPtr window);
    public delegate void GLFWwindowrefreshfun(IntPtr window);
    public delegate void GLFWwindowfocusfun(IntPtr window, int focused);
    public delegate void GLFWwindowiconifyfun(IntPtr window, int iconified);
    public delegate void GLFWwindowmaximizefun(IntPtr window, int iconified);
    public delegate void GLFWframebuffersizefun(IntPtr window, int width, int height);
    public delegate void GLFWwindowcontentscalefun(IntPtr window, float xscale, float yscale);
    public delegate void GLFWmousebuttonfun(IntPtr window, int button, int action, int mods);
    public delegate void GLFWcursorposfun(IntPtr window, double x, double y);
    public delegate void GLFWcursorenterfun(IntPtr window, int entered);
    public delegate void GLFWscrollfun(IntPtr window, double xoffset, double yoffset);
    public delegate void GLFWkeyfun(IntPtr window, int key, int scancode, int action, int mods);
    public delegate void GLFWcharfun(IntPtr window, uint codepoint);
    public delegate void GLFWcharmodsfun(IntPtr window, uint codepoint, int mods);
    public delegate void GLFWdropfun(IntPtr window, int path_count, IntPtr paths);
    public delegate void GLFWmonitorfun(IntPtr monitor, int monitor_event);
    public delegate void GLFWjoystickfun(int jid, int joystick_event);

    [StructLayout(LayoutKind.Sequential)]
    public struct GLFWvidmode
    {
        /*! The width, in screen coordinates, of the video mode.
        */
        public int width;
        /*! The height, in screen coordinates, of the video mode.
        */
        public int height;
        /*! The bit depth of the red channel of the video mode.
        */
        public int redBits;
        /*! The bit depth of the green channel of the video mode.
        */
        public int greenBits;
        /*! The bit depth of the blue channel of the video mode.
        */
        public int blueBits;
        /*! The refresh rate, in Hz, of the video mode.
        */
        public int refreshRate;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GLFWgammaramp
    {
        /*! An array of value describing the response of the red channel.
        */
        public ushort[] red;
        /*! An array of value describing the response of the green channel.
        */
        public short[] green;
        /*! An array of value describing the response of the blue channel.
        */
        public short[] blue;
        /*! The number of elements in each array.
        */
        public int size;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct GLFWimage
    {
        /*! The width, in pixels, of this image.
        */
        public int width;
        /*! The height, in pixels, of this image.
        */
        public int height;
        /*! The pixel data of this image, arranged left-to-right, top-to-bottom.
        */
        public IntPtr pixels;
    } 

    [StructLayout(LayoutKind.Sequential)]
    public struct GLFWgamepadstate
    {
        /*! The states of each [gamepad button](@ref gamepad_buttons), `GLFW_PRESS`
        *  or `GLFW_RELEASE`.
        */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
        public byte[] buttons;
        /*! The states of each [gamepad axis](@ref gamepad_axes), in the range -1.0
        *  to 1.0 inclusive.
        */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public float[] axes;
    }

    public static class GLFW
    {
        private const string GLFW_LIBRARY = "glfw";

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int glfwInit();

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwTerminate();

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwInitHint(int hint, int value);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwGetVersion(out int major, out int minor, out int rev);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr glfwGetVersionString();

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int glfwGetError(out IntPtr description);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern GLFWerrorfun glfwSetErrorCallback(GLFWerrorfun callback);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr[] glfwGetMonitors(out int count);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr glfwGetPrimaryMonitor();

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwGetMonitorPos(IntPtr monitor, out int xpos, out int ypos);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwGetMonitorWorkarea(IntPtr monitor, out int xpos, out int ypos, out int width, out int height);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwGetMonitorPhysicalSize(IntPtr monitor, out int widthMM, out int heightMM);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwGetMonitorContentScale(IntPtr monitor, out float xscale, out float yscale);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr glfwGetMonitorName(IntPtr monitor);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwSetMonitorUserPointer(IntPtr monitor, IntPtr pointer);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr glfwGetMonitorUserPointer(IntPtr monitor);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern GLFWmonitorfun glfwSetMonitorCallback(GLFWmonitorfun callback);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr glfwGetVideoModes(IntPtr monitor, out int count);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr glfwGetVideoMode(IntPtr monitor);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwSetGamma(IntPtr monitor, float gamma);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr glfwGetGammaRamp(IntPtr monitor);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwSetGammaRamp(IntPtr monitor, ref GLFWgammaramp ramp);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwDefaultWindowHints();

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwWindowHint(int hint, int value);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void glfwWindowHintString(int hint, string value);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern IntPtr glfwCreateWindow(int width, int height, string title, IntPtr monitor, IntPtr share);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwDestroyWindow(IntPtr window);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int glfwWindowShouldClose(IntPtr window);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwSetWindowShouldClose(IntPtr window, int value);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void glfwSetWindowTitle(IntPtr window, string title);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwSetWindowIcon(IntPtr window, int count, IntPtr images);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwGetWindowPos(IntPtr window, out int xpos, out int ypos);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwSetWindowPos(IntPtr window, int xpos, int ypos);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwGetWindowSize(IntPtr window, out int width, out int height);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwSetWindowSizeLimits(IntPtr window, int minwidth, int minheight, int maxwidth, int maxheight);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwSetWindowAspectRatio(IntPtr window, int numer, int denom);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwSetWindowSize(IntPtr window, int width, int height);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwGetFramebufferSize(IntPtr window, out int width, out int height);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwGetWindowFrameSize(IntPtr window, out int left, out int top, out int right, out int bottom);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwGetWindowContentScale(IntPtr window, out float xscale, out float yscale);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern float glfwGetWindowOpacity(IntPtr window);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwSetWindowOpacity(IntPtr window, float opacity);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwIconifyWindow(IntPtr window);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwRestoreWindow(IntPtr window);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwMaximizeWindow(IntPtr window);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwShowWindow(IntPtr window);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwHideWindow(IntPtr window);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwFocusWindow(IntPtr window);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwRequestWindowAttention(IntPtr window);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr glfwGetWindowMonitor(IntPtr window);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwSetWindowMonitor(IntPtr window, IntPtr monitor, int xpos, int ypos, int width, int height, int refreshRate);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int glfwGetWindowAttrib(IntPtr window, int attrib);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwSetWindowAttrib(IntPtr window, int attrib, int value);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwSetWindowUserPointer(IntPtr window, IntPtr pointer);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr glfwGetWindowUserPointer(IntPtr window);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern GLFWwindowposfun glfwSetWindowPosCallback(IntPtr window, GLFWwindowposfun callback);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern GLFWwindowsizefun glfwSetWindowSizeCallback(IntPtr window, GLFWwindowsizefun callback);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern GLFWwindowclosefun glfwSetWindowCloseCallback(IntPtr window, GLFWwindowclosefun callback);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern GLFWwindowrefreshfun glfwSetWindowRefreshCallback(IntPtr window, GLFWwindowrefreshfun callback);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern GLFWwindowfocusfun glfwSetWindowFocusCallback(IntPtr window, GLFWwindowfocusfun callback);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern GLFWwindowiconifyfun glfwSetWindowIconifyCallback(IntPtr window, GLFWwindowiconifyfun callback);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern GLFWwindowmaximizefun glfwSetWindowMaximizeCallback(IntPtr window, GLFWwindowmaximizefun callback);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern GLFWframebuffersizefun glfwSetFramebufferSizeCallback(IntPtr window, GLFWframebuffersizefun callback);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern GLFWwindowcontentscalefun glfwSetWindowContentScaleCallback(IntPtr window, GLFWwindowcontentscalefun callback);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwPollEvents();

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwWaitEvents();

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwWaitEventsTimeout(double timeout);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwPostEmptyEvent();

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int glfwGetInputMode(IntPtr window, int mode);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwSetInputMode(IntPtr window, int mode, int value);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int glfwRawMouseMotionSupported();

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr glfwGetKeyName(int key, int scancode);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int glfwGetKeyScancode(int key);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int glfwGetKey(IntPtr window, int key);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int glfwGetMouseButton(IntPtr window, int button);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwGetCursorPos(IntPtr window, out double xpos, out double ypos);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwSetCursorPos(IntPtr window, double xpos, double ypos);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr glfwCreateCursor(IntPtr image, int xhot, int yhot);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr glfwCreateStandardCursor(int shape);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwDestroyCursor(IntPtr cursor);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwSetCursor(IntPtr window, IntPtr cursor);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern GLFWkeyfun glfwSetKeyCallback(IntPtr window, GLFWkeyfun callback);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern GLFWcharfun glfwSetCharCallback(IntPtr window, GLFWcharfun callback);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern GLFWcharmodsfun glfwSetCharModsCallback(IntPtr window, GLFWcharmodsfun callback);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern GLFWmousebuttonfun glfwSetMouseButtonCallback(IntPtr window, GLFWmousebuttonfun callback);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern GLFWcursorposfun glfwSetCursorPosCallback(IntPtr window, GLFWcursorposfun callback);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern GLFWcursorenterfun glfwSetCursorEnterCallback(IntPtr window, GLFWcursorenterfun callback);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern GLFWscrollfun glfwSetScrollCallback(IntPtr window, GLFWscrollfun callback);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern GLFWdropfun glfwSetDropCallback(IntPtr window, GLFWdropfun callback);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int glfwJoystickPresent(int jid);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr glfwGetJoystickAxes(int jid, out int count);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr glfwGetJoystickButtons(int jid, out int count);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr glfwGetJoystickHats(int jid, out int count);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr glfwGetJoystickName(int jid);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr glfwGetJoystickGUID(int jid);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwSetJoystickUserPointer(int jid, IntPtr pointer);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr glfwGetJoystickUserPointer(int jid);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int glfwJoystickIsGamepad(int jid);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern GLFWjoystickfun glfwSetJoystickCallback(GLFWjoystickfun callback);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern int glfwUpdateGamepadMappings(string str);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr glfwGetGamepadName(int jid);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int glfwGetGamepadState(int jid, ref GLFWgamepadstate state);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern void glfwSetClipboardString(IntPtr window, string str);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr glfwGetClipboardString(IntPtr window);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern double glfwGetTime();

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwSetTime(double time);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern UInt64 glfwGetTimerValue();

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern UInt64 glfwGetTimerFrequency();

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwMakeContextCurrent(IntPtr window);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr glfwGetCurrentContext();

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwSwapBuffers(IntPtr window);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void glfwSwapInterval(int interval);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int glfwExtensionSupported(IntPtr extension);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern GLFWglproc glfwGetProcAddress(IntPtr procname);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int glfwVulkanSupported();

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr glfwGetRequiredInstanceExtensions(out UInt32 count);

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl)]
        internal static extern GLFWvkproc glfwGetInstanceProcAddress(IntPtr instance, IntPtr procname);


        public static int Init()
        {
            return glfwInit();
        }

        public static void Terminate()
        {
            glfwTerminate();
        }

        public static void InitHint(int hint, int value)
        {
            glfwInitHint(hint, value);
        }

        public static void GetVersion(out int major, out int minor, out int rev)
        {
            glfwGetVersion(out major, out minor, out rev);
        }

        public static string GetVersionString()
        {
            IntPtr str = glfwGetVersionString();
            return Marshal.PtrToStringAnsi(str);
        }

        public static int GetError(out string description)
        {
            int result = glfwGetError(out IntPtr ptr);

            if(ptr != IntPtr.Zero)
            {
                description = Marshal.PtrToStringAnsi(ptr);
                return result;
            }

            description = string.Empty;
            return result;

        }

        public static GLFWerrorfun SetErrorCallback(GLFWerrorfun callback)
        {
            return glfwSetErrorCallback(callback);
        }

        public static IntPtr[] GetMonitors(out int count)
        {
            return glfwGetMonitors(out count);
        }

        public static IntPtr GetPrimaryMonitor()
        {
            return glfwGetPrimaryMonitor();
        }

        public static void GetMonitorPos(IntPtr monitor, out int xpos, out int ypos)
        {
            glfwGetMonitorPos(monitor, out xpos, out ypos);
        }

        public static void GetMonitorWorkarea(IntPtr monitor, out int xpos, out int ypos, out int width, out int height)
        {
            glfwGetMonitorWorkarea(monitor, out xpos, out ypos, out width, out height);
        }

        public static void GetMonitorPhysicalSize(IntPtr monitor, out int widthMM, out int heightMM)
        {
            glfwGetMonitorPhysicalSize(monitor, out widthMM, out heightMM);
        }

        public static void GetMonitorContentScale(IntPtr monitor, out float xscale, out float yscale)
        {
            glfwGetMonitorContentScale(monitor, out xscale, out yscale);
        }

        public static string GetMonitorName(IntPtr monitor)
        {
            IntPtr str = glfwGetMonitorName(monitor);
            return Marshal.PtrToStringAnsi(str);
        }

        public static void SetMonitorUserPointer(IntPtr monitor, IntPtr pointer)
        {
            glfwSetMonitorUserPointer(monitor, pointer);
        }

        public static IntPtr GetMonitorUserPointer(IntPtr monitor)
        {
            return glfwGetMonitorUserPointer(monitor);
        }

        public static GLFWmonitorfun SetMonitorCallback(GLFWmonitorfun callback)
        {
            return glfwSetMonitorCallback(callback);
        }

        public static GLFWvidmode[] GetVideoModes(IntPtr monitor)
        {
            IntPtr ptr = glfwGetVideoModes(monitor, out int count);
            
            if (ptr != IntPtr.Zero && count > 0)
            {
                GLFWvidmode[] videoModes = new GLFWvidmode[count];

                for (int i = 0; i < count; i++)
                {
                    IntPtr modePtr = new IntPtr(ptr.ToInt64() + i * Marshal.SizeOf(typeof(GLFWvidmode)));
                    videoModes[i] = Marshal.PtrToStructure<GLFWvidmode>(modePtr);
                }

                return videoModes;
            }

            return null;
        }

        public static bool GetVideoMode(IntPtr monitor, out GLFWvidmode mode)
        {
            IntPtr ptr = glfwGetVideoMode(monitor);

            if(ptr != IntPtr.Zero)
            {
                mode = Marshal.PtrToStructure<GLFWvidmode>(ptr);
                return true;
            }

            mode = default;
            return false;
        }

        public static void SetGamma(IntPtr monitor, float gamma)
        {
            glfwSetGamma(monitor, gamma);
        }

        public static bool GetGammaRamp(IntPtr monitor, out GLFWgammaramp gamma)
        {
            IntPtr ptr = glfwGetGammaRamp(monitor);
            
            if(ptr != IntPtr.Zero)
            {
                gamma = Marshal.PtrToStructure<GLFWgammaramp>(ptr);
                return true;
            }

            gamma = default;
            return false;
        }

        public static void SetGammaRamp(IntPtr monitor, GLFWgammaramp ramp)
        {
            glfwSetGammaRamp(monitor, ref ramp);
        }

        public static void DefaultWindowHints()
        {
            glfwDefaultWindowHints();
        }

        public static void WindowHint(int hint, int value)
        {
            glfwWindowHint(hint, value);
        }

        public static void WindowHintString(int hint, string value)
        {
            glfwWindowHintString(hint, value);
        }

        public static IntPtr CreateWindow(int width, int height, string title, IntPtr monitor, IntPtr share)
        {
            return glfwCreateWindow(width, height, title, monitor, share);
        }

        public static void DestroyWindow(IntPtr window)
        {
            glfwDestroyWindow(window);
        }

        public static int WindowShouldClose(IntPtr window)
        {
            return glfwWindowShouldClose(window);
        }

        public static void SetWindowShouldClose(IntPtr window, int value)
        {
            glfwSetWindowShouldClose(window, value);
        }

        public static void SetWindowTitle(IntPtr window, string title)
        {
            glfwSetWindowTitle(window, title);
        }

        public static void SetWindowIcon(IntPtr window, GLFWimage[] images)
        {
            // IntPtr iconImagesPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLFWimage)) * images.Length);
            // for (int i = 0; i < images.Length; i++)
            // {
            //     IntPtr currentImagePtr = new IntPtr(iconImagesPtr.ToInt64() + i * Marshal.SizeOf(typeof(GLFWimage)));
            //     Marshal.StructureToPtr(images[i], currentImagePtr, false);
            // }
            // glfwSetWindowIcon(window, images.Length, iconImagesPtr);
        }

        public static void GetWindowPos(IntPtr window, out int xpos, out int ypos)
        {
            glfwGetWindowPos(window, out xpos, out ypos);
        }

        public static void SetWindowPos(IntPtr window, int xpos, int ypos)
        {
            glfwSetWindowPos(window, xpos, ypos);
        }

        public static void GetWindowSize(IntPtr window, out int width, out int height)
        {
            glfwGetWindowSize(window, out width, out height);
        }

        public static void SetWindowSizeLimits(IntPtr window, int minwidth, int minheight, int maxwidth, int maxheight)
        {
            glfwSetWindowSizeLimits(window, minwidth, minheight, maxwidth, maxheight);
        }

        public static void SetWindowAspectRatio(IntPtr window, int numer, int denom)
        {
            glfwSetWindowAspectRatio(window, numer, denom);
        }

        public static void SetWindowSize(IntPtr window, int width, int height)
        {
            glfwSetWindowSize(window, width, height);
        }

        public static void GetFramebufferSize(IntPtr window, out int width, out int height)
        {
            glfwGetFramebufferSize(window, out width, out height);
        }

        public static void GetWindowFrameSize(IntPtr window, out int left, out int top, out int right, out int bottom)
        {
            glfwGetWindowFrameSize(window, out left, out top, out right, out bottom);
        }

        public static void GetWindowContentScale(IntPtr window, out float xscale, out float yscale)
        {
            glfwGetWindowContentScale(window, out xscale, out yscale);
        }

        public static float GetWindowOpacity(IntPtr window)
        {
            return glfwGetWindowOpacity(window);
        }

        public static void SetWindowOpacity(IntPtr window, float opacity)
        {
            glfwSetWindowOpacity(window, opacity);
        }

        public static void IconifyWindow(IntPtr window)
        {
            glfwIconifyWindow(window);
        }

        public static void RestoreWindow(IntPtr window)
        {
            glfwRestoreWindow(window);
        }

        public static void MaximizeWindow(IntPtr window)
        {
            glfwMaximizeWindow(window);
        }

        public static void ShowWindow(IntPtr window)
        {
            glfwShowWindow(window);
        }

        public static void HideWindow(IntPtr window)
        {
            glfwHideWindow(window);
        }

        public static void FocusWindow(IntPtr window)
        {
            glfwFocusWindow(window);
        }

        public static void RequestWindowAttention(IntPtr window)
        {
            glfwRequestWindowAttention(window);
        }

        public static IntPtr GetWindowMonitor(IntPtr window)
        {
            return glfwGetWindowMonitor(window);
        }

        public static void SetWindowMonitor(IntPtr window, IntPtr monitor, int xpos, int ypos, int width, int height, int refreshRate)
        {
            glfwSetWindowMonitor(window, monitor, xpos, ypos, width, height, refreshRate);
        }

        public static int GetWindowAttrib(IntPtr window, int attrib)
        {
            return glfwGetWindowAttrib(window, attrib);
        }

        public static void SetWindowAttrib(IntPtr window, int attrib, int value)
        {
            glfwSetWindowAttrib(window, attrib, value);
        }

        public static void SetWindowUserPointer(IntPtr window, IntPtr pointer)
        {
            glfwSetWindowUserPointer(window, pointer);
        }

        public static IntPtr GetWindowUserPointer(IntPtr window)
        {
            return glfwGetWindowUserPointer(window);
        }

        public static GLFWwindowposfun SetWindowPosCallback(IntPtr window, GLFWwindowposfun callback)
        {
            return glfwSetWindowPosCallback(window, callback);
        }

        public static GLFWwindowsizefun SetWindowSizeCallback(IntPtr window, GLFWwindowsizefun callback)
        {
            return glfwSetWindowSizeCallback(window, callback);
        }

        public static GLFWwindowclosefun SetWindowCloseCallback(IntPtr window, GLFWwindowclosefun callback)
        {
            return glfwSetWindowCloseCallback(window, callback);
        }

        public static GLFWwindowrefreshfun SetWindowRefreshCallback(IntPtr window, GLFWwindowrefreshfun callback)
        {
            return glfwSetWindowRefreshCallback(window, callback);
        }

        public static GLFWwindowfocusfun SetWindowFocusCallback(IntPtr window, GLFWwindowfocusfun callback)
        {
            return glfwSetWindowFocusCallback(window, callback);
        }

        public static GLFWwindowiconifyfun SetWindowIconifyCallback(IntPtr window, GLFWwindowiconifyfun callback)
        {
            return glfwSetWindowIconifyCallback(window, callback);
        }

        public static GLFWwindowmaximizefun SetWindowMaximizeCallback(IntPtr window, GLFWwindowmaximizefun callback)
        {
            return glfwSetWindowMaximizeCallback(window, callback);
        }

        public static GLFWframebuffersizefun SetFramebufferSizeCallback(IntPtr window, GLFWframebuffersizefun callback)
        {
            return glfwSetFramebufferSizeCallback(window, callback);
        }

        public static GLFWwindowcontentscalefun SetWindowContentScaleCallback(IntPtr window, GLFWwindowcontentscalefun callback)
        {
            return glfwSetWindowContentScaleCallback(window, callback);
        }

        public static void PollEvents()
        {
            glfwPollEvents();
        }

        public static void WaitEvents()
        {
            glfwWaitEvents();
        }

        public static void WaitEventsTimeout(double timeout)
        {
            glfwWaitEventsTimeout(timeout);
        }

        public static void PostEmptyEvent()
        {
            glfwPostEmptyEvent();
        }

        public static int GetInputMode(IntPtr window, int mode)
        {
            return glfwGetInputMode(window, mode);
        }

        public static void SetInputMode(IntPtr window, int mode, int value)
        {
            glfwSetInputMode(window, mode, value);
        }

        public static int RawMouseMotionSupported()
        {
            return glfwRawMouseMotionSupported();
        }

        public static bool GetKeyName(int key, int scancode, out string keyName)
        {
            IntPtr ptr = glfwGetKeyName(key, scancode);

            if (ptr != IntPtr.Zero)
            {
                keyName = Marshal.PtrToStringAnsi(ptr);
                return true;
            }

            keyName = string.Empty;
            return false;
        }

        public static int GetKeyScancode(int key)
        {
            return glfwGetKeyScancode(key);
        }

        public static int GetKey(IntPtr window, int key)
        {
            return glfwGetKey(window, key);
        }

        public static int GetMouseButton(IntPtr window, int button)
        {
            return glfwGetMouseButton(window, button);
        }

        public static void GetCursorPos(IntPtr window, out double xpos, out double ypos)
        {
            glfwGetCursorPos(window, out xpos, out ypos);
        }

        public static void SetCursorPos(IntPtr window, double xpos, double ypos)
        {
            glfwSetCursorPos(window, xpos, ypos);
        }

        public static IntPtr CreateCursor(IntPtr image, int xhot, int yhot)
        {
            return glfwCreateCursor(image, xhot, yhot);
        }

        public static IntPtr CreateStandardCursor(int shape)
        {
            return glfwCreateStandardCursor(shape);
        }

        public static void DestroyCursor(IntPtr cursor)
        {
            glfwDestroyCursor(cursor);
        }

        public static void SetCursor(IntPtr window, IntPtr cursor)
        {
            glfwSetCursor(window, cursor);
        }

        public static GLFWkeyfun SetKeyCallback(IntPtr window, GLFWkeyfun callback)
        {
            return glfwSetKeyCallback(window, callback);
        }

        public static GLFWcharfun SetCharCallback(IntPtr window, GLFWcharfun callback)
        {
            return glfwSetCharCallback(window, callback);
        }

        public static GLFWcharmodsfun SetCharModsCallback(IntPtr window, GLFWcharmodsfun callback)
        {
            return glfwSetCharModsCallback(window, callback);
        }

        public static GLFWmousebuttonfun SetMouseButtonCallback(IntPtr window, GLFWmousebuttonfun callback)
        {
            return glfwSetMouseButtonCallback(window, callback);
        }

        public static GLFWcursorposfun SetCursorPosCallback(IntPtr window, GLFWcursorposfun callback)
        {
            return glfwSetCursorPosCallback(window, callback);
        }

        public static GLFWcursorenterfun SetCursorEnterCallback(IntPtr window, GLFWcursorenterfun callback)
        {
            return glfwSetCursorEnterCallback(window, callback);
        }

        public static GLFWscrollfun SetScrollCallback(IntPtr window, GLFWscrollfun callback)
        {
            return glfwSetScrollCallback(window, callback);
        }

        public static GLFWdropfun SetDropCallback(IntPtr window, GLFWdropfun callback)
        {
            return glfwSetDropCallback(window, callback);
        }

        public static int JoystickPresent(int jid)
        {
            return glfwJoystickPresent(jid);
        }

        public static float[] GetJoystickAxes(int jid)
        {
            IntPtr ptr = glfwGetJoystickAxes(jid, out int count);

            if (count > 0 && ptr != IntPtr.Zero)
            {
                // Convert the IntPtr to a float array to access the axis states
                float[] axisStates = new float[count];
                Marshal.Copy(ptr, axisStates, 0, count);
                return axisStates;
            }
            
            return null;
        }

        public static byte[] GetJoystickButtons(int jid)
        {
            IntPtr ptr = glfwGetJoystickButtons(jid, out int count);

            if (count > 0 && ptr != IntPtr.Zero)
            {
                // Convert the IntPtr to a byte array to access the button states
                byte[] buttonStates = new byte[count];
                Marshal.Copy(ptr, buttonStates, 0, count);
                return buttonStates;
            }

            return null;
        }

        public static byte[] GetJoystickHats(int jid)
        {
            IntPtr ptr = glfwGetJoystickHats(jid, out int count);

            if(ptr != IntPtr.Zero && count > 0)
            {
                byte[] hatStates = new byte[count];
                Marshal.Copy(ptr, hatStates, 0, count);
                return hatStates;
            }

            return null;
        }

        public static bool GetJoystickName(int jid, out string name)
        {
            IntPtr ptr = glfwGetJoystickName(jid);

            if (ptr != IntPtr.Zero)
            {
                name = Marshal.PtrToStringAnsi(ptr);
                return true;
            }

            name = string.Empty;
            return false;
        }

        public static bool GetJoystickGUID(int jid, out string guid)
        {
            IntPtr ptr = glfwGetJoystickGUID(jid);

            if (ptr != IntPtr.Zero)
            {
                guid = Marshal.PtrToStringAnsi(ptr);
                return true;
            }

            guid = string.Empty;
            return false;
        }

        public static void SetJoystickUserPointer(int jid, IntPtr pointer)
        {
            glfwSetJoystickUserPointer(jid, pointer);
        }

        public static IntPtr GetJoystickUserPointer(int jid)
        {
            return glfwGetJoystickUserPointer(jid);
        }

        public static int JoystickIsGamepad(int jid)
        {
            return glfwJoystickIsGamepad(jid);
        }

        public static GLFWjoystickfun SetJoystickCallback(GLFWjoystickfun callback)
        {
            return glfwSetJoystickCallback(callback);
        }

        public static int UpdateGamepadMappings(string str)
        {
            return glfwUpdateGamepadMappings(str);
        }

        public static bool GetGamepadName(int jid, out string name)
        {
            IntPtr ptr = glfwGetGamepadName(jid);

            if (ptr != IntPtr.Zero)
            {
                name = Marshal.PtrToStringAnsi(ptr);
                return true;
            }

            name = string.Empty;
            return false;
        }

        public static int GetGamepadState(int jid, ref GLFWgamepadstate state)
        {
            return glfwGetGamepadState(jid, ref state);
        }

        public static void SetClipboardString(IntPtr window, string str)
        {
            glfwSetClipboardString(window, str);
        }

        public static bool GetClipboardString(IntPtr window, out string str)
        {
            IntPtr ptr = glfwGetClipboardString(window);

            if (ptr != IntPtr.Zero)
            {
                str = Marshal.PtrToStringAnsi(ptr);
                return true;
            }

            str = string.Empty;
            return false;
        }

        public static double GetTime()
        {
            return glfwGetTime();
        }

        public static void SetTime(double time)
        {
            glfwSetTime(time);
        }

        public static UInt64 GetTimerValue()
        {
            return glfwGetTimerValue();
        }

        public static UInt64 GetTimerFrequency()
        {
            return glfwGetTimerFrequency();
        }

        public static void MakeContextCurrent(IntPtr window)
        {
            glfwMakeContextCurrent(window);
        }

        public static IntPtr GetCurrentContext()
        {
            return glfwGetCurrentContext();
        }

        public static void SwapBuffers(IntPtr window)
        {
            glfwSwapBuffers(window);
        }

        public static void SwapInterval(int interval)
        {
            glfwSwapInterval(interval);
        }

        public static int ExtensionSupported(IntPtr extension)
        {
            return glfwExtensionSupported(extension);
        }

        public static GLFWglproc GetProcAddress(IntPtr procname)
        {
            return glfwGetProcAddress(procname);
        }

        public static string[] GetRequiredInstanceExtensions()
        {
            IntPtr ptr = glfwGetRequiredInstanceExtensions(out UInt32 count);

            if (count > 0 && ptr != IntPtr.Zero)
            {
                // Convert the IntPtr to an array of strings to access the extension names
                string[] extensionNames = new string[count];

                for (uint i = 0; i < count; i++)
                {
                    IntPtr namePtr = Marshal.ReadIntPtr(ptr, (int)i * IntPtr.Size);
                    extensionNames[i] = Marshal.PtrToStringAnsi(namePtr);
                }
                return extensionNames;
            }
            
            return null;
        }
    }
}