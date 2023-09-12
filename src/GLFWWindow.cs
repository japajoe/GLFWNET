using System;
using System.Runtime.InteropServices;

namespace GLFWNet
{
    public delegate void ErrorEvent(int error_code, string description);
    public delegate void WindowPosEvent(int x, int y);
    public delegate void WindowSizeEvent(int width, int height);
    public delegate void WindowCloseEvent();
    public delegate void WindowRefreshEvent();
    public delegate void WindowFocusEvent(int focused);
    public delegate void WindowIconifyEvent(int iconified);
    public delegate void WindowMaximizeEvent(int iconified);
    public delegate void FramebufferSizeEvent(int width, int height);
    public delegate void WindowContentScaleEvent(float xscale, float yscale);
    public delegate void MouseButtonEvent(int button, int action, int mods);
    public delegate void CursorPosEvent(double x, double y);
    public delegate void CursorEnterEvent(int entered);
    public delegate void ScrollEvent(double xoffset, double yoffset);
    public delegate void KeyEvent(int key, int scancode, int action, int mods);
    public delegate void CharEvent(uint codepoint);
    public delegate void CharModsEvent(uint codepoint, int mods);
    public delegate void DropEvent(string[] paths);
    public delegate void MonitorEvent(IntPtr monitor, int monitor_event);
    public delegate void JoystickEvent(int jid, int joystick_event);
    public delegate void NewFrameEvent();

    public class GLFWWindow
    {
        public event ErrorEvent Error;
        public event WindowPosEvent WindowPos;
        public event WindowSizeEvent WindowSize;
        public event WindowCloseEvent WindowClose;
        public event WindowRefreshEvent WindowRefresh;
        public event WindowFocusEvent WindowFocus;
        public event WindowIconifyEvent WindowIconify;
        public event WindowMaximizeEvent WindowMaximize;
        public event FramebufferSizeEvent FramebufferSize;
        public event WindowContentScaleEvent WindowContentScale;
        public event MouseButtonEvent MouseButton;
        public event CursorPosEvent CursorPos;
        public event CursorEnterEvent CursorEnter;
        public event ScrollEvent Scroll;
        public event KeyEvent Key;
        public event CharEvent Char;
        public event CharModsEvent CharMods;
        public event DropEvent Drop;
        public event MonitorEvent Monitor;
        public event JoystickEvent Joystick;
        public event NewFrameEvent NewFrame;

        private readonly GLFWerrorfun errorfunCallback;
        private readonly GLFWmonitorfun monitorfunCallback;
        private readonly GLFWwindowposfun windowposfunCallback;
        private readonly GLFWwindowsizefun windowsizefunCallback;
        private readonly GLFWwindowclosefun windowclosefunCallback;
        private readonly GLFWwindowrefreshfun windowrefreshfunCallback;
        private readonly GLFWwindowfocusfun windowfocusfunCallback;
        private readonly GLFWwindowiconifyfun windowiconifyfunCallback;
        private readonly GLFWwindowmaximizefun windowmaximizefunCallback;
        private readonly GLFWframebuffersizefun framebuffersizefunCallback;
        private readonly GLFWwindowcontentscalefun windowcontentscalefunCallback;
        private readonly GLFWkeyfun keyfunCallback;
        private readonly GLFWcharfun charfunCallback;
        private readonly GLFWcharmodsfun charmodsfunCallback;
        private readonly GLFWmousebuttonfun mousebuttonfunCallback;
        private readonly GLFWcursorposfun cursorposfunCallback;
        private readonly GLFWcursorenterfun cursorenterfunCallback;
        private readonly GLFWscrollfun scrollfunCallback;
        private readonly GLFWdropfun dropfunCallback;
        private readonly GLFWjoystickfun joystickfunCallback;
        private IntPtr window;

        public GLFWWindow()
        {
            errorfunCallback = OnError;
            monitorfunCallback = OnMonitor;
            windowposfunCallback = OnWindowPos;
            windowsizefunCallback = OnWindowSize;
            windowclosefunCallback = OnWindowClose;
            windowrefreshfunCallback = OnWindowRefresh;
            windowfocusfunCallback = OnWindowFocus;
            windowiconifyfunCallback = OnWindowIconify;
            windowmaximizefunCallback = OnWindowMaximize;
            framebuffersizefunCallback = OnFramebufferSize;
            windowcontentscalefunCallback = OnWindowContentScale;
            keyfunCallback = OnKey;
            charfunCallback = OnChar;
            charmodsfunCallback = OnCharMods;
            mousebuttonfunCallback = OnMouseButton;
            cursorposfunCallback = OnCursorPos;
            cursorenterfunCallback = OnCursorEnter;
            scrollfunCallback = OnScroll;
            dropfunCallback = OnDrop;
            joystickfunCallback = OnJoystick;
        }

