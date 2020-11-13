using System;
using System.Drawing;

namespace MartianRobots
{
    public class RobotInfo : ICloneable
    {
        public Point Position { get; set; }

        public bool IsLost { get; set; }

        public Direction Direction { get; set; }

        public RobotInfo(int x, int y, Direction direction)
        {
            Position = new Point(x, y);
            Direction = direction;
        }

        public RobotInfo Clone()
        {
            return (RobotInfo)MemberwiseClone();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }
}