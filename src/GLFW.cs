// MIT License

// Copyright (c) 2025 japajoe

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

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
        private const string GLFW_LIBRARY = "glfw3";

        public const int VERSION_MAJOR = 3;
        public const int VERSION_MINOR = 4;
        public const int VERSION_REVISION = 0;
        public const int TRUE = 1;
        public const int FALSE = 0;
        public const int RELEASE = 0;
        public const int PRESS = 1;
        public const int REPEAT = 2;
        public const int HAT_CENTERED = 0;
        public const int HAT_UP = 1;
        public const int HAT_RIGHT = 2;
        public const int HAT_DOWN = 4;
        public const int HAT_LEFT = 8;
        public const int HAT_RIGHT_UP = (HAT_RIGHT | HAT_UP);
        public const int HAT_RIGHT_DOWN = (HAT_RIGHT | HAT_DOWN);
        public const int HAT_LEFT_UP = (HAT_LEFT | HAT_UP);
        public const int HAT_LEFT_DOWN = (HAT_LEFT | HAT_DOWN);
        public const int KEY_UNKNOWN =-1;
        public const int KEY_SPACE = 32;
        public const int KEY_APOSTROPHE = 39;
        public const int KEY_COMMA = 44;
        public const int KEY_MINUS = 45;
        public const int KEY_PERIOD = 46;
        public const int KEY_SLASH = 47;
        public const int KEY_0 = 48;
        public const int KEY_1 = 49;
        public const int KEY_2 = 50;
        public const int KEY_3 = 51;
        public const int KEY_4 = 52;
        public const int KEY_5 = 53;
        public const int KEY_6 = 54;
        public const int KEY_7 = 55;
        public const int KEY_8 = 56;
        public const int KEY_9 = 57;
        public const int KEY_SEMICOLON = 59;
        public const int KEY_EQUAL = 61;
        public const int KEY_A = 65;
        public const int KEY_B = 66;
        public const int KEY_C = 67;
        public const int KEY_D = 68;
        public const int KEY_E = 69;
        public const int KEY_F = 70;
        public const int KEY_G = 71;
        public const int KEY_H = 72;
        public const int KEY_I = 73;
        public const int KEY_J = 74;
        public const int KEY_K = 75;
        public const int KEY_L = 76;
        public const int KEY_M = 77;
        public const int KEY_N = 78;
        public const int KEY_O = 79;
        public const int KEY_P = 80;
        public const int KEY_Q = 81;
        public const int KEY_R = 82;
        public const int KEY_S = 83;
        public const int KEY_T = 84;
        public const int KEY_U = 85;
        public const int KEY_V = 86;
        public const int KEY_W = 87;
        public const int KEY_X = 88;
        public const int KEY_Y = 89;
        public const int KEY_Z = 90;
        public const int KEY_LEFT_BRACKET = 91;
        public const int KEY_BACKSLASH = 92;
        public const int KEY_RIGHT_BRACKET = 93;
        public const int KEY_GRAVE_ACCENT = 96;
        public const int KEY_WORLD_1 = 161;
        public const int KEY_WORLD_2 = 162;
        public const int KEY_ESCAPE = 256;
        public const int KEY_ENTER = 257;
        public const int KEY_TAB = 258;
        public const int KEY_BACKSPACE = 259;
        public const int KEY_INSERT = 260;
        public const int KEY_DELETE = 261;
        public const int KEY_RIGHT = 262;
        public const int KEY_LEFT = 263;
        public const int KEY_DOWN = 264;
        public const int KEY_UP = 265;
        public const int KEY_PAGE_UP = 266;
        public const int KEY_PAGE_DOWN = 267;
        public const int KEY_HOME = 268;
        public const int KEY_END = 269;
        public const int KEY_CAPS_LOCK = 280;
        public const int KEY_SCROLL_LOCK = 281;
        public const int KEY_NUM_LOCK = 282;
        public const int KEY_PRINT_SCREEN = 283;
        public const int KEY_PAUSE = 284;
        public const int KEY_F1 = 290;
        public const int KEY_F2 = 291;
        public const int KEY_F3 = 292;
        public const int KEY_F4 = 293;
        public const int KEY_F5 = 294;
        public const int KEY_F6 = 295;
        public const int KEY_F7 = 296;
        public const int KEY_F8 = 297;
        public const int KEY_F9 = 298;
        public const int KEY_F10 = 299;
        public const int KEY_F11 = 300;
        public const int KEY_F12 = 301;
        public const int KEY_F13 = 302;
        public const int KEY_F14 = 303;
        public const int KEY_F15 = 304;
        public const int KEY_F16 = 305;
        public const int KEY_F17 = 306;
        public const int KEY_F18 = 307;
        public const int KEY_F19 = 308;
        public const int KEY_F20 = 309;
        public const int KEY_F21 = 310;
        public const int KEY_F22 = 311;
        public const int KEY_F23 = 312;
        public const int KEY_F24 = 313;
        public const int KEY_F25 = 314;
        public const int KEY_KP_0 = 320;
        public const int KEY_KP_1 = 321;
        public const int KEY_KP_2 = 322;
        public const int KEY_KP_3 = 323;
        public const int KEY_KP_4 = 324;
        public const int KEY_KP_5 = 325;
        public const int KEY_KP_6 = 326;
        public const int KEY_KP_7 = 327;
        public const int KEY_KP_8 = 328;
        public const int KEY_KP_9 = 329;
        public const int KEY_KP_DECIMAL = 330;
        public const int KEY_KP_DIVIDE = 331;
        public const int KEY_KP_MULTIPLY = 332;
        public const int KEY_KP_SUBTRACT = 333;
        public const int KEY_KP_ADD = 334;
        public const int KEY_KP_ENTER = 335;
        public const int KEY_KP_EQUAL = 336;
        public const int KEY_LEFT_SHIFT = 340;
        public const int KEY_LEFT_CONTROL = 341;
        public const int KEY_LEFT_ALT = 342;
        public const int KEY_LEFT_SUPER = 343;
        public const int KEY_RIGHT_SHIFT = 344;
        public const int KEY_RIGHT_CONTROL = 345;
        public const int KEY_RIGHT_ALT = 346;
        public const int KEY_RIGHT_SUPER = 347;
        public const int KEY_MENU = 348;
        public const int KEY_LAST = KEY_MENU;
        public const int MOD_SHIFT = 0x0001;
        public const int MOD_CONTROL = 0x0002;
        public const int MOD_ALT = 0x0004;
        public const int MOD_SUPER = 0x0008;
        public const int MOD_CAPS_LOCK = 0x0010;
        public const int MOD_NUM_LOCK = 0x0020;
        public const int MOUSE_BUTTON_1 = 0;
        public const int MOUSE_BUTTON_2 = 1;
        public const int MOUSE_BUTTON_3 = 2;
        public const int MOUSE_BUTTON_4 = 3;
        public const int MOUSE_BUTTON_5 = 4;
        public const int MOUSE_BUTTON_6 = 5;
        public const int MOUSE_BUTTON_7 = 6;
        public const int MOUSE_BUTTON_8 = 7;
        public const int MOUSE_BUTTON_LAST = MOUSE_BUTTON_8;
        public const int MOUSE_BUTTON_LEFT = MOUSE_BUTTON_1;
        public const int MOUSE_BUTTON_RIGHT = MOUSE_BUTTON_2;
        public const int MOUSE_BUTTON_MIDDLE = MOUSE_BUTTON_3;
        public const int JOYSTICK_1 = 0;
        public const int JOYSTICK_2 = 1;
        public const int JOYSTICK_3 = 2;
        public const int JOYSTICK_4 = 3;
        public const int JOYSTICK_5 = 4;
        public const int JOYSTICK_6 = 5;
        public const int JOYSTICK_7 = 6;
        public const int JOYSTICK_8 = 7;
        public const int JOYSTICK_9 = 8;
        public const int JOYSTICK_10 = 9;
        public const int JOYSTICK_11 = 10;
        public const int JOYSTICK_12 = 11;
        public const int JOYSTICK_13 = 12;
        public const int JOYSTICK_14 = 13;
        public const int JOYSTICK_15 = 14;
        public const int JOYSTICK_16 = 15;
        public const int JOYSTICK_LAST = JOYSTICK_16;
        public const int GAMEPAD_BUTTON_A = 0;
        public const int GAMEPAD_BUTTON_B = 1;
        public const int GAMEPAD_BUTTON_X = 2;
        public const int GAMEPAD_BUTTON_Y = 3;
        public const int GAMEPAD_BUTTON_LEFT_BUMPER = 4;
        public const int GAMEPAD_BUTTON_RIGHT_BUMPER = 5;
        public const int GAMEPAD_BUTTON_BACK = 6;
        public const int GAMEPAD_BUTTON_START = 7;
        public const int GAMEPAD_BUTTON_GUIDE = 8;
        public const int GAMEPAD_BUTTON_LEFT_THUMB = 9;
        public const int GAMEPAD_BUTTON_RIGHT_THUMB = 10;
        public const int GAMEPAD_BUTTON_DPAD_UP = 11;
        public const int GAMEPAD_BUTTON_DPAD_RIGHT = 12;
        public const int GAMEPAD_BUTTON_DPAD_DOWN = 13;
        public const int GAMEPAD_BUTTON_DPAD_LEFT = 14;
        public const int GAMEPAD_BUTTON_LAST = GAMEPAD_BUTTON_DPAD_LEFT;
        public const int GAMEPAD_BUTTON_CROSS = GAMEPAD_BUTTON_A;
        public const int GAMEPAD_BUTTON_CIRCLE = GAMEPAD_BUTTON_B;
        public const int GAMEPAD_BUTTON_SQUARE = GAMEPAD_BUTTON_X;
        public const int GAMEPAD_BUTTON_TRIANGLE = GAMEPAD_BUTTON_Y;
        public const int GAMEPAD_AXIS_LEFT_X = 0;
        public const int GAMEPAD_AXIS_LEFT_Y = 1;
        public const int GAMEPAD_AXIS_RIGHT_X = 2;
        public const int GAMEPAD_AXIS_RIGHT_Y = 3;
        public const int GAMEPAD_AXIS_LEFT_TRIGGER = 4;
        public const int GAMEPAD_AXIS_RIGHT_TRIGGER =5;
        public const int GAMEPAD_AXIS_LAST = GAMEPAD_AXIS_RIGHT_TRIGGER;
        public const int NO_ERROR = 0;
        public const int NOT_INITIALIZED = 0x00010001;
        public const int NO_CURRENT_CONTEXT = 0x00010002;
        public const int INVALID_ENUM = 0x00010003;
        public const int INVALID_VALUE = 0x00010004;
        public const int OUT_OF_MEMORY = 0x00010005;
        public const int API_UNAVAILABLE = 0x00010006;
        public const int VERSION_UNAVAILABLE = 0x00010007;
        public const int PLATFORM_ERROR = 0x00010008;
        public const int FORMAT_UNAVAILABLE = 0x00010009;
        public const int NO_WINDOW_CONTEXT = 0x0001000A;
        public const int CURSOR_UNAVAILABLE = 0x0001000B;
        public const int FEATURE_UNAVAILABLE = 0x0001000C;
        public const int FEATURE_UNIMPLEMENTED = 0x0001000D;
        public const int PLATFORM_UNAVAILABLE = 0x0001000E;
        public const int FOCUSED = 0x00020001;
        public const int ICONIFIED = 0x00020002;
        public const int RESIZABLE = 0x00020003;
        public const int VISIBLE = 0x00020004;
        public const int DECORATED = 0x00020005;
        public const int AUTO_ICONIFY = 0x00020006;
        public const int FLOATING = 0x00020007;
        public const int MAXIMIZED = 0x00020008;
        public const int CENTER_CURSOR = 0x00020009;
        public const int TRANSPARENT_FRAMEBUFFER =0x0002000A;
        public const int HOVERED = 0x0002000B;
        public const int FOCUS_ON_SHOW = 0x0002000C;
        public const int MOUSE_PASSTHROUGH = 0x0002000D;
        public const int POSITION_X = 0x0002000E;
        public const int POSITION_Y = 0x0002000F;
        public const int RED_BITS = 0x00021001;
        public const int GREEN_BITS = 0x00021002;
        public const int BLUE_BITS = 0x00021003;
        public const int ALPHA_BITS = 0x00021004;
        public const int DEPTH_BITS = 0x00021005;
        public const int STENCIL_BITS = 0x00021006;
        public const int ACCUM_RED_BITS = 0x00021007;
        public const int ACCUM_GREEN_BITS = 0x00021008;
        public const int ACCUM_BLUE_BITS = 0x00021009;
        public const int ACCUM_ALPHA_BITS = 0x0002100A;
        public const int AUX_BUFFERS = 0x0002100B;
        public const int STEREO = 0x0002100C;
        public const int SAMPLES = 0x0002100D;
        public const int SRGB_CAPABLE = 0x0002100E;
        public const int REFRESH_RATE = 0x0002100F;
        public const int DOUBLEBUFFER = 0x00021010;
        public const int CLIENT_API = 0x00022001;
        public const int CONTEXT_VERSION_MAJOR = 0x00022002;
        public const int CONTEXT_VERSION_MINOR = 0x00022003;
        public const int CONTEXT_REVISION = 0x00022004;
        public const int CONTEXT_ROBUSTNESS = 0x00022005;
        public const int OPENGL_FORWARD_COMPAT = 0x00022006;
        public const int CONTEXT_DEBUG = 0x00022007;
        public const int OPENGL_DEBUG_CONTEXT = CONTEXT_DEBUG;
        public const int OPENGL_PROFILE = 0x00022008;
        public const int CONTEXT_RELEASE_BEHAVIOR =0x00022009;
        public const int CONTEXT_NO_ERROR = 0x0002200A;
        public const int CONTEXT_CREATION_API = 0x0002200B;
        public const int SCALE_TO_MONITOR = 0x0002200C;
        public const int COCOA_RETINA_FRAMEBUFFER =0x00023001;
        public const int COCOA_FRAME_NAME = 0x00023002;
        public const int COCOA_GRAPHICS_SWITCHING =0x00023003;
        public const int X11_CLASS_NAME = 0x00024001;
        public const int X11_INSTANCE_NAME = 0x00024002;
        public const int WIN32_KEYBOARD_MENU = 0x00025001;
        public const int WAYLAND_APP_ID = 0x00026001;
        public const int NO_API = 0;
        public const int OPENGL_API = 0x00030001;
        public const int OPENGL_ES_API = 0x00030002;
        public const int NO_ROBUSTNESS = 0;
        public const int NO_RESET_NOTIFICATION = 0x00031001;
        public const int LOSE_CONTEXT_ON_RESET = 0x00031002;
        public const int OPENGL_ANY_PROFILE = 0;
        public const int OPENGL_CORE_PROFILE = 0x00032001;
        public const int OPENGL_COMPAT_PROFILE = 0x00032002;
        public const int CURSOR = 0x00033001;
        public const int STICKY_KEYS = 0x00033002;
        public const int STICKY_MOUSE_BUTTONS = 0x00033003;
        public const int LOCK_KEY_MODS = 0x00033004;
        public const int RAW_MOUSE_MOTION = 0x00033005;
        public const int CURSOR_NORMAL = 0x00034001;
        public const int CURSOR_HIDDEN = 0x00034002;
        public const int CURSOR_DISABLED = 0x00034003;
        public const int CURSOR_CAPTURED = 0x00034004;
        public const int ANY_RELEASE_BEHAVIOR = 0;
        public const int RELEASE_BEHAVIOR_FLUSH =0x00035001;
        public const int RELEASE_BEHAVIOR_NONE = 0x00035002;
        public const int NATIVE_CONTEXT_API = 0x00036001;
        public const int EGL_CONTEXT_API = 0x00036002;
        public const int OSMESA_CONTEXT_API = 0x00036003;
        public const int ANGLE_PLATFORM_TYPE_NONE = 0x00037001;
        public const int ANGLE_PLATFORM_TYPE_OPENGL = 0x00037002;
        public const int ANGLE_PLATFORM_TYPE_OPENGLES =0x00037003;
        public const int ANGLE_PLATFORM_TYPE_D3D9 = 0x00037004;
        public const int ANGLE_PLATFORM_TYPE_D3D11 = 0x00037005;
        public const int ANGLE_PLATFORM_TYPE_VULKAN = 0x00037007;
        public const int ANGLE_PLATFORM_TYPE_METAL = 0x00037008;
        public const int WAYLAND_PREFER_LIBDECOR = 0x00038001;
        public const int WAYLAND_DISABLE_LIBDECOR = 0x00038002;
        public const uint ANY_POSITION = 0x80000000;
        public const int ARROW_CURSOR = 0x00036001;
        public const int IBEAM_CURSOR = 0x00036002;
        public const int CROSSHAIR_CURSOR = 0x00036003;
        public const int POINTING_HAND_CURSOR = 0x00036004;
        public const int RESIZE_EW_CURSOR = 0x00036005;
        public const int RESIZE_NS_CURSOR = 0x00036006;
        public const int RESIZE_NWSE_CURSOR = 0x00036007;
        public const int RESIZE_NESW_CURSOR = 0x00036008;
        public const int RESIZE_ALL_CURSOR = 0x00036009;
        public const int NOT_ALLOWED_CURSOR = 0x0003600A;
        public const int HRESIZE_CURSOR = RESIZE_EW_CURSOR;
        public const int VRESIZE_CURSOR = RESIZE_NS_CURSOR;
        public const int HAND_CURSOR = POINTING_HAND_CURSOR;
        public const int CONNECTED = 0x00040001;
        public const int DISCONNECTED = 0x00040002;
        public const int JOYSTICK_HAT_BUTTONS = 0x00050001;
        public const int ANGLE_PLATFORM_TYPE = 0x00050002;
        public const int PLATFORM = 0x00050003;
        public const int COCOA_CHDIR_RESOURCES = 0x00051001;
        public const int COCOA_MENUBAR = 0x00051002;
        public const int X11_XCB_VULKAN_SURFACE =0x00052001;
        public const int WAYLAND_LIBDECOR = 0x00053001;
        public const int ANY_PLATFORM = 0x00060000;
        public const int PLATFORM_WIN32 = 0x00060001;
        public const int PLATFORM_COCOA = 0x00060002;
        public const int PLATFORM_WAYLAND = 0x00060003;
        public const int PLATFORM_X11 = 0x00060004;
        public const int PLATFORM_NULL = 0x00060005;
        public const int DONT_CARE = -1;

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

        [DllImport(GLFW_LIBRARY, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        internal static extern GLFWglproc glfwGetProcAddress(string procname);

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
            glfwWindowHint((int)hint, value);
        }

        public static void WindowHintString(int hint, string value)
        {
            glfwWindowHintString((int)hint, value);
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
            if(images == null)
                throw new NullReferenceException("GLFW.SetWindowIcon: images can not be null");

            IntPtr pIcons = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(GLFWimage)) * images.Length);

            if(pIcons == IntPtr.Zero)
                throw new InsufficientMemoryException();
            
            for (int i = 0; i < images.Length; i++)
            {
                IntPtr pImage = new IntPtr(pIcons.ToInt64() + i * Marshal.SizeOf(typeof(GLFWimage)));
                Marshal.StructureToPtr(images[i], pImage, false);
            }
            
            glfwSetWindowIcon(window, images.Length, pIcons);

            Marshal.FreeHGlobal(pIcons);
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

        public static GLFWglproc GetProcAddress(string procname)
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