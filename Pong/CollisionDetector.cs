using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pong
{
    class CollisionDetector
    {
        ///<summary>
        ///This is algorithm called bounding box test which assumes two bodies are square.
        ///And in our case, all of our bodies are squares.
        ///</summary>
        public static bool Overlaps(IPhysicalObject2D a, IPhysicalObject2D b)
        {
            var aRectangle = new Rectangle(new Point((int)a.X, (int)a.Y), new Point(a.Width, a.Height));
            var bRectangle = new Rectangle(new Point((int)b.X, (int)b.Y), new Point(b.Width, b.Height));

            return !(aRectangle.Bottom < bRectangle.Top
                || aRectangle.Top > bRectangle.Bottom
                || aRectangle.Left > bRectangle.Right
                || aRectangle.Right < bRectangle.Left);    
        }
    }
}
