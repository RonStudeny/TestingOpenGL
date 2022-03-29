using TestingOpenGL.GameLoop;
using TestingOpenGL.Rendering.Display;
using GLFW;
using static TestingOpenGL.OpenGL.GL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingOpenGL
{
    class TestGame : Game
    {
        public TestGame(int initialWindowWidth, int initialWindowHeight, string initialWindowTitle) : base(initialWindowWidth, initialWindowHeight, initialWindowTitle)
        {
        }

        protected override void Initialize()
        {

        }

        protected override void LoadContent()
        {

        }

        protected override void Update()
        {

        }
        protected override void Render()
        {
            glClearColor(MathF.Sin(GameTime.ElapsedSeconds), 0, 0, 1);
            glClear(GL_COLOR_BUFFER_BIT);

            Glfw.SwapBuffers(DisplayManager.Window);
        }

    }
}
