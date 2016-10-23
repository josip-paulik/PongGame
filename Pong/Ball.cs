using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pong
{
    /// <summary>
    /// Game representation of ball
    /// </summary>
    public class Ball : Sprite, IPhysicalObject2D
    {


        /// <summary>
        /// Defines current ball speed.
        /// </summary>
        private float _speed;

        public float Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                if(value > GameConstants.BallMaxSpeed)
                {
                    _speed = GameConstants.BallMaxSpeed;
                }
            }
        }



        public float BumpSpeedIncreaseFactor { get; set; }

        /// <summary>
        /// Defines ball speed direction.
        /// Valid values: (1, 1), (-1, -1), (-1, 1), (1, -1)
        /// </summary>
        public SafeVector2 Direction { get; set; }

        public Ball(int size, float speed, float defaultBumpSpeedIncreaseFactor) : base(size, size)
        {
            _speed = speed;
            BumpSpeedIncreaseFactor = defaultBumpSpeedIncreaseFactor;
            //Inital direction
            Direction = new SafeVector2(1, 1);
        }
    }
}
