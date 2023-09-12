using System;

namespace GLFWNet
{
    public class GLFWApplication
    {
        private readonly int width;
        private readonly int height;
        private readonly string title;
        private GLFWWindow window;

        public GLFWApplication(string title, int width, int height)
        {
            this.title = title;
            this.width = width;
            this.height = height;
        }

        public void Run()
        {
            if (GLFW.Init() == 0)
            {
                Console.WriteLine("Failed to initialize GLFW");
                return;
            }

            window = new GLFWWindow();
            window.NewFrame += OnNewFrame;

            if(window.Create(title, width, height))
            {
                window.Update();
            }

            // Terminate your GLFW wrapper (call your termination method)
            GLFW.Terminate();
        }

        private void OnNewFrame()
        {

        }
    }
}