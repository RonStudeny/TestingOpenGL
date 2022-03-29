﻿using TestingOpenGL.Rendering.Display;
using GLFW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingOpenGL.GameLoop
{
    abstract class Game
    {
        public Game(int initialWindowWidth, int initialWindowHeight, string initialWindowTitle)
        {
            InitialWindowWidth = initialWindowWidth;
            InitialWindowHeight = initialWindowHeight;
            InitialWindowTitle = initialWindowTitle;
        }

        protected int InitialWindowWidth { get; set; }
        protected int InitialWindowHeight { get; set;}
        protected string InitialWindowTitle { get; set; }
        public void Run()
        {
            Initialize();
            DisplayManager.CreateWindow(InitialWindowWidth, InitialWindowHeight, InitialWindowTitle);
            LoadContent();
            while (!Glfw.WindowShouldClose(DisplayManager.Window))
            {
                GameTime.DeltaTime = (float)Glfw.Time - GameTime.ElapsedSeconds;
                GameTime.ElapsedSeconds = (float)Glfw.Time;
                Glfw.PollEvents();
                Render();
            }

            DisplayManager.Closeindow();
        }

        protected abstract void Initialize();
        protected abstract void LoadContent();

        protected abstract void Update();
        protected abstract void Render();
    }
}
