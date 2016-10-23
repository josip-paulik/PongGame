using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class SafeVector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public SafeVector2(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static SafeVector2 operator *(SafeVector2 v, float scalar)
        {
            return new SafeVector2(v.X * scalar, v.Y * scalar);
        }
    }
}
