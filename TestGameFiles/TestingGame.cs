using TestingOpenGL.GameLoop;
using TestingOpenGL.Rendering.Shaders;
using TestingOpenGL.Rendering.Display;
using TestingOpenGL.Rendering.Cameras;
using TestingOpenGL.TestGame;
using GLFW;
using static TestingOpenGL.OpenGL.GL;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingOpenGL
{
    class TestingGame : Game
    {
        uint vao;
        uint vbo;

        Shader shader;

        Player player;
        Camera2D cam;
        public TestingGame(int initialWindowWidth, int initialWindowHeight, string initialWindowTitle) : base(initialWindowWidth, initialWindowHeight, initialWindowTitle)
        {

            Vector2 playerPos = new Vector2(250, 250);
            Vector3 playerColor = new Vector3(1, 1, 0);
            player = new Player(playerPos, playerColor, 8);
        }

        protected override void Initialize()
        {

        }

        protected unsafe override void LoadContent()
        {
            string vertexShader = @"#version 330 core
                                    layout (location = 0) in vec2 aPosition;
                                    layout (location = 1) in vec3 aColor;
                                    out vec4 vertexColor;

                                    uniform mat4 projection;
                                    uniform mat4 model;
                                    
                                    void main()
                                    {
                                        vertexColor = vec4(aColor.rgb, 1.0);
                                        gl_Position = projection * model * vec4(aPosition.xy, 0, 1.0);
                                    }";

            string fragmentShader = @"#version 330 core
                                        out vec4 FragColor;
                                        in vec4 vertexColor;
                                        
                                        void main()
                                        {
                                            FragColor = vertexColor;
                                        }";

            shader = new Shader(vertexShader, fragmentShader);
            shader.Load();

            vao = glGenVertexArray();
            vbo = glGenBuffer();

            glBindVertexArray(vao);

            glBindBuffer(GL_ARRAY_BUFFER, vbo);


            float[] vertices =
                        {
                -0.5f, 0.5f, 1f, 1f, 0f, // top left
                0.5f, 0.5f, 1f, 1f, 0f,// top right
                -0.5f, -0.5f, 1f, 1f, 0f, // bottom left

                0.5f, 0.5f, 1f, 1f, 0f,// top right
                0.5f, -0.5f, 1f, 1f, 0f, // bottom right
                -0.5f, -0.5f, 1f, 1f, 0f, // bottom left
            };
            fixed (float* v = &vertices[0])
            {
                glBufferData(GL_ARRAY_BUFFER, sizeof(float) * vertices.Length, v, GL_STATIC_DRAW);
            }

            glVertexAttribPointer(0, 2, GL_FLOAT, false, 5 * sizeof(float), (void*)0);
            glEnableVertexAttribArray(0);

            glVertexAttribPointer(1, 3, GL_FLOAT, false, 5 * sizeof(float), (void*)(2 * sizeof(float)));
            glEnableVertexAttribArray(1);

            glBindBuffer(GL_ARRAY_BUFFER, 0);
            glBindVertexArray(0);

            cam = new Camera2D(DisplayManager.WindowSize / 2f, 2.5f);
        }

        protected override void Update()
        {

        }
        protected override void Render()
        {
            glClearColor(0.3f, 0.3f, 0.3f, 0);
            glClear(GL_COLOR_BUFFER_BIT);

            player.DrawPlayer();

            //Vector2 position = new Vector2(400, 300);
            //Vector2 scale = new Vector2(150, 100);
            //float rotation = MathF.Sin(GameTime.ElapsedSeconds) * MathF.PI * 2f;

            //Matrix4x4 trans = Matrix4x4.CreateTranslation(position.X, position.Y, 0);
            //Matrix4x4 sca = Matrix4x4.CreateScale(scale.X, scale.Y, 1);
            //Matrix4x4 rot = Matrix4x4.CreateRotationZ(rotation);

            shader.SetMatrix4x4("model", player.PlayerScaleMatix * player.PlayerTransMatix);

            shader.Use();
            shader.SetMatrix4x4("projection", cam.GetProjectionMatrix());

            glBindVertexArray(vao);
            glDrawArrays(GL_TRIANGLES, 0, 6);
            glBindVertexArray(0);

            Glfw.SwapBuffers(DisplayManager.Window);
        }

    }
}
