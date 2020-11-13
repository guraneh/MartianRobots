using System;
using System.Collections.Generic;
using System.Drawing;

namespace MartianRobots
{
    public class Context
    {
        public Rectangle Place { get; set; }

        public List<(Point, Direction)> ScentPoints { get; set; } = new List<(Point, Direction)>();

        public static Context Create(InputData sourse)
        {
            return new Context(sourse.MaxX, sourse.MaxY);
        }

        public Context(int width, int height)
        {
            Place = new Rectangle(0, 0, width + 1, height + 1);
        }
    }
}
