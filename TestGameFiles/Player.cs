using static TestingOpenGL.OpenGL.GL;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingOpenGL.TestGame
{
    public class Player
    {
        public Player(Vector2 playerPosition, Vector3 playerColor, int playerSize)
        {
            PlayerPosition = playerPosition;
            PlayerColor = playerColor;
            PlayerSize = playerSize;
        }

        public Vector2 PlayerPosition { get; set; }
        public Vector3 PlayerColor { get; set; }
        public int PlayerSize { get; set; } = 8;
        public Matrix4x4 PlayerTransMatix { get; set; }
        public Matrix4x4 PlayerScaleMatix { get; set; }



        public void DrawPlayer()
        {

            PlayerTransMatix = Matrix4x4.CreateTranslation(PlayerPosition.X, PlayerPosition.Y, 0);
            PlayerScaleMatix = Matrix4x4.CreateScale(PlayerSize, PlayerSize, 1);
        }

        public void MovementInput()
        {

        }
    }


}
