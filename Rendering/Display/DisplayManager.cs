using GLFW;
using System;
using System.Drawing;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TestingOpenGL.OpenGL.GL;

namespace TestingOpenGL.Rendering.Display
{
    public static class DisplayManager
    {
        public static Window Window { get; set; }
        public static Vector2 WindowSize { get; set; }
        public static void CreateWindow(int width, int height, string title)
        {
            WindowSize = new Vector2(width, height);

            Glfw.Init();

            Glfw.WindowHint(Hint.ContextVersionMajor, 3);
            Glfw.WindowHint(Hint.ContextVersionMinor, 3);
            Glfw.WindowHint(Hint.OpenglProfile, Profile.Core);

            Glfw.WindowHint(Hint.Focused, true);
            Glfw.WindowHint(Hint.Resizable, false);

            Window = Glfw.CreateWindow(width, height, title, Monitors.None, Window.None);

            if (Window == Window.None) return;

            Glfw.SetWindowPosition(Window, (Glfw.PrimaryMonitor.WorkArea.Width - width) / 2, (Glfw.PrimaryMonitor.WorkArea.Height - height) / 2);

            Glfw.MakeContextCurrent(Window);
            Import(Glfw.GetProcAddress);

            glViewport(0, 0, width, height);
            Glfw.SwapInterval(0); // Vsync


        }
        public static void Closeindow() => Glfw.Terminate();

    }
}
