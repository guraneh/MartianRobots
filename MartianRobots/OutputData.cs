using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots
{
    public class OutputData
    {
        public List<RobotInfo> Robots { get; set; } = new List<RobotInfo>();

        public override string ToString()
        {
            return string.Join(
                Environment.NewLine, 
                Robots
                    .Select(x =>
                    {
                        var lostMarker = x.IsLost ? " LOST" : "";
                        return $"{x.Position.X} {x.Position.Y} {x.Direction}{lostMarker}";
                    }));
        }
    }
}