        public bool Create(string title, int width, int height)
        {
            window = GLFW.CreateWindow(width, height, title, IntPtr.Zero, IntPtr.Zero);

            if (window == IntPtr.Zero)
            {
                Console.WriteLine("Failed to create GLFW window");
                return false;
            }

            GLFW.SetErrorCallback(errorfunCallback);
            GLFW.SetMonitorCallback(monitorfunCallback);
            GLFW.SetWindowPosCallback(window, windowposfunCallback);
            GLFW.SetWindowSizeCallback(window, windowsizefunCallback);
            GLFW.SetWindowCloseCallback(window, windowclosefunCallback);
            GLFW.SetWindowRefreshCallback(window, windowrefreshfunCallback);
            GLFW.SetWindowFocusCallback(window, windowfocusfunCallback);
            GLFW.SetWindowIconifyCallback(window, windowiconifyfunCallback);
            GLFW.SetWindowMaximizeCallback(window, windowmaximizefunCallback);
            GLFW.SetFramebufferSizeCallback(window, framebuffersizefunCallback);
            GLFW.SetWindowContentScaleCallback(window, windowcontentscalefunCallback);
            GLFW.SetKeyCallback(window, keyfunCallback);
            GLFW.SetCharCallback(window, charfunCallback);
            GLFW.SetCharModsCallback(window, charmodsfunCallback);
            GLFW.SetMouseButtonCallback(window, mousebuttonfunCallback);
            GLFW.SetCursorPosCallback(window, cursorposfunCallback);
            GLFW.SetCursorEnterCallback(window, cursorenterfunCallback);
            GLFW.SetScrollCallback(window, scrollfunCallback);
            GLFW.SetDropCallback(window, dropfunCallback);
            GLFW.SetJoystickCallback(joystickfunCallback);
            
            return true;
        }

        public void Update()
        {
            while (GLFW.WindowShouldClose(window) == 0)
            {
                NewFrame?.Invoke();
                GLFW.SwapBuffers(window);
                GLFW.PollEvents();
            }
        }

        private void OnError(int error_code, IntPtr description)
        {
            if(description != IntPtr.Zero)
            {
                string error = Marshal.PtrToStringAnsi(description);
                Error?.Invoke(error_code, error);
            }
            else
            {
                Error?.Invoke(error_code, string.Empty);
            }
        }

        private void OnWindowPos(IntPtr window, int x, int y)
        {
            WindowPos?.Invoke(x, y);
        }

        private void OnWindowSize(IntPtr window, int width, int height)
        {
            WindowSize?.Invoke(width, height);
        }

        private void OnWindowClose(IntPtr window)
        {
            WindowClose?.Invoke();
        }

        private void OnWindowRefresh(IntPtr window)
        {
            WindowRefresh?.Invoke();
        }

        private void OnWindowFocus(IntPtr window, int focused)
        {
            WindowFocus?.Invoke(focused);
        }

        private void OnWindowIconify(IntPtr window, int iconified)
        {
            WindowIconify?.Invoke(iconified);
        }

        private void OnWindowMaximize(IntPtr window, int iconified)
        {
            WindowMaximize?.Invoke(iconified);
        }

        private void OnFramebufferSize(IntPtr window, int width, int height)
        {
            FramebufferSize?.Invoke(width, height);
        }

        private void OnWindowContentScale(IntPtr window, float xscale, float yscale)
        {
            WindowContentScale?.Invoke(xscale, yscale);
        }

        private void OnMouseButton(IntPtr window, int button, int action, int mods)
        {
            MouseButton?.Invoke(button, action, mods);
        }

        private void OnCursorPos(IntPtr window, double x, double y)
        {
            CursorPos?.Invoke(x, y);
        }

        private void OnCursorEnter(IntPtr window, int entered)
        {
            CursorEnter?.Invoke(entered);
        }

        private void OnScroll(IntPtr window, double xoffset, double yoffset)
        {
            Scroll?.Invoke(xoffset, yoffset);
        }

        private void OnKey(IntPtr window, int key, int scancode, int action, int mods)
        {
            Key?.Invoke(key, scancode, action, mods);
        }

        private void OnChar(IntPtr window, uint codepoint)
        {
            Char?.Invoke(codepoint);
        }

        private void OnCharMods(IntPtr window, uint codepoint, int mods)
        {
            CharMods?.Invoke(codepoint, mods);
        }

        private void OnDrop(IntPtr window, int path_count, IntPtr paths)
        {
            if(path_count > 0 && paths != IntPtr.Zero)
            {
                string[] p = new string[path_count];

                for (uint i = 0; i < path_count; i++)
                {
                    IntPtr namePtr = Marshal.ReadIntPtr(paths, (int)i * IntPtr.Size);
                    p[i] = Marshal.PtrToStringAnsi(namePtr);
                }
                
                Drop?.Invoke(p);
            }
            else
            {
                Drop?.Invoke(null);
            }
        }

        private void OnMonitor(IntPtr monitor, int monitor_event)
        {
            Monitor?.Invoke(monitor, monitor_event);
        }

        private void OnJoystick(int jid, int joystick_event)
        {
            Joystick?.Invoke(jid, joystick_event);
        }
    }
}