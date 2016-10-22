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

        public const int TextureWidth = 900;
        public const int TextureHeight = 500;
        public const int TextureMiddleWidth = TextureWidth / 2;
        public const int TextureMiddleHeight = TextureHeight / 2;

        public const float PaddleBottomXPostionInital = 250;
        public const float PaddleBottomYPositionInital = 900;

        public const float PaddleTopXPostionInital = 250;
        public const float PaddleTopYPositionInital = 0;

        

        public const float DefaultInitialBallSpeed = 0.4f;
        public const float DefaultBallBumpSpeedIncreaseFactor = 1.05f;
        public const int DefaultBallSize = 40;
    }
}
