using System;
namespace GLFWNet;
class Program
{
    static void Main(string[] args)
    {
        // Initialize your GLFW wrapper (call your initialization method)
        if (GLFW.Init() == 0)
        {
            Console.WriteLine("Failed to initialize GLFW");
            return;
        }

        // Create a GLFW window (call your window creation method)
        IntPtr window = GLFW.CreateWindow(800, 600, "GLFW Window", IntPtr.Zero, IntPtr.Zero);

        if (window == IntPtr.Zero)
        {
            Console.WriteLine("Failed to create GLFW window");
            GLFW.Terminate();
            return;
        }

        // Main loop for rendering and event handling
        while (GLFW.WindowShouldClose(window) == 0)
        {
            // Add your rendering code here

            // Swap buffers and poll events
            GLFW.SwapBuffers(window);
            GLFW.PollEvents();
        }

        // Terminate your GLFW wrapper (call your termination method)
        GLFW.Terminate();
    }
}
