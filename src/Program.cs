namespace GLFWNet
{
    class Program
    {
        static void Main()
        {
            var application = new GLFWApplication("Test Application", 512, 512);
            application.Run();
        }
    }
}