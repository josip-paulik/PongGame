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
        public float Speed { get; set; }

        public float BumpSpeedIncreaseFactor { get; set; }

        /// <summary>
        /// Defines ball speed direction.
        /// Valid values: (1, 1), (-1, -1), (-1, 1), (1, -1)
        /// </summary>
        public Vector2 Direction { get; set; }

        public Ball(int size, float speed, float defaultBumpSpeedIncreaseFactor) : base(size, size)
        {
            Speed = speed;
            BumpSpeedIncreaseFactor = defaultBumpSpeedIncreaseFactor;
            //Inital direction
            Direction = new Vector2(1, 1);
        }
    }
}
