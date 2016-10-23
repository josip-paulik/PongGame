using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class GameConstants
    {
        public const float PaddleDefaulSpeed = 0.9f;
        public const int PaddleDefaultWidth = 200;
        public const int PaddleDefaulHeight = 20;

        public const int TextureWidth = 500;
        public const int TextureHeight = 900;

        public const int TextureMiddleWidth = TextureWidth / 2;
        public const int TextureMiddleHeight = TextureHeight / 2;

        public const int PaddleBottomXPostionInital = 250 - PaddleDefaultWidth / 2;
        public const int PaddleBottomYPositionInital = 880;

        public const int PaddleTopXPostionInital = 250 - PaddleDefaultWidth / 2;
        public const int PaddleTopYPositionInital = 0;

        public const int WallDefaultSize = 100; 

        public const float DefaultInitialBallSpeed = 0.4f;
        public const float BallMaxSpeed = 1.0f;
        public const float DefaultBallBumpSpeedIncreaseFactor = 1.05f;
        public const int DefaultBallSize = 40;
    }
}
